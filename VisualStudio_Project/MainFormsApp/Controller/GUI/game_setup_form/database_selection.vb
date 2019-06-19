Namespace controller.GUI.game_setup_form

    Public Class database_selection

        Public Const MESSAGE_INVALID_FILE_PATH_WITH_EXCEPTION As String =
            "There was an error while accessing the database at the path you gave:"

        Private Property _UI_database_selection_control As controller.UI.game_setup.database_selection

        Public Sub New(UI_database_selection_control As controller.UI.game_setup.database_selection)
            _UI_database_selection_control = UI_database_selection_control
        End Sub

        ''' <summary>
        ''' Trys to change the file for the tile database. Shows a message
        ''' box with an error message if it didn't work.
        ''' </summary>
        ''' <param name="new_file_path"></param>
        Public Sub change_database_file(new_file_path As String, file_path_label As Label)

            If file_path_label Is Nothing Then Throw New ArgumentNullException()

            Try
                _UI_database_selection_control.choose_file_path(new_file_path)
            Catch ex As Exception
                MsgBox(MESSAGE_INVALID_FILE_PATH_WITH_EXCEPTION & vbNewLine & ex.Message)
                Exit Sub
            End Try

            file_path_label.Text = _UI_database_selection_control.database.file_path

        End Sub

        Public Sub choose_database_file(file_path_label As Label)

            Dim file_choosing_dialog As New Windows.Forms.OpenFileDialog() With {
                .CheckFileExists = True,
                .Title = "please choose the database file of your tile set",
                .Multiselect = False,
                .Filter = "SQLite Database files(*.sqlite3)|*.sqlite3"
            }

            If My.Computer.FileSystem.FileExists(file_path_label.Text) Then
                file_choosing_dialog.InitialDirectory = My.Computer.FileSystem.GetParentPath(file_path_label.Text)
            End If

            Dim file_choosing_dialog_result As DialogResult = file_choosing_dialog.ShowDialog()

            If file_choosing_dialog_result = DialogResult.OK Then
                change_database_file(file_choosing_dialog.FileName, file_path_label)
            End If

        End Sub

    End Class

End Namespace
