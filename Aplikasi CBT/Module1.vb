Imports System.Data.OleDb
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared


Module Module1

    Public Conn As OleDbConnection
    Public DA As OleDbDataAdapter
    Public DS As DataSet
    Public CMD As OleDbCommand
    Public DR As OleDbDataReader

    'Public cryRpt As New ReportDocument
    'Public crtableLogoninfos As New TableLogOnInfos
    'Public crtableLogoninfo As New TableLogOnInfo
    'Public crConnectionInfo As New ConnectionInfo
    'Public CrTables As Tables

    'Public Sub seting_laporan()
    '    With crConnectionInfo
    '        .ServerName = (Application.StartupPath.ToString & "\DTBUjian.mdb")
    '        .DatabaseName = (Application.StartupPath.ToString & "\DTBUjian.mdb")
    '        .UserID = ""
    '        .Password = ""
    '    End With

    '    CrTables = cryRpt.Database.Tables
    '    For Each CrTable In CrTables
    '        crtableLogoninfo = CrTable.LogOnInfo
    '        crtableLogoninfo.ConnectionInfo = crConnectionInfo
    '        CrTable.ApplyLogOnInfo(crtableLogoninfo)
    '    Next
    'End Sub

    Public Sub Koneksi()
        Try
            Conn = New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=DTBUjian.mdb")
            Conn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
    End Sub
End Module

