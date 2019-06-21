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
            Dim tile_width As Integer = _gui_board.Size.Width / 4 * 0.91
            Dim new_panel As Panel

            For i As Integer = 1 To _board.Count

                new_panel = New Panel() With {
                        .Name = i,
                        .Size = New System.Drawing.Size(tile_width, tile_width),
                        .Padding = New Padding(0),
                        .TabStop = True
                    }

                _gui_board.Controls.Add(new_panel)

            Next

        End Sub

        Public Sub paint_tiles(click_handler As MainFormsApp.game_form)

            Dim tile As tile
            Dim files_info As List(Of dto.File_Info)
            Dim tile_info As dto.File_Info
            Dim item_info As dto.Item
            Dim new_control As Control
            Dim panel_at_tile As Panel

            For i As Integer = 0 To _board.Count - 1

                tile = _board.positions(i)
                panel_at_tile = _gui_board.Controls(i)
                panel_at_tile.Controls.Clear()

                If tile IsNot Nothing Then
                    If tile.covered Then

                        new_control = New Label() With {
                            .BorderStyle = BorderStyle.FixedSingle,
                            .Dock = DockStyle.Fill
                        }

                    Else

                        item_info = _database.item_with_id(tile.item.id)
                        files_info = _database.files_for_item_id(item_info.id)

                        tile_info = files_info.Where(
                            Function(info As dto.File_Info) info.id = tile.item.design.id)(0)

                        Select Case tile_info.id_File_Type
                            Case file_type.text
                                new_control = New Label() With {
                                    .Text = item_info.name,
                                    .BorderStyle = BorderStyle.FixedSingle,
                                    .Dock = DockStyle.Fill
                                }
                            Case file_type.jpeg, file_type.png
                                new_control = New PictureBox() With {
                                    .ImageLocation =
                                        My.Computer.FileSystem.CombinePath(_database.file_path, tile_info.path)}
                            Case Else
                                Throw New NotImplementedException() ' TODO
                        End Select

                    End If

                    AddHandler new_control.Click, AddressOf click_handler.uncover_tile
                    panel_at_tile.Controls.Add(new_control)

                End If

            Next

        End Sub

    End Class

End Namespace
