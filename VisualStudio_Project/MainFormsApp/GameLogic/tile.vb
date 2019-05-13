Namespace game_logic

    ''' <summary>
    ''' Represents a tile on the game board.
    ''' It can be covered and uncovered.
    ''' When uncovered the item on the tile can be looked at.
    ''' When uncovered the tile can be regularly matched against other uncovered tiles.
    ''' Also provides an irregular way for matching tiles.
    ''' </summary>
    Public Class tile

        Implements IEquatable(Of tile)

        Public Const EXCEPTION_MESSAGE_LOOKED_AT_ITEM_ON_COVERED_TILE As String =
            "Attempted to look at an item on a covered tile."

        Private Property _id As Integer
        Private Property _covered As Boolean
        Private Property _item As i_tile_item

        Public Sub New(id As Integer, item As i_tile_item, Optional covered As Boolean = True)

            If item Is Nothing Then Throw New ArgumentNullException()

            _id = id
            _item = item
            _covered = covered

        End Sub

        Public ReadOnly Property id As Integer
            Get
                Return _id
            End Get
        End Property

        Public ReadOnly Property covered As Boolean
            Get
                Return _covered
            End Get
        End Property

        ''' <summary>
        ''' Returns the tile's item iff the tile is uncovered.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property item As i_tile_item
            Get
                If Not covered Then
                    Return _item
                Else
                    Throw New InvalidOperationException(EXCEPTION_MESSAGE_LOOKED_AT_ITEM_ON_COVERED_TILE)
                End If
            End Get
        End Property

        ''' <summary>
        ''' Returns the tile's item regardless of whether the tile is covered or not.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property undercover_item As i_tile_item
            Get
                Return _item
            End Get
        End Property

        ''' <summary>
        ''' Compares the tile against another tile.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns><code>True</code> if the items on the tiles match. Otherwise <code>False</code>.</returns>
        ''' <see cref="i_tile_item"/>
        Public Function matches(other As tile) As Boolean
            If other Is Nothing Then Throw New ArgumentNullException()
            Return item.matches(other.item)
        End Function

        ''' <summary>
        ''' Compares two potentially covered tiles against each other.
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns><code>True</code> if the items on the tiles match. Otherwise <code>False</code>.</returns>
        ''' <see cref="i_tile_item"/>
        Public Function undercover_matches(other As tile) As Boolean
            If other Is Nothing Then Throw New ArgumentNullException()
            Return undercover_item.matches(other.undercover_item)
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

        Public Overrides Function GetHashCode() As Integer
            Return id
        End Function

        Public Shadows Function Equals(other As tile) As Boolean Implements IEquatable(Of tile).Equals
            If other Is Nothing Then
                Return False
            Else
                Return id.Equals(other.id)
            End If
        End Function

        Public Class equality_comparer_of_tiles_by_item

            Implements IEqualityComparer(Of tile)

            Public Shadows Function Equals(x As tile, y As tile) As Boolean Implements IEqualityComparer(Of tile).Equals
                If x Is Nothing OrElse y Is Nothing Then
                    Return False
                Else
                    Return x.undercover_matches(y)
                End If
            End Function

            Public Shadows Function GetHashCode(obj As tile) As Integer Implements IEqualityComparer(Of tile).GetHashCode
                Throw New NotImplementedException()
            End Function

        End Class

    End Class

End Namespace
