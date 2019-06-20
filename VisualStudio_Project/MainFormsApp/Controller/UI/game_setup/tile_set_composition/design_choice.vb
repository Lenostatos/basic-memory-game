Namespace controller.ui.game_setup.tile_set_composition

    Public Class design_choice

        Private Property _database As tile_database.i_database
        Private Property _pattern As how_to_select_designs
        Private Property _items_to_choose_for As List(Of tile_database.dto.Item)
        Private Property _num_tiles_to_choose As Integer

        Private Property _chosen_designs As Dictionary(Of tile_database.dto.Item, List(Of tile_database.dto.File_Info))
        Private Property _choice_was_made As Boolean

        Public Sub New(previous_choice As num_tiles_per_item_choice)

            _database = previous_choice.database
            _pattern = previous_choice.design_selection_pattern
            _items_to_choose_for = previous_choice.items_to_choose_for
            _num_tiles_to_choose = previous_choice.chosen_number

            _choice_was_made = False

        End Sub

        Public Sub choose_randomly()

            unchoose()

            _chosen_designs = New Dictionary(Of tile_database.dto.Item, List(Of tile_database.dto.File_Info))

            Dim design_list As New List(Of tile_database.dto.File_Info)
            Dim randomly_chosen_design As tile_database.dto.File_Info

            Select Case _pattern
                Case how_to_select_designs.only_identical_designs_per_item

                    For Each item As tile_database.dto.Item In _items_to_choose_for

                        design_list.Clear()

                        randomly_chosen_design = utility.functions.sample_enumerable(Of tile_database.dto.File_Info)(
                            _database.files_for_item(item), size:=1)

                        For i As Integer = 1 To _num_tiles_to_choose
                            design_list.Add(randomly_chosen_design)
                        Next

                        _chosen_designs.Add(item, design_list)

                    Next

                Case how_to_select_designs.identical_and_unique_designs_per_item

                    For Each item As tile_database.dto.Item In _items_to_choose_for

                        design_list.Clear()

                        design_list.AddRange(utility.functions.sample_enumerable(Of tile_database.dto.File_Info)(
                            _database.files_for_item(item), size:=_num_tiles_to_choose, replace:=True))

                        _chosen_designs.Add(item, design_list)

                    Next

                Case how_to_select_designs.only_unique_designs_per_item

                    For Each item As tile_database.dto.Item In _items_to_choose_for

                        design_list.Clear()

                        design_list.AddRange(utility.functions.sample_enumerable(Of tile_database.dto.File_Info)(
                            _database.files_for_item(item), size:=_num_tiles_to_choose, replace:=False))

                        _chosen_designs.Add(item, design_list)

                    Next

            End Select

            _choice_was_made = True

        End Sub

        Public Sub unchoose()
            _choice_was_made = False
            _chosen_designs = Nothing
        End Sub

        Public ReadOnly Property items_to_choose_for As IReadOnlyList(Of tile_database.dto.Item)
            Get
                Return _items_to_choose_for
            End Get
        End Property

        Public ReadOnly Property choice_was_made As Boolean
            Get
                Return _choice_was_made
            End Get
        End Property

        Public ReadOnly Property chosen_designs As Dictionary(Of tile_database.dto.Item, List(Of tile_database.dto.File_Info))
            Get
                If Not choice_was_made Then Throw New InvalidOperationException()
                Return _chosen_designs
            End Get
        End Property

    End Class

End Namespace
