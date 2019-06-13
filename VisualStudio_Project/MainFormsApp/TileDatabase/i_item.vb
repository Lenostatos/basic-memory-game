Namespace tile_database

    ''' <summary>
    ''' A tile item stored in the database.
    ''' </summary>
    Public Interface i_item

        ReadOnly Property id As Integer
        ReadOnly Property name As String
        ReadOnly Property number_of_representations As Integer

    End Interface

End Namespace
