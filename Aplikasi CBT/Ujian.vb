Imports System.Data.OleDb

Public Class Ujian
    Dim jam As Integer
    Dim menit As Integer
    Dim detik As Integer
    Private Sub Ujian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call datacombo()
        Call SOAL1()

        'Label11.Text = Format(Today, "MM/dd/yyyy")
        'If Label6.Text = "VII" Then
        '    Call Koneksi()
        '    CMD = New OleDbCommand("select * from TBLPelajaran where right (ID_Pelajaran,3) = 'VII'", Conn)
        '    DR = CMD.ExecuteReader
        '    ComboBox1.Items.Clear()
        '    Do While DR.Read
        '        ComboBox1.Items.Add(DR.Item("ID_Pelajaran") & Space(5) & DR.Item("Mata_Pelajaran"))
        '    Loop
        'End If
        'If Label2.Text = "VII" Then
        '    Call Koneksi()
        '    CMD = New OleDbCommand("select * from TBL Pelajaran where left (ID_Pelajaran,3) = 'VII'", Conn)
        '    DR = CMD.ExecuteReader
        '    DR.Read()

        'End If
        Label2.Text = MenuSiswa.panel2.Text
        Label4.Text = MenuSiswa.panel3.Text
        Label6.Text = MenuSiswa.panel1.Text
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        Label14.Visible = False
        Label13.Visible = False
        Label17.Visible = False
        Label16.Text = Format(Today, "dd MMMM yyyy")


        'Label17.Text = 0
        'Label18.Text = 0
        'Label19.Text = "-"
        DGV.ReadOnly = True
        DGV.Rows.Clear()

        jam = 1
        menit = 0
        detik = 0
        Label9.Text = Format(jam, "00") & ":" & Format(menit, "00") & ":" & Format(detik, "00")
        Timer1.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        RadioButton4.Enabled = False
        ListBox1.Enabled = False
        BTNJawab.Enabled = False
        BTNBatal.Enabled = False
        BTNSelesai.Enabled = False
        BTNTutup.Enabled = True
        BTNMulai.Enabled = False

        TextBox1.Enabled = False
        'TextBox1.ReadOnly = True

        With DGV
            .Columns(2).Visible = False
            .Columns(3).Visible = False

        End With

    End Sub
    Sub datacombo()
            Call Koneksi()
            CMD = New OleDbCommand("select distinct ID_Pelajaran from TBLPelajaran ORDER BY ID_Pelajaran", Conn)
            DR = CMD.ExecuteReader
            ComboBox1.Items.Clear()
            Do While DR.Read
            ComboBox1.Items.Add(DR.Item("ID_Pelajaran"))
            Loop

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal ByVale As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        BTNMulai.Enabled = True
        'cari data NIM yang pernah melakukan ujian di mata kuliah yang dipilih di combobox1
        'CMD = New OleDbCommand("select * from TBLMaster_Jawaban where No_Peserta='" & Label2.Text & "' and ID_Pelajaran='" & Microsoft.VisualBasic.Left(ComboBox1.Text, 3) & "'", Conn)
        'DR = CMD.ExecuteReader
        'DR.Read()
        'If DR.HasRows Then
        '    'jika sudah ada maka tampilkan pesan
        '    MsgBox("Anda sudah mengikuti test mata kuliah ini " & Chr(13) & _
        '            "Tanggal    :" & Format(DR.Item("tanggal"), "dd-MMM-yyyy") & " " & Chr(13) & _
        '            "Mulai      :" & Format(DR.Item("Mulai"), "hh:mm:ss") & " " & vbCrLf & _
        '            "Selesai    :" & Format(DR.Item("selesai"), "hh:mm:ss") & " " & vbCrLf & _
        '            "Jml Soal   :" & DR.Item("jmlsoal") & " " & vbCrLf & _
        '            "Dijawab    :" & DR.Item("dijawab") & " " & vbCrLf & _
        '            "Jml Benar  :" & DR.Item("benar") & " " & vbCrLf & _
        '            "Jml Salah  :" & DR.Item("salah") & " " & vbCrLf & _
        '            "Keterangan :" & DR.Item("keterangan") & " ")
        '    Exit Sub
        'End If

        'jika belum ada maka tampilkan nomor soal ujiannya
        CMD = New OleDbCommand("select Nomor from TBLSoal where ID_Pelajaran ='" & ComboBox1.Text & "'", Conn)
        DR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        Do While DR.Read
            ListBox1.Items.Add(DR.Item("Nomor"))
        Loop
        ListBox1.Focus()
        Label17.Text = ListBox1.Items.Count
    End Sub
   

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal ByVale As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
        RadioButton4.Enabled = True
        Call BersihkanJawaban()
        'tampilkan pertanyaan soal ujian dalam textbox1 sesuai dengan nomor soal yang dipilih
        CMD = New OleDbCommand("select * from TBLSoal where ID_Pelajaran ='" & ComboBox1.Text & "' and VAL(Nomor)='" & Val(ListBox1.Text) & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            'ListBox2.Text = DR.Item("Pertanyaan")
            TextBox1.Items.Clear()
            TextBox1.Text = DR.Item("Pertanyaan")
            TextBox1.Items.Add(DR.Item("Pertanyaan"))
            RadioButton1.Text = DR.Item("A")
            RadioButton2.Text = DR.Item("B")
            RadioButton3.Text = DR.Item("C")
            RadioButton4.Text = DR.Item("D")
        End If


    End Sub

    Sub BersihkanJawaban()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        'jika jawaban A dipilih maka lakukan proses penyesuaian jawaban apakah benar atau salah
        RadioButton1.Checked = True
        CMD = New OleDbCommand("select * from TBLSoal where ID_Pelajaran ='" & ComboBox1.Text & "' and VAL(Nomor)='" & ListBox1.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Label11.Text = "A"
            Label10.Text = DR.Item("Jawaban")
            If Label11.Text = Label10.Text Then Label12.Text = "BENAR" Else Label12.Text = "SALAH"
        End If
        'DGV.Rows.Add(1)
        'DGV.Rows(DGV.RowCount - 2).Cells(0).Value = ListBox1.Text
        'DGV.Rows(DGV.RowCount - 2).Cells(1).Value = Label11.Text
        'DGV.Rows(DGV.RowCount - 2).Cells(2).Value = Label10.Text
        'DGV.Rows(DGV.RowCount - 2).Cells(3).Value = Label12.Text '(ListBox1.Text, Label11.Text, Label10.Text, Label12.Text)
        'DGV.Update()
        'If DGV.CurrentRow.Index <> DGV.NewRowIndex Then
        '    DGV.Rows.RemoveAt(DGV.CurrentRow.Index)

        'For BARIS As Integer = 0 To DGV.RowCount - 1
        '    If ListBox1.Text = DGV.Rows(BARIS).Cells(0).Value Then
        '        MsgBox("Nomor ini sudah dijawab")
        '        Exit Sub
        '    End If
        'Next
        
    End Sub

    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        'jika jawaban B dipilih maka lakukan proses penyesuaian jawaban apakah benar atau salah
        CMD = New OleDbCommand("select * from TBLSoal where ID_Pelajaran='" & ComboBox1.Text & "' and VAL(nomor)='" & ListBox1.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Label11.Text = "B"
            Label10.Text = DR.Item("Jawaban")
            If Label11.Text = Label10.Text Then Label12.Text = "BENAR" Else Label12.Text = "SALAH"
        End If
        'DGV.Rows.Remove(DGV.CurrentRow)

        '======== cegah kode yang sama

    End Sub

    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        'jika jawaban C dipilih maka lakukan proses penyesuaian jawaban apakah benar atau salah
        CMD = New OleDbCommand("select * from TBLSoal where ID_Pelajaran ='" & ComboBox1.Text & "' and VAL(nomor)='" & ListBox1.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Label11.Text = "C"
            Label10.Text = DR.Item("Jawaban")
            If Label11.Text = Label10.Text Then Label12.Text = "BENAR" Else Label12.Text = "SALAH"
        End If
    End Sub

    Private Sub RadioButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.Click
        'jika jawaban D dipilih maka lakukan proses penyesuaian jawaban apakah benar atau salah
        CMD = New OleDbCommand("select * from TBLSoal where ID_Pelajaran ='" & ComboBox1.Text & "' and VAL(nomor)='" & ListBox1.Text & "'", Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Label11.Text = "D"
            Label10.Text = DR.Item("Jawaban")
            If Label11.Text = Label10.Text Then Label12.Text = "BENAR" Else Label12.Text = "SALAH"
        End If
    End Sub


    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e AsSystem.EventArgs) Handles Timer1.Tick
    '    Label12.Text = TimeOfDay
    '    Timer1.Enabled = False
    'End Sub

    'Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e AsSystem.EventArgs) Handles Timer2.Tick
    '    Label13.Text = TimeOfDay
    'End Sub

    ''membuat fungsi untuk menghitung jumlah jawaban yang benar
    Sub JumlahBenar()
        Dim hitung As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 2
            If DGV.Rows(baris).Cells(3).Value = "BENAR" Then
                hitung = hitung + 1
                Label13.Text = hitung
            End If
        Next
        'jmlbenar.Text = Label13.Text
    End Sub

    ''membuat fungsi untuk menghitung jumlah jawaban yang benar
    Sub JumlahSalah()
        Dim hitung As Integer = 0
        For baris As Integer = 0 To DGV.RowCount - 2
            If DGV.Rows(baris).Cells(3).Value = "SALAH" Then
                hitung = hitung + 1
                Label14.Text = hitung
            End If
        Next
        'jmlsalah.Text = Label14.Text
    End Sub


    'Private Sub BTNTutup_Click(ByVal sender As System.Object, ByVal e AsSystem.EventArgs) Handles BTNTutup.Click
    '    ComboBox1.Text = ""
    '    ListBox1.Items.Clear()
    '    TextBox1.Clear()
    '    DGV.Rows.Clear()
    '    Me.Close()
    'End Sub

    'Private Sub BTNPetunjuk_Click(ByVal sender As System.Object, ByVal e AsSystem.EventArgs) Handles BTNPetunjuk.Click
    '    MsgBox("1. Pilih Materi di combo paling atas" & Chr(13) & _
    '    "2. Pilih Nomor Soal dalam list di sebelah kiri" & Chr(13) & _
    '    "3. Pilih Jawaban pada option button" & vbCrLf & _
    '    "4. Klik Jawab" & vbCrLf & _
    '    "5. Lanjutkan ke soal nomor Berikutnya")
    'End Sub

    'Private Sub BTNBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '    ComboBox1.Text = ""
    '    '    ListBox1.Items.Clear()
    '    '    TextBox1.Clear()
    '    '    DGV.Rows.Clear()
    '    '    Call BersihkanJawaban()



    'End Sub

    Private Sub BTNJawab_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNJawab.Click
        'jika mata kuliah belum dipilih
        If ComboBox1.Text = "" Then
            MsgBox("Anda belum memilih mata pelajaran")
            Exit Sub
        End If
        'jika belum memeilih nomor soal
        If ListBox1.Text = "" Or TextBox1.Text = "" Then
            MsgBox("Anda belum memilih nomor soal")
            Exit Sub
        End If

        'jika belum memilih jawaban
        If RadioButton1.Checked = False And RadioButton2.Checked = False And RadioButton3.Checked = False And RadioButton4.Checked = False Then
            MsgBox("Anda belum memilih jawaban")
            Exit Sub
        End If
        'jika nomor soal tersebut sudah dijawab
        For BARIS As Integer = 0 To DGV.RowCount - 1
            If ListBox1.Text = DGV.Rows(BARIS).Cells(0).Value Then
                MsgBox("Nomor ini sudah dijawab")


                Exit Sub
            End If
        Next
        'jawaban akan tampil di dalam grid sebelah kanan
        DGV.Rows.Add(ListBox1.Text, Label11.Text, Label10.Text, Label12.Text)
        ListBox1.Focus()
        ListBox1.SelectedItem = ListBox1.SelectedItem + 1

        'For BARIS As Integer = 0 To DGV.RowCount - 1
        '    If ListBox1.Text = DGV.Rows(BARIS).Cells(0).Value Then
        '        MsgBox("Nomor ini sudah dijawab")

        '    End If

        'Next


        'DGV.Rows.Add(1)
        'DGV.Rows(DGV.RowCount - 2).Cells(0).Value = ListBox1.Text
        'DGV.Rows(DGV.RowCount - 2).Cells(1).Value = Label11.Text
        'DGV.Rows(DGV.RowCount - 2).Cells(2).Value = Label10.Text
        'DGV.Rows(DGV.RowCount - 2).Cells(3).Value = Label12.Text '(ListBox1.Text, Label11.Text, Label10.Text, Label12.Text)
        'DGV.Update()

            'DGV.Rows.Add(ListBox1.Text, Label11.Text, Label10.Text, Label12.Text)
            'ListBox1.Focus()
            'ListBox1.SelectedItem = ListBox1.SelectedItem + 1

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        detik -= 1
        If detik < 0 Then
            detik = 59
            menit -= 1
            If menit < 0 Then
                menit = 59
                jam -= 1
            End If



        End If
        Label9.Text = Format(jam, "00") & ":" & Format(menit, "00") & ":" & Format(detik, "00")

        If jam = 0 And menit = 0 And detik = 0 Then
            Timer1.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            RadioButton3.Enabled = False
            RadioButton4.Enabled = False
            ListBox1.Enabled = False
            BTNJawab.Enabled = False
            BTNBatal.Enabled = False
            BTNMulai.Enabled = False
            TextBox1.Enabled = False
            ComboBox1.Enabled = False

            MsgBox("Waktu Habis !!!!!")
        End If

    End Sub



    Private Sub BTNSelesai_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSelesai.Click
        If MessageBox.Show("yakin ingin selesai?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            
            Try
                '        'ketika BTNselesai di klik maka....
                '        'Timer2.Enabled = False
                '        'Dim awal As Date = TimeValue(Label12.Text)
                '        'Dim hasil As TimeSpan = Now - awal
                '        'hitung durasi pengerjaan soal ujian
                '        'Label14.Text = (String.Format("{0}:{1}:{2}", hasil.Hours, hasil.Minutes, hasil.Seconds))
                '        'hitung banyaknya nomor soal ujian
                '        'Label15.Text = ListBox1.Items.Count
                '        'Label16.Text = DGV.RowCount - 1

                Call JumlahBenar()
                Call JumlahSalah()
                '        'jika jumlah benar > jumlah salah maka "LULUS"
                '        If Val(Label17.Text) > Val(Label18.Text) Then
                '            Label19.Text = "LULUS"
                '        Else
                '            Label19.Text = "GAGAL"
                '        End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Timer1.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            RadioButton3.Enabled = False
            RadioButton4.Enabled = False
            ListBox1.Enabled = False
            BTNJawab.Enabled = False
            BTNBatal.Enabled = False
            BTNSelesai.Enabled = False
            BTNMulai.Enabled = False
            TextBox1.Enabled = False
            BTNTutup.Enabled = True
         
        Else
            Exit Sub

        End If
        If Label2.Text = "" Or Label4.Text = "" Or ComboBox1.Text = "" Or Label16.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New OleDbCommand("select * from TBLMaster_Jawaban where Nomor_Peserta ='" & Label2.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                Call Koneksi()
                'Dim simpan As String = "insert into TBLDetail_Jawaban values('" & ComboBox1.Text & "','" & Label2.Text & "','" & NilaiUjian.Label1.Text & "')"
                'CMD = New OleDbCommand(simpan, Conn)
                'CMD.ExecuteNonQuery()
                'MsgBox("data berhasil disimpan")

                Dim simpan As String = "insert into TBLMaster_Jawaban values('" & Label2.Text & "','" & Label4.Text & "','" & Label16.Text & "','" & ComboBox1.Text & "','" & Label17.Text & "','" & Label13.Text & "','" & Val(10 * Label13.Text) & "')"
                CMD = New OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()

            Else
                'Call Koneksi()
                'Dim edit As String = "insert into TBLDetail_Jawaban values('" & ComboBox1.Text & "','" & Label2.Text & "','" & NilaiUjian.Label1.Text & "')"
                'CMD = New OleDbCommand(edit, Conn)
                'CMD.ExecuteNonQuery()

                Call Koneksi()
                Dim edit As String = "insert into TBLMaster_Jawaban values('" & Label2.Text & "','" & Label4.Text & "','" & Label16.Text & "','" & ComboBox1.Text & "','" & Label17.Text & "','" & Label13.Text & "','" & Val(10 * Label13.Text) & "')"
                CMD = New OleDbCommand(edit, Conn)
                CMD.ExecuteNonQuery()
            End If
        End If
        'Sisa_Waktu = '" & Label9.Text & "',
        ','" & Format(DateValue(Label16.Text), "dd MMMM yyyy") & "'
        'jmlsoal.Text = Val(10 * Label13.Text)
        Me.Hide()
        NilaiUjian.Show()
        NilaiUjian.Label1.Text = Val(10 * Label13.Text)
    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub

    Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit

    End Sub

    Private Sub BTNBatal_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBatal.Click
        If DGV.CurrentRow.Index <> DGV.NewRowIndex Then
            DGV.Rows.RemoveAt(DGV.CurrentRow.Index)
        End If
    End Sub

    Private Sub BTNMulai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMulai.Click
        Timer1.Enabled = True
        
        ListBox1.Enabled = True
        BTNJawab.Enabled = True
        BTNBatal.Enabled = True
        BTNSelesai.Enabled = True
        TextBox1.Enabled = True
        BTNMulai.Enabled = False
        BTNTutup.Enabled = False
    End Sub

    Private Sub BTNTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNTutup.Click
        ComboBox1.Text = ""
        ListBox1.Items.Clear()

        Me.Hide()
        MenuSiswa.Show()
        Call Koneksi()
    End Sub
End Class

