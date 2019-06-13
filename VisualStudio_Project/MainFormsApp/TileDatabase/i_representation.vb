Namespace tile_database

    ''' <summary>
    ''' Contains information on a file that stores a representation of a tile item.
    ''' </summary>
    Public Interface i_representation_file_info

        ReadOnly Property file_path As String
        ReadOnly Property item As i_item
        ReadOnly Property file_type As String

    End Interface

End Namespace
