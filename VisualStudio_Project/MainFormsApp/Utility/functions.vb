Namespace utility

    Module functions

        ''' <summary>
        ''' Returns a shuffled copy of <paramref name="collection"/>.
        ''' </summary>
        ''' <typeparam name="t"></typeparam>
        ''' <param name="collection"></param>
        ''' <returns></returns>
        Public Function shuffle_collection(Of t)(collection As ICollection(Of t)) As ICollection(Of t)

            ' Create a sequence of indices.
            Dim indices As New List(Of UInteger)(collection.Count)
            For i As UInteger = 0 To collection.Count - 1
                indices.Item(i) = i
            Next

            ' Pick random indices to create a new shuffled collection.
            Dim rand As New System.Random   ' RNG used for the shuffling
            Dim random_index As UInteger
            Dim shuffled_collection As New List(Of t)(collection.Count)

            For Each item As t In shuffled_collection

                random_index = rand.Next(maxValue:=indices.Count)
                item = collection.ElementAt(random_index)
                indices.RemoveAt(random_index)

            Next

            Return shuffled_collection

        End Function

    End Module

End Namespace
