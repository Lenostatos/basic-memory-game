Namespace game_logic

    ''' <summary>
    ''' Models a group of at least two matching tiles.
    ''' </summary>
    Public Class matching_tiles

        Public ReadOnly Property tiles As List(Of tile)
            Get
                Return _tiles
            End Get
        End Property

        Private Property _tiles As List(Of tile)

        Public Sub New(tiles As List(Of tile))

            If tiles Is Nothing Then Throw New ArgumentNullException()

            If tiles.Count < 2 Then Throw New ArgumentException(
                "Attempted to create a group of matching tiles from less than two tiles."
                )

            Dim previous As tile = tiles.First

            For Each t As tile In tiles
                If Not t.undercover_matches(previous) Then Throw New ArgumentException(
                    "Attempted to create a group of matching tiles from tiles that do not match."
                    )
                previous = t
            Next

            _tiles = tiles

        End Sub

        Protected Function undercover_matches(other As matching_tiles) As Boolean
            If other Is Nothing Then Throw New ArgumentNullException()
            Return _tiles.First.undercover_matches(other.tiles.First)
        End Function
    End Class

End Namespace
