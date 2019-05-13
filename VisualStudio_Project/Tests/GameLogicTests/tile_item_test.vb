Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class tile_item_test

        <TestMethod()>
        Public Sub test_matching()

            Dim i_1 As New tile_item(0, New tile_item_design())
            Dim i_2 As New tile_item(0, New tile_item_design())
            Dim i_3 As New tile_item(1, New tile_item_design())

            Assert.IsTrue(i_1.matches(i_2))
            Assert.IsFalse(i_1.matches(i_3))

        End Sub

    End Class

End Namespace
