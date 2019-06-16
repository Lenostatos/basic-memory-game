Namespace tile_database

    ''' <summary>
    ''' A tile item stored in the database.
    ''' </summary>
    Public Interface i_item

        ReadOnly Property id As Integer
        ReadOnly Property name As String
        ReadOnly Property representations As IReadOnlyList(Of i_representation_file)

    End Interface

End Namespace
