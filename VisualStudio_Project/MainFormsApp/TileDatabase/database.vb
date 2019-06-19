Imports MainFormsApp.tile_database.DTOs
Imports MicroLite
Imports MicroLite.Configuration

Namespace tile_database

    Public Class database

        Implements i_database

        Public Const EXCEPTION_MESSAGE_COULD_NOT_FIND_FILE As String =
            "Could not find any file at the specified path."
        Public Const EXCEPTION_MESSAGE_COULD_NOT_CONNECT_TO_DATABASE As String =
            "Could not connect to a database at the specified path."

        Public Const DEFAULT_PATH As String =
            "../../../../data/test_tile_set/database.sqlite3"

        Private Shared Property _file_path As String
        Private Shared Property _session_factory As ISessionFactory

        ''' <summary>
        ''' Indicates whether the EF's mapping conventions have been customised.
        ''' </summary>
        Private Shared Property _customised_mapping_conventions As Boolean = False

        Public Shared ReadOnly Property shared_file_path As String
            Get
                Return _file_path
            End Get
        End Property

        Public Shared ReadOnly Property session_factory As ISessionFactory
            Get
                Return _session_factory
            End Get
        End Property

        Private Shared Function build_connection_string(file_path As String) As String
            Return "Data Source =" & file_path & "; Version = 3; ForeignKeyConstraints = On;"
        End Function

        ''' <summary>
        ''' Returns a session factory that can be used by the database objects
        ''' to connect to a file database.
        ''' </summary>
        ''' <param name="file_path">A path that points to an sqlite3 database file
        ''' which organizes files for a tile set.</param>
        ''' <returns></returns>
        Private Shared Function initialize_session_factory(file_path As String) As ISessionFactory

            If Not My.Computer.FileSystem.FileExists(file_path) Then
                Throw New ArgumentException(EXCEPTION_MESSAGE_COULD_NOT_FIND_FILE)
            End If

            test_database_schema(build_connection_string(file_path))

            Dim return_factory As ISessionFactory

            return_factory =
                Configure.Fluently().
                ForSQLiteConnection("tile_database_connection",
                                    build_connection_string(file_path),
                                    "System.Data.SQLite").
                CreateSessionFactory()

            Return return_factory

        End Function

        ''' <summary>
        ''' Tests the structure of the database at the specified <paramref name="connection_string"/>.
        ''' </summary>
        ''' <TODO>Also test table names, column names and column types.</TODO>
        ''' <param name="connection_string"></param>
        Public Shared Sub test_database_schema(connection_string As String)

            Dim test_connection As New SQLite.SQLiteConnection(connection_string)
            test_connection.Open()
            Try
                test_connection.GetSchema("tables")
            Catch ex As Exception
                Throw New ArgumentException(EXCEPTION_MESSAGE_COULD_NOT_CONNECT_TO_DATABASE, ex)
            Finally
                test_connection.Close()
            End Try

        End Sub

        ''' <summary>
        ''' Customises the EF's mapping conventions to fit the database's naming scheme.
        ''' </summary>
        Private Shared Sub customise_mapping_conventions()

            Dim custom_mapping_convention_settings As New Mapping.ConventionMappingSettings

            With custom_mapping_convention_settings

                .UsePluralClassNameForTableName = False
                .IsIdentifier = Function(property_info As Reflection.PropertyInfo) As Boolean
                                    Return property_info.Name.Equals("id")
                                End Function
                .ResolveColumnName = Function(property_info As Reflection.PropertyInfo) As String
                                         Return property_info.Name
                                     End Function

            End With

            Configure.Extensions().WithConventionBasedMapping(custom_mapping_convention_settings)

        End Sub

        Public Sub New()
        End Sub

        ''' <summary>
        ''' Sets the session factory and file path used by all database objects.
        ''' </summary>
        ''' <param name="file_path"></param>
        Public Sub initialize(file_path As String) Implements i_database.initialize

            If Not _customised_mapping_conventions Then
                customise_mapping_conventions()
                _customised_mapping_conventions = True
            End If

            _session_factory = initialize_session_factory(file_path)
            _file_path = file_path

        End Sub

        Public ReadOnly Property items As IEnumerable(Of Item) Implements i_database.items
            Get
                Return service.Item.all()
            End Get
        End Property

        Public ReadOnly Property item_count As Integer Implements i_database.item_count
            Get
                Return service.Item.count()
            End Get
        End Property

        Public ReadOnly Property max_num_files_per_item As Integer Implements i_database.max_num_files_per_item
            Get
                Return service.File_Count.max_count()
            End Get
        End Property

        Public ReadOnly Property min_num_files_per_item As Integer Implements i_database.min_num_files_per_item
            Get
                Return service.File_Count.min_but_not_zero_file_count()
            End Get
        End Property

        Public Function get_num_items_with_exactly_num_files(num_files As Integer) As Integer Implements i_database.get_num_items_with_exactly_num_files
            Return service.File_Count.count_items_with_num_files(num_files)
        End Function

        Public Function count_items_with_at_least_num_files(num_files As Integer) As Integer Implements i_database.count_items_with_at_least_num_files
            Return service.File_Count.count_items_with_at_least_num_files(num_files)
        End Function

        Public Function get_shared_num_files_among_num_items_items_with_highest_file_count(num_items As Object) As Integer Implements i_database.get_shared_num_files_among_num_items_items_with_highest_file_count
            Return service.File_Count.shared_num_files_among_num_items_items_with_highest_file_count(num_items)
        End Function

        Public ReadOnly Property map_num_files_to_num_of_items_with_exactly_that_many As IDictionary(Of Integer, Integer) Implements i_database.map_num_files_to_num_of_items_with_exactly_that_many
            Get

                Dim return_dict As New Dictionary(Of Integer, Integer)

                For file_count As Integer = min_num_files_per_item To max_num_files_per_item
                    return_dict.Add(file_count, service.File_Count.count_items_with_num_files(file_count))
                Next

                Return return_dict

            End Get
        End Property

        Public ReadOnly Property map_num_files_to_num_of_items_with_at_least_that_many As IDictionary(Of Integer, Integer) Implements i_database.map_num_files_to_num_of_items_with_at_least_that_many
            Get

                Dim return_dict As New Dictionary(Of Integer, Integer)
                Dim cumulative_item_count As Integer = 0
                Dim num_items_with_file_count As Integer

                For file_count As Integer = max_num_files_per_item To min_num_files_per_item
                    num_items_with_file_count = service.File_Count.count_items_with_num_files(file_count)
                    cumulative_item_count = cumulative_item_count + num_items_with_file_count
                    return_dict.Add(file_count, cumulative_item_count)
                Next

                Return return_dict

            End Get
        End Property

        Public ReadOnly Property file_path As String Implements i_database.file_path
            Get
                Return database.shared_file_path
            End Get
        End Property

        Public Function files_for_item(item As Item) As IEnumerable(Of File_Info) Implements i_database.files_for_item
            Return service.File_Info.get_for_Item_id(item.id)
        End Function

        Public Function items_with_exactly_num_files(num_files As Integer) As IEnumerable(Of Item) Implements i_database.items_with_exactly_num_files

            Dim return_items As New List(Of DTOs.Item)

            For Each file_count As DTOs.File_Count In service.File_Count.get_for_count(num_files)
                return_items.Add(service.Item.get_by_id(file_count.id_Item))
            Next

            Return return_items

        End Function

        Public Function items_with_at_least_num_files(num_files As Integer) As IEnumerable(Of Item) Implements i_database.items_with_at_least_num_files

            If num_files > max_num_files_per_item Then
                Throw New ArgumentOutOfRangeException()
            End If

            Dim return_item As New List(Of DTOs.Item)

            For file_Count As Integer = num_files To max_num_files_per_item
                return_item.AddRange(items_with_exactly_num_files(file_Count))
            Next

            Return return_item

        End Function
    End Class

End Namespace
