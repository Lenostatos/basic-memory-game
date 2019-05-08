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

        Private Property _tile_sets As System.Collections.Generic.HashSet(Of matching_tiles)

        Public Sub New(tile_sets As List(Of matching_tiles))

            Dim num_tiles_per_set As Integer = tile_sets(0).tiles.Count
            Dim previous As matching_tiles = tile_sets(0)

            For Each tile_set As matching_tiles In tile_sets

                If tile_set.tiles.Count <> num_tiles_per_set Then
                    Throw New ArgumentException("Attempted to initialize a collection of tiles with differently sized sets of matching tiles.")
                End If

                Try
                    _tile_sets.Add(tile_set)
                Catch ex As Exception
                    Throw New ArgumentException("Attempted to initialize a collection of tiles with sets of matching tiles that also match among each other.",
                                                ex)
                End Try

            Next

        End Sub

    End Class

End Namespace
