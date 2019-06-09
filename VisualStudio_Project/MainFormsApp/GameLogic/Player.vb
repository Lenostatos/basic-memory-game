Namespace game_logic

    ''' <summary>
    ''' Models a player that can collect matching tiles.
    ''' </summary>
    Public Class player

        Implements IEquatable(Of player)

        Private Property _name As String
        Private Property _won_tile_sets As matching_tiles_set

        Public Sub New(name As String)

            If name Is Nothing Then Throw New ArgumentNullException()
            If name = "" Then Throw New ArgumentException()

            _name = name
            _won_tile_sets = New matching_tiles_set()

        End Sub

        Public ReadOnly Property name As String
            Get
                Return _name
            End Get
        End Property

        Public ReadOnly Property won_tile_sets As matching_tiles_set
            Get
                Return _won_tile_sets
            End Get
        End Property

        Public Sub collect_tiles(tiles As matching_tiles)
            If tiles Is Nothing Then Throw New ArgumentNullException()
            _won_tile_sets.Add(tiles)
        End Sub

        Public Overrides Function Equals(obj As Object) As Boolean
            Return Equals(TryCast(obj, player))
        End Function

        Public Overloads Function Equals(other As player) As Boolean Implements IEquatable(Of player).Equals
            Return other IsNot Nothing AndAlso
                   _name = other._name
        End Function

        Public Overrides Function GetHashCode() As Integer
            Dim hashCode As Long = -1647798067
            hashCode = (hashCode * -1521134295 + EqualityComparer(Of String).Default.GetHashCode(_name)).GetHashCode()
            Return hashCode
        End Function

        Public Overrides Function ToString() As String
            Return name
        End Function
    End Class

End Namespace
