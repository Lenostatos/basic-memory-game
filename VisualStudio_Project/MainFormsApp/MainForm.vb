Imports MainFormsApp.game_logic

Public Class MainForm

    Private _m_3_t_1 As New matching_tiles() From {
        New tile(0, New tile_item(0, New tile_item_design())),
        New tile(1, New tile_item(0, New tile_item_design())),
        New tile(2, New tile_item(0, New tile_item_design()))
    }

    Private _m_3_t_2 As New matching_tiles() From {
        New tile(3, New tile_item(1, New tile_item_design())),
        New tile(4, New tile_item(1, New tile_item_design())),
        New tile(5, New tile_item(1, New tile_item_design()))
    }

    Private _m_3_t_3 As New matching_tiles() From {
        New tile(8, New tile_item(2, New tile_item_design())),
        New tile(6, New tile_item(2, New tile_item_design())),
        New tile(7, New tile_item(2, New tile_item_design()))
    }

    Private _tiles As New matching_tiles_set() From {
            _m_3_t_1, _m_3_t_2, _m_3_t_3
    }

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim my_tiles As matching_tiles_set = _tiles

        Dim my_board As New board(my_tiles)

        my_board.shuffle_tiles()

    End Sub
End Class
