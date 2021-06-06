Imports System.Data.OleDb

Public Class LoginPeserta
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Call Koneksi()
            CMD = New OleDbCommand("select * from TBLSiswa where Nomor_Peserta='" & TextBox1.Text & "' and Password_Siswa ='" & TextBox2.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                MsgBox("Login gagal")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            Else
                Me.Visible = False
                MenuSiswa.Show()
                MenuSiswa.panel1.Text = DR.Item("Kelas")
                MenuSiswa.panel2.Text = DR.Item("Nomor_Peserta")
                MenuSiswa.panel3.Text = DR.Item("Nama_Siswa")
                'MenuUtama.GroupBox1.Visible = True
                'MenuUtama.GroupBox2.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        MenuPeserta.Show()

    End Sub

    Private Sub LoginPeserta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
        TextBox2.PasswordChar = "*"
    End Sub
End Class