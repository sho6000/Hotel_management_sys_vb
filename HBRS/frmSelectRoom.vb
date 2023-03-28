Imports System.Data.SqlClient
Public Class frmSelectRoom
    Dim connectionString As String = "Data Source=TUF-3050\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
    Dim con As New SqlConnection(connectionString)

    Private Sub frmSelectRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display_room()
    End Sub
    Private Sub display_room()
        con.Open()
        Dim Dt As New DataTable("tblRoom")
        Dim rs As SqlDataAdapter

        rs = New SqlDataAdapter("Select * from tblRoom WHERE Status = 'Available'", con)

        rs.Fill(Dt)
        Dim indx As Integer
        lvRoom.Items.Clear()
        For indx = 0 To Dt.Rows.Count - 1
            Dim lv As New ListViewItem
            lv.Text = Dt.Rows(indx).Item("RoomNumber")
            lv.SubItems.Add(Dt.Rows(indx).Item("RoomType"))
            lv.SubItems.Add(Dt.Rows(indx).Item("RoomRate"))
            lv.SubItems.Add(Dt.Rows(indx).Item("NoOfOccupancy"))
            lvRoom.Items.Add(lv)
        Next
        rs.Dispose()
        con.Close()
    End Sub

    Private Sub lvRoom_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRoom.DoubleClick
        frmCheckin.txtRoomNumber.Text = lvRoom.SelectedItems(0).Text
        frmCheckin.txtRoomType.Text = lvRoom.SelectedItems(0).SubItems(1).Text
        frmCheckin.txtRoomRate.Text = lvRoom.SelectedItems(0).SubItems(2).Text
        frmCheckin.lblNoOfOccupancy.Text = lvRoom.SelectedItems(0).SubItems(3).Text

        frmReserve.txtRoomNumber.Text = lvRoom.SelectedItems(0).Text
        frmReserve.txtRoomType.Text = lvRoom.SelectedItems(0).SubItems(1).Text
        frmReserve.txtRoomRate.Text = lvRoom.SelectedItems(0).SubItems(2).Text
        frmReserve.lblNoOfOccupancy.Text = lvRoom.SelectedItems(0).SubItems(3).Text

        Me.Close()
    End Sub

    Private Sub lvRoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvRoom.SelectedIndexChanged

    End Sub
End Class