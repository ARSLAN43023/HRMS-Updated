Public Class frmODBCLogin


    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Dim nlResult As Long

        Me.Refresh()

        If Trim(txtUID.Text) = "" Then
            MessageBox.Show("Login Falied")
            Exit Sub
        End If

        If Trim(cboDSNList.Text) = "" Then
            MessageBox.Show("Login Falied")
            Exit Sub
        End If

        nlResult = RetryConnection()

        If nlResult = 0 Then
            frmUserLogin.Show()
            frmUserLogin.Focus()
        End If

        '    If nlResult <> 0 Then
        '        Me.Caption = "Login failed"
        '        MsgBox LoadResString(25206), , "Login Failure"
        '    Me.Caption = "Database Logon"
        '        Me.MousePointer = vbDefault
        '        Exit Sub
        '    End If

        '    Me.Caption = "Login successfull"

        '    g_Server = Left(DSNList(cboDSNList.ListIndex), 16)

        '    Me.MousePointer = 0
        '    Unload Me
        'Me.Caption = "Logon"
        Exit Sub


    End Sub

    Private Sub frmODBCLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim connetionString As String = Nothing
        Dim conn As Odbc.OdbcConnection
        Dim command As Odbc.OdbcCommand
        Dim adapter As New Odbc.OdbcDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sSql As String


        g_sConnectionLoginId = GetSetting("ERP", "Database Settings", "UserId", "")
        g_sConnectionPassword = GetSetting("ERP", "Database Settings", "Password", "")
        g_sDSN = GetSetting("ERP", "Database Settings", "DSN", "")

        ''connetionString = sConnectionString 'Dsn=ERPACL;uid=sa;pwd=Delt@13l
        If g_sConnectionPassword = "" Then
            connectionString = "Dsn=" + g_sDSN + ";Uid=" + g_sConnectionLoginId + ""
        Else
            connectionString = "Dsn=" + g_sDSN + ";Uid=" + g_sConnectionLoginId + ";pwd=" + g_sConnectionPassword
        End If


        conn = New Odbc.OdbcConnection(connectionString)
        Try
            conn.Open()
            conn.Close()
            frmUserLogin.Show()
            frmUserLogin.Focus()
            Me.Visible = False

            'ConnectToDataBase = AIS_SUCCESS

        Catch ex As Exception
            If nlResult = AIS_SUCCESS Then nlResult = AIS_FAILURE

            Dim myODBCKeys As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources", False)
            For Each myName As String In myODBCKeys.GetValueNames
                cboDSNList.Items.Add(myName)
            Next
            'ConnectToDataBase = nlResult

            'MessageBox.Show("Could Not connect To database.")
        End Try


    End Sub

    Public Function ConnectToDataBase() As Integer

        Dim connetionString As String = Nothing
        Dim conn As Odbc.OdbcConnection
        Dim command As Odbc.OdbcCommand
        Dim adapter As New Odbc.OdbcDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sSql As String


        g_sConnectionLoginId = GetSetting("ERP", "Database Settings", "UserId", "")
        g_sConnectionPassword = GetSetting("ERP", "Database Settings", "Password", "")
        g_sDSN = GetSetting("ERP", "Database Settings", "DSN", "")

        ''connetionString = sConnectionString 'Dsn=ERPACL;uid=sa;pwd=Delt@13l
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

        Catch ex As Exception
            If nlResult = AIS_SUCCESS Then nlResult = AIS_FAILURE
            ConnectToDataBase = nlResult

            'MessageBox.Show("Could Not connect To database.")
        End Try

    End Function

    Public Function RetryConnection()
        On Error GoTo Catch_RetryConnection_Error
        Dim nlResult As Long
        'Dim udtLogin As udtLogin

        g_sDSN = Trim(Me.cboDSNList.Text)
        g_sConnectionLoginId = Trim(txtUID.Text)
        g_sConnectionPassword = Trim(txtPWD.Text)

        'udtLogin.m_sDSN_Name = g_sDSN
        'udtLogin.m_sUser_Id = g_sConnectionLoginId
        'udtLogin.m_sPassword = g_sConnectionPassword

        'Set conn = New ADODB.Connection
        conn.Open(g_sDSN, g_sConnectionLoginId, g_sConnectionPassword)

        SaveSetting("ERP", "Database Settings", "UserId", g_sConnectionLoginId)
        SaveSetting("ERP", "Database Settings", "Password", g_sConnectionPassword)
        SaveSetting("ERP", "Database Settings", "DSN", g_sDSN)

        'nlResult = SaveInfoForConnection(udtLogin)
        RetryConnection = nlResult

        Exit Function

Catch_RetryConnection_Error:
        If (nlResult = AIS_SUCCESS) Then
            nlResult = AIS_FAILURE
            If Trim(txtUID.Text = "") Then
                MessageBox.Show("Login Failed")
            Else
                MessageBox.Show("Login Failed for user " & g_sConnectionLoginId)
            End If

        Else
            Call SecurityMessage(nlResult)
        End If
        RetryConnection = nlResult
    End Function

    Sub GetDSNsAndDrivers()

    End Sub

    Public Sub SecurityMessage(ByVal a_sErrCode As String)
        On Error GoTo Err_Label_0
        Dim sErrMessage As String

        If (a_sErrCode = AIS_FAILURE) Then Exit Sub
        'sErrMessage = LoadResString(CLng(a_sErrCode))
        ' M 'essageBox.Show("" & sErrMessage & ".", vbInformation)
        Exit Sub
Err_Label_0:
        Select Case Err.Number
            Case 13 'Type mismatch
                If (Trim(a_sErrCode) <> "") Then
                    MessageBox.Show("Invalid error code (" & Trim(a_sErrCode) & ") passed. Error code contains alphabets")
                Else
                    MessageBox.Show("Blank error code. Try to pass a non blank error code")
                End If
            Case 326 'No string found in resource table
                MessageBox.Show("An undocumented error (" & Trim(a_sErrCode) & ") occured. Please get an updated version of executable  ")
            Case 5 'Argument value exceedes maximum limit (65000)
                MessageBox.Show("Invalid error code (" & Trim(a_sErrCode) & ") passed. Error code exceedes the maximum allowed limit")
            Case Else 'Any other exceptions
                MessageBox.Show(" - Error Code " & Err.Number)
        End Select
    End Sub

    Private Sub frmODBCLogin_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub
End Class