﻿Namespace tile_database.DTOs

    Public Class Item

        Implements IEquatable(Of Item)

        Public Property id As Integer
        Public Property name As String

        Public Overrides Function Equals(other As Object) As Boolean

            If other Is Nothing Then
                Return False
            ElseIf TypeOf other Is Item Then
                Return id = other.id
            Else
                Return MyBase.Equals(other)
            End If

        End Function

        Public Overloads Function Equals(other As Item) As Boolean Implements IEquatable(Of Item).Equals
            Return other IsNot Nothing AndAlso id = other.id
        End Function
    End Class

End Namespace
