Imports System.Data.SqlClient

Public Class frmSelectGuest
    Dim connectionString As String = "Data Source=TUF-3050\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
    Dim con As New SqlConnection(connectionString)
    Private Sub frmSelectGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display_guest()
    End Sub
    Private Sub display_guest()
        con.Open()
        Dim Dt As New DataTable("tblGuest")
        Dim rs As SqlDataAdapter

        rs = New SqlDataAdapter("Select * from tblGuest WHERE Remarks = 'Available' ", con)

        rs.Fill(Dt)
        Dim indx As Integer
        lvGuest.Items.Clear()
        For indx = 0 To Dt.Rows.Count - 1
            Dim lv As New ListViewItem
            lv.Text = Dt.Rows(indx).Item("ID")
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestFName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestMName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestLName"))
            lvGuest.Items.Add(lv)
        Next
        rs.Dispose()
        con.Close()
    End Sub

    Private Sub lvGuest_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvGuest.DoubleClick
        frmCheckin.lblGuestID.Text = lvGuest.SelectedItems(0).Text
        frmCheckin.txtGuestName.Text = lvGuest.SelectedItems(0).SubItems(1).Text & " " & lvGuest.SelectedItems(0).SubItems(2).Text & " " & lvGuest.SelectedItems(0).SubItems(3).Text

        frmReserve.lblGuestID.Text = lvGuest.SelectedItems(0).Text
        frmReserve.txtGuestName.Text = lvGuest.SelectedItems(0).SubItems(1).Text & " " & lvGuest.SelectedItems(0).SubItems(2).Text & " " & lvGuest.SelectedItems(0).SubItems(3).Text
        Me.Close()
    End Sub
End Class