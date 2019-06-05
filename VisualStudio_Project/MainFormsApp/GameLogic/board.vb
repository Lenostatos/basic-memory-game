Imports System.Collections.Generic

Namespace game_logic

    '''' <summary>
    '''' Models a rectangular board of memory tiles.
    '''' </summary>
    'Public Class board

    '    ''' <summary>
    '    ''' The number of tiles per row.
    '    ''' </summary>
    '    Public ReadOnly Property num_cols As Integer
    '        Get
    '            Return _num_cols
    '        End Get
    '    End Property

    '    ''' <summary>
    '    ''' The number of rows.
    '    ''' </summary>
    '    Public ReadOnly Property num_rows As Integer
    '        Get
    '            Return Math.Ceiling(_tile_groups.count_of_single_tiles / num_cols)
    '        End Get
    '    End Property

    '    ''' <summary>
    '    ''' Returns the number of tiles on the board.
    '    ''' </summary>
    '    ''' <returns></returns>
    '    Public ReadOnly Property num_tiles As Integer
    '        Get
    '            Return _tile_groups.count_of_single_tiles
    '        End Get
    '    End Property

    '    ''' <summary>
    '    ''' Returns the number of tiles that match with each other.
    '    ''' </summary>
    '    ''' <returns></returns>
    '    Public ReadOnly Property tile_tuple_size As Integer
    '        Get
    '            Return _tile_groups.First().Count
    '        End Get
    '    End Property

    '    Private Property _tile_groups As tile_game_set
    '    Private Property _num_cols As Integer

    '    ''' <summary>
    '    ''' Creates a new board from the passed tiles.
    '    ''' All tiles are covered and put into a random order.
    '    ''' </summary>
    '    ''' <param name="width"></param>
    '    ''' <param name="tile_groups"></param>
    '    Public Sub New(width As Integer, tile_groups As tile_game_set)

    '        If tile_groups Is Nothing Then Throw New ArgumentNullException(
    '            "Attempted to initialize a board without tiles."
    '            )

    '        If width < 1 Then Throw New ArgumentOutOfRangeException(
    '            "Attempted to initialize a memory board with a width lower than 1."
    '            )
    '        If width > tile_groups.count_of_single_tiles Then Throw New ArgumentOutOfRangeException(
    '            "Attempted to initialize a memory board with a width 
    '            higher than the number of given tiles."
    '            )

    '        _num_cols = width
    '        _tile_groups = tile_groups

    '        shuffle_tiles()

    '        For Each t As tile In _tile_groups.tiles
    '            t.cover()
    '        Next

    '    End Sub

    '    ''' <summary>
    '    ''' Shuffles the tiles on the board.
    '    ''' </summary>
    '    Private Sub shuffle_tiles()
    '        _tile_groups = utility.functions.shuffle_collection(Of tile)(_tile_groups)
    '    End Sub

    '    ''' <summary>
    '    ''' Covers all tiles on the board.
    '    ''' </summary>
    '    Public Sub cover_tiles()
    '        For Each t As tile In _tile_groups.tiles
    '            t.cover()
    '        Next
    '    End Sub

    '    ''' <summary>
    '    ''' Returns the tile at the specified column and row.
    '    ''' </summary>
    '    ''' <param name="column">A zero-based column index.</param>
    '    ''' <param name="row">A zero-based row index.</param>
    '    ''' <returns></returns>
    '    Public Function tile_at(column As Integer, row As Integer) As tile

    '        If column >= num_cols OrElse column < 0 Then Throw New ArgumentOutOfRangeException(
    '            "Attempted to get a tile in an invalid column."
    '            )
    '        If row >= num_rows OrElse row < 0 Then Throw New ArgumentOutOfRangeException(
    '            "Attempted to get a tile in an invalid row."
    '            )

    '        Return _tile_groups.tiles(column + row * num_cols)

    '    End Function

    '    ''' <summary>
    '    ''' Returns the tile at the specified index.
    '    ''' For this the tiles are arranged in a list that results from all rows being concatenated.
    '    ''' </summary>
    '    ''' <param name="index">A zero-based index.</param>
    '    ''' <returns></returns>
    '    Public Function tile_at(index As Integer) As tile

    '        If index >= _tile_groups.count_of_single_tiles OrElse index < 0 Then Throw New ArgumentOutOfRangeException(
    '            "Attempted to get a tile at an invalid index."
    '            )

    '        Return _tile_groups.tiles(index)

    '    End Function

    'End Class

End Namespace
