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

            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With
                {
                    .id = 1,
                    .path = "pine/english_name.txt",
                    .id_Item = 1,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With
                {
                    .id = 5,
                    .path = "spruce/english_name.txt",
                    .id_Item = 3,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With
                {
                    .id = 10,
                    .path = "birch/latin_name.txt",
                    .id_Item = 5,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))

            Assert.AreEqual(10, my_infos.Count)

        End Sub

        <TestMethod>
        Public Sub count()

            Assert.AreEqual(10, service.File_Info.count())

        End Sub

        <TestMethod>
        Public Sub get_by_item()

            Dim my_infos As List(Of DTOs.File_Info)

            my_infos = service.File_Info.get_for_Item_id(0)
            Assert.AreEqual(0, my_infos.Count)

            my_infos = service.File_Info.get_for_Item_id(1)
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With
                {
                    .id = 1,
                    .path = "pine/english_name.txt",
                    .id_Item = 1,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With
                {
                    .id = 2,
                    .path = "pine/latin_name.txt",
                    .id_Item = 1,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))

            my_infos = service.File_Info.get_for_Item_id(2)
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With
                {
                    .id = 3,
                    .path = "oak/english_name.txt",
                    .id_Item = 2,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New DTOs.File_Info() With
                {
                    .id = 4,
                    .path = "oak/latin_name.txt",
                    .id_Item = 2,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))

        End Sub

    End Class

End Namespace
