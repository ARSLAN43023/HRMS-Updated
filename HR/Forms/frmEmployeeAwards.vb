Public Class frmEmployeeAwards
    Dim nEmployeeId As Integer = Nothing
    Dim nAwardId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean

    Private Sub frmEmployeeAwards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain

        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        Clear()
    End Sub

    Private Sub Clear()
        nEmployeeId = Nothing
        nAwardId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        txtAwardName.Text = ""
        txtAwardName.Tag = ""
        txtAwardingAuthority.Text = ""
        txtAwardingAuthority.Tag = ""
        dtpAwardingDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpAwardingDate.Tag = dtpAwardingDate.Value
        txtAwardDescription.Text = ""
        txtAwardDescription.Tag = ""
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
        Dim sSql As String = "SELECT Id, Award, AwardingAuthority, AwardingDate, Description From " &
                             " HR_EmployeeJobHistory_Award Where EmployeeId = " & nEmployeeId

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdAwards.DataSource = Nothing
            grdAwards.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading awards.")
        End Try
        connODBC.Close()
        grdAwards.Refresh()
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
        frmEmployeeSearch.sCalledForm = "Employee Awards"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub grdAwards_DoubleClick(sender As Object, e As EventArgs) Handles grdAwards.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_EmployeeJobHistory_Award Where Id = " & Convert.ToString(grdAwards.Columns(0).Value) &
               " And EmployeeId = " & nEmployeeId

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMisc.RecordCount > 0 Then
            nAwardId = CInt(rsMisc("Id").Value)
            txtAwardName.Text = Convert.ToString(rsMisc("Award").Value)
            txtAwardName.Tag = txtAwardName.Text
            txtAwardingAuthority.Text = Convert.ToString(rsMisc("AwardingAuthority").Value)
            txtAwardingAuthority.Tag = txtAwardingAuthority.Text
            If Not IsDBNull(rsMisc("AwardingDate").Value) Then
                dtpAwardingDate.Value = CDate(rsMisc("AwardingDate").Value)
                dtpAwardingDate.Tag = dtpAwardingDate.Value
            End If
            If Not IsDBNull(rsMisc("Description").Value) Then
                txtAwardDescription.Text = Convert.ToString(rsMisc("Description").Value)
                txtAwardDescription.Tag = txtAwardDescription.Text
            End If
            FillAudit()
        End If
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        'If txtEmployeeName.Text = "" Then Exit Sub
        If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

        Try
            bProcessing = True

            If (nAwardId = Nothing) Or (nAwardId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeeJobHistory_Award Where EmployeeId = " & nEmployeeId
                GetRecordSet(rsMisc, sSql)
                If rsMisc.RecordCount > 0 Then
                    If Not IsDBNull(rsMisc("Id").Value) Then
                        nAwardId = CInt(rsMisc("Id").Value)
                        nAwardId += 1
                    Else
                        nAwardId = 1
                    End If
                Else
                    nAwardId = 1
                End If

                sSql = "Insert INTO HR_EmployeeJobHistory_Award (Id, EmployeeId, Award, AwardingAuthority, AwardingDate, Description)" &
               " Values(" & nAwardId & ", " & nEmployeeId & ", '" & AdjustSingleQuotes(txtAwardName.Text) &
               "', '" & AdjustSingleQuotes(txtAwardingAuthority.Text) & "', '" & dtpAwardingDate.Value.ToString("dd MMM yyyy") &
               "', '" & AdjustSingleQuotes(txtAwardDescription.Text) & "')"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeeJobHistory_Award Set Award = '" & AdjustSingleQuotes(txtAwardName.Text) &
                       "', AwardingAuthority = '" & AdjustSingleQuotes(txtAwardingAuthority.Text) &
                       "', AwardingDate = '" & dtpAwardingDate.Value.ToString("dd MMM yyyy") & "', Description = '" & AdjustSingleQuotes(txtAwardDescription.Text) &
                       "' Where Id = " & nAwardId & " And EmployeeId = " & nEmployeeId
                conn.Execute(sSql)
            End If

            sSql = "Insert Into HR_EmployeeJobHistory_AwardAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            Convert.ToString(nAwardId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
            MessageBox.Show("Error saving record.")
        End Try

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()
        'conn.Close()

        bProcessing = False
    End Sub

    Private Sub Delete()
        Dim sSql As String

        If Trim(txtEmployeeName.Text) = "" Then Exit Sub
        If nAwardId = Nothing Then Exit Sub

        If MsgBox("Do you want to Delete this award?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeeJobHistory_Award Where Id = " & nAwardId & " and EmployeeId = " & nEmployeeId
        conn.Execute(sSql)
        sSql = "Delete From HR_EmployeeJobHistory_AwardAudit Where vcDocumentId = '" & Convert.ToString(nAwardId) & "'"
        conn.Execute(sSql)

        Display()
        MsgBox("Award deleted successfully.", vbInformation)
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From HR_EmployeeJobHistory_AwardAudit Where vcDocumentId = '" + Convert.ToString(nAwardId) + "' Order by dtmActionDate"

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

        ValidateFields = False

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        If txtAwardName.Text = "" Then
            MsgBox("Please enter award name.", vbCritical)
            txtAwardName.Focus()
            Exit Function
        End If

        If txtAwardingAuthority.Text = "" Then
            MsgBox("Please enter awarding authority.", vbCritical)
            txtAwardingAuthority.Focus()
            Exit Function
        End If

        If nAwardId = 0 Then
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
        IsAnyFieldChanged = (nEmployeeId = 0) Or (nAwardId = 0) Or (Trim(txtAwardName.Text) <> Trim(txtAwardName.Tag)) Or
                            (Trim(txtAwardingAuthority.Text) <> Trim(txtAwardingAuthority.Tag)) Or (Trim(txtAwardDescription.Text) <> Trim(txtAwardDescription.Tag)) Or
                            (dtpAwardingDate.Value <> dtpAwardingDate.Tag)
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

    Private Sub frmEmployeeAwards_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If (conn.State = ConnectionState.Open) Then conn.Close()
    End Sub
End Class