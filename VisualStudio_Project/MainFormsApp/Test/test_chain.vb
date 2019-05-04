Namespace test

    ''' <summary>
    ''' Runs all the tests that have been passed to the constructor.
    ''' </summary>
    Public Class test_chain

        Public Sub New(ParamArray tests() As i_test)

            For Each t As i_test In tests
                If Not t.run() Then Throw New Exception(TypeName(t) & " was not successful.")
            Next

        End Sub

    End Class

End Namespace
