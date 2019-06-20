Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class tile_test

        <TestMethod()>
        <ExpectedException(GetType(ArgumentNullException))>
        Public Sub initialization_with_item_is_nothing_should_throw_argumentnullexception()
            Dim tile As tile = New tile(0, Nothing)
        End Sub

        <TestMethod()>
        Public Sub test_tile_covering()

            Dim t As New tile(0, New tile_item(0, New tile_item_design(0)))

            Assert.IsTrue(t.covered, "Tile was not covered after construction.")

            t.cover()
            Assert.IsTrue(t.covered, "Tile was not covered after calling the cover method.")

            t.uncover()
            t.cover()
            Assert.IsTrue(t.covered, "Tile was not covered after calling the cover method.")

        End Sub

        <TestMethod()>
        Public Sub get_item_from_covered_tile_should_throw_invalidoperationexception()

            Dim t As New tile(0, New tile_item(0, New tile_item_design(0)))

            Try
                Dim i As tile_item = t.item
            Catch ex As InvalidOperationException
                StringAssert.Contains(ex.Message, tile.EXCEPTION_MESSAGE_LOOKED_AT_ITEM_ON_COVERED_TILE)
                Return
            End Try

            Assert.Fail("The expected exception was not thrown.")

        End Sub

        <TestMethod()>
        Public Sub test_matching_uncovered_tiles()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design(0)), False)
            Dim t_2 As New tile(0, New tile_item(0, New tile_item_design(0)), False)
            Dim t_3 As New tile(0, New tile_item(1, New tile_item_design(0)), False)

            Assert.IsTrue(t_1.matches(t_2))
            Assert.IsFalse(t_1.matches(t_3))

        End Sub

        <TestMethod()>
        Public Sub test_undercover_matching()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design(0)))
            Dim t_2 As New tile(0, New tile_item(0, New tile_item_design(0)))
            Dim t_3 As New tile(0, New tile_item(1, New tile_item_design(0)))

            Assert.IsTrue(t_1.undercover_matches(t_2))
            Assert.IsFalse(t_1.undercover_matches(t_3))

        End Sub

        <TestMethod()>
        Public Sub matching_covered_tiles_should_throw_invalidoperationexception()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design(0)))
            Dim t_2 As New tile(0, New tile_item(0, New tile_item_design(0)))

            Try
                t_1.matches(t_2)
            Catch ex As InvalidOperationException
                StringAssert.Contains(ex.Message, tile.EXCEPTION_MESSAGE_LOOKED_AT_ITEM_ON_COVERED_TILE)
                Return
            End Try

            t_1.uncover()
            Try
                t_1.matches(t_2)
            Catch ex As InvalidOperationException
                StringAssert.Contains(ex.Message, tile.EXCEPTION_MESSAGE_LOOKED_AT_ITEM_ON_COVERED_TILE)
                Return
            End Try

            t_1.cover()
            t_2.uncover()
            Try
                t_1.matches(t_2)
            Catch ex As InvalidOperationException
                StringAssert.Contains(ex.Message, tile.EXCEPTION_MESSAGE_LOOKED_AT_ITEM_ON_COVERED_TILE)
                Return
            End Try

            Assert.Fail("The expected exception was not thrown.")

        End Sub

    End Class

End Namespace