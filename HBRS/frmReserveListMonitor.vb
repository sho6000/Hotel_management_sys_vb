Imports System.Data.SqlClient

Public Class frmReserveListMonitor
    Dim connectionString As String = "Data Source=TUF-3050\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
    Dim con As New SqlConnection(connectionString)

    Private Sub frmReserveListMonitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Dt As New DataTable("tblGuest")
        Dim rs As SqlDataAdapter

        rs = New SqlDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = 'Reserve'", con)

        rs.Fill(Dt)
        Dim indx As Integer
        lvlreserve.Items.Clear()
        For indx = 0 To Dt.Rows.Count - 1
            Dim lv As New ListViewItem
            Dim getdate As TimeSpan
            Dim days, rate As Integer
            Dim discount, subtotal, total, advance As Double

            Dim value As Integer = Val(Dt.Rows(indx).Item("TransID"))

            lv.Text = "TransID - " & value.ToString("0000")
            lv.SubItems.Add(Dt.Rows(indx).Item("GuestFName") & " " & Dt.Rows(indx).Item("GuestLName"))
            lv.SubItems.Add(Dt.Rows(indx).Item("RoomNum"))

            rate = Dt.Rows(indx).Item("RoomRate")

            lv.SubItems.Add(Dt.Rows(indx).Item("CheckInDate"))
            lv.SubItems.Add(Dt.Rows(indx).Item("CheckOutDate"))

            dtIn.Value = Dt.Rows(indx).Item("CheckOutDate")
            dtOut.Value = Dt.Rows(indx).Item("CheckInDate")

            getdate = dtIn.Value - dtOut.Value
            days = getdate.Days

            lv.SubItems.Add(days)
            lv.SubItems.Add(Dt.Rows(indx).Item("NoOfChild"))
            lv.SubItems.Add(Dt.Rows(indx).Item("NoOfAdult"))
            advance = Dt.Rows(indx).Item("AdvancePayment")
            lv.SubItems.Add("Php " & Val(advance).ToString("N"))
            lv.SubItems.Add(Dt.Rows(indx).Item("DiscountType"))

            discount = Val(Dt.Rows(indx).Item("DiscountRate"))

            subtotal = (days * rate) - ((days * rate) * discount)

            total = Val(subtotal) - Val(Dt.Rows(indx).Item("AdvancePayment"))

            lv.SubItems.Add("Php " & Val(total).ToString("N"))
            lvlreserve.Items.Add(lv)
        Next
        rs.Dispose()
    End Sub
End Class