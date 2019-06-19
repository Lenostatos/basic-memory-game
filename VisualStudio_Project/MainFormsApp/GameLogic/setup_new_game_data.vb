Namespace game_logic

    ''' <summary>
    ''' Collects the data that is necessary for starting a new game.
    ''' </summary>
    Public Class setup_new_game_data

        Private Property _players As List(Of player)
        Private Property _starting_player As player
        Private Property _tile_set As matching_tiles_set

        Public Sub New()
            _tile_set = New matching_tiles_set()
            _players = New List(Of player)
        End Sub

        Public ReadOnly Property players As IReadOnlyList(Of player)
            Get
                Return _players
            End Get
        End Property

        Public Property starting_player As player
            Get
                Return _starting_player
            End Get
            Set(p As player)

                If p IsNot Nothing AndAlso Not players.Contains(p) Then
                    Throw New ArgumentException()
                End If

                _starting_player = p

            End Set
        End Property

        Public Property tile_set As matching_tiles_set
            Get
                Return _tile_set
            End Get
            Set(value As matching_tiles_set)

                If value Is Nothing Then Throw New ArgumentNullException()
                _tile_set = value

            End Set
        End Property

        Public Sub add_player(p As player)

            If p Is Nothing Then Throw New ArgumentNullException()
            If players.Contains(p) Then Throw New ArgumentException()

            _players.Add(p)

        End Sub

        Public Function remove_player(p As player) As Boolean

            If p Is Nothing Then Throw New ArgumentNullException()
            Return _players.Remove(p)

        End Function

        ''' <summary>
        ''' Indicates whether the stored the data is sufficient for starting a new game.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property ready_to_go As Boolean
            Get

                Return players.Count > 0 AndAlso starting_player IsNot Nothing AndAlso tile_set.Count > 1

            End Get
        End Property

    End Class

End Namespace
