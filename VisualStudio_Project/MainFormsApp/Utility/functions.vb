Namespace utility

    Module functions

        ''' <summary>
        ''' Returns a shuffled copy of <paramref name="collection"/>.
        ''' </summary>
        ''' <typeparam name="t"></typeparam>
        ''' <param name="collection"></param>
        ''' <returns></returns>
        Public Function shuffle_collection(Of t)(collection As IEnumerable(Of t)) As IEnumerable(Of t)

            ' Create a sequence of indices.
            Dim indices As New List(Of UInteger)(collection.Count)
            For i As UInteger = 0 To collection.Count - 1
                indices.Add(i)
            Next

            ' Pick random indices to create a new shuffled collection.
            Dim rand As New System.Random   ' RNG used for the shuffling
            Dim random_number As UInteger
            Dim picked_index As UInteger
            Dim shuffled_collection As New List(Of t)(collection.Count)

            While indices.Count > 0

                ' Generate a random number.
                random_number = rand.Next(maxValue:=indices.Count)

                ' Pick an index with it.
                picked_index = indices(random_number)

                ' Use the index to add an element to the shuffled collection
                shuffled_collection.Add(collection(picked_index))

                ' Remove the index from the "list of candidates"
                indices.RemoveAt(random_number)

            End While

            Return shuffled_collection

        End Function

    End Module

End Namespace
