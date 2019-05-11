Namespace game_logic

    ''' <summary>
    ''' Represents a tile on the game board.
    ''' It can be covered and uncovered.
    ''' When uncovered the item on it can be looked at.
    ''' When uncovered the tile can be regularly matched against other uncovered tiles.
    ''' There is an irregular way for matching tiles.
    ''' </summary>
    Public Class tile

        Public ReadOnly Property covered As Boolean
            Get
                Return _covered
            End Get
        End Property

        Public ReadOnly Property item As i_tile_item
            Get
                If Not covered Then
                    Return _item
                Else
                    Throw New InvalidOperationException("Attempted to look at an item on a covered tile.")
                End If
            End Get
        End Property

        Private _covered As Boolean
        Private _item As i_tile_item

        Public Sub New(item As i_tile_item, Optional covered As Boolean = True)
            _item = item
            _covered = covered
        End Sub

        ''' <summary>
        ''' Compares the tile against another tile.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns><code>True</code> if the items on the tiles match. Otherwise <code>False</code>.</returns>
        ''' <see cref="i_tile_item"/>
        Public Function matches(other As tile) As Boolean
            Return item.matches(other.item)
        End Function

        ''' <summary>
        ''' Compares two potentially covered tiles against each other.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns><code>True</code> if the items on the tiles match. Otherwise <code>False</code>.</returns>
        ''' <see cref="i_tile_item"/>
        Public Function undercover_matches(other As tile) As Boolean
            Return _item.matches(other._item)
        End Function

        ''' <summary>
        ''' Uncovers the tile. Does nothing if the tile is already uncovered.
        ''' </summary>
        Public Sub uncover()
            If covered Then
                _covered = False
            End If
        End Sub

        ''' <summary>
        ''' Covers the tile. Does nothing if the tile is already covered.
        ''' </summary>
        Public Sub cover()
            If Not covered Then
                _covered = True
            End If
        End Sub

    End Class

End Namespace
