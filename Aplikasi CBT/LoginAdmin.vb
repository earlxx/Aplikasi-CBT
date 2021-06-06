Imports System.Data.OleDb

Public Class Login


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
            CMD = New OleDbCommand("select * from TBLUser where Nama_User ='" & TextBox1.Text & "' and Password_User ='" & TextBox2.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                MsgBox("Login gagal")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            Else
                Me.Visible = False
                MenuUtama.Show()
                MenuUtama.Panel1.Text = DR.Item("Kode_User")
                MenuUtama.Panel2.Text = DR.Item("Nama_User")
                MenuUtama.Panel3.Text = DR.Item("Status_User")
                'MenuUtama.GroupBox1.Visible = True
                'MenuUtama.GroupBox2.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        MenuPeserta.Show()

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
        TextBox2.PasswordChar = "*"
    End Sub
End Class
