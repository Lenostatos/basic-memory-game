Imports System.Collections.Generic

Namespace game_logic

    ''' <summary>
    ''' Models a board of memory tiles.
    ''' </summary>
    Public Class board

        ''' <summary>
        ''' The number of tiles per row.
        ''' </summary>
        Public ReadOnly Property num_cols As Integer

        ''' <summary>
        ''' The number of rows.
        ''' </summary>
        Public ReadOnly Property num_rows As Integer
            Get
                Return System.Math.Ceiling(_tiles.Count / num_cols)
            End Get
        End Property

        Public ReadOnly Property num_tiles As Integer
            Get
                Return _tiles.Count
            End Get
        End Property

        Private Property _tiles As List(Of tile)

        ''' <summary>
        ''' Creates a new board from the passed tiles.
        ''' All tiles are covered and put into a random order.
        ''' </summary>
        ''' <param name="width"></param>
        ''' <param name="tiles"></param>
        Public Sub New(width As Integer, tiles As List(Of tile))

            If tiles Is Nothing Then Throw New ArgumentNullException(
                "Attempted to initialize a board without tiles."
                )

            If width < 1 Then Throw New ArgumentOutOfRangeException(
                "Attempted to initialize a memory board with a width lower than 1."
                )
            If width > tiles.Count Then Throw New ArgumentOutOfRangeException(
                "Attempted to initialize a memory board with a width 
                higher than the number of given tiles."
                )

            If tiles.Count Mod 2 <> 0 Then Throw New ArgumentOutOfRangeException(
                "Attempted to initialize a game with an uneven number of tiles."
                )

            Me.num_cols = width
            _tiles = tiles

            shuffle_tiles()


        End Sub

        ''' <summary>
        ''' Shuffles the tiles on the board.
        ''' </summary>
        Public Sub shuffle_tiles()
            _tiles = utility.functions.shuffle_collection(Of tile)(_tiles)
        End Sub

        ''' <summary>
        ''' Covers all tiles on the board.
        ''' </summary>
        Public Sub cover_tiles()
            For Each t As tile In _tiles
                t.cover()
            Next
        End Sub

        ''' <summary>
        ''' Returns the tile at the specified column and row.
        ''' </summary>
        ''' <param name="column">A zero-based column index.</param>
        ''' <param name="row">A zero-based row index.</param>
        ''' <returns></returns>
        Public Function tile_at(column As Integer, row As Integer) As tile

            If column >= num_cols OrElse column < 0 Then Throw New ArgumentOutOfRangeException(
                "Attempted to get a tile in an invalid column."
                )
            If row >= num_rows OrElse row < 0 Then Throw New ArgumentOutOfRangeException(
                "Attempted to get a tile in an invalid row."
                )

            Return _tiles(column + row * num_cols)

        End Function

        ''' <summary>
        ''' Returns the tile at the specified index.
        ''' For this the tiles are arranged in a list that results from all rows being concatenated.
        ''' </summary>
        ''' <param name="index">A zero-based index.</param>
        ''' <returns></returns>
        Public Function tile_at(index As Integer) As tile

            If index >= _tiles.Count OrElse index < 0 Then Throw New ArgumentOutOfRangeException(
                "Attempted to get a tile at an invalid index."
                )

            Return _tiles(index)

        End Function

    End Class

End Namespace
