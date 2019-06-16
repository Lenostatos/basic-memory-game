Imports MicroLite

Namespace tile_database.service

    Public Module File_Info

        Public Function all() As IEnumerable(Of DTOs.File_Info)

            Dim return_items As IEnumerable(Of DTOs.File_Info)

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_items = session.Fetch(Of DTOs.File_Info)(SQL_register.File_Info.select_all())
                    transaction.Commit()
                End Using
            End Using

            Return return_items

        End Function

        Public Function count() As Integer

            Dim return_value As Integer

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_value = session.Single(Of Integer)(SQL_register.File_Info.count())
                    transaction.Commit()
                End Using
            End Using

            Return return_value

        End Function

        Public Function get_for_Item(item As DTOs.Item) As IEnumerable(Of DTOs.File_Info)

            Dim return_items As IEnumerable(Of DTOs.File_Info)

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_items = session.Fetch(Of DTOs.File_Info)(SQL_register.File_Info.select_by_item_id(item.id))
                    transaction.Commit()
                End Using
            End Using

            Return return_items

        End Function

    End Module

End Namespace
