Imports MicroLite

Namespace tile_database.service

    Public Module File_Count

        ''' <summary>
        ''' Returns all File_Count records in the database.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property all As IEnumerable(Of DTOs.File_Count)
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
        ''' Counts the items that are associated with at least one file.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property count_items_with_files As Integer
            Get

                Dim return_count As Integer

                Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                    Using transaction As ITransaction = session.BeginTransaction()
                        return_count = session.Single(Of Integer)(SQL_register.File_Count.count())
                        transaction.Commit()
                    End Using
                End Using

                Return return_count

            End Get
        End Property

        ''' <summary>
        ''' Returns all File_Count records with a file count of <paramref name="count"/>.
        ''' </summary>
        ''' <param name="count"></param>
        ''' <returns></returns>
        Public Function get_for_count(count As Integer) As IEnumerable(Of DTOs.File_Count)

            If count < 0 OrElse count > max_count Then
                Throw New ArgumentOutOfRangeException()
            End If

            Dim return_counts As IEnumerable(Of DTOs.File_Count)

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_counts = session.Fetch(Of DTOs.File_Count)(
                        SQL_register.File_Count.by_file_count(count))
                    transaction.Commit()
                End Using
            End Using

            Return return_counts

        End Function

        ''' <summary>
        ''' Returns the number of files for any item id.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function count_files_for_Item_id(id As Integer) As Integer

            Dim return_count As Integer

            Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                Using transaction As ITransaction = session.BeginTransaction()
                    return_count = session.Single(Of Integer)(SQL_register.File_Count.count_files_for_item_id(id))
                    transaction.Commit()
                End Using
            End Using

            Return return_count

        End Function

        ''' <summary>
        ''' Returns the maximum number of files that an item is associated with.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property max_count As Integer
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
        ''' Returns the minimum number of files that an item is associated with
        ''' but does not return zero, even if there is an item without
        ''' associated files.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property min_but_not_zero_file_count As Integer
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
        ''' <param name="num_files"></param>
        ''' <returns></returns>
        Public Function count_items_with_num_files(num_files As Integer) As Integer

            Select Case num_files
                Case < 0
                    Throw New ArgumentOutOfRangeException()
                Case = 0
                    Return Item.count - count_items_with_files
                Case Else

                    Dim return_count As Integer

                    Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                        Using transaction As ITransaction = session.BeginTransaction()
                            return_count = session.Single(Of Integer)(
                                SQL_register.File_Count.count_items_with_file_count(num_files))
                            transaction.Commit()
                        End Using
                    End Using

                    Return return_count

            End Select

        End Function

        ''' <summary>
        ''' Counts the items that are associated with at least
        ''' <paramref name="num_files"/> files.
        ''' </summary>
        ''' <param name="num_files"></param>
        ''' <returns></returns>
        Public Function count_items_with_at_least_num_files(num_files As Integer) As Integer

            Select Case num_files
                Case < 0
                    Throw New ArgumentOutOfRangeException()
                Case = 0
                    Return Item.count
                Case Else

                    Dim return_count As Integer

                    Using session As IReadOnlySession = database.session_factory.OpenReadOnlySession()
                        Using transaction As ITransaction = session.BeginTransaction()
                            return_count = session.Single(Of Integer)(
                                SQL_register.File_Count.count_of_equal_to_or_greater_than_file_count(num_files))
                            transaction.Commit()
                        End Using
                    End Using

                    Return return_count

            End Select

        End Function

    End Module

End Namespace
