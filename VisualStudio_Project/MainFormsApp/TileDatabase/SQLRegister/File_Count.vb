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
        ''' Selects all File_Count records that show a certain value in
        ''' the count column.
        ''' </summary>
        ''' <param name="count"></param>
        ''' <returns></returns>
        Public Function by_count(count As Integer) As SqlQuery
            Return New SqlQuery("SELECT * FROM ""File_Count"" WHERE ""count"" = @p0", count)
        End Function

        ''' <summary>
        ''' Selects the number of files that are associated with an item.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function count_for_item_id(id As Integer) As SqlQuery
            Return New SqlQuery("SELECT ""count"" FROM ""File_Count"" WHERE ""id_item"" = @p0", id)
        End Function

        ''' <summary>
        ''' Selects the number of records that show a certain value in the
        ''' count column.
        ''' </summary>
        ''' <param name="count"></param>
        ''' <returns></returns>
        Public Function count_of_specific_count(count As Integer) As SqlQuery
            Return New SqlQuery("SELECT COUNT(*) FROM ""File_Count"" WHERE ""count"" = @p0", count)
        End Function

        ''' <summary>
        ''' Selects the maximum value in the count column.
        ''' </summary>
        ''' <returns></returns>
        Public Function max_count() As SqlQuery
            Return New SqlQuery("SELECT MAX(""count"") FROM ""File_Count""")
        End Function

        ''' <summary>
        ''' Selects the minimum value in the count column.
        ''' </summary>
        ''' <returns></returns>
        Public Function min_count() As SqlQuery
            Return New SqlQuery("SELECT MIN(""count"") FROM ""File_Count""")
        End Function

    End Module

End Namespace