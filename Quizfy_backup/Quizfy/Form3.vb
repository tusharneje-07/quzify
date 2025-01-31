Imports MySql.Data.MySqlClient

Public Class Form3
    Dim totalSec As Integer
    Dim WINDOW_WARNING As Integer = 1
    Dim QNO As Integer = 1
    Dim db As New DatabaseConnection()
    Dim CORRECET_ANS As String = ""
    Dim que_table As String = ""
    Dim ans_table As String = ""
    Dim totalQuestions As Integer = 5
    Dim totalMarks As Integer = 0
    Dim totalTime As Integer = 0
    Public Property testCode As String
    Public Property username As String
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        totalTime = 1
        totalSec = totalTime * 60

        que_table = $"{testCode}_que"
        ans_table = $"{testCode}_ans"

        Form4.username = username
        Form4.testCode = ans_table
        Form4.totalQues = totalQuestions

        updateStaticData(ans_table)

        setQuestion(que_table, ans_table, QNO)
        'Me.FormBorderStyle = FormBorderStyle.None
        'Me.WindowState = FormWindowState.Maximized
        'Dim primaryScreen As Screen = Screen.PrimaryScreen
        'Me.Bounds = primaryScreen.Bounds
    End Sub

    Private Sub updateStaticData(ans_table As String)
        Dim staticReader As MySqlDataReader = db.runQuery($"SELECT Q,A1,A2 FROM {que_table} WHERE QNO = '0'")
        While staticReader.Read()
            totalQuestions = staticReader.GetInt64(0)
            totalMarks = staticReader.GetInt64(1)
            totalTime = staticReader.GetInt64(2)
        End While
        staticReader.Close()
    End Sub

    Private Sub setQuestion(v1 As String, v2 As String, Qno As Integer)
        Dim rd1 As MySqlDataReader = db.runQuery($"SELECT * FROM {v1} WHERE QNO = '{Qno}'")
        While rd1.Read()
            Label4.Text = rd1.GetValue(0).ToString() + " " + rd1.GetValue(1).ToString()
            RadioButton1.Text = rd1.GetValue(2).ToString()
            RadioButton2.Text = rd1.GetValue(3).ToString()
            RadioButton3.Text = rd1.GetValue(4).ToString()
            RadioButton4.Text = rd1.GetValue(5).ToString()
            CORRECET_ANS = rd1.GetValue(6).ToString()
        End While
        rd1.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        totalSec -= 1
        Dim mint As Integer = totalSec / 60
        Dim sec As Integer = totalSec Mod 60
        Label2.Text = $"{mint} : {sec} Remaining"
        If totalSec = 0 Then
            saveAnswer(100)
            Timer1.Stop()
            MessageBox.Show("Test is Auto Submitted! Time Runs Up!")
        End If
    End Sub


    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If WINDOW_WARNING = 4 Then
            WINDOW_WARNING = 100
            MessageBox.Show("Test is Auto Submitted Due to Misbehaviur During Test.")
            saveAnswer(100)
        Else
            Label3.Text = $"{WINDOW_WARNING} Waraning! st/nd/rd DO NOT CHANGE WINDOW."
            Label3.ForeColor = Color.Red
            WINDOW_WARNING += 1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        saveAnswer(0)
    End Sub

    Private Sub saveAnswer(ByVal flag As Integer)
        Dim selectedOption As String = ""
        If RadioButton1.Checked Then
            selectedOption = "A"
        ElseIf RadioButton2.Checked Then
            selectedOption = "B"
        ElseIf RadioButton3.Checked Then
            selectedOption = "C"
        ElseIf RadioButton4.Checked Then
            selectedOption = "D"
        End If
        Dim checkAnswer As Integer = 0
        If selectedOption = CORRECET_ANS Then
            checkAnswer = 1
        End If
        Dim rd2 As MySqlDataReader = db.runQuery($"UPDATE `{ans_table}` SET `Q{QNO}`='{checkAnswer}' WHERE USERNAME = '{username}'")
        rd2.Close()

        Dim rdUpdate As MySqlDataReader = db.runQuery($"SELECT * FROM {ans_table} WHERE USERNAME = '{username}'")
        Dim sum As Integer = 0
        While rdUpdate.Read
            sum = 0
            For i As Integer = 1 To totalQuestions Step 1
                sum += rdUpdate.GetInt64(i)
            Next
        End While
        rdUpdate.Close()

        Dim rdUpdate2 As MySqlDataReader = db.runQuery($"UPDATE {ans_table} SET TOTAL = '{sum}' WHERE USERNAME = '{username}'")
        rdUpdate2.Close()

        If flag = 1 Then
            If QNO = totalQuestions Then
                Button4.Enabled = True
            Else
                QNO += 1
                setQuestion(que_table, ans_table, QNO)
            End If
        ElseIf flag = -1 Then
            If QNO = 1 Then
            Else
                QNO -= 1
                setQuestion(que_table, ans_table, QNO)
            End If
        ElseIf flag = 100 Then
            Me.Hide()
            Form4.Show()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        saveAnswer(1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        saveAnswer(-1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        saveAnswer(100)
    End Sub
End Class