Imports MainFormsApp.game_logic

Namespace controller.UI.game_setup

    Public Class database_selection

        Private Property _database As tile_database.i_database

        Public Sub New()
            _database = New tile_database.database()
        End Sub

        Public ReadOnly Property database As tile_database.i_database
            Get
                Return _database
            End Get
        End Property

        Public ReadOnly Property default_database_path As String
            Get
                Return tile_database.database.DEFAULT_PATH
            End Get
        End Property

        Public Sub choose_file_path(path As String)
            _database.initialize(path)
        End Sub

    End Class

End Namespace
