Namespace controller.ui.game_setup.tile_set_composition

    Public Class item_choice

        Private Property _database As tile_database.i_database

        Private ReadOnly Property _chosen_design_combination As how_to_select_designs

        Private Property _candidate_items As List(Of tile_database.dto.Item)
        Private Property _choice_was_made As Boolean

        Private Property _chosen_items As List(Of tile_database.dto.Item)

        Public Sub New(previous_choice As design_combination_choice)

            If Not previous_choice.choice_was_made Then Throw New ArgumentException()

            _database = previous_choice.database

            _chosen_design_combination = previous_choice.choice
            _candidate_items = previous_choice.resulting_candidate_items

            _choice_was_made = False
            _chosen_items = Nothing

        End Sub

        Public Sub choose_randomly(num_items As Integer)

            unchoose()

            Select Case num_items
                Case < 2
                    Throw New ArgumentOutOfRangeException("num_items", num_items)
                Case > _candidate_items.Count
                    Throw New ArgumentOutOfRangeException("num_items", num_items)
                Case = _candidate_items.Count
                    _chosen_items = _candidate_items
                    _choice_was_made = True
                Case Else

                    Dim max_possible_num_designs As Integer =
                        _database.get_shared_num_files_among_num_items_items_with_highest_file_count(num_items)

                    _chosen_items = utility.functions.sample_enumerable(Of tile_database.dto.Item)(
                        _database.items_with_at_least_num_files(max_possible_num_designs), num_items)

                    _choice_was_made = True
            End Select

        End Sub

        Public Sub choose_manually(items As IEnumerable(Of tile_database.dto.Item))

            unchoose()

            If Not items.All(Function(i As tile_database.dto.Item) candidate_items.Contains(i)) Then
                Throw New ArgumentException()
            End If

            _chosen_items = items
            _choice_was_made = True

        End Sub

        Public Sub unchoose()
            _choice_was_made = False
            _chosen_items = Nothing
        End Sub

        Public ReadOnly Property database As tile_database.i_database
            Get
                Return _database
            End Get
        End Property

        Public ReadOnly Property candidate_items As IEnumerable(Of tile_database.dto.Item)
            Get
                Return _candidate_items
            End Get
        End Property

        Public ReadOnly Property choice_was_made As Boolean
            Get
                Return _choice_was_made
            End Get
        End Property

        Public ReadOnly Property chosen_design_combination As how_to_select_designs
            Get
                Return _chosen_design_combination
            End Get
        End Property

        Public ReadOnly Property chosen_items As IEnumerable(Of tile_database.dto.Item)
            Get
                If Not choice_was_made Then Throw New InvalidOperationException()
                Return _chosen_items
            End Get
        End Property

    End Class

End Namespace
