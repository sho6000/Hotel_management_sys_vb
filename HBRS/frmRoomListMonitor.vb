Imports System.Data.SqlClient

Public Class frmRoomListMonitor
    Dim connectionString As String = "Data Source=TUF-3050\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
    Dim con As New SqlConnection(connectionString)

    Private Sub frmRoomListMonitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open()
        Dim Dt As New DataTable("tblRoom")
        Dim rs As SqlDataAdapter

        rs = New SqlDataAdapter("Select * from tblRoom", con)

        rs.Fill(Dt)
        Dim indx As Integer
        lvRoom.Items.Clear()
        For indx = 0 To Dt.Rows.Count - 1
            Dim lv As New ListViewItem
            lv.Text = Dt.Rows(indx).Item("RoomNumber")
            lv.SubItems.Add(Dt.Rows(indx).Item("RoomType"))
            lv.SubItems.Add(Dt.Rows(indx).Item("RoomRate"))
            lv.SubItems.Add(Dt.Rows(indx).Item("NoOfOccupancy"))
            lv.SubItems.Add(Dt.Rows(indx).Item("Status"))
            lvRoom.Items.Add(lv)
        Next
        rs.Dispose()
        con.Close()
    End Sub
End Class