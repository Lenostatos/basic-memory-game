Imports MainFormsApp.tile_database
Imports MainFormsApp.tile_database.service

Namespace tile_database_test.service_test

    <TestClass>
    Public Class File_Info_test

        Private _my_db As i_database = initialize_database()

        Private Function initialize_database() As i_database
            Dim return_db As New database()
            return_db.initialize(database.TEST_PATH)
            Return return_db
        End Function

        <TestMethod>
        Public Sub get_all()

            Dim my_infos As New List(Of dto.File_Info)(service.File_Info.all())

            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 1,
                    .path = "pine/english_name.txt",
                    .id_Item = 1,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 9,
                    .path = "spruce/english_name.txt",
                    .id_Item = 3,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 14,
                    .path = "birch/latin_name.txt",
                    .id_Item = 5,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))

            Assert.AreEqual(14, my_infos.Count)

        End Sub

        <TestMethod>
        Public Sub count()

            Assert.AreEqual(14, service.File_Info.count())

        End Sub

        <TestMethod>
        Public Sub get_for_item()

            Dim my_infos As List(Of dto.File_Info)

            my_infos = service.File_Info.get_for_Item_id(1)
            Assert.AreEqual(4, my_infos.Count)
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 1,
                    .path = "pine/english_name.txt",
                    .id_Item = 1,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 2,
                    .path = "pine/latin_name.txt",
                    .id_Item = 1,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 3,
                    .path = "pine/whole_tree.jpg",
                    .id_Item = 1,
                    .id_File_Type = MainFormsApp.tile_database.file_type.jpeg
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 4,
                    .path = "pine/leaves_and_cones.jpg",
                    .id_Item = 1,
                    .id_File_Type = MainFormsApp.tile_database.file_type.jpeg
                }))

            my_infos = service.File_Info.get_for_Item_id(2)
            Assert.AreEqual(4, my_infos.Count)
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 5,
                    .path = "oak/english_name.txt",
                    .id_Item = 2,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 6,
                    .path = "oak/latin_name.txt",
                    .id_Item = 2,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 7,
                    .path = "oak/whole_tree.jpg",
                    .id_Item = 2,
                    .id_File_Type = MainFormsApp.tile_database.file_type.jpeg
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 8,
                    .path = "oak/leaves_and_acorns.jpg",
                    .id_Item = 2,
                    .id_File_Type = MainFormsApp.tile_database.file_type.jpeg
                }))

            my_infos = service.File_Info.get_for_Item_id(3)
            Assert.AreEqual(2, my_infos.Count)
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 9,
                    .path = "spruce/english_name.txt",
                    .id_Item = 3,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 10,
                    .path = "spruce/whole_tree.jpg",
                    .id_Item = 3,
                    .id_File_Type = MainFormsApp.tile_database.file_type.jpeg
                }))

            my_infos = service.File_Info.get_for_Item_id(4)
            Assert.AreEqual(3, my_infos.Count)
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 11,
                    .path = "black_alder/english_name.txt",
                    .id_Item = 4,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 12,
                    .path = "black_alder/latin_name.txt",
                    .id_Item = 4,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 13,
                    .path = "black_alder/leaves_and_fruits.jpg",
                    .id_Item = 4,
                    .id_File_Type = MainFormsApp.tile_database.file_type.jpeg
                }))

            my_infos = service.File_Info.get_for_Item_id(5)
            Assert.AreEqual(1, my_infos.Count)
            Assert.IsTrue(my_infos.Contains(New dto.File_Info() With
                {
                    .id = 14,
                    .path = "birch/latin_name.txt",
                    .id_Item = 5,
                    .id_File_Type = MainFormsApp.tile_database.file_type.text
                }))

        End Sub

    End Class

End Namespace
