Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmEmployee
    Dim connectionString As String = "Data Source=TUF-3050\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
    Dim con As New SqlConnection(connectionString)
    Dim id As Integer

    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Call display_employee() to populate the ListView with employee data
        display_employee()
    End Sub

    Private Sub bttnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnSave.Click
        con.Open()

        Dim fname As String = Trim(txtFName.Text)
        Dim lname As String = Trim(txtLName.Text)
        Dim add As String = Trim(txtAddress.Text)
        Dim num As String = Trim(txtNumber.Text)
        Dim email As String = Trim(txtEmail.Text)
        Dim stat As String = Trim(txtStatus.Text)

        If fname = Nothing Or lname = Nothing Or add = Nothing Or num = Nothing Or stat = Nothing Then
            MsgBox("Please Fill All Fields", vbInformation, "Note")
        Else
            If bttnSave.Text = "&Update" Then ' update selected employee's details
                Dim update_emp As New SqlCommand("UPDATE tblEmployee SET FName='" & fname & "', LName='" & lname & "', Email='" & email & "', Phone='" & num & "', Address='" & add & "', Status='" & stat & "' WHERE EmpID='" & id & "'", con)
                update_emp.ExecuteNonQuery()
                update_emp.Dispose()
                MsgBox("Employee details updated!", vbInformation, "Note")
                bttnSave.Text = "&Save"
                id = 0
            Else ' add new employee
                Dim add_emp As New SqlCommand("INSERT INTO tblEmployee(FName,LName,Email,Phone,Address,Status) values ('" & fname & "','" & lname & "','" & email & "','" & num & "','" & add & "','" & stat & "')", con)
                add_emp.ExecuteNonQuery()
                add_emp.Dispose()
                MsgBox("Employee Registered!", vbInformation, "Note")
            End If
            txtFName.Clear()
            txtLName.Clear()
            txtEmail.Clear()
            txtNumber.Clear()
            txtAddress.Clear()
            txtStatus.Items.Clear()
        End If
        con.Close()
        display_employee()
    End Sub


    Private Sub display_employee()
        con.Open()
        Dim Dt As New DataTable("tblEmployee")
        Dim rs As SqlDataAdapter

        rs = New SqlDataAdapter("Select * from tblEmployee", con)

        rs.Fill(Dt)
        Dim indx As Integer
        lvEmployee.Items.Clear()
        For indx = 0 To Dt.Rows.Count - 1
            Dim lv As New ListViewItem
            lv.Text = Dt.Rows(indx).Item("EmpID")
            lv.SubItems.Add(Dt.Rows(indx).Item("FName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("LName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("Address"))
            lv.SubItems.Add(Dt.Rows(indx).Item("Phone"))
            lv.SubItems.Add(Dt.Rows(indx).Item("Status"))
            lvEmployee.Items.Add(lv)
        Next
        rs.Dispose()
        con.Close()
    End Sub

    Private Sub bttnCancel_Click(sender As Object, e As EventArgs) Handles bttnCancel.Click
        txtFName.Clear()
        txtLName.Clear()
        txtAddress.Clear()
        txtNumber.Clear()
        txtEmail.Clear()
        txtStatus.Items.Clear()
    End Sub

    Private Sub lvEmployee_DoubleClick(sender As Object, e As EventArgs) Handles lvEmployee.DoubleClick
        Dim a As String = MsgBox("Update selected Item?", vbQuestion + vbYesNo, "Update Employee")
        If a = vbYes Then
            id = lvEmployee.SelectedItems(0).Text
            txtFName.Text = lvEmployee.SelectedItems(0).SubItems(1).Text
            txtLName.Text = lvEmployee.SelectedItems(0).SubItems(2).Text
            txtAddress.Text = lvEmployee.SelectedItems(0).SubItems(3).Text
            txtNumber.Text = lvEmployee.SelectedItems(0).SubItems(4).Text
            txtStatus.Text = lvEmployee.SelectedItems(0).SubItems(5).Text

            TabControlemp.SelectTab(0)
            bttnSave.Text = "&Update"
        End If
    End Sub



End Class
