<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HasilUjian
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HasilUjian))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lnomor = New System.Windows.Forms.Label()
        Me.lnama = New System.Windows.Forms.Label()
        Me.ltanggal = New System.Windows.Forms.Label()
        Me.lpelajaran = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnhapusemua = New System.Windows.Forms.Button()
        Me.btntutup = New System.Windows.Forms.Button()
        Me.btnbatal = New System.Windows.Forms.Button()
        Me.btnhapus = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lnilai = New System.Windows.Forms.Label()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No. Peserta"
        '
        'txtcari
        '
        Me.txtcari.Location = New System.Drawing.Point(6, 21)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(536, 20)
        Me.txtcari.TabIndex = 5
        '
        'DGV
        '
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 148)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(902, 234)
        Me.DGV.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Location = New System.Drawing.Point(12, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "ID Pelajaran"
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(12, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tanggal Ujian"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(12, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama"
        '
        'lnomor
        '
        Me.lnomor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lnomor.Location = New System.Drawing.Point(118, 9)
        Me.lnomor.Name = "lnomor"
        Me.lnomor.Size = New System.Drawing.Size(100, 23)
        Me.lnomor.TabIndex = 9
        '
        'lnama
        '
        Me.lnama.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lnama.Location = New System.Drawing.Point(118, 32)
        Me.lnama.Name = "lnama"
        Me.lnama.Size = New System.Drawing.Size(222, 23)
        Me.lnama.TabIndex = 10
        '
        'ltanggal
        '
        Me.ltanggal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ltanggal.Location = New System.Drawing.Point(118, 55)
        Me.ltanggal.Name = "ltanggal"
        Me.ltanggal.Size = New System.Drawing.Size(100, 23)
        Me.ltanggal.TabIndex = 11
        '
        'lpelajaran
        '
        Me.lpelajaran.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lpelajaran.Location = New System.Drawing.Point(118, 78)
        Me.lpelajaran.Name = "lpelajaran"
        Me.lpelajaran.Size = New System.Drawing.Size(100, 23)
        Me.lpelajaran.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnhapusemua)
        Me.GroupBox1.Controls.Add(Me.btntutup)
        Me.GroupBox1.Controls.Add(Me.btnbatal)
        Me.GroupBox1.Controls.Add(Me.btnhapus)
        Me.GroupBox1.Controls.Add(Me.txtcari)
        Me.GroupBox1.Location = New System.Drawing.Point(346, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 133)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cari Data Hasil Ujian"
        '
        'btnhapusemua
        '
        Me.btnhapusemua.BackgroundImage = CType(resources.GetObject("btnhapusemua.BackgroundImage"), System.Drawing.Image)
        Me.btnhapusemua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnhapusemua.Image = CType(resources.GetObject("btnhapusemua.Image"), System.Drawing.Image)
        Me.btnhapusemua.Location = New System.Drawing.Point(76, 50)
        Me.btnhapusemua.Name = "btnhapusemua"
        Me.btnhapusemua.Size = New System.Drawing.Size(89, 71)
        Me.btnhapusemua.TabIndex = 9
        Me.btnhapusemua.Text = "Hapus Semua"
        Me.btnhapusemua.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnhapusemua.UseVisualStyleBackColor = True
        '
        'btntutup
        '
        Me.btntutup.BackgroundImage = CType(resources.GetObject("btntutup.BackgroundImage"), System.Drawing.Image)
        Me.btntutup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btntutup.Location = New System.Drawing.Point(241, 50)
        Me.btntutup.Name = "btntutup"
        Me.btntutup.Size = New System.Drawing.Size(64, 71)
        Me.btntutup.TabIndex = 8
        Me.btntutup.Text = "Tutup"
        Me.btntutup.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btntutup.UseVisualStyleBackColor = True
        '
        'btnbatal
        '
        Me.btnbatal.BackgroundImage = CType(resources.GetObject("btnbatal.BackgroundImage"), System.Drawing.Image)
        Me.btnbatal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnbatal.Location = New System.Drawing.Point(171, 50)
        Me.btnbatal.Name = "btnbatal"
        Me.btnbatal.Size = New System.Drawing.Size(64, 71)
        Me.btnbatal.TabIndex = 7
        Me.btnbatal.Text = "Batal"
        Me.btnbatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnbatal.UseVisualStyleBackColor = True
        '
        'btnhapus
        '
        Me.btnhapus.BackgroundImage = CType(resources.GetObject("btnhapus.BackgroundImage"), System.Drawing.Image)
        Me.btnhapus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnhapus.Location = New System.Drawing.Point(6, 50)
        Me.btnhapus.Name = "btnhapus"
        Me.btnhapus.Size = New System.Drawing.Size(64, 71)
        Me.btnhapus.TabIndex = 6
        Me.btnhapus.Text = "Hapus"
        Me.btnhapus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnhapus.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(12, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Nilai"
        '
        'lnilai
        '
        Me.lnilai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lnilai.Location = New System.Drawing.Point(118, 101)
        Me.lnilai.Name = "lnilai"
        Me.lnilai.Size = New System.Drawing.Size(100, 23)
        Me.lnilai.TabIndex = 15
        '
        'HasilUjian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 390)
        Me.Controls.Add(Me.lnilai)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lpelajaran)
        Me.Controls.Add(Me.ltanggal)
        Me.Controls.Add(Me.lnama)
        Me.Controls.Add(Me.lnomor)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "HasilUjian"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HasilUjian"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcari As System.Windows.Forms.TextBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lnomor As System.Windows.Forms.Label
    Friend WithEvents lnama As System.Windows.Forms.Label
    Friend WithEvents ltanggal As System.Windows.Forms.Label
    Friend WithEvents lpelajaran As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btntutup As System.Windows.Forms.Button
    Friend WithEvents btnbatal As System.Windows.Forms.Button
    Friend WithEvents btnhapus As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lnilai As System.Windows.Forms.Label
    Friend WithEvents btnhapusemua As System.Windows.Forms.Button
End Class
