Imports System.Data.SqlClient

Public Class frmLogin
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        If Trim(UsernameTextBox.Text) = "" Or Trim(PasswordTextBox.Text) = "" Then
            MsgBox("Please Enter Both Fields!", vbInformation, "Note")
        Else
            Dim connectionString As String = "Data Source=TUF-3050\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
            Dim sql = "SELECT * FROM tblUser WHERE username = @username AND password = @password"

            Using con As SqlConnection = New SqlConnection(connectionString)
                Using cmd As SqlCommand = New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@username", UsernameTextBox.Text)
                    cmd.Parameters.AddWithValue("@password", PasswordTextBox.Text)

                    Try
                        con.Open()
                        Dim dr As SqlDataReader = cmd.ExecuteReader()

                        If dr.HasRows = False Then
                            MsgBox("Login Failed!", vbCritical, "Note")
                        Else
                            MsgBox("Login Successful!", vbInformation, "Note")
                            frmMain.status.Items(0).Text = "Login as : " & Trim(UsernameTextBox.Text)
                            Dim datenow As Date = Now
                            frmMain.status.Items(2).Text = "Date and Time : " & datenow.ToString("MMMM dd, yyyy") & " " & TimeOfDay
                            con.Close()
                            Me.Hide()
                            frmMain.ShowDialog()
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        End
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         
    End Sub

    Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
