Namespace game_logic

    ''' <summary>
    ''' Models the rows and columns of a near-rectangular matrix of positions.
    ''' </summary>
    Public Class game_board_layout

        Public Const EXCEPTION_MESSAGE_LESS_THAN_FOUR_POSITIONS As String =
            "Attempted to set the number of positions to less than four."
        Public Const EXCEPTION_MESSAGE_LESS_THAN_ONE_DIMENSION As String =
            "Attempted to set the fixed dimension length to a number less than one."
        Public Const EXCEPTION_MESSAGE_DIMENSION_LENGTH_HIGHER_THAN_POSITION_COUNT As String =
            "Attempted to change layout so that the dimension length would have been higher than the number of positions."

        Private _position_count As Integer
        Private _fixed_dimension As dimension
        Private _fixed_dimension_length As Integer

        Public Sub New(position_count As Integer, fixed_dimension As dimension, fixed_dimension_length As Integer)

            If position_count < 4 Then
                Throw New ArgumentOutOfRangeException("position_count", EXCEPTION_MESSAGE_LESS_THAN_FOUR_POSITIONS)
            End If

            If fixed_dimension_length < 1 Then
                Throw New ArgumentOutOfRangeException("fixed_dimension_length", EXCEPTION_MESSAGE_LESS_THAN_ONE_DIMENSION)
            End If

            If fixed_dimension_length > position_count Then
                Throw New ArgumentOutOfRangeException("fixed_dimension_length", EXCEPTION_MESSAGE_DIMENSION_LENGTH_HIGHER_THAN_POSITION_COUNT)
            End If

            _position_count = position_count
            _fixed_dimension = fixed_dimension
            _fixed_dimension_length = fixed_dimension_length

        End Sub

        Public Property position_count As Integer
            Get
                Return _position_count
            End Get
            Set(value As Integer)

                If value < 4 Then
                    Throw New ArgumentOutOfRangeException("value", EXCEPTION_MESSAGE_LESS_THAN_FOUR_POSITIONS)
                End If

                If fixed_dimension_length > value Then
                    Throw New ArgumentOutOfRangeException("fixed_dimension_length", EXCEPTION_MESSAGE_DIMENSION_LENGTH_HIGHER_THAN_POSITION_COUNT)
                End If

                _position_count = value

            End Set
        End Property

        Public Property fixed_dimension As dimension
            Get
                Return _fixed_dimension
            End Get
            Set(value As dimension)

                _fixed_dimension = value

            End Set
        End Property

        Public Property fixed_dimension_length As Integer
            Get
                Return _fixed_dimension_length
            End Get
            Set(value As Integer)

                If value < 1 Then
                    Throw New ArgumentOutOfRangeException("value", value, EXCEPTION_MESSAGE_LESS_THAN_ONE_DIMENSION)
                End If

                If value > position_count Then
                    Throw New ArgumentOutOfRangeException("value", value, EXCEPTION_MESSAGE_DIMENSION_LENGTH_HIGHER_THAN_POSITION_COUNT)
                End If

                _fixed_dimension_length = value

            End Set
        End Property

        Public ReadOnly Property row_count As Integer
            Get
                If _fixed_dimension = dimension.row Then
                    Return _fixed_dimension_length
                Else
                    Return Math.Ceiling(_position_count / _fixed_dimension_length)
                End If
            End Get
        End Property

        Public ReadOnly Property column_count As Integer
            Get
                If _fixed_dimension = dimension.row Then
                    Return Math.Ceiling(_position_count / _fixed_dimension_length)
                Else
                    Return _fixed_dimension_length
                End If
            End Get
        End Property

        ''' <summary>
        ''' Returns an index that a position would have if all
        ''' positions were arranged in an array by concatenating
        ''' all elements of the fixed dimension (e.g. if the
        ''' fixed dimension was the row dimension, the array
        ''' would be constructed by concatenating all rows).
        ''' </summary>
        ''' <param name="row_index">A zero-based row index.</param>
        ''' <param name="column_index">A zero-based column index.</param>
        ''' <returns>A zero-based array index.</returns>
        Public Function get_array_position(row_index As Integer, column_index As Integer) As Integer

            If row_index < 0 OrElse column_index < 0 Then
                Throw New ArgumentOutOfRangeException()
            End If

            If row_index >= row_count Then Throw New ArgumentOutOfRangeException()
            If column_index >= column_count Then Throw New ArgumentOutOfRangeException()

            Dim return_value As Integer
            If fixed_dimension = dimension.row Then
                return_value = row_index * fixed_dimension_length + column_index
            Else
                return_value = column_index * fixed_dimension_length + row_index
            End If

            If return_value >= position_count Then
                Throw New ArgumentOutOfRangeException()
            End If

            Return return_value

        End Function

        ''' <summary>
        ''' Returns a row and a column index that a position in an
        ''' array would have if the array was splitted into
        ''' elements of the fixed dimension (e.g. if the fixed
        ''' dimension was the column dimension, the array would be
        ''' splitted into as many columns as necessary to hold the
        ''' given number of positions).
        ''' </summary>
        ''' <param name="array_index">A zero-based array index.</param>
        ''' <returns>A tuple of two integers with the first one
        ''' being the zero-based row index and the second one being
        ''' the zero-based column index.</returns>
        Public Function get_matrix_position(array_index As Integer) As Tuple(Of Integer, Integer)

            If array_index < 0 OrElse array_index >= position_count Then
                Throw New ArgumentOutOfRangeException()
            End If

            Dim row_index As Integer
            Dim column_index As Integer

            If fixed_dimension = dimension.row Then
                row_index = array_index \ row_count
                column_index = array_index Mod column_count
            Else
                row_index = array_index Mod row_count
                column_index = array_index \ column_count
            End If

            If row_index >= row_count Then Throw New ArgumentOutOfRangeException()
            If column_index >= column_count Then Throw New ArgumentOutOfRangeException()

            Return New Tuple(Of Integer, Integer)(row_index, column_index)

        End Function

        Public Enum dimension
            row
            column
        End Enum

    End Class

End Namespace
