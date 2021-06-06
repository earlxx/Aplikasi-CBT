Imports System.Data.OleDb

Public Class User
    Sub Kosongkan()
        txtkode.Enabled = True
        txtkode.Clear()
        txtnama.Clear()
        txtpassword.Clear()
        cmbstatus.Text = ""
        txtkode.Focus()
    End Sub

    Sub DataBaru()
        txtnama.Clear()
        txtpassword.Clear()
        cmbstatus.Text = ""
        txtnama.Focus()
    End Sub

    Sub Tampilgrid()
        Call Koneksi()
        DA = New OleDbDataAdapter("select * from TBLUser", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Private Sub User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call Tampilgrid()
        Call datacombo()


        Me.CenterToScreen()
    End Sub
    Private Sub txtkode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtkode.KeyPress
        txtkode.MaxLength = 5
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            CMD = New OleDbCommand("select * from TBLUser where Kode_User='" & txtkode.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                txtnama.Text = DR.Item("Nama_User")
                txtpassword.Text = DR.Item("Password_User")
                cmbstatus.Text = DR.Item("Status_User")
                txtnama.Focus()
                txtkode.Enabled = False

            Else
                Call DataBaru()
            End If
        End If
    End Sub
    Private Sub txtnama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnama.KeyPress
        txtnama.MaxLength = 30
        If e.KeyChar = Chr(13) Then
            txtpassword.Focus()
        End If
    End Sub
    Private Sub txtpassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword.KeyPress
        txtpassword.MaxLength = 10
        If e.KeyChar = Chr(13) Then
            cmbstatus.Focus()
        End If
    End Sub
    Private Sub cmbstatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstatus.KeyPress
        cmbstatus.MaxLength = 15
        If e.KeyChar = Chr(13) Then
            btnsimpan.Focus()
           

        End If
    End Sub
    Sub datacombo()
        Call Koneksi()
        CMD = New OleDbCommand("select distinct Status_User from TBLUser order by Status_User", Conn)
        DR = CMD.ExecuteReader
        cmbstatus.Items.Clear()
        Do While DR.Read
            cmbstatus.Items.Add(DR.Item("Status_User"))
        Loop
        Conn.Close()
    End Sub
    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If txtkode.Text = "" Or txtnama.Text = "" Or txtpassword.Text = "" Or cmbstatus.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New OleDbCommand("select * from TBLUser where Kode_User='" & txtkode.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                Call Koneksi()
                Dim simpan As String = "insert into TBLUser values('" & txtkode.Text & "','" & txtnama.Text & "','" & txtpassword.Text & "','" & UCase(cmbstatus.Text) & "')"
                CMD = New OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("data berhasil disimpan")
            Else
                Call Koneksi()
                Dim edit As String = "update TBLUser set Nama_User='" & txtnama.Text & "',Password_User='" & txtpassword.Text & "',Status_User='" & UCase(cmbstatus.Text) & "' where Kode_User='" & txtkode.Text & "'"
                CMD = New OleDbCommand(edit, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("data berhasil diedit")
            End If
            Call Kosongkan()
            Call Tampilgrid()
        End If
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        If txtkode.Text = "" Then
            MsgBox("Kode_User user harus diisi dulu")
            txtkode.Focus()
            Exit Sub
        Else
            If MessageBox.Show("hapus data ini...?", "",
            MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Koneksi()
                Dim hapus As String = "delete from TBLUser where Kode_User ='" & txtkode.Text & "'"
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
        Call Koneksi()
        CMD = New OleDbCommand("select * from TBLUser where Nama_User like '%" & txtcari.Text & "%'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Call Koneksi()
            DA = New OleDbDataAdapter("select * from TBLUser where Nama_User like '%" & txtcari.Text & "%' or Kode_User like '%" & txtcari.Text & "%'", Conn)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
        Else
            MsgBox("user tidak ditemukan")
        End If
    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        On Error Resume Next
        txtkode.Enabled = False
        txtkode.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        txtnama.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        txtpassword.Text = DGV.Rows(e.RowIndex).Cells(2).Value
        cmbstatus.Text = DGV.Rows(e.RowIndex).Cells(3).Value
    End Sub
End Class
