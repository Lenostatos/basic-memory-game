Namespace game_logic

    ''' <summary>
    ''' Models a collection of memory tiles within which every tile has the same number of matching "partner" tiles.
    ''' There are at least two different sets of matching tiles.    
    ''' </summary>
    Public Class tile_collection

        Public ReadOnly Property tiles As List(Of tile)
            Get

                Dim return_tiles As New List(Of tile)(_tile_sets.Count * _tile_sets(0).tiles.Count)

                For Each tile_set As matching_tiles In _tile_sets
                    For Each t As tile In tile_set.tiles
                        return_tiles.Add(t)
                    Next
                Next

                Return return_tiles

            End Get
        End Property

        Public ReadOnly Property size_of_tile_sets As Integer
            Get
                Return _tile_sets(0).tiles.Count
            End Get
        End Property

        Private Property _tile_sets As HashSet(Of matching_tiles)
        Private Property _size_of_tile_sets As Integer

        Public Sub New(tile_sets As List(Of matching_tiles))

            If tile_sets Is Nothing Then Throw New ArgumentNullException()
            If tile_sets.Count < 2 Then Throw New ArgumentException("Attempted to initialize a collection of tiles with less than two sets of matching tiles.")

            _size_of_tile_sets = tile_sets(0).tiles.Count
            Dim previous As matching_tiles = tile_sets(0)

            For Each tile_set As matching_tiles In tile_sets

                If tile_set.tiles.Count <> _size_of_tile_sets Then
                    Throw New ArgumentException("Attempted to initialize a collection of tiles with differently sized sets of matching tiles.")
                End If

                If _tile_sets.Contains(tile_set) Then
                    Throw New ArgumentException("Attempted to initialize a collection of tiles with sets of matching tiles that also match among each other.")
                Else
                    _tile_sets.Add(tile_set)
                End If

            Next

        End Sub

        Public Sub add(tile_set As matching_tiles)

            If tile_set Is Nothing Then Throw New ArgumentNullException()

            If tile_set.tiles.Count <> size_of_tile_sets Then
                Throw New ArgumentException("Attempted to add a set of matching tiles with the wrong count to a collection of tiles.")
            End If

            If _tile_sets.Contains(tile_set) Then
                Throw New ArgumentException("Attempted to add a set of matching tiles to a collection of tiles that already contained another set that matched with the new set.")
            Else
                _tile_sets.Add(tile_set)
            End If

            _tile_sets.Add(tile_set)

        End Sub

    End Class

End Namespace
