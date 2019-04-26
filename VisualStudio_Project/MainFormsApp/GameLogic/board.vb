Imports System.Collections.Generic

Namespace game_logic

    ''' <summary>
    ''' Models a board of memory tiles.
    ''' </summary>
    Public Class board

        Public ReadOnly Property width As Integer ' The number of tiles per row.
        Public ReadOnly Property num_rows As Integer
            Get
                Return System.Math.Ceiling(_tiles.Count / width)
            End Get
        End Property
        Public ReadOnly Property num_tiles As Integer
            Get
                Return _tiles.Count
            End Get
        End Property

        Private Property _tiles As List(Of tile)

        Public Sub New(width As Integer, tiles As List(Of tile))

            If tiles Is Nothing Then Throw New ArgumentNullException("Attempted to initialize a board without tiles.")

            If width < 1 Then Throw New ArgumentOutOfRangeException("Attempted to initialize a memory board with a width lower than 1.")
            If width > tiles.Count Then Throw New ArgumentOutOfRangeException("Attempted to initialize a memory board with a width higher than the number of given tiles.")

            If tiles.Count Mod 2 <> 0 Then Throw New ArgumentOutOfRangeException("Attempted to initialize a game with an uneven number of tiles.")

            Me.width = width
            _tiles = tiles

        End Sub

        Public Function get_tile(column As Integer, row As Integer) As tile
            If column > width OrElse column < 1 Then Throw New ArgumentOutOfRangeException("Attempted to get a tile in an invalid column.")
            If column > num_rows OrElse row < 1 Then Throw New ArgumentOutOfRangeException("Attempted to get a tile in an invalid row.")

            Return _tiles.Item((row - 1) * width + column)
        End Function

    End Class

End Namespace
