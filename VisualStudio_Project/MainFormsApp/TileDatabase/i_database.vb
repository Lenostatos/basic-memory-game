Namespace tile_database

    Public Interface i_database

        ''' <summary>
        ''' Returns the tile items stored in the database.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property items As HashSet(Of i_item)

        ''' <summary>
        ''' Returns the number of representations for the tile item that
        ''' has the least representations associated with it.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property min_number_of_representations As Integer

        ''' <summary>
        ''' Returns the number of representations for the tile item that
        ''' has the most representations associated with it.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property max_number_of_representations As Integer

        ''' <summary>
        ''' Returns information on all representations of a tile item.
        ''' </summary>
        ''' <param name="i_item"></param>
        ''' <returns></returns>
        Function get_representations(i_item As Integer) As HashSet(Of i_representation_file_info)

    End Interface

End Namespace
