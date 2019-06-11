Public Class choose_database_help_formvb
    Private Sub choose_database_help_formvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Counts the characters of all lines in a string array until_line_index.
        ' Adds one to the count per line for the new line character.
        Dim count_char_of_lines As New Func(Of String(), Integer, Integer)(
            Function(lines As String(), until_line_index As Integer)
                Dim char_count As Integer = 0
                For line_index As Integer = 0 To until_line_index
                    char_count = char_count + lines(line_index).Length + 1
                Next
                Return char_count
            End Function)

        Dim start_index As Integer
        Dim end_index As Integer

        start_index = 0
        end_index = count_char_of_lines(RichTextBox1.Lines, 0)
        RichTextBox1.Select(start_index, end_index - start_index)
        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)

        start_index = count_char_of_lines(RichTextBox1.Lines, 3)
        end_index = count_char_of_lines(RichTextBox1.Lines, 4)
        RichTextBox1.Select(start_index, end_index - start_index)
        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
        RichTextBox1.Select(0, 0)

    End Sub
End Class