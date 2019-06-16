Imports MicroLite

Namespace tile_database.SQL_register

    Public Module File_Type

        Public Function select_all() As SqlQuery
            Return New SqlQuery("SELECT * FROM ""File_Type""")
        End Function

        Public Function count() As SqlQuery
            Return New SqlQuery("SELECT COUNT(*) FROM ""File_Type""")
        End Function

    End Module

End Namespace
