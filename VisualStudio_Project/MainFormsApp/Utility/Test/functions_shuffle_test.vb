Namespace utility.test

    Public Class functions_shuffle_test

        Implements MainFormsApp.test.i_test

        Public Function run() As Boolean Implements MainFormsApp.test.i_test.run

            Dim test_count = 1000
            Dim numbers As New List(Of Integer)(test_count)
            For i As Integer = 0 To test_count - 1
                numbers.Add(i)
            Next

            Dim shuffled_numbers = shuffle_collection(numbers)
            For Each i As Integer In numbers
                If Not shuffled_numbers.Contains(i) Then Return False
            Next

            ' TODO: shuffle a sorted list of numbers very often.
            ' In let's say at least 90 percent of the cases the shuffled list has to be different from the original.

            Return True

        End Function

    End Class

End Namespace
