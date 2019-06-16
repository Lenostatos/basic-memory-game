Imports MicroLite

Namespace tile_database.service

    Public Module Representation_Count

        Public Function all() As IEnumerable(Of DTOs.Representation_Count)

            Dim return_counts As IEnumerable(Of DTOs.Representation_Count)

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_counts = session.Fetch(Of DTOs.Representation_Count)(SQL_register.Representation_Count.select_all())
                    transaction.Commit()
                End Using
            End Using

            Return return_counts

        End Function

        Public Function get_for_Item_id(id As Integer) As DTOs.Representation_Count

            Dim return_count As DTOs.Representation_Count

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_count = session.Single(Of DTOs.Representation_Count)(SQL_register.Representation_Count.select_by_item_id(id))
                    transaction.Commit()
                End Using
            End Using

            Return return_count

        End Function

        Public Function get_max() As DTOs.Representation_Count

            Dim return_count As DTOs.Representation_Count

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_count = session.Single(Of DTOs.Representation_Count)(SQL_register.Representation_Count.select_max())
                    transaction.Commit()
                End Using
            End Using

            Return return_count

        End Function

        Public Function get_min() As DTOs.Representation_Count

            Dim return_count As DTOs.Representation_Count

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_count = session.Single(Of DTOs.Representation_Count)(SQL_register.Representation_Count.select_min())
                    transaction.Commit()
                End Using
            End Using

            Return return_count

        End Function

    End Module

End Namespace
