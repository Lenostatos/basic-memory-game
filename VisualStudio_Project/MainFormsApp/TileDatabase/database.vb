Imports MainFormsApp.tile_database.DTOs
Imports MicroLite
Imports MicroLite.Configuration

Namespace tile_database

    Public Class database

        Implements i_database

        Public Const EXCEPTION_MESSAGE_COULD_NOT_FIND_FILE As String =
            "Could not find any file at the specified path."
        Public Const EXCEPTION_MESSAGE_COULD_NOT_CONNECT_TO_DATABASE As String =
            "Could not connect to the database at the specified path."

        Public Const DEFAULT_PATH As String =
            "../../../../data/tree_species_tile_set/database.sqlite3"

        Private Shared Property _file_path As String
        Private Shared Property _session_factory As ISessionFactory

        ''' <summary>
        ''' Indicates whether the EF's mapping conventions have been customised.
        ''' </summary>
        Private Shared Property _customised_mapping_conventions As Boolean = False

        Public Shared ReadOnly Property file_path As String
            Get
                Return _file_path
            End Get
        End Property

        Public Shared ReadOnly Property session_factory As ISessionFactory
            Get
                Return _session_factory
            End Get
        End Property

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

            Dim return_factory As ISessionFactory

            Try
                return_factory =
                Configure.Fluently().
                ForSQLiteConnection("dummy", "Data Source =" & file_path &
                    "; Version = 3; ForeignKeyConstraints = On;", "System.Data.SQLite").
                CreateSessionFactory()
            Catch ex As MicroLiteException
                Throw New ArgumentException(EXCEPTION_MESSAGE_COULD_NOT_CONNECT_TO_DATABASE, ex)
            End Try

            Return return_factory

        End Function

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
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property representations As IEnumerable(Of Representation_Count) Implements i_database.representations
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property representation_count As Integer Implements i_database.representation_count
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property min_number_of_representations As Integer Implements i_database.min_number_of_representations
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property max_number_of_representations As Integer Implements i_database.max_number_of_representations
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property tile_ids_with_representation_counts As IDictionary(Of Integer, Integer) Implements i_database.tile_ids_with_representation_counts
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public Function get_representations_by_item(item As Item) As IEnumerable(Of Representation_Count) Implements i_database.get_representations_by_item
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
