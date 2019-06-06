﻿Namespace game_logic

    ''' <summary>
    ''' Models a player that can collect matching tiles.
    ''' </summary>
    Public Class player

        Private Property _name As String
        Private Property _won_tiles As matching_tiles_set

        Public Sub New(name As String)

            If name Is Nothing Then Throw New ArgumentNullException()

            _name = name
            _won_tiles = New matching_tiles_set()

        End Sub

        Public ReadOnly Property name As String
            Get
                Return _name
            End Get
        End Property

        Public ReadOnly Property won_tiles As matching_tiles_set
            Get
                Return _won_tiles
            End Get
        End Property

        Public Sub collect_tiles(tiles As matching_tiles)
            If tiles Is Nothing Then Throw New ArgumentNullException()
            _won_tiles.Add(tiles)
        End Sub

    End Class

End Namespace
