Imports MicroLite

Namespace tile_database.SQL_register

    Public Module Representation_Count

        Public Function select_all() As SqlQuery
            Return New SqlQuery("SELECT * FROM ""Representation_Count""")
        End Function

        Public Function select_by_item_id(id As Integer) As SqlQuery
            Return New SqlQuery("SELECT * FROM ""Representation_Count"" WHERE ""id_item"" = @p0", id)
        End Function

        Public Function select_max() As SqlQuery
            Return New SqlQuery("SELECT ""id_item"", MAX(""count"") AS ""count"" FROM ""Representation_Count""")
        End Function

        Public Function select_min() As SqlQuery
            Return New SqlQuery("SELECT ""id_item"", MIN(""count"") AS ""count"" FROM ""Representation_Count""")
        End Function

    End Module

End Namespace