Imports MainFormsApp.tile_database

Namespace controller.UI.game_setup

    ''' <summary>
    ''' Models the user interface for choosing the composition of the tile set.
    ''' </summary>
    Public Class tile_set_composition

        Private _database As tile_database.i_database

        Private Property _num_tiles_per_item As Integer
        Private Property _selection_pattern As design_selection_pattern

        Private Property _tile_selection_method As selection_method
        Private Property _design_selection_method As selection_method

        Private Property _filtered_items As List(Of DTOs.Item)
        Private Property _selected_items As List(Of DTOs.Item)

        Public Sub New(ByRef tile_database As tile_database.i_database)

            _database = tile_database

            _num_tiles_per_item = 0
            _selection_pattern = design_selection_pattern.unselected

            _tile_selection_method = selection_method.unselected
            _design_selection_method = selection_method.unselected

        End Sub

        Public ReadOnly Property database As i_database
            Get
                Return _database
            End Get
        End Property

        Public ReadOnly Property filtered_items As IReadOnlyList(Of DTOs.Item)
            Get
                Return _filtered_items
            End Get
        End Property

        Public ReadOnly Property selected_items As IReadOnlyList(Of DTOs.Item)
            Get
                Return _selected_items
            End Get
        End Property

        ''' <summary>
        ''' Returns the highest number of tiles that the user can choose
        ''' for the specified <paramref name="selection_pattern"/> and the current
        ''' database.
        ''' </summary>
        ''' <param name="selection_pattern"></param>
        ''' <returns></returns>
        Public Function max_num_available_tiles_per_item(selection_pattern As design_selection_pattern) As Integer

            Select Case selection_pattern
                Case design_selection_pattern.only_identical_designs_per_item
                    Return 5
                Case design_selection_pattern.identical_and_unique_designs_per_item
                    Return 5
                Case design_selection_pattern.only_unique_designs_per_item
                    Dim max_num_unique_designs_for_one_item As Integer

                    Dim number_map = database.map_num_files_to_num_of_items_with_at_least_that_many
                    For Each num_files_with_num_items In number_map
                        ' TODO
                    Next

                    Return 4
            End Select

        End Function

        Public Sub general_tile_choice(num_tiles_per_item As Integer,
                                       design_selection_pattern As design_selection_pattern)

            If design_selection_pattern = design_selection_pattern.unselected Then
                Throw New ArgumentException()
            End If
            If num_tiles_per_item < 1 Then
                Throw New ArgumentOutOfRangeException("num_tiles_per_item", num_tiles_per_item)
            End If
            If design_selection_pattern = design_selection_pattern.only_unique_designs_per_item AndAlso
                    num_tiles_per_item < 2 Then
                Throw New ArgumentException()
            End If

            Dim minimum_num_designs_per_item As Integer

            Select Case design_selection_pattern
                Case design_selection_pattern.only_identical_designs_per_item
                    minimum_num_designs_per_item = 1
                Case design_selection_pattern.identical_and_unique_designs_per_item
                    minimum_num_designs_per_item = 1
                Case design_selection_pattern.only_unique_designs_per_item
                    minimum_num_designs_per_item = num_tiles_per_item
            End Select

            Dim items_with_at_least_num_tiles_desigsn As List(Of DTOs.Item) =
                _database.items_with_at_least_num_files(num_tiles_per_item)

            If items_with_at_least_num_tiles_desigsn.Count < 2 Then
                Throw New ArgumentOutOfRangeException("num_tiles_per_item", num_tiles_per_item)
            End If

            _filtered_items = items_with_at_least_num_tiles_desigsn

        End Sub

        Public Sub choose_items_randomly_from_filtered(num_items As Integer)

            If num_items < 2 Then Throw New ArgumentOutOfRangeException("num_items", num_items)
            If num_items > _filtered_items.Count Then Throw New ArgumentOutOfRangeException("num_items", num_items)

            _selected_items = utility.functions.sample_enumerable(_filtered_items, num_items)
            _tile_selection_method = selection_method.random

        End Sub

        Public Sub handpick_items_from_filtered(items As IEnumerable(Of DTOs.Item))

            If items.Count < 2 Then Throw New ArgumentException()

            If Not items.All(Function(i As DTOs.Item) _filtered_items.Contains(i)) Then
                Throw New ArgumentException()
            End If

            _selected_items = items
            _tile_selection_method = selection_method.manual

        End Sub

    End Class

End Namespace
