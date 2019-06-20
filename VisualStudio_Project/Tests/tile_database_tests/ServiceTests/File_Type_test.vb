Imports MainFormsApp.tile_database
Imports MainFormsApp.tile_database.service

Namespace tile_database_test.service_test

    <TestClass>
    Public Class File_Type_test

        Private _my_db As database = initialize_database()

        Private Function initialize_database() As database
            Dim return_db As New database()
            return_db.initialize(database.TEST_PATH)
            Return return_db
        End Function

        <TestMethod>
        Public Sub get_all()

            Dim my_types As New List(Of dto.File_Type)(service.File_Type.all())

            Assert.IsTrue(my_types.Contains(New dto.File_Type() With {.id = 1, .interpretation = "text"}))
            Assert.IsTrue(my_types.Contains(New dto.File_Type() With {.id = 2, .interpretation = "png"}))
            Assert.IsTrue(my_types.Contains(New dto.File_Type() With {.id = 4, .interpretation = "mp3"}))

            Assert.AreEqual(4, my_types.Count)

        End Sub

        <TestMethod>
        Public Sub count()

            Assert.AreEqual(4, service.File_Type.count())

        End Sub

        <TestMethod>
        Public Sub get_by_id()

            Assert.IsNull(service.File_Type.get_by_id(0))
            Assert.IsNull(service.File_Type.get_by_id(5))

            Dim expected_item As dto.File_Type

            expected_item = New dto.File_Type() With {.id = 1, .interpretation = "text"}
            Assert.AreEqual(service.File_Type.get_by_id(1), expected_item)

            expected_item = New dto.File_Type() With {.id = 2, .interpretation = "png"}
            Assert.AreEqual(service.File_Type.get_by_id(2), expected_item)

            expected_item = New dto.File_Type() With {.id = 4, .interpretation = "mp3"}
            Assert.AreEqual(service.File_Type.get_by_id(4), expected_item)

        End Sub

    End Class

End Namespace
