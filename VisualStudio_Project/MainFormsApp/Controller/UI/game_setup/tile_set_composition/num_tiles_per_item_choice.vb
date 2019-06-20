Namespace controller.ui.game_setup.tile_set_composition

    Public Class num_tiles_per_item_choice

        Public Const MAX_MEANINGFUL_NUM_TILES_PER_ITEM As Integer = 5

        Private Property _database As tile_database.i_database
        Private Property _items_to_choose_for As List(Of tile_database.dto.Item)
        Private Property _design_selection_pattern As how_to_select_designs

        Private Property _available_choices As List(Of Integer)

        Private Property _choice_was_made As Boolean
        Private Property _chosen_number As Integer

        Public Sub New(previous_choice As item_choice)

            If Not previous_choice.choice_was_made Then Throw New ArgumentException()

            _database = previous_choice.database
            _items_to_choose_for = previous_choice.chosen_items
            _design_selection_pattern = previous_choice.chosen_design_combination

            _choice_was_made = False
            _chosen_number = -1

            _available_choices = New List(Of Integer)
            determine_available_choices()

        End Sub

        Public Sub choose(num_tiles As Integer)

            If Not available_choices.Contains(num_tiles) Then
                Throw New ArgumentOutOfRangeException()
            End If

            _choice_was_made = True
            _chosen_number = num_tiles

        End Sub

        Public Sub unchoose()

            _choice_was_made = False
            _chosen_number = -1

            determine_available_choices()

        End Sub

        Private Sub determine_available_choices()

            Dim max_possible_num_tiles As Integer

            Select Case _design_selection_pattern
                Case how_to_select_designs.only_identical_designs_per_item
                    max_possible_num_tiles = MAX_MEANINGFUL_NUM_TILES_PER_ITEM
                Case how_to_select_designs.identical_and_unique_designs_per_item
                    max_possible_num_tiles = MAX_MEANINGFUL_NUM_TILES_PER_ITEM
                Case how_to_select_designs.only_unique_designs_per_item
                    Dim file_counts As New List(Of Integer)
                    For Each i As tile_database.dto.Item In _items_to_choose_for
                        file_counts.Add(_database.files_for_item(i).Count)
                    Next
                    max_possible_num_tiles = file_counts.Min()
            End Select

            For num As Integer = 2 To max_possible_num_tiles
                _available_choices.Add(num)
            Next

        End Sub

        Public ReadOnly Property database As tile_database.i_database
            Get
                Return _database
            End Get
        End Property

        Public ReadOnly Property items_to_choose_for As IReadOnlyList(Of tile_database.dto.Item)
            Get
                Return _items_to_choose_for
            End Get
        End Property

        Public ReadOnly Property design_selection_pattern As how_to_select_designs
            Get
                Return _design_selection_pattern
            End Get
        End Property

        Public ReadOnly Property available_choices As IEnumerable(Of Integer)
            Get
                Return _available_choices
            End Get
        End Property

        Public ReadOnly Property choice_was_made As Boolean
            Get
                Return _choice_was_made
            End Get
        End Property

        Public ReadOnly Property chosen_number As Integer
            Get
                If Not choice_was_made Then Throw New InvalidOperationException()
                Return _chosen_number
            End Get
        End Property

    End Class

End Namespace
