Namespace utility

    Module functions

        Public Function shuffle_collection(Of t)(collection As ICollection(Of t)) As ICollection(Of t)

            Dim i As UInteger               ' Index used for iterations
            Dim rand As New System.Random   ' RNG used for the shuffling
            Dim random_index As UInteger
            Dim shuffled_collection As New List(Of t)(collection.Count)

            ' Create a sequence of indices.
            Dim indices As New List(Of UInteger)(collection.Count)
            For i = 0 To collection.Count - 1
                indices.Item(i) = i
            Next

            ' Take random indices to create a new shuffled collection.
            For Each item As t In shuffled_collection

                random_index = rand.Next(maxValue:=indices.Count)
                item = collection.ElementAt(random_index)
                indices.RemoveAt(random_index)

            Next

            Return shuffled_collection

        End Function

    End Module

End Namespace
