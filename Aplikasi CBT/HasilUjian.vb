Imports System.Data.OleDb

Public Class HasilUjian
    Sub Kosongkan()
        lnomor.Text = ""
        lnama.Text = ""
        ltanggal.Text = ""
        lpelajaran.Text = ""
        lnilai.Text = ""
        btnhapus.Enabled = False
        btnhapusemua.Enabled = False

        txtcari.Focus()
    End Sub
    Sub Tampilgrid()
        Call Koneksi()
        DA = New OleDbDataAdapter("select * from TBLMaster_Jawaban", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub
    Private Sub HasilUjian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Kosongkan()
        Call Tampilgrid()
        DGV.Columns(1).Width = 250

    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call Koneksi()
        CMD = New OleDbCommand("select * from TBLMaster_Jawaban where Nomor_Peserta like '%" & txtcari.Text & "%'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Call Koneksi()
            DA = New OleDbDataAdapter("select * from TBLMaster_Jawaban where Nomor_Peserta like '%" & txtcari.Text & "%' or Nama_Siswa like '%" & txtcari.Text & "%' or Tanggal_Ujian like '%" & txtcari.Text & "%' or ID_Pelajaran like '%" & txtcari.Text & "%'", Conn)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
        Else
            MsgBox("user tidak ditemukan")
        End If
    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        On Error Resume Next
        btnhapus.Enabled = True
        btnhapusemua.Enabled = True
        lnomor.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        lnama.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        ltanggal.Text = DGV.Rows(e.RowIndex).Cells(2).Value
        lpelajaran.Text = DGV.Rows(e.RowIndex).Cells(3).Value
        lnilai.Text = DGV.Rows(e.RowIndex).Cells(6).Value
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        Call Kosongkan()

    End Sub

    Private Sub btntutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntutup.Click
        Me.Close()

    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        If lnomor.Text = "" Or lnama.Text = "" Or lpelajaran.Text = "" Or ltanggal.Text = "" Or lnilai.Text = "" Then
            MsgBox(" pilih data terlebih dulu")
            Exit Sub
        Else
            If MessageBox.Show("hapus data ini...?", "",
            MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete from TBLMaster_Jawaban where ID_Pelajaran ='" & lpelajaran.Text & "' and Nomor_Peserta = '" & lnomor.Text & "'"
                CMD = New OleDbCommand(hapus, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("data berhasil dihapus")
                Call Kosongkan()
                Call Tampilgrid()

            Else
                Call Kosongkan()
            End If
        End If
    End Sub

    Private Sub btnhapusemua_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapusemua.Click
        If lnomor.Text = "" Or lnama.Text = "" Or lpelajaran.Text = "" Or ltanggal.Text = "" Or lnilai.Text = "" Then
            MsgBox(" pilih data terlebih dulu")
            Exit Sub
        Else
            If MessageBox.Show("hapus semua data ini...?", "",
            MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete * from TBLMaster_Jawaban"
                CMD = New OleDbCommand(hapus, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("semua data berhasil dihapus")
                Call Kosongkan()
                Call Tampilgrid()

            Else
                Call Kosongkan()
            End If
        End If
    End Sub
End Class