Imports System.Data.OleDb

Public Class ImportSoalUjian

    'membuat definisi variabel untuk koneksi yang baru ke data excel
    Dim connexcel As OleDbConnection
    Dim daexcel As OleDbDataAdapter
    Dim dsexcel As DataSet
    Dim cmdexcel As OleDbCommand
    Dim drexcel As OleDbDataReader

    Sub excelkoneksi()
        'string koneksi ke data excel
        connexcel = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & Label1.Text & "';Extended Properties=""Excel 12.0 Xml;HDR=YES"";")
        connexcel.Open()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "(*.xls)|*.xls|(*.xlsx)|*.xlsx|All files (*.*)|*.*"
        OpenFileDialog1.ShowDialog()
        Label1.Text = OpenFileDialog1.FileName
        Call excelkoneksi()

        Dim dtSheets As DataTable = connexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim listSheet As New List(Of String)
        Dim drSheet As DataRow
        'menambahan nama-nama sheet excel agar dianggap sebagai tabel
        For Each drSheet In dtSheets.Rows
            listSheet.Add(drSheet("TABLE_NAME"))
        Next
        'menampilkan nama-nama worksheet dalam file excel
        For Each sheet As String In listSheet
            ListBox1.Items.Add(sheet)
        Next
        ListBox1.Enabled = True

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label1.Text = ""
        ListBox1.Items.Clear()
        DGV.Columns.Clear()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal ByVale As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Call excelkoneksi()
        'menampilkan isi worksheet excel yang dipilih dalam listbox1 ke dalam grid
        daexcel = New OleDbDataAdapter("select * from [" & ListBox1.Text & "]", connexcel)
        dsexcel = New DataSet
        daexcel.Fill(dsexcel)
        DGV.DataSource = dsexcel.Tables(0)
        DGV.ReadOnly = True
        Button5.Enabled = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListBox1.Text = "" Then
            MsgBox("pilih soal ujian dalam listbox")
            Exit Sub
        End If

        For baris As Integer = 0 To DGV.RowCount - 2
            'Call Koneksi()
            Dim simpan1 As String = "insert into TBLSoal values ('" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(1).Value & "','" & DGV.Rows(baris).Cells(2).Value & "','" & DGV.Rows(baris).Cells(3).Value & "','" & DGV.Rows(baris).Cells(4).Value & "','" & DGV.Rows(baris).Cells(5).Value & "','" & DGV.Rows(baris).Cells(6).Value & "','" & DGV.Rows(baris).Cells(7).Value & "')"
            CMD = New OleDbCommand(simpan1, Conn)
            CMD.ExecuteNonQuery()


            'Call Koneksi()
            'CMD = New OleDbCommand("select ID_Pelajaran from TBLSoal where ID_Pelajaran ='" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
            'DR = CMD.ExecuteReader
            'DR.Read()

            'If DR.HasRows Then
            '    'data yang sudah ada dihapus terlebih dahulu

            '    Call Koneksi()
            '    Dim simpan1 As String = "insert into TBLSoal values ('" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(1).Value & "','" & DGV.Rows(baris).Cells(2).Value & "','" & DGV.Rows(baris).Cells(3).Value & "','" & DGV.Rows(baris).Cells(4).Value & "','" & DGV.Rows(baris).Cells(5).Value & "','" & DGV.Rows(baris).Cells(6).Value & "','" & DGV.Rows(baris).Cells(7).Value & "')"
            '    CMD = New OleDbCommand(simpan1, Conn)
            '    CMD.ExecuteNonQuery()
            '    MsgBox("Soal berhasil disimpan")

            'Call Koneksi()
            'Dim hapus As String = "delete * from TBLSoal where ID_Pelajaran ='" & DGV.Rows(baris).Cells(0).Value & "'"
            'CMD = New OleDbCommand(hapus, Conn)
            'CMD.ExecuteNonQuery()
            'Else

            'Call Koneksi()
            'Dim simpan2 As String = "insert into TBLSoal values ('" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(1).Value & "','" & DGV.Rows(baris).Cells(2).Value & "','" & DGV.Rows(baris).Cells(3).Value & "','" & DGV.Rows(baris).Cells(4).Value & "','" & DGV.Rows(baris).Cells(5).Value & "','" & DGV.Rows(baris).Cells(6).Value & "','" & DGV.Rows(baris).Cells(7).Value & "')"
            'CMD = New OleDbCommand(simpan2, Conn)
            'CMD.ExecuteNonQuery()
            'MsgBox("Soal berhasil disimpan")


            'Else
            '    Call Koneksi()
            '    Dim hapus As String = "delete * from TBLSoal where ID_Pelajaran ='" & DGV.Rows(baris).Cells(0).Value & "'"
            '    CMD = New OleDbCommand(hapus, Conn)
            '    CMD.ExecuteNonQuery()
            'End If

        Next
        'For baris2 As Integer = 1 To DGV.RowCount - 2
        '    Call Koneksi()
        '    Dim simpan1 As String = "insert into TBLSoal values ('" & DGV.Rows(baris2).Cells(0).Value & "','" & DGV.Rows(baris2).Cells(1).Value & "','" & DGV.Rows(baris2).Cells(2).Value & "','" & DGV.Rows(baris2).Cells(3).Value & "','" & DGV.Rows(baris2).Cells(4).Value & "','" & DGV.Rows(baris2).Cells(5).Value & "','" & DGV.Rows(baris2).Cells(6).Value & "','" & DGV.Rows(baris2).Cells(7).Value & "')"
        '    CMD = New OleDbCommand(simpan1, Conn)
        '    CMD.ExecuteNonQuery()
        '    MsgBox("Soal berhasil disimpan")
        'Next
        MsgBox("Soal berhasil disimpan")
        DGV.Columns.Clear()
        Label1.Text = ""
        ListBox1.Items.Clear()
        Button5.Enabled = False
        Button2.Enabled = False
        ListBox1.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        For baris As Integer = 0 To DGV.RowCount - 2
            Call Koneksi()
            CMD = New OleDbCommand("select ID_Pelajaran from TBLSoal where ID_Pelajaran ='" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then

                Call Koneksi()
                Dim hapus As String = "delete * from TBLSoal where ID_Pelajaran ='" & DGV.Rows(baris).Cells(0).Value & "'"
                CMD = New OleDbCommand(hapus, Conn)
                CMD.ExecuteNonQuery()
                MessageBox.Show("soal sudah bisa disimpan")
                Conn.Close()

                '    Call Koneksi()
                '    Dim hapus As String = "delete * from TBLSoal where ID_Pelajaran ='" & DGV.Rows(baris).Cells(0).Value & "'"
                '    CMD = New OleDbCommand(hapus, Conn)
                '    CMD.ExecuteNonQuery()
            End If
        Next
        Button2.Enabled = True

    End Sub

    Private Sub ImportSoalUjian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button5.Enabled = False
        Button2.Enabled = False
        ListBox1.Enabled = False
        Button3.Enabled = False

    End Sub
End Class
