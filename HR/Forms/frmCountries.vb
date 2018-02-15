Public Class frmCountries
    Dim nCountryId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean

    Private Sub frmCountries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Clear()
    End Sub

    Private Sub Clear()
        nCountryId = Nothing
        txtCountry.Text = ""
        txtCountry.Tag = ""

        FillGrid()
    End Sub

    Private Sub FillGrid()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = sConnectionString '"Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "Select Id, Description From HR_PRMParameters Where Type = 1 Order By Description"

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdCountries.DataSource = Nothing
            grdCountries.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading countries.")
        End Try
        connODBC.Close()
        grdCountries.Refresh()
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewCountrytId As Integer

        If Trim(txtCountry.Text) = "" Then
            MsgBox("Please enter country.", vbCritical)
            Exit Sub
        End If

        Try
            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            bProcessing = True
            conn.BeginTrans()

            If (nCountryId = Nothing) Or (nCountryId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_PRMParameters"
                GetRecordSet(rsMisc, sSql)
                nNewCountrytId = CInt(rsMisc("Id").Value)
                nNewCountrytId += 1

                sSql = "Insert INTO HR_PRMParameters (Id, Description, Type, BusinessUnitId, Status) " &
                       "Values(" & nNewCountrytId & ", '" & txtCountry.Text & "', 1, 1, 1)"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_PRMParameters Set Description = '" & txtCountry.Text & "' Where Id = " & nCountryId

                conn.Execute(sSql)
            End If

            conn.CommitTrans()

            If nCountryId <> Nothing Then
                sSql = "Select * From HR_PRMParameters Where Id = " & nCountryId
                If rsMain.State = 1 Then rsMain.Close()
                rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            End If

            Clear()
            conn.Close()
            MessageBox.Show("Country successfully saved.")
        Catch ex As Exception
            MessageBox.Show("Error saving record: " + ex.Message)
        End Try

        bProcessing = False
    End Sub

    Private Sub Delete()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Clear()
    End Sub

    Private Sub grdCountries_DoubleClick(sender As Object, e As EventArgs) Handles grdCountries.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_PRMParameters Where Id = " & Convert.ToString(grdCountries.Columns(0).Value)

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        nCountryId = CInt(rsMisc("Id").Value)
        txtCountry.Text = Convert.ToString(rsMisc("Description").Value)
    End Sub

    Private Sub frmCountries_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        If (conn.State = ConnectionState.Open) Then conn.Close()
    End Sub
End Class