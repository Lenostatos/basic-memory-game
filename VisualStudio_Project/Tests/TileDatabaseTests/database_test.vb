Imports MainFormsApp.tile_database

Namespace tile_database_test

    <TestClass>
    Public Class database_test

        Private _valid_path As String = "../../../../data/tree_species_tile_set/database.sqlite3"

        <TestMethod>
        Public Sub initialize_w_valid_arguments()
            Dim my_db As New database(_valid_path)
        End Sub

        <TestMethod>
        Public Sub initialize_w_invalid_arguments()

            Assert.ThrowsException(Of ArgumentException)(
                Sub()
                    Dim my_db As New database("../../../data/tree_species_tile_set/database.sqlite3")
                End Sub, database.EXCEPTION_MESSAGE_COULD_NOT_FIND_DATABASE)

            Assert.ThrowsException(Of ArgumentException)(
                Sub()
                    Dim my_db As New database("../../../../data/tree_species_tile_set/database")
                End Sub, database.EXCEPTION_MESSAGE_COULD_NOT_FIND_DATABASE)

            Assert.ThrowsException(Of ArgumentException)(
                Sub()
                    Dim my_db As New database("../../../../data/tree_species_tile_set/databas.sqlite3")
                End Sub, database.EXCEPTION_MESSAGE_COULD_NOT_FIND_DATABASE)

        End Sub

        <TestMethod>
        Public Sub get_items()

            Dim my_database As New database(_valid_path)

            Dim items As New List(Of i_item)(my_database.items)

        End Sub

    End Class

End Namespace
