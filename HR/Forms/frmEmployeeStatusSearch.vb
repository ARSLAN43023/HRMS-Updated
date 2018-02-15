Public Class frmEmployeeStatusSearch
    Public sCalledForm As String
    Dim sSql As String
    Dim sQueryForTransfer As String

    Private Sub frmEmployeeSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtEmployeeNo.Text = ""
        txtEmployeeName.Text = ""
        grdSearch.DataSource = Nothing
        grdSearch.Rebind(True)
        cbStatus.SelectedIndex = -1
        dtpFromDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpFromDate.Checked = False
        dtpToDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpToDate.Checked = False


    End Sub
    Private Function GetQuery() As String
        Dim sSql As String
        Dim sCriteria As String = ""

        If Trim(txtEmployeeNo.Text) <> "" Then
            sCriteria = sCriteria & " And b.EmployeeNo = '" & Trim(txtEmployeeNo.Text) & "'"
        End If

        If Trim(txtEmployeeName.Text) <> "" Then
            sCriteria = sCriteria & " And b.FullName Like '%" & Trim(txtEmployeeName.Text) & "%'"
        End If

        If cbStatus.SelectedIndex <> -1 Then
            sCriteria = sCriteria & " And a.nStatusId = " & cbStatus.SelectedIndex
        End If

        If dtpFromDate.Checked = True Then
            sCriteria = sCriteria & " And a.dtmDate >= '" & dtpFromDate.Value & "'"
        End If

        If dtpToDate.Checked = True Then
            sCriteria = sCriteria & " And a.dtmDate <= '" & dtpToDate.Value & "'"
        End If

        'If cbLocation.SelectedValue <> Nothing Then
        '    sCriteria = sCriteria & " And BranchId = " & cbLocation.SelectedValue
        'End If

        sSql = "Select a.vcDocumentNo, b.FullName, a.nStatusId, a.dtmDate From EM_EmployeeStatus a, EM_Employee b " &
               " Where a.nEmployeeId = b.Id " & sCriteria

        'sSql = "Select EmployeeNo, FullName, dbo.ufn_GetDesignation(DesignationId) vcDesignation, dbo.ufn_GetDepartmentName(DepartmentId) vcDepartment, isTechnical, Id " &
        '       "From EM_Employee Where 1 = 1 " & sCriteria

        sSql = sSql & " Order by a.vcDocumentNo"

        sQueryForTransfer = "Select * From EM_EmployeeStatus"
        GetQuery = sSql
    End Function

    Private Sub SearchRecords()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()

        Dim sSql As String = GetQuery()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            'grdSearch.DataSource = ds.Tables(0)
            'grdSearch.Rebind(holdFields:=True)
            grdSearch.DataSource = Nothing
            grdSearch.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error getting results.")
        End Try
        connODBC.Close()
    End Sub

    Private Sub SendResultsToMainForm()
        If grdSearch.RowCount = 0 Then Exit Sub

        frmEmployeeStatus.Show()
        frmEmployeeStatus.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
        frmEmployeeStatus.Focus()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call SearchRecords()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call ClearForm()
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        Call SendResultsToMainForm()
    End Sub

    Private Sub grdSearch_DoubleClick(sender As Object, e As EventArgs) Handles grdSearch.DoubleClick
        Call SendResultsToMainForm()
    End Sub
End Class