Imports MicroLite

Namespace tile_database.service

    Public Module File_Info

        ''' <summary>
        ''' Returns all File_Info records.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property all() As IEnumerable(Of DTOs.File_Info)
            Get

                Dim return_items As IEnumerable(Of DTOs.File_Info)

                Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                    Using transaction As ITransaction = session.BeginTransaction()
                        return_items = session.Fetch(Of DTOs.File_Info)(SQL_register.File_Info.select_all())
                        transaction.Commit()
                    End Using
                End Using

                Return return_items

            End Get
        End Property

        ''' <summary>
        ''' Returns the number of File_Info records stored in the database.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property count() As Integer
            Get

                Dim return_value As Integer

                Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                    Using transaction As ITransaction = session.BeginTransaction()
                        return_value = session.Single(Of Integer)(SQL_register.File_Info.count())
                        transaction.Commit()
                    End Using
                End Using

                Return return_value

            End Get
        End Property

        ''' <summary>
        ''' Returns all files (aka File_Infos) for a certain item.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function get_for_Item_id(id As Integer) As IEnumerable(Of DTOs.File_Info)

            Dim return_items As IEnumerable(Of DTOs.File_Info)

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_items = session.Fetch(Of DTOs.File_Info)(SQL_register.File_Info.select_by_item_id(id))
                    transaction.Commit()
                End Using
            End Using

            Return return_items

        End Function

    End Module

End Namespace
