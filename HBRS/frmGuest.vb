Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class frmGuest
    Dim connectionString As String = "Data Source=TUF-3050\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
    Dim con As New SqlConnection(connectionString)

    Private Sub bttnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnSave.Click
        con.Open()
        Dim fname As String = Trim(txtFName.Text)
        Dim mname As String = Trim(txtMName.Text)
        Dim lname As String = Trim(txtLName.Text)
        Dim add As String = Trim(txtAddress.Text)
        Dim num As String = Trim(txtNumber.Text)
        Dim email As String = Trim(txtEmail.Text)
        Dim stat As String = "Active"
        Dim remark As String = "Available"

        If fname = "" Or mname = "" Or lname = "" Or add = "" Or num = "" Then
            MsgBox("Please Fill All Required Fields", vbInformation, "Note")
        Else
            ' Perform validation on phone number and email
            If Not IsNumeric(num) OrElse num.Length <> 10 Then
                MsgBox("Please enter a valid 10-digit phone number", vbInformation, "Note")
            ElseIf Not (New Regex("^([\w\.\-]+)@(gmail|hotmail)\.com$")).IsMatch(email) Then
                MsgBox("Please enter a valid email address", vbInformation, "Note")
            Else
                ' All required fields are filled in and phone number and email are valid
                Dim add_guest As New SqlCommand("INSERT INTO tblGuest(GuestFName,GuestMName,GuestLName,GuestAddress,GuestContactNumber,GuestGender,GuestEmail,Status,Remarks) values ('" &
                                              fname & "','" &
                                              mname & "','" &
                                              lname & "','" &
                                              add & "','" &
                                              num & "','" &
                                              cboGender.Text & "','" &
                                              email & "','" &
                                              stat & "','" &
                                              remark & "')", con)
                add_guest.ExecuteNonQuery()
                add_guest.Dispose()
                MsgBox("Guest Added!", vbInformation, "Note")
                txtFName.Clear()
                txtMName.Clear()
                txtLName.Clear()
                txtAddress.Clear()
                txtNumber.Clear()
                txtEmail.Clear()
            End If
        End If
        con.Close()
        display_guest()
    End Sub


    Private Sub frmGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display_guest()
        TabControl1.SelectTab(0)
    End Sub

    Private Sub display_guest()
        con.Open()
        Dim Dt As New DataTable("tblGuest")
        Dim rs As SqlDataAdapter

        rs = New SqlDataAdapter("Select * from tblGuest", con)

        rs.Fill(Dt)
        Dim indx As Integer
        lvGuest.Items.Clear()
        For indx = 0 To Dt.Rows.Count - 1
            Dim lv As New ListViewItem
            lv.Text = Dt.Rows(indx).Item("ID")
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestFName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestMName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestLName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestAddress"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestContactNumber"))
            lv.SubItems.Add(Dt.Rows(indx).Item("Status"))
            lvGuest.Items.Add(lv)
        Next
        rs.Dispose()
        con.Close()
    End Sub

    Private Sub bttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click
        txtFName.Clear()
        txtMName.Clear()
        txtLName.Clear()
        txtAddress.Clear()
        txtNumber.Clear()
        txtEmail.Clear()


    End Sub


    Private Sub txtFName_TextChanged(sender As Object, e As EventArgs) Handles txtFName.TextChanged

    End Sub

    'extra validations ------------------------------------------------------------------------------------------------

    Private Sub txtFName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFName.KeyPress
        ' Check if the key pressed is a letter or a backspace
        If Not Char.IsLetter(e.KeyChar) AndAlso Not e.KeyChar = ControlChars.Back Then
            ' If the key is not a letter or a backspace, suppress the key press event
            e.Handled = True
        End If
    End Sub

    Private Sub txtLName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLName.KeyPress
        ' Check if the key pressed is a letter or a backspace
        If Not Char.IsLetter(e.KeyChar) AndAlso Not e.KeyChar = ControlChars.Back Then
            ' If the key is not a letter or a backspace, suppress the key press event
            e.Handled = True
        End If
    End Sub

    Private Sub txtMName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMName.KeyPress
        ' Check if the key pressed is a letter or a backspace
        If Not Char.IsLetter(e.KeyChar) AndAlso Not e.KeyChar = ControlChars.Back Then
            ' If the key is not a letter or a backspace, suppress the key press event
            e.Handled = True
        End If
    End Sub

    Private Sub txtAddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddress.KeyPress
        ' Check if the key pressed is a letter or a backspace
        If Not Char.IsLetter(e.KeyChar) AndAlso Not e.KeyChar = ControlChars.Back Then
            ' If the key is not a letter or a backspace, suppress the key press event
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumber.KeyPress
        ' Allow only numeric key presses and the Backspace key
        If (Not Char.IsDigit(e.KeyChar)) AndAlso (e.KeyChar <> ChrW(Keys.Back)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub txtNumber_TextChanged(sender As Object, e As EventArgs) Handles txtNumber.TextChanged

    End Sub
End Class