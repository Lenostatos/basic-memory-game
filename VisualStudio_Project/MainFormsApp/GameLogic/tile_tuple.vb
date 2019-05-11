Namespace game_logic

    ''' <summary>
    ''' Models a group of at least two matching tiles.
    ''' </summary>
    Public Class tile_tuple

        Inherits matching_tiles

        Public Sub New(collection As IEnumerable(Of tile))
            MyBase.New(collection)
            If collection.Count < 2 Then Throw New ArgumentException()
        End Sub

        Public Shadows Sub remove(t As tile)
            If Count < 3 Then
                Throw New InvalidOperationException()
            Else
                MyBase.Remove(t)
            End If
        End Sub

    End Class

End Namespace
