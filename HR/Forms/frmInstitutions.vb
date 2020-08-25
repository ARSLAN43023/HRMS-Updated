Public Class frmInstitutions
    Dim nInstitutionId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean
    Dim rsMisc As ADODB.Recordset

    Private Sub frmInstitutions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmCountries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Clear()
        UserRights(rsMisc)
    End Sub

    Private Sub Clear()
        nInstitutionId = Nothing
        txtInstitution.Text = ""
        txtInstitution.Tag = ""

        FillGrid()
    End Sub

    Public Sub UserRights(ByRef rsMisc As ADODB.Recordset)

        Dim sSql As String
        Dim Button As String
        Dim TabControlRights As String

        Try

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

            'sSql = "Select a.nActionId, a.vcName,a.vcDocType, b.vcUserId from ComActionCodes a, ComAccessRights b " &
            '   "Where a.nActionId = b.nActionId And a.vcDocType = b.vcDocId And " &
            '   "b.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "'  And a.vcDocType = 'emsEmployee'"
            'GetRecordSet(rsMisc, sSql)
            sSql = "Select vcName, nGroupId, vcUserId From((Select comActionCodes.vcName, ComAccessRights.nGroupId, ComAccessRights.vcUserId From ComAccessRights, comActionCodes, ComUserGroups " &
                    " Where comActionCodes.vcDocType = ComAccessRights.vcDocId " &
                    "And comActionCodes.nActionId = ComAccessRights.nActionId " &
                    " And ComAccessRights.vcDocId ='emsEmployee' " &
                    "And ComUserGroups.nGroupId = ComAccessRights.nGroupId " &
                    "And ComUserGroups.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "') " &
                    " Union (Select comActionCodes.vcName, ComAccessRights.nGroupId, ComAccessRights.vcUserId " &
                    " From ComAccessRights, comActionCodes " &
                    " Where comActionCodes.vcDocType = ComAccessRights.vcDocId " &
                    " And comActionCodes.nActionId = ComAccessRights.nActionId And " &
                    "ComAccessRights.nGroupId = 0  " &
                    " And ComAccessRights.vcDocId ='emsEmployee' " &
                    " And ComAccessRights.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "')) g Order by vcName Desc "
            GetRecordSet(rsMisc, sSql)

            While Not rsMisc.EOF
                Button = "btn_" & rsMisc("vcName").Value
                TabControlRights = "tb" & rsMisc("vcName").Value
                If Button = "btn_Prepare" Then
                    btn_Prepare.Enabled = True
                ElseIf Button = "btn_Modify" Then
                    btn_Modify.Enabled = True
                ElseIf Button = "btn_Delete" Then
                    btn_Delete.Enabled = True
                End If
                rsMisc.MoveNext()
            End While

        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    Private Sub FillGrid()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = sConnectionString ' "Dsn=ERP;uid=sa"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "Select Id, Description From HR_PRMParameters Where Type = 9 Order By Description"

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdInstitution.DataSource = Nothing
            grdInstitution.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading Institutions .")
        End Try
        connODBC.Close()
        grdInstitution.Refresh()
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewInstitutionId As Integer

        If Trim(txtInstitution.Text) = "" Then
            MsgBox("Please Institution Name.", vbCritical)
            Exit Sub
        End If

        Try
            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            bProcessing = True
            conn.BeginTrans()

            If (nInstitutionId = Nothing) Or (nInstitutionId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_PRMParameters"
                GetRecordSet(rsMisc, sSql)
                nNewInstitutionId = CInt(rsMisc("Id").Value)
                nNewInstitutionId += 1

                sSql = "Insert INTO HR_PRMParameters (Id, Description, Type, BusinessUnitId, Status) " &
                       "Values(" & nNewInstitutionId & ", '" & txtInstitution.Text & "', 9, 1, 1)"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_PRMParameters Set Description = '" & txtInstitution.Text & "' Where Id = " & nInstitutionId

                conn.Execute(sSql)
            End If

            conn.CommitTrans()

            If nInstitutionId <> Nothing Then
                sSql = "Select * From HR_PRMParameters Where Id = " & nInstitutionId
                If rsMain.State = 1 Then rsMain.Close()
                rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            End If

            Clear()
            conn.Close()
            MessageBox.Show("Institutions successfully saved.")
        Catch ex As Exception
            MessageBox.Show("Error saving record: " + ex.Message)
        End Try

        bProcessing = False
    End Sub

    Private Sub Delete()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btn_Modify.Click
        Save()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btn_Prepare.Click
        Clear()
    End Sub

    Private Sub grdInstitution_DoubleClick(sender As Object, e As EventArgs) Handles grdInstitution.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_PRMParameters Where Id = " & Convert.ToString(grdInstitution.Columns(0).Value)

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        nInstitutionId = CInt(rsMisc("Id").Value)
        txtInstitution.Text = Convert.ToString(rsMisc("Description").Value)
    End Sub

    Private Sub frmCountries_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        If (conn.State = ConnectionState.Open) Then conn.Close()
    End Sub
End Class