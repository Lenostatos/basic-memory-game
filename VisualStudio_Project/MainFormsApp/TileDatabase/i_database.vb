Namespace tile_database

    Public Interface i_database

        ''' <summary>
        ''' Initializes a connection to the database used by all database objects.
        ''' </summary>
        ''' <param name="file_path"></param>
        Sub initialize(file_path As String)

        ReadOnly Property file_path As String


        '' ------------------------------------------------------------------------------------------------------
        '' Information on database content
        '' ------------------------------------------------------------------------------------------------------

        ''' <summary>
        ''' Returns the number of tile items stored in the database.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property item_count As Integer

        ''' <summary>
        ''' Returns the highest number of representations that one or
        ''' more items in the database are associated with.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property max_num_files_per_item As Integer

        ''' <summary>
        ''' Returns the lowest number of representations that one or
        ''' more items in the database are associated with.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property min_num_files_per_item As Integer

        ''' <summary>
        ''' Returns the number of items that are associated with exactly
        ''' <paramref name="num_files"/> files in the database.
        ''' </summary>
        ''' <param name="num_files"></param>
        ''' <returns></returns>
        Function get_num_items_with_exactly_num_files(num_files As Integer) As Integer

        ''' <summary>
        ''' Returns the number of items that are associated with at least
        ''' <paramref name="num_files"/> files in the database.
        ''' </summary>
        ''' <param name="num_files"></param>
        ''' <returns></returns>
        Function count_items_with_at_least_num_files(num_files As Integer) As Integer

        ''' <summary>
        ''' Returns the maximum number of files that the <paramref name="num_items"/> items with the
        ''' highest numbers of files can all provide.
        ''' </summary>
        ''' <param name="num_items"></param>
        ''' <returns></returns>
        Function get_shared_num_files_among_num_items_items_with_highest_file_count(num_items) As Integer

        ''' <summary>
        ''' Maps numbers of files to the number of those items that are
        ''' associated with at least that many files.
        ''' </summary>
        ''' <returns>A dictionary where the keys represent numbers of
        ''' files and the values represent the number of those items
        ''' that are associated with at least that many files.</returns>
        ReadOnly Property map_num_files_to_num_of_items_with_at_least_that_many As IDictionary(Of Integer, Integer)

        ''' <summary>
        ''' Maps numbers of files to the number of those items that are
        ''' associated with at exactly that many files.
        ''' </summary>
        ''' <returns>A dictionary where the keys represent numbers of
        ''' files and the values represent the number of those items
        ''' that are associated with exactly that many files.</returns>
        ReadOnly Property map_num_files_to_num_of_items_with_exactly_that_many As IDictionary(Of Integer, Integer)


        '' ------------------------------------------------------------------------------------------------------
        '' Get actual data
        '' ------------------------------------------------------------------------------------------------------

        ''' <summary>
        ''' Returns the tile items stored in the database.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property items As IEnumerable(Of dto.Item)

        ''' <summary>
        ''' Returns information on all files that are associated with <paramref name="item"/>.
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Function files_for_item(item As dto.Item) As IEnumerable(Of dto.File_Info)

        ''' <summary>
        ''' Returns information on all files that are associated with
        ''' an item with a certain <paramref name="id"/>.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Function files_for_item_id(id As Integer) As IEnumerable(Of dto.File_Info)

        ''' <summary>
        ''' Returns all items that are associated with at least <paramref name="num_files"/>
        ''' files.
        ''' </summary>
        ''' <param name="num_files"></param>
        ''' <returns></returns>
        Function items_with_at_least_num_files(num_files As Integer) As IEnumerable(Of dto.Item)

        ''' <summary>
        ''' Returns all items that are associated with exactly <paramref name="num_files"/>
        ''' files.
        ''' </summary>
        ''' <param name="num_files"></param>
        ''' <returns></returns>
        Function items_with_exactly_num_files(num_files As Integer) As IEnumerable(Of dto.Item)

    End Interface

End Namespace
