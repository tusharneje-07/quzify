Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class Form6
    Dim db As New DatabaseConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text.ToString()
        Dim password As String = TextBox2.Text.ToString()
        Dim password2 As String = TextBox3.Text.ToString()
        If Not (username.Equals("") And password.Equals("") And password2.Equals("")) Then
            If password.Equals(password2) Then
                Dim crtUser As MySqlDataReader = db.runQuery($"INSERT INTO AUTH VALUES('{username}','{password}')")
                crtUser.Close()
                MessageBox.Show("User Created!")
            Else
                MessageBox.Show("Check Password, Reconfirm It!")
            End If
        Else
            MessageBox.Show("Enter Propper Data!")
        End If
    End Sub
    Private Sub Form6_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        Form1.Show()
    End Sub
End Class