Imports System.Text.RegularExpressions

Public Class Form1
    Dim voornaam As String
    Dim achternaam As String
    Dim wachtwoord As String
    Dim teller As Integer = 0
    Dim username As String
    Dim encryptie As Boolean = True
    Dim encryptiewacht
    Dim wachtwoord2
    Dim lengtewachtwoord



    Private Function foutePogingen(ByVal teller As Integer)
        If teller >= 3 Then
            Return MsgBox("Teveel foute pogingen")

        End If
        Return MsgBox("Probeer nog een keer")
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'de knop om in te loggen bestaat, maar je kan er geen succes uithalen
        voornaam = TextBox1.Text
        achternaam = TextBox3.Text
        wachtwoord = TextBox2.Text
        username = (voornaam & " " & achternaam)
        If wachtwoord.Length < 8 Then
            MsgBox("Het wachtwoord moet minstens 8 characters lang zijn")
            TextBox2.Clear()
            teller += 1
            'call is niet nodig om een functie op te roepen
            Call foutePogingen(teller)
            'deze voorwaarden werken niet zoals het zou moeten, je kan niet inloggen ondanks een goed wachtwoord
        ElseIf Not wachtwoord.Any(Function(c) Char.IsDigit(c)) Or (Regex.IsMatch(wachtwoord, "[~`!@#$%^&*()-+=|{}':;.,<>/?]")) Then
            MsgBox("Het wachtwoord voldoet niet aan de eisen")
            TextBox2.Clear()
            teller += 1
            Call foutePogingen(teller)
        Else
            ' teller wordt niet gereset, hierdoor moet je het programma opnieuw opstarten
            MsgBox("Login was succesvol")
            TextBox1.Hide()
            TextBox2.Hide()
            TextBox3.Hide()
            Label3.Hide()
            Button1.Hide()
            Button3.Show()
            Button2.Hide()

            'dit blijft staan zelfs na de reset
            If encryptie Then
                Label4.Text = ("Wachtwoord: " & "**********")
                encryptie = False

            Else
                Label4.Text = ("Wachtwoord: " & wachtwoord)
                encryptie = True
            End If
            Label2.Text = ("Username: " & username)

        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If encryptie Then
            Label4.Text = "**********"
            encryptie = False

        Else
            Label4.Text = wachtwoord
            encryptie = True
        End If
    End Sub
End Class
