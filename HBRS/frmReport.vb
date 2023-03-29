Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO


Public Class frmReport
    Dim connectionString As String = "Data Source=TUF-3050\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Populate the date picker controls with current date by default
        dtpStartDate.Value = DateTime.Today
        dtpEndDate.Value = DateTime.Today
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click
        'Validate user input
        If dtpStartDate.Value > dtpEndDate.Value Then
            MessageBox.Show("End date must be greater than start date.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'Query the database for revenue spent during the selected period
        Dim startDate As String = dtpStartDate.Value.ToString("yyyy-MM-dd")
        Dim endDate As String = dtpEndDate.Value.ToString("yyyy-MM-dd")
        'Dim query As String = $"SELECT SUM(revenue) as TotalRevenue FROM Transactions WHERE date BETWEEN '{startDate}' AND '{endDate}'"
        Dim query As String = $"SELECT t.ReservationDate, t.AdvancePayment, g.GuestFName, g.GuestMName, g.GuestLName FROM tblTransaction t INNER JOIN tblGuest g ON t.GuestID = g.ID WHERE t.ReservationDate BETWEEN '{startDate}' AND '{endDate}'"
        Dim dataTable As New DataTable()
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Using adapter As New SqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using
            End Using
        End Using

        'Display the result in the datagridview
        dgvRevenue.DataSource = dataTable

        'Enable the export to PDF button
        btnExportToPDF.Enabled = True
    End Sub

    'Dim fileName As String = $"Generated Report ({dtpStartDate.Value.ToString("yyyy-MM-dd")} to {dtpEndDate.Value.ToString("yyyy-MM-dd")}).pdf"
    Private Sub btnExportToPDF_Click(sender As Object, e As EventArgs) Handles btnExportToPDF.Click
        'Create a new SaveFileDialog object
        Dim saveFileDialog1 As New SaveFileDialog()

        'Set the dialog properties
        saveFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf"
        saveFileDialog1.Title = "Save Report as PDF"
        saveFileDialog1.FileName = $"Generated_Report ({dtpStartDate.Value.ToString("yyyy-MM-dd")} to {dtpEndDate.Value.ToString("yyyy-MM-dd")}).pdf"

        'Show the dialog and check if the user clicked OK
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            'Create the PDF document and table
            Dim document As New Document()
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(saveFileDialog1.FileName, FileMode.Create))
            document.Open()
            Dim table As New PdfPTable(dgvRevenue.Columns.Count)

            'Add the table headers
            For Each column As DataGridViewColumn In dgvRevenue.Columns
                table.AddCell(column.HeaderText)
            Next

            'Add the table rows
            For Each row As DataGridViewRow In dgvRevenue.Rows
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Value IsNot Nothing Then
                        table.AddCell(cell.Value.ToString())
                    Else
                        table.AddCell("")
                    End If
                Next
            Next

            'Add the table to the document and close it
            document.Add(table)
            document.Close()

            'Show a message box to confirm that the file was saved successfully
            MessageBox.Show("Report saved successfully.", "Report Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub bttncsv_Click(sender As Object, e As EventArgs) Handles bttncsv.Click
        'Create a new SaveFileDialog object
        Dim saveFileDialog1 As New SaveFileDialog()

        'Set the dialog properties
        saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv"
        saveFileDialog1.Title = "Save Report as CSV"
        saveFileDialog1.FileName = $"Generated_Report ({dtpStartDate.Value.ToString("yyyy-MM-dd")} to {dtpEndDate.Value.ToString("yyyy-MM-dd")}).csv"

        'Show the dialog and check if the user clicked OK
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            'Create a new StreamWriter object to write the CSV data to a file
            Using writer As New StreamWriter(saveFileDialog1.FileName)
                'Write the column headers to the file
                For Each column As DataGridViewColumn In dgvRevenue.Columns
                    writer.Write(column.HeaderText & ",")
                Next
                writer.WriteLine()

                'Write the data rows to the file
                For Each row As DataGridViewRow In dgvRevenue.Rows
                    For Each cell As DataGridViewCell In row.Cells
                        If cell.Value IsNot Nothing Then
                            writer.Write(cell.Value.ToString() & ",")
                        Else
                            writer.Write(",")
                        End If
                    Next
                    writer.WriteLine()
                Next
            End Using

            'Show a message box to confirm that the file was saved successfully
            MessageBox.Show("Report saved successfully.", "Report Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class
