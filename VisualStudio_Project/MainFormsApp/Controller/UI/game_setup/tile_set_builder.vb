Imports MainFormsApp.tile_database.dto
Imports MainFormsApp.game_logic

Namespace controller.ui.game_setup

    Public Class tile_set_builder

        Public Shared Function build(
            dict_of_item_and_file_info_dtos As Dictionary(
                Of Item, List(Of File_Info))) As game_logic.matching_tiles_set

            If dict_of_item_and_file_info_dtos Is Nothing Then
                Throw New ArgumentNullException()
            End If

            If dict_of_item_and_file_info_dtos.Count = 0 Then
                Throw New ArgumentException()
            End If

            Dim tile_counter As Integer = 0
            Dim new_tile_item_design As tile_item_design
            Dim new_tile_item As tile_item
            Dim new_tile As tile
            Dim new_tiles As New List(Of tile)
            Dim return_set As New matching_tiles_set()

            For Each item_with_designs As KeyValuePair(Of Item, List(Of File_Info)) In dict_of_item_and_file_info_dtos

                new_tiles.Clear()

                For Each design As File_Info In item_with_designs.Value

                    new_tile_item_design = New tile_item_design(design.id)
                    new_tile_item = New tile_item(item_with_designs.Key.id, new_tile_item_design)
                    new_tile = New tile(tile_counter, new_tile_item)
                    new_tiles.Add(new_tile)

                    tile_counter = tile_counter + 1

                Next

                return_set.Add(New matching_tiles(new_tiles))

            Next

            Return return_set

        End Function

    End Class

End Namespace
