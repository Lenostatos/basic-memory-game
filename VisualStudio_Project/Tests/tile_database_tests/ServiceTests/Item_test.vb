Imports MainFormsApp.tile_database
Imports MainFormsApp.tile_database.service

Namespace tile_database_test.service_test

    <TestClass>
    Public Class Item_test

        Private _my_db As database = initialize_database()

        Private Function initialize_database() As database
            Dim return_db As New database()
            return_db.initialize(database.TEST_PATH)
            Return return_db
        End Function

        <TestMethod>
        Public Sub get_all()

            Dim my_items As New List(Of dto.Item)(Item.all())

            Assert.IsTrue(my_items.Contains(New dto.Item() With {.id = 1, .name = "Pine"}))
            Assert.IsTrue(my_items.Contains(New dto.Item() With {.id = 6, .name = "Beech"}))
            Assert.AreEqual(6, my_items.Count)

        End Sub

        <TestMethod>
        Public Sub count()

            Assert.AreEqual(6, Item.count())

        End Sub

        <TestMethod>
        Public Sub get_by_id()

            Assert.IsNull(Item.get_by_id(0))
            Assert.IsNull(Item.get_by_id(7))

            Dim expected_item As dto.Item

            expected_item = New dto.Item() With {.id = 1, .name = "Pine"}
            Assert.AreEqual(Item.get_by_id(1), expected_item)

            expected_item = New dto.Item() With {.id = 2, .name = "Oak"}
            Assert.AreEqual(Item.get_by_id(2), expected_item)

            expected_item = New dto.Item() With {.id = 5, .name = "Birch"}
            Assert.AreEqual(Item.get_by_id(5), expected_item)

            expected_item = New dto.Item() With {.id = 6, .name = "Beech"}
            Assert.AreEqual(Item.get_by_id(6), expected_item)

        End Sub

        <TestMethod>
        Public Sub get_by_name()

            Assert.IsNull(Item.get_by_name("foo"))

            Dim expected_item As dto.Item

            expected_item = New dto.Item() With {.id = 1, .name = "Pine"}
            Assert.AreEqual(Item.get_by_name("Pine"), expected_item)

            expected_item = New dto.Item() With {.id = 2, .name = "Oak"}
            Assert.AreEqual(Item.get_by_name("Oak"), expected_item)

            expected_item = New dto.Item() With {.id = 5, .name = "Birch"}
            Assert.AreEqual(Item.get_by_name("Birch"), expected_item)

        End Sub

    End Class

End Namespace
