Imports MicroLite

Namespace tile_database.SQL_register

    Public Module Item

        Public Function select_all() As SqlQuery
            Return New SqlQuery("SELECT * FROM ""Item""")
        End Function

        Public Function count() As SqlQuery
            Return New SqlQuery("SELECT COUNT(*) FROM ""Item""")
        End Function

        Public Function select_by_name(name As String) As SqlQuery
            Return New SqlQuery("SELECT * FROM ""Item"" WHERE ""name"" = @p0", name)
        End Function

    End Module

End Namespace
