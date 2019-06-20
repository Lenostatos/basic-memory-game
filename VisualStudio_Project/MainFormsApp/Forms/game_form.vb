Imports MainFormsApp.game_logic
Imports MainFormsApp.controller.gui.game_form

Public Class game_form

    Private Property _game As game
    Private Property _database As tile_database.i_database

    Private Property _board_painter As board_painter

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _game = New game(My.Forms.game_setup_form.setup_data)
        _database = My.Forms.game_setup_form.UI_controler_database_selection.database

        _board_painter = New board_painter(flow_layout_panel_board, _game.board, _database)
        _board_painter.fill_board()

    End Sub

    Public Sub game_form_Close(sender As Object, e As EventArgs) Handles Me.Closed
        ' TODO find code for quitting the Application
    End Sub

End Class
