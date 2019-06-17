Imports MicroLite

Namespace tile_database.service

    Public Module File_Count

        ''' <summary>
        ''' Returns all File_Count records in the database.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property all() As IEnumerable(Of DTOs.File_Count)
            Get

                Dim return_counts As IEnumerable(Of DTOs.File_Count)

                Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                    Using transaction As ITransaction = session.BeginTransaction()
                        return_counts = session.Fetch(Of DTOs.File_Count)(SQL_register.File_Count.all())
                        transaction.Commit()
                    End Using
                End Using

                Return return_counts

            End Get
        End Property

        ''' <summary>
        ''' Returns all File_Count records with a file count of <paramref name="count"/>.
        ''' </summary>
        ''' <param name="count"></param>
        ''' <returns></returns>
        Public Function get_for_count(count As Integer) As IEnumerable(Of DTOs.File_Count)

            Dim return_counts As IEnumerable(Of DTOs.File_Count)

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_counts = session.Fetch(Of DTOs.File_Count)(
                        SQL_register.File_Count.by_count(count))
                    transaction.Commit()
                End Using
            End Using

            Return return_counts

        End Function

        ''' <summary>
        ''' Returns the number of files for an item.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function count_files_for_Item_id(id As Integer) As Integer

            Dim return_count As Integer

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_count = session.Single(Of Integer)(SQL_register.File_Count.count_for_item_id(id))
                    transaction.Commit()
                End Using
            End Using

            Return return_count

        End Function

        ''' <summary>
        ''' Returns the maximum number of files that an item is associated with.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property max_count() As Integer
            Get

                Dim return_count As Integer

                Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                    Using transaction As ITransaction = session.BeginTransaction()
                        return_count = session.Single(Of Integer)(SQL_register.File_Count.max_count())
                        transaction.Commit()
                    End Using
                End Using

                Return return_count

            End Get
        End Property

        ''' <summary>
        ''' Returns the minimum number of files that an item is associated with.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property min_count() As Integer
            Get

                Dim return_count As Integer

                Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                    Using transaction As ITransaction = session.BeginTransaction()
                        return_count = session.Single(Of Integer)(SQL_register.File_Count.min_count())
                        transaction.Commit()
                    End Using
                End Using

                Return return_count

            End Get
        End Property

        ''' <summary>
        ''' Returns the number of items that are associated with a certain number of files.
        ''' </summary>
        ''' <param name="count"></param>
        ''' <returns></returns>
        Public Function count_items_with_file_count(count As Integer) As Integer

            Dim return_count As Integer

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_count = session.Single(Of Integer)(SQL_register.File_Count.min_count())
                    transaction.Commit()
                End Using
            End Using

            Return return_count

        End Function

    End Module

End Namespace
