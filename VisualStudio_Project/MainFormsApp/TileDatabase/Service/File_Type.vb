Imports MicroLite

Namespace tile_database.service

    Public Module File_Type

        Public Function all() As IEnumerable(Of dto.File_Type)

            Dim return_types As IEnumerable(Of dto.File_Type)

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_types = session.Fetch(Of dto.File_Type)(SQL_register.File_Type.select_all())
                    transaction.Commit()
                End Using
            End Using

            Return return_types

        End Function

        Public Function count() As Integer

            Dim return_value As Integer

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_value = session.Single(Of Integer)(SQL_register.File_Type.count())
                    transaction.Commit()
                End Using
            End Using

            Return return_value

        End Function

        Public Function get_by_id(id As Integer) As dto.File_Type

            Dim return_type As dto.File_Type

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_type = session.Single(Of dto.File_Type)(id)
                    transaction.Commit()
                End Using
            End Using

            Return return_type

        End Function

    End Module

End Namespace
