Namespace controller.UI.game_setup.tile_set_composition

    Public Class item_choice

        Private Property _database As tile_database.i_database

        Private Property _candidate_items As List(Of tile_database.DTOs.Item)
        Private Property _choice_was_made As Boolean

        Private Property _chosen_items As List(Of tile_database.DTOs.Item)

        Public Sub New(database As tile_database.i_database, candidate_items As IEnumerable(Of tile_database.DTOs.Item))

            _database = database

            Me.candidate_items = candidate_items
            _choice_was_made = False

            _chosen_items = Nothing

        End Sub

        Public Sub choose_randomly(num_items As Integer)

            Select Case num_items
                Case < 2
                    Throw New ArgumentOutOfRangeException("num_items", num_items)
                Case > candidate_items.Count
                    Throw New ArgumentOutOfRangeException("num_items", num_items)
                Case = candidate_items.Count
                    _chosen_items = _candidate_items
                    _choice_was_made = True
                Case Else

                    Dim max_possible_num_designs As Integer =
                        _database.get_shared_num_files_among_num_items_items_with_highest_file_count(num_items)

                    _chosen_items = utility.functions.sample_enumerable(Of tile_database.DTOs.Item)(
                        _database.items_with_at_least_num_files(max_possible_num_designs), num_items)

                    _choice_was_made = True
            End Select

        End Sub

        Public Sub choose_manually(items As IEnumerable(Of tile_database.DTOs.Item))

            If Not items.All(Function(i As tile_database.DTOs.Item) candidate_items.Contains(i)) Then
                Throw New ArgumentException()
            End If

            _chosen_items = items
            _choice_was_made = True

        End Sub

        Public Sub unchoose()
            _choice_was_made = False
            _chosen_items = Nothing
        End Sub

        ''' <summary>
        ''' Note: Setting the candidate items to a new value unmakes the previous
        ''' choice.
        ''' </summary>
        ''' <returns></returns>
        Public Property candidate_items As IEnumerable(Of tile_database.DTOs.Item)
            Get
                Return _candidate_items
            End Get
            Set(items As IEnumerable(Of tile_database.DTOs.Item))
                If items Is Nothing Then Throw New ArgumentNullException()
                _candidate_items = items
                unchoose()
            End Set
        End Property

        Public ReadOnly Property choice_was_made As Boolean
            Get
                Return _choice_was_made
            End Get
        End Property

        Public ReadOnly Property chosen_items As IEnumerable(Of tile_database.DTOs.Item)
            Get
                Return _chosen_items
            End Get
        End Property

    End Class

End Namespace
