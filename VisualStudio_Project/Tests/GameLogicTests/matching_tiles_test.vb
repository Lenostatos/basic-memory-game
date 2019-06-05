Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class matching_tiles_test

        <TestMethod>
        Public Sub initialization_with_nothing_should_produce_empty_list()

            Dim mt As New matching_tiles()
            Assert.AreEqual(0, mt.tiles.Count)

        End Sub

        <TestMethod>
        Public Sub initialization_with_non_matching_tiles_should_throw_argumentexception()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design()))
            Dim t_2 As New tile(1, New tile_item(1, New tile_item_design()))

            Try
                Dim matches As New matching_tiles From {t_1, t_2}
            Catch ex As ArgumentException
                StringAssert.Contains(ex.Message, matching_tiles.EXCEPTION_MESSAGE_ADDED_NON_MATCHING_TILE)
                Return
            End Try

            Assert.Fail("The expected exception was not thrown.")

        End Sub

        <TestMethod>
        Public Sub initialization_with_non_individual_tiles_should_throw_argumentexception()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design()))
            Dim t_2 As New tile(0, New tile_item(0, New tile_item_design()))

            Try
                Dim matches As New matching_tiles From {t_1, t_2}
            Catch ex As ArgumentException
                StringAssert.Contains(ex.Message, matching_tiles.EXCEPTION_MESSAGE_ADDED_ALREADY_EXISTING_TILE)
                Return
            End Try

            Assert.Fail("The expected exception was not thrown.")

        End Sub

        <TestMethod>
        Public Sub adding_non_matching_tiles_should_throw_argumentexception()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design()))
            Dim t_2 As New tile(1, New tile_item(1, New tile_item_design()))

            Dim matches As New matching_tiles()
            matches.Add(t_1)

            Try
                matches.Add(t_2)
            Catch ex As ArgumentException
                StringAssert.Contains(ex.Message, matching_tiles.EXCEPTION_MESSAGE_ADDED_NON_MATCHING_TILE)
                Return
            End Try

            Assert.Fail("The expected exception was not thrown.")

        End Sub

        <TestMethod>
        Public Sub adding_non_individual_tiles_should_throw_argumentexception()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design()))
            Dim t_2 As New tile(0, New tile_item(0, New tile_item_design()))

            Dim matches As New matching_tiles()
            matches.Add(t_1)

            Try
                matches.Add(t_2)
            Catch ex As ArgumentException
                StringAssert.Contains(ex.Message, matching_tiles.EXCEPTION_MESSAGE_ADDED_ALREADY_EXISTING_TILE)
                Return
            End Try

            Assert.Fail("The expected exception was not thrown.")

        End Sub

        <TestMethod>
        Public Sub test_undercover_matching()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design()))
            Dim t_2 As New tile(1, New tile_item(0, New tile_item_design()))

            Dim t_3 As New tile(2, New tile_item(1, New tile_item_design()))

            Dim t_4 As New tile(3, New tile_item(0, New tile_item_design()))

            Dim t_5 As New tile(0, New tile_item(0, New tile_item_design()))

            Dim mt_1 As New matching_tiles() From {t_1, t_2}
            Dim mt_2 As New matching_tiles() From {t_3}

            Assert.IsFalse(mt_1.undercover_matches_common_item(mt_2))

            Dim mt_3 As New matching_tiles() From {t_4}

            Assert.IsTrue(mt_1.undercover_matches_common_item(mt_3))

            Dim mt_4 As New matching_tiles() From {t_5}

            Assert.IsTrue(mt_1.undercover_matches_common_item(mt_4))

        End Sub

    End Class

End Namespace
