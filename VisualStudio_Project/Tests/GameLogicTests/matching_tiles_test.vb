Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class matching_tiles_test

        <TestMethod>
        Public Sub initialization_with_non_matching_tiles_should_throw_argumentexception()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design()))
            Dim t_2 As New tile(1, New tile_item(1, New tile_item_design()))

            Try
                Dim matches As New matching_tiles From {
                    t_1,
                    t_2
                }
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
                Dim matches As New matching_tiles From {
                    t_1,
                    t_2
                }
            Catch ex As ArgumentException
                StringAssert.Contains(ex.Message, matching_tiles.EXCEPTION_MESSAGE_ADDED_ALREADY_EXISTING_TILE)
                Return
            End Try

            Assert.Fail("The expected exception was not thrown.")

        End Sub

    End Class

End Namespace
