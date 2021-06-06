Imports System.Data.OleDb

Public Class DataSiswa

    Sub Tampilgrid()
        Call Koneksi()
        DA = New OleDbDataAdapter("select * from TBLSiswa", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub


    Private Sub DataSiswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmbjenjang.Items.Add("PAKET A")
        cmbjenjang.Items.Add("PAKET B")
        cmbjenjang.Items.Add("PAKET C")

        cmbkelas.Items.Add("VI")
        cmbkelas.Items.Add("VII")

        cmbkelas.Items.Add("VIII")
        cmbkelas.Items.Add("IX")
        cmbkelas.Items.Add("X")
        cmbkelas.Items.Add("XI")
        cmbkelas.Items.Add("XII")
        cmbjenjang.Enabled = False
        'cmbkelas.Enabled = False
        'txtnama.Enabled = False
        'txtpassword.Enabled = False
        txtnomor.MaxLength = 7
        'Call datajenjang()
        'Call datakelas()

        ' DGV.Columns(1).Width = 250
        Call Tampilgrid()
        'TextBox1.Enabled = False
        'TextBox2.Enabled = False
        'TextBox5.Enabled = False
    End Sub

    'Private Sub cmbjenjang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbjenjang.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Call CariJumlahSiswa()
    '        Call Carikelas()
    '        TextBox3.Focus()
    '    End If
    'End Sub

    Sub nemuin_siswa()
        Call Koneksi()
        CMD = New OleDbCommand("select * from TBLSiswa where Nama_Siswa = '" & txtnama.Text & "' or Nomor_Peserta = '" & txtnomor.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            txtnama.Text = DR.Item("Nama_Siswa")
            txtnomor.Text = DR.Item("Nomor_Peserta")
            txtpassword.Text = DR.Item("Password_Siswa")
            cmbkelas.Text = DR.Item("Kelas")
            cmbjenjang.Text = DR.Item("Jenjang")
            cmbkelas.Enabled = True
            txtnama.Enabled = True
            txtnomor.Enabled = False
            txtpassword.Enabled = True
            'cmbjenjang.Enabled = True


        Else
            MsgBox("data tidak ditemukan")
            cmbkelas.Enabled = True
            txtnama.Enabled = True
            txtnomor.Enabled = False
            txtpassword.Enabled = True
            'cmbjenjang.Enabled = True

        End If
        Conn.Close()
    End Sub

    'Private Sub cmbjenjang_SelectedIndexChanged(ByVal sender As System.Object, ByVal ByVale As System.EventArgs) Handles cmbjenjang.SelectedIndexChanged
    '    'Call CariJumlahSiswa()
    '    'Call Carikelas()
    '    'TextBox3.Focus()
    '    Call clearkelas()


    '    Call pilihankelas()
    'End Sub
    Sub clearkelas()
        If cmbkelas.Text = "VI" Then
            cmbjenjang.Text = "PAKET A"
        ElseIf cmbkelas.Text = "VII" Or cmbkelas.Text = "VIII" Or cmbkelas.Text = "IX" Then
            cmbjenjang.Text = "PAKET B"
        ElseIf cmbkelas.Text = "X" Or cmbkelas.Text = "XI" Or cmbkelas.Text = "XII" Then
            cmbjenjang.Text = "PAKET C"

        End If
    End Sub

    Sub Kosongkan()
        txtnama.Clear()
        txtnomor.Clear()
        cmbjenjang.Text = ""
        cmbkelas.Text = ""
        txtpassword.Clear()
        cmbjenjang.Enabled = False

        cmbkelas.Enabled = True

        txtnama.Enabled = True
        txtpassword.Enabled = True
        txtnama.Focus()
        txtnomor.Enabled = True

    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        On Error Resume Next
        cmbjenjang.Enabled = False
        txtnomor.Enabled = False

        txtnomor.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        txtnama.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        cmbkelas.Text = DGV.Rows(e.RowIndex).Cells(2).Value
        cmbjenjang.Text = DGV.Rows(e.RowIndex).Cells(3).Value
        txtpassword.Text = DGV.Rows(e.RowIndex).Cells(4).Value

    End Sub

    'Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e AsSystem.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Button1.Focus()
    '    End If
    'End Sub

    'Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e AsSystem.EventArgs) Handles TextBox4.TextChanged
    '    
    'End Sub


    'Sub pilihankelas()
    '    If cmbjenjang.Text = "PAKET A" Then
    '        cmbkelas.Items.Clear()
    '        cmbkelas.Items.Add("VI")
    '    ElseIf cmbjenjang.Text = "PAKET B" Then
    '        cmbkelas.Items.Clear()
    '        cmbkelas.Items.Add("VIIA")
    '        cmbkelas.Items.Add("VIIB")
    '        cmbkelas.Items.Add("VIII")
    '        cmbkelas.Items.Add("IX")
    '    ElseIf cmbjenjang.Text = "PAKET C" Then
    '        cmbkelas.Items.Clear()
    '        cmbkelas.Items.Add("X")
    '        cmbkelas.Items.Add("XI")
    '        cmbkelas.Items.Add("XII")
    '    End If

    'End Sub

    Private Sub txtnomor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnomor.KeyPress
        'If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        'Dim keyascii As Short = Asc(e.KeyChar)
        'If (e.KeyChar Like "[A-Z,a-z]" OrElse keyascii = Keys.Back OrElse Keys.Space OrElse keyascii = Keys.Return OrElse keyascii = Keys.Delete) Then
        '    keyascii = 0
        'End If
        'e.Handled = CBool(keyascii)
        If e.KeyChar = Chr(13) Then
            Call nemuin_siswa()
        End If
    End Sub

    'Sub datajenjang()
    '    Call Koneksi()
    '    CMD = New OleDbCommand("select distinct Jenjang from TBLSiswa order by Jenjang", Conn)
    '    DR = CMD.ExecuteReader
    '    cmbjenjang.Items.Clear()
    '    Do While DR.Read
    '        cmbjenjang.Items.Add(DR.Item("Jenjang"))
    '    Loop
    '    Conn.Close()

    'End Sub
    'Sub datakelas()
    '    Call Koneksi()
    '    CMD = New OleDbCommand("select distinct Kelas from TBLSiswa order by Kelas", Conn)
    '    DR = CMD.ExecuteReader
    '    cmbkelas.Items.Clear()
    '    Do While DR.Read
    '        cmbkelas.Items.Add(DR.Item("Kelas"))
    '    Loop
    '    Conn.Close()

    'End Sub

    'Private Sub txtnama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnama.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Call nemuin_siswa()
    '    End If
    'End Sub

    Private Sub cmbkelas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbkelas.SelectedIndexChanged
        Call clearkelas()

    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If txtnomor.Text = "" Or txtnama.Text = "" Or txtpassword.Text = "" Or cmbkelas.Text = "" Or cmbjenjang.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New OleDbCommand("select * from TBLSiswa where Nomor_Peserta='" & txtnomor.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                Call Koneksi()
                Dim simpan As String = "insert into TBLSiswa values('" & txtnomor.Text & "','" & txtnama.Text & "','" & UCase(cmbkelas.Text) & "','" & UCase(cmbjenjang.Text) & "','" & txtpassword.Text & "')"
                CMD = New OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("data berhasil disimpan")
            Else
                Call Koneksi()
                Dim edit As String = "update TBLSiswa set Nama_Siswa='" & txtnama.Text & "',Kelas='" & UCase(cmbkelas.Text) & "',Jenjang='" & UCase(cmbjenjang.Text) & "',Password_Siswa = '" & txtpassword.Text & "' where Nomor_Peserta='" & txtnomor.Text & "'"
                CMD = New OleDbCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("data berhasil diedit")
            End If
            Call Kosongkan()
            Call Tampilgrid()
            'Call datajenjang()
            'Call datakelas()

        End If
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        If txtnomor.Text = "" Then
            MsgBox("Nomor Peserta harus diisi dulu")
            txtnomor.Focus()
            Exit Sub
        Else
            If MessageBox.Show("hapus data ini...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete from TBLSiswa where Nomor_Peserta='" & txtnomor.Text & "'"
                CMD = New OleDbCommand(hapus, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("data berhasil dihapus")
                Call Kosongkan()
                Call Tampilgrid()
                'Call datajenjang()
                'Call datakelas()

            Else
                Call Kosongkan()
            End If
        End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        Call Kosongkan()
        'Call datakelas()
        'Call datajenjang()


    End Sub

    Private Sub btntutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntutup.Click
        Me.Close()

    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call cari_siswa()

    End Sub

    Sub cari_siswa()
        Call Koneksi()
        DA = New OleDbDataAdapter("select * from TBLSiswa where Nama_Siswa like '%" & txtcari.Text & "%' or Nomor_Peserta like '%" & txtcari.Text & "%' or Kelas like '%" & txtcari.Text & "%' or Jenjang like '%" & txtcari.Text & "%'", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        Conn.Close()

    End Sub

    Private Sub txtnomor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnomor.TextChanged

    End Sub

    Private Sub cmbkelas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbkelas.TextChanged
        Call clearkelas()

    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub
End Class