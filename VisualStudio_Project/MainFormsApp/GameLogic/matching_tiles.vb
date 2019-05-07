Namespace game_logic

    ''' <summary>
    ''' Models a set of at least two matching tiles.
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
            If tiles.Count < 2 Then Throw New ArgumentException("Attempted to create a set of matching tiles from less than two tiles.")

            Dim previous As tile = tiles(0)
            previous.uncover()

            For Each t As tile In tiles
                t.uncover()
                If Not t.matches(previous) Then Throw New ArgumentException("Attempted to create a set of matching tiles from tiles that do not match.")
                previous = t
            Next

            _tiles = tiles

        End Sub

        Public Function matches(other As matching_tiles) As Boolean
            Return _tiles(0).matches(other.tiles(0))
        End Function

    End Class

End Namespace
