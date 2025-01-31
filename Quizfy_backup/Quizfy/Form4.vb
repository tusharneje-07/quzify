Imports MySql.Data.MySqlClient

Public Class Form4
    Public Property username As String = ""
    Public Property testCode As String = ""
    Public Property totalQues As Integer
    Dim db As New DatabaseConnection()
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        Form1.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rdUpdate As MySqlDataReader = db.runQuery($"SELECT * FROM {testCode} WHERE USERNAME = '{username}'")
        Dim sum As Integer = 0
        While rdUpdate.Read
            sum = 0
            For i As Integer = 1 To totalQues Step 1
                sum += rdUpdate.GetInt64(i)
            Next
        End While
        rdUpdate.Close()
        Dim rdUpdate2 As MySqlDataReader = db.runQuery($"UPDATE {testCode} SET TOTAL = '{sum}' WHERE USERNAME = '{username}'")
        rdUpdate2.Close()
        Label3.Text = $"{sum}/{totalQues}"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Close()
    End Sub
End Class