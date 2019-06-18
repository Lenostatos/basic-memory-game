Imports MainFormsApp.tile_database
Imports MainFormsApp.tile_database.service

Namespace tile_database_test.service_test

    <TestClass>
    Public Class File_Count_test

        Private _my_db As database = initialize_database()

        Private Function initialize_database() As database
            Dim return_db As New database()
            return_db.initialize(database.DEFAULT_PATH)
            Return return_db
        End Function

        <TestMethod>
        Public Sub get_all()

            Dim my_counts As New List(Of DTOs.File_Count)(service.File_Count.all())
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 1, .count = 4}))
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 2, .count = 4}))
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 3, .count = 2}))
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 4, .count = 3}))
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 5, .count = 1}))

        End Sub

        <TestMethod>
        Public Sub get_for_count()

            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() service.File_Count.get_for_count(-1))
            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() service.File_Count.get_for_count(service.File_Count.min_count() - 1))

            Dim my_counts As List(Of DTOs.File_Count)

            my_counts = service.File_Count.get_for_count(1)
            Assert.AreEqual(1, my_counts.Count)
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 5, .count = 1}))

            my_counts = service.File_Count.get_for_count(2)
            Assert.AreEqual(1, my_counts.Count)
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 3, .count = 2}))

            my_counts = service.File_Count.get_for_count(3)
            Assert.AreEqual(1, my_counts.Count)
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 4, .count = 3}))

            my_counts = service.File_Count.get_for_count(4)
            Assert.AreEqual(2, my_counts.Count)
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 1, .count = 4}))
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 2, .count = 4}))

        End Sub

        <TestMethod>
        Public Sub count_files_for_item()

            Assert.AreEqual(4, service.File_Count.count_files_for_Item_id(1))
            Assert.AreEqual(4, service.File_Count.count_files_for_Item_id(2))
            Assert.AreEqual(2, service.File_Count.count_files_for_Item_id(3))
            Assert.AreEqual(3, service.File_Count.count_files_for_Item_id(4))
            Assert.AreEqual(1, service.File_Count.count_files_for_Item_id(5))
            Assert.AreEqual(0, service.File_Count.count_files_for_Item_id(6))

        End Sub

        <TestMethod>
        Public Sub min_max_count()

            Assert.AreEqual(4, service.File_Count.max_count())
            Assert.AreEqual(1, service.File_Count.min_count())

        End Sub

        <TestMethod>
        Public Sub count_items_with_file_count()

            Assert.AreEqual(1, service.File_Count.count_items_with_file_count(1))
            Assert.AreEqual(1, service.File_Count.count_items_with_file_count(2))
            Assert.AreEqual(1, service.File_Count.count_items_with_file_count(3))
            Assert.AreEqual(2, service.File_Count.count_items_with_file_count(4))

        End Sub

    End Class

End Namespace
