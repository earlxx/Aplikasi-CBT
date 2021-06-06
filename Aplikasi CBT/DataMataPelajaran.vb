Imports System.Data.OleDb

Public Class DataMataPelajaran

    Sub Kosongkan()
        cmbjenjang.Text = ""
        cmbkelas.Text = ""
        txtidpelajaran.Clear()
        txtmatapelajaran.Text = ""
        txtjpl.Clear()
        txtcari.Clear()
        'cmbjenjang.Enabled = True
        'cmbjenjang.Enabled = True
        txtidpelajaran.Enabled = True
        'txtmatapelajaran.Enabled = True
        'txtjpl.Enabled = True
        'cmbjenjang.Focus()
    End Sub
    Sub Tampilgrid()
        Call Koneksi()
        DA = New OleDbDataAdapter("select * from TBLPelajaran", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub
    'Sub TampilKuliah()
    '    CMD = New OleDbCommand("select distinct jurusan from tblsiswa", Conn)
    '    DR = CMD.ExecuteReader
    '    cmbjenjang.Items.Clear()
    '    Do While DR.Read
    '        cmbjenjang.Items.Add(DR.Item("Jurusan"))
    '    Loop
    'End Sub
    'Private Sub DataMataKuliah_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Call Koneksi()
    '    Call TampilKuliah()
    '    Call Tampilgrid()
    '    'menampilkan semeter 1 - 6 dalam combobox2
    '    For smt As Integer = 1 To 6
    '        cmbkelas.Items.Add(smt)
    '    Next
    '    txtidpelajaran.Enabled = False
    'End Sub
    'Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbjenjang.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '    End If
    'End Sub
    ''membuat kode mata kuliah secara otomatis berdasarkan jurusan
    'Sub CariKodeKuliah()
    '    Call Koneksi()
    '    CMD = New OleDbCommand("select idkuliah from TBLPelajaran where jurusan='" & cmbjenjang.Text & "' order by idkuliah desc", Conn)
    '    DR = CMD.ExecuteReader
    '    DR.Read()
    '    If Not DR.HasRows Then
    '        If cmbjenjang.Text = "MANAJEMEN INFORMATIKA" Then
    '            txtidpelajaran.Text = "101"
    '        ElseIf cmbjenjang.Text = "MANAJEMEN ADMINISTRASI" Then
    '            txtidpelajaran.Text = "201"
    '        ElseIf cmbjenjang.Text = "AKUNTANSI" Then
    '            txtidpelajaran.Text = "301"
    '        ElseIf cmbjenjang.Text = "SEKRETARI" Then
    '            txtidpelajaran.Text = "401"
    '        End If
    '    Else
    '        txtidpelajaran.Text = DR.Item("idkuliah") + 1
    '    End If
    'End Sub
    'Private Sub Textbox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmatapelajaran.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        txtjpl.Focus()
    '    End If
    'End Sub
    'Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtjpl.KeyPress
    '    txtjpl.MaxLength = 1
    '    If e.KeyChar = Chr(13) Then
    '        cmbkelas.Focus()
    '    End If
    '    If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar =
    '    vbBack) Then
    '        e.Handled = True
    '    End If
    'End Sub
    'Private Sub Combobox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbkelas.KeyPress
    '    cmbkelas.MaxLength = 1
    '    If e.KeyChar = Chr(13) Then
    '        Button1.Focus()
    '    End If
    'End Sub
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If cmbjenjang.Text = "" Or txtidpelajaran.Text = "" Or
    '    txtmatapelajaran.Text = "" Or txtjpl.Text = "" Or cmbkelas.Text = "" Then
    '        MsgBox("data belum lengkap")
    '        Exit Sub
    '    Else
    '        Call Koneksi()
    '        'cari kode mata kuliah
    '        CMD = New OleDbCommand("select * from TBLPelajaran where idkuliah='" & txtidpelajaran.Text & "'", Conn)
    '        DR = CMD.ExecuteReader
    '        DR.Read()
    '        If Not DR.HasRows Then
    '            Call Koneksi()
    '            'jika tidak ada maka lakukan insert
    '            Dim simpan As String = "insert into TBLPelajaran values('" & txtidpelajaran.Text & "','" & txtmatapelajaran.Text & "','" & txtjpl.Text & "','" & cmbkelas.Text & "','" & cmbjenjang.Text & "')"
    '            CMD = New OleDbCommand(simpan, Conn)
    '            CMD.ExecuteNonQuery()
    '        Else
    '            Call Koneksi()
    '            'jika sudah ada maka lakukan update
    '            Dim edit As String = "update TBLPelajaran set MataKuliah='" & txtmatapelajaran.Text & "',SKS='" & txtjpl.Text & "', SEmESTER='" & cmbkelas.Text & "',JURUSAN='" & cmbkelas.Text & "' where idkuliah='" & txtidpelajaran.Text & "'"
    '            CMD = New OleDbCommand(edit, Conn)
    '            CMD.ExecuteNonQuery()
    '        End If
    '        Call Kosongkan()
    '        Call Tampilgrid()
    '    End If
    'End Sub
    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    Call Kosongkan()
    'End Sub
    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    Me.Close()
    'End Sub
    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    If txtmatapelajaran.Text = "" Then
    '        MsgBox("idkuliah harus diisi dulu")
    '        txtmatapelajaran.Focus()
    '        Exit Sub
    '    Else
    '        If MessageBox.Show("hapus data ini...?", "",
    '        MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '            Call Koneksi()
    '            Dim hapus As String = "delete from TBLPelajaran where idkuliah='" & txtidpelajaran.Text & "'"
    '            CMD = New OleDbCommand(hapus, Conn)
    '            CMD.ExecuteNonQuery()
    '            Call Kosongkan()
    '            Call Tampilgrid()
    '        Else
    '            Call Kosongkan()
    '        End If
    '    End If
    'End Sub
    'Private Sub DGV_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
    '    On Error Resume Next
    '    cmbjenjang.Enabled = False
    '    txtidpelajaran.Enabled = False
    '    txtidpelajaran.Text = DGV.Rows(e.RowIndex).Cells(0).Value
    '    txtmatapelajaran.Text = DGV.Rows(e.RowIndex).Cells(1).Value
    '    txtjpl.Text = DGV.Rows(e.RowIndex).Cells(2).Value
    '    cmbjenjang.Text = DGV.Rows(e.RowIndex).Cells(4).Value
    '    cmbkelas.Text = DGV.Rows(e.RowIndex).Cells(3).Value
    'End Sub
    'Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
    '    Call Koneksi()
    '    CMD = New OleDbCommand("select * from TBLPelajaran where MataKuliah like '%" & txtcari.Text & "%'", Conn)
    '    DR = CMD.ExecuteReader
    '    DR.Read()
    '    If DR.HasRows Then
    '        Call Koneksi()
    '        DA = New OleDbDataAdapter("select * from TBLPelajaran where MataKuliah like '%" & txtcari.Text & "%'", Conn)
    '        DS = New DataSet
    '        DA.Fill(DS)
    '        DGV.DataSource = DS.Tables(0)
    '    Else
    '        MsgBox("MataKuliah tidak ditemukan")
    '    End If
    'End Sub
    'Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbjenjang.SelectedIndexChanged
    '    Call CariKodeKuliah()
    '    txtmatapelajaran.Focus()
    'End Sub

    Private Sub DataMataPelajaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmbkelas.Items.Add("VI")
        cmbkelas.Items.Add("VII")
        'cmbkelas.Items.Add("VIIB")
        cmbkelas.Items.Add("VIII")
        cmbkelas.Items.Add("IX")
        cmbkelas.Items.Add("X")
        cmbkelas.Items.Add("XI")
        cmbkelas.Items.Add("XII")
        txtmatapelajaran.Items.Add("Agama Islam")
        txtmatapelajaran.Items.Add("Matematika")
        txtmatapelajaran.Items.Add("Ilmu Pengetahuan Alam")
        txtmatapelajaran.Items.Add("Ilmu Pengetahuan Sosial")
        txtmatapelajaran.Items.Add("Teknologi Informasi dan Komunikasi")
        txtmatapelajaran.Items.Add("Seni Budaya Keterampilan")
        txtmatapelajaran.Items.Add("Pendidikan Lingkungan Budaya Jakarta")
        txtmatapelajaran.Items.Add("Pendidikan Kesehatan Jasmani")
        txtmatapelajaran.Items.Add("Bahasa Indonesia")
        txtmatapelajaran.Items.Add("Bahasa Inggris")
        txtmatapelajaran.Items.Add("Prakarya")
        txtmatapelajaran.Items.Add("Sejarah Indonesia")
        txtmatapelajaran.Items.Add("Ekonomi")
        txtmatapelajaran.Items.Add("Pendidikan Kewarganegaraan")
        txtmatapelajaran.Items.Add("Sosiologi")
        txtmatapelajaran.Items.Add("Geografi")

        cmbjenjang.Enabled = False
        'txtidpelajaran.Enabled = False
        'txtmatapelajaran.Enabled = False




        Call Tampilgrid()
    End Sub
    Sub clearkelas()
        If cmbkelas.Text = "VI" Then
            cmbjenjang.Text = "PAKET A"
        ElseIf cmbkelas.Text = "VII" Or cmbkelas.Text = "VIII" Or cmbkelas.Text = "IX" Then
            cmbjenjang.Text = "PAKET B"
        ElseIf cmbkelas.Text = "X" Or cmbkelas.Text = "XI" Or cmbkelas.Text = "XII" Then
            cmbjenjang.Text = "PAKET C"

        End If
    End Sub

    Private Sub cmbkelas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbkelas.SelectedIndexChanged
        Call clearkelas()



    End Sub

    Sub nemuin_pelajaran()
        Call Koneksi()
        CMD = New OleDbCommand("select * from TBLPelajaran where ID_Pelajaran = '" & txtidpelajaran.Text & "' or Mata_Pelajaran = '" & txtmatapelajaran.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            txtmatapelajaran.Text = DR.Item("Mata_Pelajaran")
            txtidpelajaran.Text = DR.Item("ID_Pelajaran")
            txtjpl.Text = DR.Item("JPL")
            cmbkelas.Text = DR.Item("Kelas")
            cmbjenjang.Text = DR.Item("Jenjang")
            txtidpelajaran.Enabled = False

        Else
            MsgBox("data tidak ditemukan")
        End If
        Conn.Close()
    End Sub

    Private Sub txtidpelajaran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtidpelajaran.KeyPress
        If e.KeyChar = Chr(13) Then
            Call nemuin_pelajaran()
        End If
    End Sub

    'Private Sub txtmatapelajaran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Call nemuin_pelajaran()
    '    End If
    'End Sub
    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If cmbjenjang.Text = "" Or cmbkelas.Text = "" Or txtidpelajaran.Text = "" Or txtmatapelajaran.Text = "" Or txtjpl.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New OleDbCommand("select * from TBLPelajaran where ID_Pelajaran='" & txtidpelajaran.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                Call Koneksi()
                Dim simpan As String = "insert into TBLPelajaran values('" & txtidpelajaran.Text & "','" & txtmatapelajaran.Text & "','" & txtjpl.Text & "','" & cmbkelas.Text & "','" & cmbjenjang.Text & "')"
                CMD = New OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("data berhasil disimpan")
                Call Kosongkan()
                Call Tampilgrid()
            Else
                Call Koneksi()
                Dim edit As String = "update TBLPelajaran set Mata_Pelajaran ='" & txtidpelajaran.Text & "', JPL ='" & txtjpl.Text & "', Kelas ='" & cmbkelas.Text & "', Jenjang = '" & cmbjenjang.Text & "' where ID_Pelajaran ='" & txtidpelajaran.Text & "'"
                CMD = New OleDbCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("data berhasil diedit")
                Call Kosongkan()
                Call Tampilgrid()
            End If
            'Call Kosongkan()
            'Call Tampilgrid()
        End If
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        If txtidpelajaran.Text = "" Then
            MsgBox("ID Pelajaran harus diisi dulu")
            txtidpelajaran.Focus()
            Exit Sub
        Else
            If MessageBox.Show("hapus data ini...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete from TBLPelajaran where ID_Pelajaran ='" & txtidpelajaran.Text & "'"
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

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        Call Kosongkan()

    End Sub

    Private Sub btntutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntutup.Click
        Me.Close()

    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        Call cari_pelajaran()

    End Sub

    Sub cari_pelajaran()
        Call Koneksi()
        DA = New OleDbDataAdapter("select * from TBLPelajaran where ID_Pelajaran like '%" & txtcari.Text & "%' or Mata_Pelajaran like '%" & txtcari.Text & "%' or Kelas like '%" & txtcari.Text & "%' or Jenjang like '%" & txtcari.Text & "%'", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        Conn.Close()

    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick
        

    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        On Error Resume Next
        txtidpelajaran.Enabled = False
        txtidpelajaran.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        txtmatapelajaran.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        txtjpl.Text = DGV.Rows(e.RowIndex).Cells(2).Value
        cmbkelas.Text = DGV.Rows(e.RowIndex).Cells(3).Value
        cmbjenjang.Text = DGV.Rows(e.RowIndex).Cells(4).Value
    End Sub
End Class