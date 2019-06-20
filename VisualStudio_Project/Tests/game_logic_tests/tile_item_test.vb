Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class tile_item_test

        <TestMethod()>
        Public Sub test_matching()

            Dim i_1 As New tile_item(0, New tile_item_design(0))
            Dim i_2 As New tile_item(0, New tile_item_design(0))
            Dim i_3 As New tile_item(1, New tile_item_design(0))

            Assert.IsTrue(i_1.matches(i_2))
            Assert.IsFalse(i_1.matches(i_3))

        End Sub

        <TestMethod()>
        Public Sub test_equality()

            Dim i_1 As New tile_item(0, New tile_item_design(0))
            Dim i_2 As New tile_item(0, New tile_item_design(0))
            Dim i_3 As New tile_item(1, New tile_item_design(0))

            Assert.IsTrue(i_1.Equals(i_2))
            Assert.IsFalse(i_1.Equals(i_3))

        End Sub

    End Class

End Namespace
