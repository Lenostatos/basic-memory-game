Imports MicroLite

Namespace tile_database.SQL_register

    Public Module File_Count

        ''' <summary>
        ''' Selects all File_Count records.
        ''' </summary>
        ''' <returns></returns>
        Public Function all() As SqlQuery
            Return New SqlQuery("SELECT * FROM ""File_Count""")
        End Function

        ''' <summary>
        ''' Counts the items that are associated with at least one file.
        ''' </summary>
        ''' <returns></returns>
        Public Function count() As SqlQuery
            Return New SqlQuery("SELECT COUNT(*) FROM ""File_Count""")
        End Function

        ''' <summary>
        ''' Selects all File_Count records with a certain file count.
        ''' </summary>
        ''' <param name="file_count"></param>
        ''' <returns></returns>
        Public Function by_file_count(file_count As Integer) As SqlQuery
            Return New SqlQuery("SELECT * FROM ""File_Count"" WHERE ""count"" = @p0", file_count)
        End Function

        ''' <summary>
        ''' Counts the number of files that are associated with a certain item.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function count_files_for_item_id(id As Integer) As SqlQuery
            Return New SqlQuery("SELECT ""count"" FROM ""File_Count"" WHERE ""id_item"" = @p0", id)
        End Function

        ''' <summary>
        ''' Counts the items that show a certain file count.
        ''' </summary>
        ''' <param name="file_count"></param>
        ''' <returns></returns>
        Public Function count_items_with_file_count(file_count As Integer) As SqlQuery
            Return New SqlQuery("SELECT COUNT(*) FROM ""File_Count"" WHERE ""count"" = @p0", file_count)
        End Function

        ''' <summary>
        ''' Counts the items with a file count that is equal to or
        ''' greater than <paramref name="file_count"/>.
        ''' </summary>
        ''' <param name="file_count"></param>
        ''' <returns></returns>
        Public Function count_of_equal_to_or_greater_than_file_count(file_count As Integer) As SqlQuery
            Return New SqlQuery("SELECT COUNT(*) FROM ""File_Count"" WHERE ""count"" >= @p0", file_count)
        End Function

        ''' <summary>
        ''' Selects the maximum file count.
        ''' </summary>
        ''' <returns></returns>
        Public Function max_count() As SqlQuery
            Return New SqlQuery("SELECT MAX(""count"") FROM ""File_Count""")
        End Function

        ''' <summary>
        ''' Selects the minimum file count.
        ''' </summary>
        ''' <returns></returns>
        Public Function min_count() As SqlQuery
            Return New SqlQuery("SELECT MIN(""count"") FROM ""File_Count""")
        End Function

    End Module

End Namespace