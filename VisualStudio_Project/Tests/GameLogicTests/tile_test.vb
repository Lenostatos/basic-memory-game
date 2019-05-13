Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()> Public Class tile_test

        <TestMethod()>
        <ExpectedException(GetType(ArgumentNullException))>
        Public Sub new_with_item_is_nothing_should_throw_argumentnullexception()
            Dim tile As tile = New tile(0, Nothing)
        End Sub

    End Class

End Namespace