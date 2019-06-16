Imports MainFormsApp.tile_database
Imports MainFormsApp.tile_database.service

Namespace tile_database_test.service_test

    <TestClass>
    Public Class Representation_Count_test

        Private _my_db As database = initialize_database()

        Private Function initialize_database() As database
            Dim return_db As New database()
            return_db.initialize(database.DEFAULT_PATH)
            Return return_db
        End Function

        <TestMethod>
        Public Sub get_all()

            Dim my_counts As New List(Of DTOs.Representation_Count)(service.Representation_Count.all())
            Assert.IsTrue(my_counts.Contains(New DTOs.Representation_Count() With {.id_item = 1, .count = 2}))
            Assert.IsTrue(my_counts.Contains(New DTOs.Representation_Count() With {.id_item = 3, .count = 2}))
            Assert.IsTrue(my_counts.Contains(New DTOs.Representation_Count() With {.id_item = 5, .count = 2}))

        End Sub

        <TestMethod>
        Public Sub get_for_item()

            Dim my_count As DTOs.Representation_Count

            my_count = service.Representation_Count.get_for_item(New DTOs.Item() With {.id = 1, .name = "Pine"})
            Assert.AreEqual(New DTOs.Representation_Count() With {.id_item = 1, .count = 2}, my_count)

        End Sub

        <TestMethod>
        Public Sub get_min_max()

            Dim my_max_count As New DTOs.Representation_Count(service.Representation_Count.get_max())
            Dim my_min_count As New DTOs.Representation_Count(service.Representation_Count.get_min())

            Assert.AreEqual(New DTOs.Representation_Count() With {.id_item = 1, .count = 2}, my_max_count)
            Assert.AreEqual(New DTOs.Representation_Count() With {.id_item = 1, .count = 2}, my_min_count)

        End Sub

    End Class

End Namespace
