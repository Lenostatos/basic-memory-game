Imports MainFormsApp.tile_database

Namespace tile_database_test

    <TestClass>
    Public Class database_test

        Private _tree_species_tile_set_path As String =
            "../../../../data/tree_species_tile_set/database.sqlite3"

        <TestMethod>
        Public Sub initialize_w_valid_arguments()
            Dim my_db As New database()
            my_db.initialize(_tree_species_tile_set_path)
        End Sub

        <TestMethod>
        Public Sub initialize_w_invalid_arguments()

            Dim my_db As New database()

            Assert.ThrowsException(Of ArgumentException)(
                Sub()
                    my_db.initialize("../../../data/tree_species_tile_set/database.sqlite3")
                End Sub, database.EXCEPTION_MESSAGE_COULD_NOT_FIND_FILE)

            Assert.ThrowsException(Of ArgumentException)(
                Sub()
                    my_db.initialize("../../../../data/tree_species_tile_set/database")
                End Sub, database.EXCEPTION_MESSAGE_COULD_NOT_FIND_FILE)

            Assert.ThrowsException(Of ArgumentException)(
                Sub()
                    my_db.initialize("../../../../data/tree_species_tile_set/databas.sqlite3")
                End Sub, database.EXCEPTION_MESSAGE_COULD_NOT_FIND_FILE)

        End Sub

    End Class

End Namespace
