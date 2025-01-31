
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class DatabaseConnection
    Implements IDisposable
    Dim connStr As String = "server=localhost;user=root;database='quizfy';port=3306;password='';"
    Dim conn As MySqlConnection = New MySqlConnection(connStr)
    Public Sub New()
        Try
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Database is Not Connected")
            Form1.Close()
        End Try
    End Sub

    Public Function runQuery(ByVal query As String)
        Dim cmd As New MySqlCommand(query, conn)
        Dim reader = cmd.ExecuteReader()
        Return reader
    End Function

    Public Function runConstantQuery(ByVal query As String)
        Dim cmd2 As New MySqlCommand(query, conn)
        Dim reader = cmd2.ExecuteReader()
        Return reader
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        conn.Close()
    End Sub

    Public Function auth(ByVal username As String, ByVal pass As String)
        Dim reader2 = runQuery($"Select * FROM AUTH WHERE USERNAME = '{username}' AND PASSWORD = '{pass}'")
        If reader2.HasRows Then
            reader2.Close()
            Return True
        Else
            reader2.Close()
            Return False
        End If
    End Function
End Class
