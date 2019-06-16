Imports MicroLite

Namespace tile_database.SQL_register

    Public Module File_Info

        Public Function select_all() As SqlQuery
            Return New SqlQuery("SELECT * FROM ""File_Info""")
        End Function

        Public Function count() As SqlQuery
            Return New SqlQuery("SELECT COUNT(*) FROM ""File_Info""")
        End Function

        Public Function select_by_item_id(id As Integer) As SqlQuery
            Return New SqlQuery("SELECT * FROM ""File_Info"" WHERE ""id_Item"" = @p0", id)
        End Function

    End Module

End Namespace
