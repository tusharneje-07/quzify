Public Class Admin_Login
    Dim db As New DatabaseConnection()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Equals("admin") And TextBox2.Text.Equals("admin") Then
            Form5.Show()
            Me.Hide()
        ElseIf TextBox1.Text IsNot "" And TextBox2.Text IsNot "" Then
            Dim status = db.auth(TextBox1.Text, TextBox2.Text)
            If status Then
                Form2.Username = TextBox1.Text
                Me.Hide()
                Form5.Show()
            Else
                MessageBox.Show("Login Failed")
            End If
        Else
            MessageBox.Show("Please Enter Username and Password")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Admin_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class