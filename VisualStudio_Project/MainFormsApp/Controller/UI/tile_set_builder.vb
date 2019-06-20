Imports MainFormsApp.tile_database
Imports MainFormsApp.game_logic

Namespace controller

    Public Class tile_set_builder

        Public Shared Function build(items_with_designs As IDictionary(
                                         Of tile_database.dto.Item,
                                         IEnumerable(Of tile_database.dto.File_Info))) As _
                                    game_logic.matching_tiles_set

            ' TODO

        End Function

        Public Shared Function build(items As List(Of tile_database.dto.Item), database As tile_database.i_database) As game_logic.matching_tiles_set

            Dim files_of_item As List(Of dto.File_Info)
            Dim new_item As tile_item
            Dim return_item_set As matching_tiles_set

            For Each i As dto.Item In items

            Next

        End Function

    End Class

End Namespace
