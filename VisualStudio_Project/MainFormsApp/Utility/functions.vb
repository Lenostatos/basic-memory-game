Namespace utility

    Module functions

        Public Function sample_enumerable(Of t)(enumerable As IEnumerable(Of t), size As Integer, Optional replace As Boolean = False) As IEnumerable(Of t)

            If size < 1 Then Throw New ArgumentOutOfRangeException("size", size)
            If Not replace AndAlso size > enumerable.Count Then Throw New ArgumentOutOfRangeException("size", size)

            ' Create a sequence of indices.
            Dim indices As New List(Of Integer)(enumerable.Count)
            For i As Integer = 0 To enumerable.Count - 1
                indices.Add(i)
            Next

            ' Pick random indices to create a new shuffled collection.
            Dim rand As New System.Random   ' RNG used for the shuffling

            Dim random_number As Integer
            Dim picked_index As Integer

            Dim sample As New List(Of t)(size)

            For i As Integer = 1 To size

                ' Generate a random number.
                random_number = rand.Next(maxValue:=indices.Count)

                ' Pick an index with it.
                picked_index = indices(random_number)

                ' Use the index to add an element to the shuffled collection
                sample.Add(enumerable(picked_index))

                If Not replace Then
                    ' Remove the index from the "list of candidates"
                    indices.RemoveAt(random_number)
                End If

            Next

            Return sample

        End Function

        ''' <summary>
        ''' Returns a shuffled copy of <paramref name="enumerable"/>.
        ''' </summary>
        ''' <typeparam name="t"></typeparam>
        ''' <param name="enumerable"></param>
        ''' <returns></returns>
        Public Function shuffle_enumerable(Of t)(enumerable As IEnumerable(Of t)) As IEnumerable(Of t)

            ' Create a sequence of indices.
            Dim indices As New List(Of UInteger)(enumerable.Count)
            For i As UInteger = 0 To enumerable.Count - 1
                indices.Add(i)
            Next

            ' Pick random indices to create a new shuffled collection.
            Dim rand As New System.Random   ' RNG used for the shuffling
            Dim random_number As UInteger
            Dim picked_index As UInteger
            Dim shuffled_collection As New List(Of t)(enumerable.Count)

            While indices.Count > 0

                ' Generate a random number.
                random_number = rand.Next(maxValue:=indices.Count)

                ' Pick an index with it.
                picked_index = indices(random_number)

                ' Use the index to add an element to the shuffled collection
                shuffled_collection.Add(enumerable(picked_index))

                ' Remove the index from the "list of candidates"
                indices.RemoveAt(random_number)

            End While

            Return shuffled_collection

        End Function

    End Module

End Namespace
