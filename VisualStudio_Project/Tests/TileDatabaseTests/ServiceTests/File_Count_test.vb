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
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 1, .count = 2}))
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 3, .count = 2}))
            Assert.IsTrue(my_counts.Contains(New DTOs.File_Count() With {.id_Item = 5, .count = 2}))

        End Sub

        <TestMethod>
        Public Sub get_for_item()

            Assert.AreEqual(2, service.File_Count.count_files_for_Item_id(1))

        End Sub

        <TestMethod>
        Public Sub get_by_count()

            Dim my_2_count_items As List(Of DTOs.File_Count) =
                service.File_Count.get_for_count(2)

            Assert.IsTrue(service.File_Count.all().All(
                          Function(count As DTOs.File_Count) As Boolean
                              Return my_2_count_items.Contains(count)
                          End Function))
        End Sub

        <TestMethod>
        Public Sub get_min_max()

            Assert.AreEqual(2, service.File_Count.max_count())
            Assert.AreEqual(2, service.File_Count.min_count())

        End Sub

    End Class

End Namespace
