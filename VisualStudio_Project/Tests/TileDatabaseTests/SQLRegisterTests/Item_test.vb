Imports MainFormsApp.tile_database
Imports MainFormsApp.tile_database.SQL_register

Namespace tile_database_test.SQL_register_test

    <TestClass>
    Public Class Item_test

        ''' <summary>
        ''' As it is not possible to test more than the basic funtionality
        ''' of the entity framework like this, no further tests of the SQL
        ''' registers will be conducted.
        ''' </summary>
        <TestMethod>
        Public Sub get_item_by_name()

            Dim my_db As New database()
            my_db.initialize(database.DEFAULT_PATH)

            Assert.AreEqual("SELECT * FROM ""Item"" WHERE ""name"" = @p0", Item.select_by_name("oak").CommandText)
            Assert.AreEqual("oak", Item.select_by_name("oak").Arguments(0).Value)

        End Sub

    End Class

End Namespace
