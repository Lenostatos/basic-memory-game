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

        ''' <summary>
        ''' Returns all different representations of the items in the database.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property item_representations As IEnumerable(Of DTOs.File_Info)
        ReadOnly Property representation_count As Integer

        ''' <summary>
        ''' Returns all representations of a tile item.
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Function get_representations_for_item(item As DTOs.Item) As IEnumerable(Of DTOs.Representation_Count)

        Function get_item_with_least_representations() As DTOs.Item
        ''' <summary>
        ''' Returns the number of representations for the tile item that
        ''' has the least representations associated with it.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property min_number_of_representations As Integer

        Function get_item_with_most_representations() As DTOs.Item
        ''' <summary>
        ''' Returns the number of representations for the tile item that
        ''' has the most representations associated with it.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property max_number_of_representations As Integer

        ''' <summary>
        ''' Returns a dictionary with tiles and the number of representations
        ''' available for each of them.
        ''' </summary>
        ''' <returns>A dictionary with tiles as the keys and counts of
        ''' representations as the values.</returns>
        ReadOnly Property tiles_with_representation_counts As IDictionary(Of DTOs.Item, Integer)

    End Interface

End Namespace
