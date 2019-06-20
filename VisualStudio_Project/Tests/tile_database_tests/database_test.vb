Imports MainFormsApp.tile_database

Namespace tile_database_test

    ''' <summary>
    ''' This class only tests the database methods that do more than just
    ''' call a service method.
    ''' <TODO>Implement more tests for this.</TODO>
    ''' </summary>
    <TestClass>
    Public Class database_test

        <TestMethod>
        Public Sub initialize_w_valid_arguments()
            Dim my_db As New database()
            my_db.initialize(database.TEST_PATH)
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

            Assert.ThrowsException(Of ArgumentException)(
                Sub()
                    my_db.initialize("../../../../data/tree_species_tile_set/pine/english_name.txt")
                End Sub, database.EXCEPTION_MESSAGE_COULD_NOT_CONNECT_TO_DATABASE)

        End Sub

    End Class

End Namespace
