Imports MicroLite

Namespace tile_database.service

    Public Module Item

        ''' <summary>
        ''' Returns all items stored in the database.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property all() As IEnumerable(Of DTOs.Item)
            Get

                Dim return_items As IEnumerable(Of DTOs.Item)

                Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                    Using transaction As ITransaction = session.BeginTransaction()
                        return_items = session.Fetch(Of DTOs.Item)(SQL_register.Item.select_all())
                        transaction.Commit()
                    End Using
                End Using

                Return return_items

            End Get
        End Property

        ''' <summary>
        ''' Returns the number of items stored in the database.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property count() As Integer
            Get

                Dim return_value As Integer

                Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                    Using transaction As ITransaction = session.BeginTransaction()
                        return_value = session.Single(Of Integer)(SQL_register.Item.count())
                        transaction.Commit()
                    End Using
                End Using

                Return return_value

            End Get
        End Property

        ''' <summary>
        ''' Gets an item record based on an id.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function get_by_id(id As Integer) As DTOs.Item

            Dim return_item As DTOs.Item

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_item = session.Single(Of DTOs.Item)(id)
                    transaction.Commit()
                End Using
            End Using

            Return return_item

        End Function

        ''' <summary>
        ''' Gets an item record based on an item's name.
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function get_by_name(name As String) As DTOs.Item

            If name = "" Then Throw New ArgumentException()

            Dim return_item As DTOs.Item

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_item = session.Single(Of DTOs.Item)(SQL_register.Item.select_by_name(name))
                    transaction.Commit()
                End Using
            End Using

            Return return_item

        End Function

    End Module

End Namespace
