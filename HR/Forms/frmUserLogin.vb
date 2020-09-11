Imports System.Data
Imports System.Data.Odbc

Public Class frmUserLogin
    Private Sub frmuserlogin_load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sSql As String
        Dim rsComp As New ADODB.Recordset
        '''''''''''''''''''''''''''''''''''''''''
        'txtUserID.Text = GetSetting("ERP", "HRMS", "UserLoginId", "")
        'If Trim(txtUserID.Text) <> "" Then
        '    txtPassword.Select()
        'End If

        ConnectToDataBase()

        If (nlResult = AIS_SUCCESS) Then
            If (conn.State <> ConnectionState.Open) Then conn.Open(connectionString)
            sSql = "Select nCompanyId, vcCompanyCode From comCompany"
            GetRecordSet(rsComp, sSql)
            If rsComp.RecordCount > 0 Then
                rsComp.MoveFirst()
                g_nCompanyId = CInt(rsComp("nCompanyId").Value)
            Else
                g_nCompanyId = 0
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'txtUserID.Text = GetSetting("ERP", "HRMS", "UserLoginId", "")
            If g_nCompanyId = 1 Then
                txtUserID.Text = GetSetting("ERP", "HRMS", "UserLoginId", "")
            ElseIf g_nCompanyId = 2 Then
                txtUserID.Text = GetSetting("ERPACL", "HRMS", "UserLoginId", "")
            End If
            If Trim(txtUserID.Text) <> "" Then
                txtPassword.Select()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            g_sLoggedInUser = txtUserID.Text
            '''''''''''''''''''''''''''''''''''''''
            PopulateControls()
            frmODBCLogin.Close()
        End If

    End Sub

    Public Function ConnectToDataBase() As Integer

        Dim connetionString As String = Nothing
        Dim conn As Odbc.OdbcConnection
        Dim adapter As New Odbc.OdbcDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0


        g_sConnectionLoginId = GetSetting("ERP", "Database Settings", "UserId", "")
        g_sConnectionPassword = GetSetting("ERP", "Database Settings", "Password", "")
        g_sDSN = GetSetting("ERP", "Database Settings", "DSN", "")

        If g_sConnectionPassword = "" Then
            connectionString = "Dsn=" + g_sDSN + ";Uid=" + g_sConnectionLoginId + ""
        Else
            connectionString = "Dsn=" + g_sDSN + ";Uid=" + g_sConnectionLoginId + ";pwd=" + g_sConnectionPassword
        End If


        conn = New Odbc.OdbcConnection(connectionString)
        Try
            conn.Open()
            conn.Close()
            ConnectToDataBase = AIS_SUCCESS
            nlResult = AIS_SUCCESS

        Catch ex As Exception
            If nlResult = AIS_SUCCESS Then nlResult = AIS_FAILURE
            ConnectToDataBase = nlResult
        End Try

    End Function


    Public Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        If Not ValidateFields() Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select vcPrefName, vcPrefValue, nLocationId From EM_SysPreferences Where vcPrefName = 'HR_" & Trim(txtUserID.Text) & "'"
        GetRecordSet(rsMisc, sSql)

        If rsMisc.RecordCount > 0 Then
            If txtPassword.Text <> Convert.ToString(rsMisc("vcPrefValue").Value) Then
                MsgBox("Invalid Password", vbCritical)
                txtPassword.Focus()
                Exit Sub
            Else
                sSql = "Select vcParamValue From ComSysPreferences Where vcParamName = 'HRMS'"
                GetRecordSet(rsMisc, sSql)

                If sVersion <> Convert.ToString(rsMisc("vcParamValue").Value) Then
                    MsgBox("A new version of HRMS is now available. Please update.", vbCritical)
                    Exit Sub
                End If

                mdFunctions.sUserId = txtUserID.Text
                ''''''''''''''''''''''''''''''''''''
                'SaveSetting("ERP", "HRMS", "UserLoginId", txtUserID.Text)
                If g_nCompanyId = 1 Then
                    SaveSetting("ERP", "HRMS", "UserLoginId", txtUserID.Text)
                ElseIf g_nCompanyId = 2 Then
                    SaveSetting("ERPACL", "HRMS", "UserLoginId", txtUserID.Text)
                End If
                ''''''''''''''''''''''''''''''''''''
                frmMdiMain.Show()
                frmMdiMain.Focus()
                Me.Hide()
            End If
        Else
            MsgBox("Invalid UserName", vbCritical)
            txtUserID.Focus()
            Exit Sub
        End If
    End Sub

    Private Function ValidateFields() As Boolean
        ValidateFields = False

        If txtUserID.Text = "" Then
            MsgBox("Please Enter User Id", vbCritical)
            txtUserID.Focus()
            Exit Function
        End If

        If txtPassword.Text = "" Then
            MsgBox("Please Enter Password", vbCritical)
            txtPassword.Focus()
            Exit Function
        End If

        If cbCompany.SelectedIndex = -1 Then
            MsgBox("Please Select Company", vbCritical)
            cbCompany.Focus()
            Exit Function
        End If

        If cbLocation.SelectedIndex = -1 Then
            MsgBox("Please Select Location", vbCritical)
            cbLocation.Focus()
            Exit Function
        End If
        ValidateFields = True
    End Function

    Private Sub PopulateControls()
        PopulateControl(cbCompany, "Select nCompanyId, vcCompanyCode From comCompany", "nCompanyId", "vcCompanyCode")
        'cbCompany.SelectedValue = 1
        cbCompany.SelectedIndex = 0
        PopulateControl(cbLocation, "Select nLocationId, vcLocationName From comLocation Order by vcLocationName", "nLocationId", "vcLocationName")
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmUserLogin_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If (conn.State = ConnectionState.Open) Then conn.Close()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown

        If e.KeyCode = Keys.Enter Then

            cmdOK_Click(sender, e)

        End If

    End Sub
End Class
