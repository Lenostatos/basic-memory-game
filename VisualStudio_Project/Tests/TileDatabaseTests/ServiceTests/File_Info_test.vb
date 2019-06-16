Imports MainFormsApp.tile_database
Imports MainFormsApp.tile_database.service

Namespace tile_database_test.service_test

    <TestClass>
    Public Class File_Info_test

        Private _my_db As database = initialize_database()

        Private Function initialize_database() As database
            Dim return_db As New database()
            return_db.initialize(database.DEFAULT_PATH)
            Return return_db
        End Function

        <TestMethod>
        Public Sub get_all()

            Dim my_infos As New List(Of DTOs.File_Info)(service.File_Info.all())

            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With {.id = 1, .path = "pine/english_name.txt"}))
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With {.id = 5, .path = "spruce/english_name.txt"}))
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With {.id = 10, .path = "birch/latin_name.txt"}))

            Assert.AreEqual(10, my_infos.Count)

        End Sub

        <TestMethod>
        Public Sub count()

            Assert.AreEqual(10, service.File_Info.count())

        End Sub

        <TestMethod>
        Public Sub get_by_item()

            Dim my_infos As List(Of DTOs.File_Info)

            my_infos = service.File_Info.get_for_Item(New DTOs.Item() With {.id = 0, .name = "Pine"})
            Assert.AreEqual(0, my_infos.Count)

            my_infos = service.File_Info.get_for_Item(New DTOs.Item() With {.id = 1, .name = "Pine"})
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With {.id = 1}))
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With {.id = 2}))

            my_infos = service.File_Info.get_for_Item(New DTOs.Item() With {.id = 2, .name = "Pine"})
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With {.id = 3}))
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With {.id = 4}))

        End Sub

    End Class

End Namespace
