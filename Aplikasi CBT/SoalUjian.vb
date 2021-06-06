Imports System.Data.OleDb

Public Class SoalUjian

    Sub TampilPelajaran()
        CMD = New OleDbCommand("select * from TBLPelajaran order by 1", Conn)
        DR = CMD.ExecuteReader
        ComboBox1.Items.Clear()
        Do While DR.Read
            ComboBox1.Items.Add(DR.Item("ID_Pelajaran"))
        Loop
    End Sub

    Sub JumlahSoal()
        For jumlah As Integer = 5 To 50 Step 5
            ComboBox2.Items.Add(jumlah)
        Next
    End Sub

    Private Sub SoalUjian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call TampilPelajaran()
        Call JumlahSoal()
    End Sub

    Sub AturKolomBaru()
        'DGV.Columns.Add("ID_Pelajaran", "ID Pelajaran")
        DGV.Columns.Add("Pertanyaan", "Pertanyaan")
        DGV.Columns(1).Width = 550
        DGV.Columns.Add("A", "Jawaban A") : DGV.Columns(2).Width = 75
        DGV.Columns.Add("B", "Jawaban B") : DGV.Columns(3).Width = 75
        DGV.Columns.Add("C", "Jawaban C") : DGV.Columns(4).Width = 75
        DGV.Columns.Add("D", "Jawaban D") : DGV.Columns(5).Width = 75
        DGV.Columns.Add("Jawaban", "Kunci Jawaban") : DGV.Columns(6).Width = 75
        DGV.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal ByVale As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        DGV.Columns.Clear()
        DGV.DataSource = Nothing
        DGV.Refresh()
        DGV.Columns.Add("Nomor", "Nomor")
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(0).Width = 50
        For baris As Integer = 0 To Val(ComboBox2.Text) - 1
            DGV.RowCount = DGV.RowCount + 1
            DGV.Rows(baris).Cells(0).Value = DGV.RowCount - 1
        Next

        Call AturKolomBaru()

    End Sub

    Sub AturKolomKetemu()
        DGV.Columns(0).Width = 50
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGV.Columns(1).Width = 550
        DGV.Columns(2).Width = 75
        DGV.Columns(3).Width = 75
        DGV.Columns(4).Width = 75
        DGV.Columns(5).Width = 75
        DGV.Columns(6).Width = 75
        DGV.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For baris As Integer = 0 To DGV.RowCount - 2
            DGV.Rows(baris).Cells(0).ReadOnly = True
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal ByVale As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call Koneksi()
        CMD = New OleDbCommand("select Nomor,Pertanyaan,A,B,C,D,Jawaban from tblsoal where ID_Pelajaran='" & ComboBox1.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Call Koneksi()
            DA = New OleDbDataAdapter("select Nomor,Pertanyaan,A,B,C,D,Jawaban from tblsoal where ID_Pelajaran='" & ComboBox1.Text & "' order by 1 ", Conn)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
            Call AturKolomKetemu()
            ComboBox2.Enabled = False
            DGV.Columns(0).ReadOnly = False
        Else
            DGV.Columns.Clear()
            ComboBox2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        DGV.Columns.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    '    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e AsSystem.EventArgs) Handles Label4.Click

    '    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For baris As Integer = 0 To DGV.RowCount - 2
            Call Koneksi()
            'Dim simpan2 As String = "insert into TBLSoal values('" & ComboBox1.Text & "','" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(1).Value & "','" & DGV.Rows(baris).Cells(2).Value & "','" & DGV.Rows(baris).Cells(3).Value & "','" & DGV.Rows(baris).Cells(4).Value & "','" & DGV.Rows(baris).Cells(5).Value & "','" & DGV.Rows(baris).Cells(6).Value & "')"
            'CMD = New OleDbCommand(simpan2, Conn)
            'CMD.ExecuteNonQuery()
            CMD = New OleDbCommand("select ID_Pelajaran from TBLSoal where Nomor ='" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                'data yang sudah ada dihapus terlebih dahulu
                Call Koneksi()
                Dim hapus As String = "delete * from TBLSoal"
                CMD = New OleDbCommand(hapus, Conn)
                CMD.ExecuteNonQuery()
            Else
                Call Koneksi()
                Dim simpan2 As String = "insert into TBLSoal values('" & ComboBox1.Text & "','" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(1).Value & "','" & DGV.Rows(baris).Cells(2).Value & "','" & DGV.Rows(baris).Cells(3).Value & "','" & DGV.Rows(baris).Cells(4).Value & "','" & DGV.Rows(baris).Cells(5).Value & "','" & DGV.Rows(baris).Cells(6).Value & "')"
                CMD = New OleDbCommand(simpan2, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("Soal berhasil disimpan")

                'Call Koneksi()
                'CMD = New OleDbCommand("select ID_Pelajaran from TBLSoal where ID_Pelajaran ='" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
                'DR = CMD.ExecuteReader
                'DR.Read()



                'If Not DR.HasRows Then
                ' ''Call Koneksi()
                ' ''Dim simpan2 As String = "insert into TBLSoal values('" & DGV.Rows(baris).Cells(0).Value & "','" & DGV.Rows(baris).Cells(1).Value & "','" & DGV.Rows(baris).Cells(2).Value & "','" & DGV.Rows(baris).Cells(3).Value & "','" & DGV.Rows(baris).Cells(4).Value & "','" & DGV.Rows(baris).Cells(5).Value & "','" & DGV.Rows(baris).Cells(6).Value & "','" & DGV.Rows(baris).Cells(7).Value & "')"
                ' ''CMD = New OleDbCommand(simpan2, Conn)
                ' ''CMD.ExecuteNonQuery()

            End If

            'CMD = New OleDbCommand("select ID_Pelajaran from TBLSoal where ID_Pelajaran ='" & DGV.Rows(baris).Cells(0).Value & "'", Conn)
            'DR = CMD.ExecuteReader
            'DR.Read()
            'If DR.HasRows Then
            '    'data yang sudah ada dihapus terlebih dahulu
            '    Call Koneksi()
            '    Dim hapus As String = "update TBLSoal set Nomor ='" & DR("Nomor") - DGV.Rows(baris).Cells(1).Value & "',Pertanyaan = '" & DR("Pertanyaan") - DGV.Rows(baris).Cells(2).Value & "',A = '" & DR("A") - DGV.Rows(baris).Cells(3).Value & "',B = '" & DR("B") - DGV.Rows(baris).Cells(4).Value & "',C = '" & DR("C") - DGV.Rows(baris).Cells(5).Value & "',D = '" & DR("D") - DGV.Rows(baris).Cells(6).Value & "',Jawaban = '" & DR("Jawaban") - DGV.Rows(baris).Cells(7).Value & "' where ID_Pelajaran = '" & DGV.Rows(baris).Cells(0).Value & "'"
            '    CMD = New OleDbCommand(hapus, Conn)
            '    CMD.ExecuteNonQuery()
            'End If
            ''CMD.CommandText = "insert into TBLSoal (ID_Pelajaran,Nomor,Pertanyaan,A,B,C,D,Jawaban) values (@ID_Pelajaran,@Nomor,@Pertanyaan,@A,@B,@C,@D,@Jawaban)"
            ''CMD.Parameters.Add("@ID_Pelajaran", OleDbType.Char)
            ''CMD.Parameters.Add("@Nomor", OleDbType.Numeric)
            ''CMD.Parameters.Add("@Pertanyaan", OleDbType.Char)
            ''CMD.Parameters.Add("@A", OleDbType.Char)
            ''CMD.Parameters.Add("@B", OleDbType.Char)
            ''CMD.Parameters.Add("@C", OleDbType.Char)
            ''CMD.Parameters.Add("@D", OleDbType.Char)
            ''CMD.Parameters.Add("@Jawaban", OleDbType.Char)
            ''Conn.Open()
            ''CMD.Connection = Conn

            ''CMD.Parameters(0).Value = DGV.Rows(baris).Cells(0).Value
            ''CMD.Parameters(1).Value = DGV.Rows(baris).Cells(1).Value
            ''CMD.Parameters(2).Value = DGV.Rows(baris).Cells(2).Value
            ''CMD.Parameters(3).Value = DGV.Rows(baris).Cells(3).Value
            ''CMD.Parameters(4).Value = DGV.Rows(baris).Cells(4).Value
            ''CMD.Parameters(5).Value = DGV.Rows(baris).Cells(5).Value
            ''CMD.Parameters(6).Value = DGV.Rows(baris).Cells(6).Value
            ''CMD.Parameters(7).Value = DGV.Rows(baris).Cells(7).Value
            ''CMD.ExecuteNonQuery()

        Next
        'If DGV.Rows(DGV.RowCount - 2).Cells(1).TE = "/" Or "." Or "'" Or "+" Then
        '    MsgBox("tidak boleh memasukan simbol/karakter")
        'End If
    End Sub

    'Private Sub DGV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGV.KeyPress
    '    '    If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    '    Dim keyascii As Short = Asc(e.KeyChar)
    '    If (e.KeyChar Like "[A-Z,a-z]" OrElse keyascii = Keys.Back OrElse Keys.Space OrElse keyascii = Keys.Return OrElse keyascii = Keys.Delete) Then
    '        keyascii = 0
    '    End If
    '    e.Handled = CBool(keyascii)
    

    'End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Call Koneksi()
        'data yang sudah ada dihapus terlebih dahulu
        Call Koneksi()
        Dim hapus As String = "delete * from TBLSoal"
        CMD = New OleDbCommand(hapus, Conn)
        CMD.ExecuteNonQuery()




    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub

    'Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
    '    If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex - 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Then
    '        '=========== cegah error jika jumlah diisi abjad
    '        Try
    '            DGV.Rows(e.RowIndex).Cells(4).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
    '        Catch ex As Exception
    '            MsgBox("harus angka")
    '            SendKeys.Send("{up}")
    '            DGV.Rows(e.RowIndex).Cells(3).Value = 1
    '            DGV.Rows(e.RowIndex).Cells(4).Value = DGV.Rows(e.RowIndex).Cells(2).Value * DGV.Rows(e.RowIndex).Cells(3).Value
    '        End Try
    '    End If

    'End Sub
End Class
