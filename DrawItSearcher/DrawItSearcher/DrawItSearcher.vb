Public Class DrawItSearcher
    Const Unknown As Char = ChrW(7)
    ReadOnly SaveLocation As String = IO.Path.Combine(Application.StartupPath, "wordlist.txt")
    Dim Ignore As Boolean
    Dim Words As String
    Private Sub Input_KeyDown(sender As Object, e As KeyEventArgs) Handles Input.KeyDown
        Ignore = False
        Select Case e.KeyCode
            Case Keys.D0
                If Not e.Control Then
                    Input.Text = StrDup(10, Unknown)
                    Input.Select(Input.Text.Length, 0)
                Else
                    Input.Select(9, 1)
                End If
                Ignore = True
            Case Keys.D1 To Keys.D9
                If Not e.Control Then
                    Input.Text = StrDup(Val([Enum].GetName(GetType(Keys), e.KeyCode)(1)), Unknown)
                    Input.Select(Input.Text.Length, 0)
                Else
                    Input.Select(Val([Enum].GetName(GetType(Keys), e.KeyCode)(1)) - 1, 1)
                End If
                Ignore = True
            Case Keys.Back
                Input.Clear()
            Case Keys.Enter
                Input.Text &= Unknown
                Input.Select(Input.Text.Length, 0)
            Case Keys.Left
                If Input.SelectionStart > 0 Then Input.Select(Input.SelectionStart - 1, 1)
                e.Handled = True
            Case Keys.Right
                Input.Select(Input.SelectionStart + 1, 1)
                e.Handled = True
            Case Keys.F2
                Words &= vbCrLf & InputBox("Input new word: ")
        End Select
    End Sub

    Private Sub Input_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Input.KeyPress
        If Ignore Then e.Handled = True
    End Sub

    Private Sub DrawItSearcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim Reader As New IO.StreamReader(SaveLocation)
            Words = Reader.ReadToEnd()
        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText(SaveLocation, "", False)
            Dim Reader As New IO.StreamReader(SaveLocation)
            Words = Reader.ReadToEnd()
        End Try
    End Sub

    Private Sub Input_TextChanged(sender As Object, e As EventArgs) Handles Input.TextChanged
        List.Items.Clear()
        Dim R As New Text.RegularExpressions.Regex(ToRegex(Input.Text), System.Text.RegularExpressions.RegexOptions.Multiline)
        For Each Word As System.Text.RegularExpressions.Match In R.Matches(Input.Text)
            List.Items.Add(Word.Value)
        Next
    End Sub
    Public Function ToRegex(Text As String) As String
        Text = System.Text.RegularExpressions.Regex.Escape(Text)
        Return "^" & Text.Replace(Unknown, "\w") & "$"
    End Function

    Private Sub List_SelectedValueChanged(sender As Object, e As EventArgs) Handles List.SelectedValueChanged
        My.Computer.Clipboard.SetText(List.SelectedItem)
    End Sub

    Private Sub DrawItSearcher_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        My.Computer.FileSystem.WriteAllText(SaveLocation, Words, False)
    End Sub
End Class
