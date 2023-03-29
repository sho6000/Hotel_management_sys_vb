<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReport))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvRevenue = New System.Windows.Forms.DataGridView()
        Me.btnExportToPDF = New System.Windows.Forms.Button()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerateReport = New System.Windows.Forms.Button()
        Me.bttncsv = New System.Windows.Forms.Button()
        CType(Me.dgvRevenue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(181, 24)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Report Generation"
        '
        'dgvRevenue
        '
        Me.dgvRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRevenue.Location = New System.Drawing.Point(12, 82)
        Me.dgvRevenue.Name = "dgvRevenue"
        Me.dgvRevenue.Size = New System.Drawing.Size(517, 146)
        Me.dgvRevenue.TabIndex = 61
        '
        'btnExportToPDF
        '
        Me.btnExportToPDF.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.btnExportToPDF.Location = New System.Drawing.Point(444, 238)
        Me.btnExportToPDF.Name = "btnExportToPDF"
        Me.btnExportToPDF.Size = New System.Drawing.Size(83, 33)
        Me.btnExportToPDF.TabIndex = 65
        Me.btnExportToPDF.Text = "&Export to PDF"
        Me.btnExportToPDF.UseVisualStyleBackColor = True
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(12, 53)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpStartDate.TabIndex = 99
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(218, 53)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEndDate.TabIndex = 100
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Location = New System.Drawing.Point(344, 239)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(83, 33)
        Me.btnGenerateReport.TabIndex = 101
        Me.btnGenerateReport.Text = "&Generate"
        Me.btnGenerateReport.UseVisualStyleBackColor = True
        '
        'bttncsv
        '
        Me.bttncsv.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.bttncsv.Location = New System.Drawing.Point(13, 239)
        Me.bttncsv.Name = "bttncsv"
        Me.bttncsv.Size = New System.Drawing.Size(74, 33)
        Me.bttncsv.TabIndex = 102
        Me.bttncsv.Text = "&CSV"
        Me.bttncsv.UseVisualStyleBackColor = True
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 284)
        Me.Controls.Add(Me.bttncsv)
        Me.Controls.Add(Me.btnGenerateReport)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.btnExportToPDF)
        Me.Controls.Add(Me.dgvRevenue)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Sytem"
        CType(Me.dgvRevenue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As Label
    Friend WithEvents dgvRevenue As DataGridView
    Friend WithEvents btnExportToPDF As Button


    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents bttncsv As Button
End Class
