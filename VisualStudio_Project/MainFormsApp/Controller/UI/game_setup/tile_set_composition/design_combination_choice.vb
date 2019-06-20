Namespace controller.ui.game_setup.tile_set_composition

    Public Class design_combination_choice

        Private _database As tile_database.i_database
        Private _available_options As List(Of how_to_select_designs)

        Private _choice_was_made As Boolean
        Private _choice As how_to_select_designs

        Private _item_candidates As List(Of tile_database.dto.Item)

        Public Sub New(tile_database As tile_database.i_database)

            If tile_database Is Nothing Then Throw New ArgumentNullException()
            _database = tile_database

            _available_options = New List(Of how_to_select_designs)

            _choice_was_made = False
            _choice = how_to_select_designs.None

            determine_available_options()

        End Sub

        Public Sub choose(pattern As how_to_select_designs)

            unchoose()

            If Not available_options.Contains(pattern) Then
                Throw New ArgumentException()
            End If

            _choice = pattern

            Select Case _choice
                Case how_to_select_designs.only_identical_designs_per_item
                    _item_candidates = _database.items_with_at_least_num_files(1)
                Case how_to_select_designs.identical_and_unique_designs_per_item
                    _item_candidates = _database.items_with_at_least_num_files(1)
                Case how_to_select_designs.only_unique_designs_per_item
                    _item_candidates = _database.items_with_at_least_num_files(2)
            End Select

            _choice_was_made = True

        End Sub

        Public Sub unchoose()

            _item_candidates = Nothing

            _choice = how_to_select_designs.None
            _choice_was_made = False

        End Sub

        Public ReadOnly Property database As tile_database.i_database
            Get
                Return _database
            End Get
        End Property

        Public ReadOnly Property available_options As IReadOnlyList(Of how_to_select_designs)
            Get
                Return _available_options
            End Get
        End Property

        Public ReadOnly Property choice_was_made As Boolean
            Get
                Return _choice_was_made
            End Get
        End Property

        Public ReadOnly Property choice As how_to_select_designs
            Get
                If Not choice_was_made Then Throw New InvalidOperationException()
                Return _choice
            End Get
        End Property

        Public ReadOnly Property resulting_candidate_items As List(Of tile_database.dto.Item)
            Get

                If Not choice_was_made Then Throw New InvalidOperationException()
                Return _item_candidates

            End Get
        End Property

        Private Sub determine_available_options()

            _available_options.Clear()

            If _database.count_items_with_at_least_num_files(1) > 1 Then
                _available_options.Add(how_to_select_designs.only_identical_designs_per_item)
                _available_options.Add(how_to_select_designs.identical_and_unique_designs_per_item)
            End If

            If _database.count_items_with_at_least_num_files(2) > 1 Then
                _available_options.Add(how_to_select_designs.only_unique_designs_per_item)
            End If

        End Sub

    End Class

End Namespace
