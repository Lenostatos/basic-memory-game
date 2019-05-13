Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class matching_tiles_test

        <TestMethod>
        <ExpectedException(GetType(Exception))>
        Public Sub initialization_with_certain_tile_combinations_should_throw_()

            Dim t_1 As New tile(0, New tile_item(0, New tile_item_design()))
            Dim t_2 As New tile(0, New tile_item(1, New tile_item_design()))

            Dim matches As New matching_tiles From {
                t_1,
                t_2
            }

            t_1 = New tile(0, New tile_item(0, New tile_item_design()))
            t_2 = New tile(1, New tile_item(0, New tile_item_design()))

            matches = New matching_tiles From {
                t_1,
                t_2
            }

        End Sub

    End Class

End Namespace
