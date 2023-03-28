Imports System.Data.SqlClient

Public Class frmCheckinListMonitor
    Dim connectionString As String = "Data Source=TUF-3050\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
    Dim con As New SqlConnection(connectionString)

    Private Sub frmCheckinListMonitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open()
        Dim Dt As New DataTable("tblTransaction")
        Dim rs As SqlDataAdapter
        rs = New SqlDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = 'Checkin' AND tblTransaction.Status = 'Active'", con)
        rs.Fill(Dt)

        Dim indx As Integer
        lvlcheckin.Items.Clear()
        For indx = 0 To Dt.Rows.Count - 1
            Dim lv As New ListViewItem
            Dim getdate As TimeSpan
            Dim days, rate As Integer
            Dim subtotal, total, advance As Double
            Dim discount As Double

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
            lv.SubItems.Add("Php " & (advance).ToString("N"))
            lv.SubItems.Add(Dt.Rows(indx).Item("DiscountType"))

            discount = Val(Dt.Rows(indx).Item("DiscountRate"))

            subtotal = (days * rate) - ((days * rate) * discount)
            total = (Val(subtotal) - Val(Dt.Rows(indx).Item("AdvancePayment"))).ToString("N")

            If Val(subtotal) > Val(Dt.Rows(indx).Item("AdvancePayment")) Then
                lv.SubItems.Add("Php " & Val(total).ToString("N"))
            Else
                lv.SubItems.Add("Php 0.00")
            End If

            lvlcheckin.Items.Add(lv)
        Next
        rs.Dispose()
        con.Close()
    End Sub
End Class