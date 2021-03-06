﻿Public Class frmCities
    Dim nCityId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean
    Dim rsMisc As ADODB.Recordset
    Private Sub frmCities_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        PopulateControl(cbCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")
        Clear()
        UserRights(rsMisc)
    End Sub

    Private Sub Clear()
        nCityId = Nothing
        txtCity.Text = ""
        txtCity.Tag = ""
        cbCountry.SelectedIndex = -1
        cbCountry.Tag = -1

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
        Dim sSql As String = "Select Id, Description, CountryId, " &
            "(Select Description From HR_PRMParameters Where Type = 1 And Id = a.CountryId) Country " &
            "From HR_PRMCity a Order By Description"

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdCities.DataSource = Nothing
            grdCities.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading cities.")
        End Try
        connODBC.Close()
        grdCities.Refresh()
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewCityId As Integer

        If (cbCountry.SelectedIndex = -1) Or (cbCountry.SelectedText = "-") Then
            MsgBox("Please select country.", vbCritical)
            Exit Sub
        End If

        If Trim(txtCity.Text) = "" Then
            MsgBox("Please enter city.", vbCritical)
            Exit Sub
        End If

        Try
            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            bProcessing = True
            conn.BeginTrans()

            If (nCityId = Nothing) Or (nCityId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_PRMCity"
                GetRecordSet(rsMisc, sSql)
                nNewCityId = CInt(rsMisc("Id").Value)
                nNewCityId += 1

                sSql = "Insert INTO HR_PRMCity (Id, Description, Status, CountryId) " &
                       "Values(" & nNewCityId & ", '" & txtCity.Text & "', 1, " & cbCountry.SelectedValue & ")"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_PRMCity Set Description = '" & txtCity.Text & "', CountryId = " & cbCountry.SelectedValue & " Where Id = " & nCityId
                conn.Execute(sSql)
            End If

            conn.CommitTrans()

            If nCityId <> Nothing Then
                sSql = "Select * From HR_PRMCity Where Id = " & nCityId
                If rsMain.State = 1 Then rsMain.Close()
                rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            End If

            Clear()
            conn.Close()
            MessageBox.Show("City successfully saved.")
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


    Private Sub frmCountries_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        If (conn.State = ConnectionState.Open) Then conn.Close()
    End Sub

    Private Sub grdCities_DoubleClick(sender As Object, e As EventArgs) Handles grdCities.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        'sSql = "Select * From HR_PRMParameters Where Id = " & Convert.ToString(grdCities.Columns(0).Value)

        'rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        nCityId = Convert.ToString(grdCities.Columns(0).Value)
        txtCity.Text = Convert.ToString(grdCities.Columns(1).Value)
        cbCountry.SelectedValue = CInt(grdCities.Columns(3).Value)
    End Sub

    Private Sub grdAudit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class