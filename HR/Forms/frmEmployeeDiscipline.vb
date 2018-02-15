Public Class frmEmployeeDiscipline
    Dim nEmployeeId As Integer = Nothing
    Dim nDisciplineId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean

    Private Sub frmEmployeeDiscipline_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain

        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        Clear()
    End Sub

    Private Sub Clear()
        nEmployeeId = Nothing
        nDisciplineId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        cbType.SelectedIndex = -1
        cbType.Tag = -1
        dtpDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDate.Tag = dtpDate.Value
        dtpDate.Checked = False
        txtRemarks.Text = ""
        txtRemarks.Tag = ""
        nStatus = 0
        slStatus.Text = "New Record"
        FillGrid()
    End Sub

    Private Sub Display()
        Clear()

        If rsMain.RecordCount = 0 Then Exit Sub
        If rsMain.EOF Then Exit Sub
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        bDisplaying = True

        nEmployeeId = CInt(rsMain("Id").Value)
        txtEmployeeName.Text = Convert.ToString(rsMain("FullName").Value)
        txtEmployeeName.Tag = txtEmployeeName.Text
        FillGrid()
        FillAudit()

        Me.Refresh()
        bDisplaying = False
    End Sub

    Private Sub FillGrid()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()

        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT nDisciplineId, dtmDate, nType, vcRemarks From " &
                             "EM_EmployeeDiscipline Where nEmployeeId = " & nEmployeeId

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdDiscipline.DataSource = Nothing
            grdDiscipline.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading warnings.")
        End Try
        connODBC.Close()
        grdDiscipline.Refresh()
    End Sub

    Public Sub SearchRecords(ByVal a_sSql As String, ByVal a_sEmpNo As String)
        If rsMain.State = ADODB.ObjectStateEnum.adStateOpen Then rsMain.Close()
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        rsMain.Open(a_sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMain.RecordCount > 0 Then
            rsMain.MoveFirst()
            rsMain.Find("EmployeeNo = '" & a_sEmpNo & "'")
            If Not rsMain.EOF Then Display()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmEmployeeSearch.sCalledForm = "Employee Discipline"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

        Try
            bProcessing = True

            If (nDisciplineId = Nothing) Or (nDisciplineId = 0) Then
                sSql = "Select MAX(nDisciplineId) As nDisciplineId From EM_EmployeeDiscipline"
                GetRecordSet(rsMisc, sSql)
                If rsMisc.RecordCount > 0 Then
                    If Not IsDBNull(rsMisc("nDisciplineId").Value) Then
                        nDisciplineId = CInt(rsMisc("nDisciplineId").Value)
                        nDisciplineId += 1
                    Else
                        nDisciplineId = 1
                    End If
                Else
                    nDisciplineId = 1
                End If

                sSql = "Insert INTO EM_EmployeeDiscipline (nDisciplineId, nEmployeeId, dtmDate, nType, vcRemarks, nsStatusId)" &
               " Values(" & nDisciplineId & ", " & nEmployeeId & ", '" & dtpDate.Value.ToString("dd MMM yyyy") &
               "', " & cbType.SelectedIndex & ", '" & AdjustSingleQuotes(txtRemarks.Text) &
               "', " & nStatus & ")"
                conn.Execute(sSql)
            Else
                sSql = "Update EM_EmployeeDiscipline Set dtmDate = '" & dtpDate.Value.ToString("dd MMM yyyy") &
                       "', nType = " & cbType.SelectedIndex &
                       ", vcRemarks = '" & AdjustSingleQuotes(txtRemarks.Text) & "', nsStatusId = " & nStatus &
                       " Where nDisciplineId = " & nDisciplineId
                conn.Execute(sSql)
            End If

            sSql = "Insert Into EM_EmployeeDisciplineAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            Convert.ToString(nDisciplineId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
            MessageBox.Show("Error saving record. " & ex.Message)
        End Try

        Display()

        bProcessing = False
    End Sub

    Private Sub Delete()
        Dim sSql As String

        If Trim(txtEmployeeName.Text) = "" Then Exit Sub
        If nDisciplineId = Nothing Then Exit Sub

        If MsgBox("Do you want to Delete this warning?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From EM_EmployeeDiscipline Where nDisciplineId = " & nDisciplineId
        conn.Execute(sSql)
        sSql = "Delete From EM_EmployeeDisciplineAudit Where vcDocumentId = '" & Convert.ToString(nDisciplineId) & "'"
        conn.Execute(sSql)

        Display()

        MsgBox("Record deleted successfully.", vbInformation)
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From EM_EmployeeDisciplineAudit Where vcDocumentId = '" + Convert.ToString(nDisciplineId) + "' Order by dtmActionDate"

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdAudit.DataSource = Nothing
            grdAudit.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading audit entries.")
        End Try
        connODBC.Close()
        grdAudit.Refresh()
    End Sub

    Private Function ValidateFields(ByVal a_nActionID As Integer, r_sAction As String) As Boolean
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        ValidateFields = False

        If nDisciplineId <> 0 Then
            sSql = "Select nsStatusId From EM_EmployeeDiscipline Where nDisciplineId = " & nDisciplineId
            GetRecordSet(rsMisc, sSql)

            If rsMisc.RecordCount > 0 Then nStatus = CInt(rsMisc("nsStatusId").Value)
            rsMisc.Close()
        End If

        If nStatus = 3 Then
            MsgBox("Invalid Action.", vbCritical)
            Exit Function
        End If

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        If dtpDate.Checked = False Then
            MsgBox("Please select date.", vbCritical)
            dtpDate.Focus()
            Exit Function
        End If

        If cbType.SelectedIndex = -1 Then
            MsgBox("Please select type.", vbCritical)
            cbType.Focus()
            Exit Function
        End If

        If nDisciplineId = 0 Then
            sAction = "Prepared"
            nStatus = 1
            slStatus.Text = "Pending"
        ElseIf a_nActionID = 0 Then 'Modify
            sAction = "Modified"
            nStatus = CInt(rsMain("nsStatusId").Value)
            slStatus.Text = "Pending"
        ElseIf a_nActionID = 3 Then
            sAction = "Approved"
            nStatus = 3
            slStatus.Text = "Approved"
        End If

        ValidateFields = True
    End Function

    Private Function IsAnyFieldChanged() As Boolean
        IsAnyFieldChanged = (nEmployeeId = 0) Or (nDisciplineId = 0) Or (cbType.SelectedIndex <> cbType.Tag) Or
                             (Trim(txtRemarks.Text) <> Trim(txtRemarks.Tag)) Or (dtpDate.Value <> dtpDate.Tag)
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ((nEmployeeId = 0) Or IsAnyFieldChanged()) Then Exit Sub
        Call Save()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub grdDiscipline_DoubleClick(sender As Object, e As EventArgs) Handles grdDiscipline.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From EM_EmployeeDiscipline Where nDisciplineId = " & grdDiscipline.Columns(0).Value

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMisc.RecordCount > 0 Then
            nDisciplineId = CInt(rsMisc("nDisciplineId").Value)
            cbType.SelectedIndex = CInt(rsMisc("nType").Value)
            cbType.Tag = cbType.SelectedIndex
            If Not IsDBNull(rsMisc("dtmDate").Value) Then
                dtpDate.Value = CDate(rsMisc("dtmDate").Value)
                dtpDate.Tag = dtpDate.Value
                dtpDate.Checked = True
            Else
                dtpDate.Checked = False
            End If
            If Not IsDBNull(rsMisc("vcRemarks").Value) Then
                txtRemarks.Text = Convert.ToString(rsMisc("vcRemarks").Value)
                txtRemarks.Tag = txtRemarks.Text
            End If
            If CInt(rsMisc("nsStatusId").Value) = 1 Then
                slStatus.Text = "Pending"
            ElseIf CInt(rsMisc("nsStatusId").Value) = 3 Then
                slStatus.Text = "Approved"
            End If
            FillAudit()
        End If

    End Sub

    Private Sub frmEmployeeDiscipline_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If (conn.State = ConnectionState.Open) Then conn.Close()
    End Sub
End Class