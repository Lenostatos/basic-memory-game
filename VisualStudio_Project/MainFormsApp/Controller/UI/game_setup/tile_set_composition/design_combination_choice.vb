Namespace controller.UI.game_setup.tile_set_composition

    Public Class design_combination_choice

        Private _database As tile_database.i_database
        Private _available_options As List(Of design_selection_pattern)

        Private _choice_was_made As Boolean
        Private _choice As design_selection_pattern

        Private _resulting_item_candidates As List(Of tile_database.DTOs.Item)

        Public Sub New(tile_database As tile_database.i_database)

            If tile_database Is Nothing Then Throw New ArgumentNullException()
            _database = tile_database

            _available_options = New List(Of design_selection_pattern)

            _choice_was_made = False
            _choice = design_selection_pattern.None

            determine_available_options()

        End Sub

        Public Sub choose(pattern As design_selection_pattern)

            If Not available_options.Contains(pattern) Then
                Throw New ArgumentException()
            End If

            _choice = pattern

            Select Case _choice
                Case design_selection_pattern.only_identical_designs_per_item
                    _resulting_item_candidates = _database.items_with_at_least_num_files(1)
                Case design_selection_pattern.identical_and_unique_designs_per_item
                    _resulting_item_candidates = _database.items_with_at_least_num_files(1)
                Case design_selection_pattern.only_unique_designs_per_item
                    _resulting_item_candidates = _database.items_with_at_least_num_files(2)
            End Select

            _choice_was_made = True

        End Sub

        Public Sub unchoose()

            _resulting_item_candidates = Nothing

            _choice = design_selection_pattern.None
            _choice_was_made = False

        End Sub

        Public ReadOnly Property database_file_path As String
            Get
                Return _database.file_path
            End Get
        End Property

        Public ReadOnly Property available_options As IReadOnlyList(Of design_selection_pattern)
            Get
                Return _available_options
            End Get
        End Property

        Public ReadOnly Property choice_was_made As Boolean
            Get
                Return _choice_was_made
            End Get
        End Property

        Public ReadOnly Property choice As design_selection_pattern
            Get
                Return _choice
            End Get
        End Property

        Public ReadOnly Property item_candidates_after_choice As List(Of tile_database.DTOs.Item)
            Get

                If Not choice_was_made Then Throw New InvalidOperationException()
                Return _resulting_item_candidates

            End Get
        End Property

        Private Sub determine_available_options()

            _available_options.Clear()

            If _database.count_items_with_at_least_num_files(1) > 1 Then
                _available_options.Add(design_selection_pattern.only_identical_designs_per_item)
                _available_options.Add(design_selection_pattern.identical_and_unique_designs_per_item)
            End If

            If _database.count_items_with_at_least_num_files(2) > 1 Then
                _available_options.Add(design_selection_pattern.only_unique_designs_per_item)
            End If

        End Sub

    End Class

End Namespace
