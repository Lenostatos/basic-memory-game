Imports MainFormsApp.game_logic
Imports MainFormsApp.tile_database

Namespace controller.gui.game_form

    Public Class board_painter

        Private Property _gui_board As FlowLayoutPanel
        Private Property _board As game_board
        Private Property _database As i_database

        Public Sub New(ByRef gui_board As FlowLayoutPanel, ByRef board As game_board, ByRef database As i_database)

            If gui_board Is Nothing Then Throw New ArgumentNullException()
            If board Is Nothing Then Throw New ArgumentNullException()
            If database Is Nothing Then Throw New ArgumentNullException()

            _gui_board = gui_board
            _board = board
            _database = database

        End Sub

        ''' <summary>
        ''' Fills the board with panels that items can be drawn on.
        ''' </summary>
        Public Sub fill_board()

            _gui_board.Controls.Clear()
            Dim tile_width As Integer = _gui_board.Size.Width / 4 * 0.95

            For i As Integer = 1 To _board.Count
                _gui_board.Controls.Add(
                    New Panel() With {
                        .Name = i,
                        .Size = New System.Drawing.Size(tile_width, tile_width),
                        .BackColor = Color.AliceBlue,
                        .Padding = New Padding(0)
                    })
            Next

        End Sub

        Public Sub pain_tiles()

            Dim item_at_tile As tile
            Dim files_info As List(Of dto.File_Info)
            Dim tile_info As dto.File_Info

            _gui_board.Controls.Clear()

            For i As Integer = 0 To _board.Count

                item_at_tile = _board.positions(i)

                If item_at_tile IsNot Nothing Then

                    If item_at_tile.covered Then

                    Else

                        files_info = _database.files_for_item_id(item_at_tile.id)
                        tile_info = files_info.Where(
                            Function(info As dto.File_Info) info.id = item_at_tile.item.id)

                        _gui_board.Controls.Add()

                    End If

                Else
                    _gui_board.Controls.Add(
                        New Label() With {
                            .BorderStyle = BorderStyle.FixedSingle
                        })
                End If

            Next

        End Sub

    End Class

End Namespace
