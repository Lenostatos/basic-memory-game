Namespace tile_database

    Public Interface i_database

        ''' <summary>
        ''' Initializes a connection to the database used by all database objects.
        ''' </summary>
        ''' <param name="file_path"></param>
        Sub initialize(file_path As String)

        ''' <summary>
        ''' Returns the tile items stored in the database.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property items As IEnumerable(Of DTOs.Item)
        ReadOnly Property item_count As Integer

        ReadOnly Property representations As IEnumerable(Of DTOs.Representation_Count)
        ReadOnly Property representation_count As Integer

        ''' <summary>
        ''' Returns all representations of a tile item.
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Function get_representations_by_item(item As DTOs.Item) As IEnumerable(Of DTOs.Representation_Count)

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
        ''' Returns a dictionary with the number of available
        ''' representations for each tile.
        ''' </summary>
        ''' <returns>A dictionary with tile ids as the keys and
        ''' representation counts as the values.</returns>
        ReadOnly Property tile_ids_with_representation_counts As IDictionary(Of Integer, Integer)

    End Interface

End Namespace
