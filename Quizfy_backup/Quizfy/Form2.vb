Imports MySql.Data.MySqlClient

Public Class Form2
    Dim db As New DatabaseConnection()
    Public Property Username As String
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        Form1.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim reader As MySqlDataReader = db.runQuery("SELECT table_name FROM information_schema.tables  WHERE table_schema = 'quizfy'  AND table_name LIKE '%_ans%'")
        While reader.Read()
            ComboBox1.Items.Add(reader.GetValue(0).ToString().Replace("_ans", ""))
        End While
        reader.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
        ElseIf CheckBox1.Checked Then
            Form3.testCode = ComboBox1.Text
            Form3.username = Username
            Me.Hide()
            Form3.Show()
        End If
    End Sub
End Class