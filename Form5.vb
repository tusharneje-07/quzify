Imports MySql.Data.MySqlClient
Public Class Form5
    Dim db As New DatabaseConnection()
    Dim QuizIDGlob As String = ""
    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.GotFocus
        Form1.Close()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim quizID As String = TextBox2.Text.ToString()
        If quizID IsNot "" Then
            Try
                Dim queTab As MySqlDataReader = db.runQuery($"CREATE TABLE {quizID}_que (QNO int(11), Q varchar(1024), A1 varchar(256), A2 varchar(256), A3 varchar(256), A4 varchar(256), CR_ANS varchar(256))")
                queTab.Close()
                Dim totalQuestions As Integer = Integer.Parse(TextBox9.Text)
                Dim totalMarks As Integer = Integer.Parse(TextBox1.Text)
                Dim totalMin As Integer = Integer.Parse(TextBox8.Text)
                Dim UpdateData As MySqlDataReader = db.runQuery($"INSERT INTO `{quizID}_que`(`QNO`, `Q`, `A1`, `A2`, `A3`, `A4`, `CR_ANS`) VALUES ('0','{totalQuestions}','{totalMarks}','{totalMin}','0','0','0')")
                UpdateData.Close()
                Dim ansTab As MySqlDataReader = db.runQuery($"CREATE TABLE {quizID}_ans (USERNAME varchar(256), TOTAL int(11))")
                ansTab.Close()
                MessageBox.Show("Quiz Created!")
            Catch ex As Exception
                MessageBox.Show("Quiz ID is Already Exist, Please Choose Another Name/ID!")
            End Try
        Else
            MessageBox.Show("Please Enter Quiz ID/Name")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim quizID As String = TextBox2.Text.ToString()
        Try
            Dim check As MySqlDataReader = db.runQuery($"SELECT * FROM {quizID}_que")
            check.Close()
            QuizIDGlob = quizID
            Label17.Text = Label17.Text.ToString() + QuizIDGlob
        Catch ex As Exception
            MessageBox.Show($"Quiz with name {quizID} is Not Created Yet! ")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim quizID As String = TextBox2.Text.ToString()
        Try
            Dim delDatabase As MySqlDataReader = db.runQuery($"DROP TABLE {quizID}_que")
            delDatabase.Close()

            Dim delDatabase2 As MySqlDataReader = db.runQuery($"DROP TABLE {quizID}_ans")
            delDatabase2.Close()

            MessageBox.Show("Quiz Removed!")
        Catch ex As Exception
            MessageBox.Show($"Quiz with name {quizID} is Not Created Yet! ")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim Question As String = TextBox3.Text.ToString()
            Dim A1 As String = TextBox4.Text.ToString()
            Dim A2 As String = TextBox5.Text.ToString()
            Dim A3 As String = TextBox6.Text.ToString()
            Dim A4 As String = TextBox7.Text.ToString()
            Dim CRR_ANS As String = ComboBox1.Text.ToString()

            If Question.Equals("") And A1.Equals("") And A2.Equals("") And A3.Equals("") And A4.Equals("") And CRR_ANS.Equals("") Then
                MessageBox.Show("Please Enter Proper Data!")
            Else
                Dim reader As MySqlDataReader = db.runQuery($"SELECT * FROM {QuizIDGlob}_que")

                Dim QNO As Integer = 0
                While reader.Read()
                    QNO += 1
                End While

                reader.Close()

                Dim queDataUpdate As MySqlDataReader = db.runQuery($"INSERT INTO `{QuizIDGlob}_que`(`QNO`, `Q`, `A1`, `A2`, `A3`, `A4`, `CR_ANS`) VALUES ('{QNO}','{Question}','{A1}','{A2}','{A3}','{A4}','{CRR_ANS}')")
                queDataUpdate.Close()


                Dim ALTERQuery As MySqlDataReader = db.runQuery($"ALTER TABLE `{QuizIDGlob}_ans` ADD `Q{QNO}` int(11) NOT NULL AFTER TOTAL")
                ALTERQuery.Close()
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                ComboBox1.Text = ""

            End If

        Catch ex As Exception
            MessageBox.Show("Error While Inserting Question!")
        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            Me.Close()
            home.Show()
        End If
    End Sub

    Private Sub TabPage3_Click_1(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub
End Class