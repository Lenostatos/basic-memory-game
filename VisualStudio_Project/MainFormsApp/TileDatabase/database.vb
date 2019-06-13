Namespace tile_database

    Public Class database

        Implements i_database

        Public Const EXCEPTION_MESSAGE_COULD_NOT_FIND_DATABASE As String =
            "Could not find a database file at the specified path."

        Private _file_path As String

        ''' <summary>
        ''' Initializes the database with a path to a file-based database.
        ''' </summary>
        ''' <param name="file_path"></param>
        Public Sub New(file_path As String)
            Throw New NotImplementedException()
        End Sub

        Public ReadOnly Property items As HashSet(Of i_item) Implements i_database.items
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

        Public Function get_representations(i_item As Integer) As HashSet(Of i_representation_file_info) Implements i_database.get_representations
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
