Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class board_layout_test

        <TestMethod>
        Public Sub test_construction_w_valid_arguments()

            Dim my_layout As New board_layout(4, board_layout.dimension.column, 4)

            Assert.AreEqual(board_layout.dimension.column, my_layout.fixed_dimension)
            Assert.AreEqual(4, my_layout.position_count)
            Assert.AreEqual(4, my_layout.column_count)

            my_layout = New board_layout(5, board_layout.dimension.row, 5)

            Assert.AreEqual(board_layout.dimension.row, my_layout.fixed_dimension)
            Assert.AreEqual(5, my_layout.position_count)
            Assert.AreEqual(5, my_layout.row_count)

            my_layout = New board_layout(20, board_layout.dimension.row, 5)

            Assert.AreEqual(board_layout.dimension.row, my_layout.fixed_dimension)
            Assert.AreEqual(20, my_layout.position_count)
            Assert.AreEqual(5, my_layout.row_count)

            For number As Integer = 2 To 4
                my_layout = New board_layout(Math.Pow(number, 3), board_layout.dimension.column, number)
                Assert.AreEqual(number, my_layout.column_count)
            Next

        End Sub

        <TestMethod>
        Public Sub test_construction_w_invalid_arguments()

            Dim my_layout As board_layout

            For number As Integer = -1 To 3
                Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                    Sub() my_layout = New board_layout(number, board_layout.dimension.column, 1),
                    board_layout.EXCEPTION_MESSAGE_LESS_THAN_FOUR_POSITIONS)
            Next

            For number As Integer = -1 To 0
                Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                    Sub() my_layout = New board_layout(4, board_layout.dimension.column, number),
                    board_layout.EXCEPTION_MESSAGE_LESS_THAN_ONE_DIMENSION)
            Next

            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_layout = New board_layout(4, board_layout.dimension.column, 5),
                board_layout.EXCEPTION_MESSAGE_DIMENSION_LENGTH_HIGHER_THAN_POSITION_COUNT)

        End Sub

        <TestMethod>
        Public Sub test_changing_dimensions()

            Dim my_layout As New board_layout(4, board_layout.dimension.row, 1)

            my_layout.fixed_dimension = board_layout.dimension.row
            Assert.AreEqual(board_layout.dimension.row, my_layout.fixed_dimension)
            Assert.AreEqual(1, my_layout.fixed_dimension_length)

            my_layout.fixed_dimension = board_layout.dimension.column
            Assert.AreEqual(board_layout.dimension.column, my_layout.fixed_dimension)
            Assert.AreEqual(1, my_layout.fixed_dimension_length)

            my_layout.fixed_dimension = board_layout.dimension.row
            Assert.AreEqual(board_layout.dimension.row, my_layout.fixed_dimension)
            Assert.AreEqual(1, my_layout.fixed_dimension_length)

            my_layout.fixed_dimension = board_layout.dimension.column
            Assert.AreEqual(board_layout.dimension.column, my_layout.fixed_dimension)
            Assert.AreEqual(1, my_layout.fixed_dimension_length)

        End Sub

        <TestMethod>
        Public Sub test_changing_position_count()

            Dim my_layout As New board_layout(4, board_layout.dimension.row, 1)

            For pos_count As Integer = 4 To 20
                my_layout.position_count = pos_count
                Assert.AreEqual(pos_count, my_layout.position_count)
            Next

        End Sub

        <TestMethod>
        Public Sub test_changing_dimension_length()

            Dim my_layout As New board_layout(20, board_layout.dimension.row, 1)

            For dim_length As Integer = 20 To 1
                my_layout.fixed_dimension_length = dim_length
                Assert.AreEqual(dim_length, my_layout.fixed_dimension_length)
            Next

            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_layout.fixed_dimension_length = 21,
                board_layout.EXCEPTION_MESSAGE_DIMENSION_LENGTH_HIGHER_THAN_POSITION_COUNT)

        End Sub

        <TestMethod>
        Public Sub test_row_and_column_count_calculation()

            Dim my_layout As New board_layout(4, board_layout.dimension.row, 1)
            Assert.AreEqual(4, my_layout.column_count)
            Assert.AreEqual(1, my_layout.row_count)

            my_layout.fixed_dimension_length = 2
            Assert.AreEqual(2, my_layout.column_count)
            Assert.AreEqual(2, my_layout.row_count)

            my_layout.fixed_dimension_length = 3
            Assert.AreEqual(2, my_layout.column_count)
            Assert.AreEqual(3, my_layout.row_count)

            my_layout.fixed_dimension_length = 4
            Assert.AreEqual(1, my_layout.column_count)
            Assert.AreEqual(4, my_layout.row_count)

            my_layout.position_count = 4
            my_layout.fixed_dimension = board_layout.dimension.column
            my_layout.fixed_dimension_length = 1
            Assert.AreEqual(4, my_layout.row_count)

            my_layout.fixed_dimension_length = 2
            Assert.AreEqual(2, my_layout.row_count)

            my_layout.fixed_dimension_length = 3
            Assert.AreEqual(2, my_layout.row_count)

            my_layout.fixed_dimension_length = 4
            Assert.AreEqual(1, my_layout.row_count)

            my_layout.position_count = 5
            my_layout.fixed_dimension = board_layout.dimension.column
            my_layout.fixed_dimension_length = 4
            Assert.AreEqual(2, my_layout.row_count)

            my_layout.position_count = 8
            my_layout.fixed_dimension = board_layout.dimension.row
            my_layout.fixed_dimension_length = 4
            Assert.AreEqual(2, my_layout.column_count)

            my_layout.position_count = 9
            Assert.AreEqual(3, my_layout.column_count)

        End Sub

        <TestMethod>
        Public Sub test_array_position_calculation()

            Dim my_layout As New board_layout(9, board_layout.dimension.row, 3)

            Assert.AreEqual(0, my_layout.get_array_position(0, 0))
            Assert.AreEqual(1, my_layout.get_array_position(0, 1))
            Assert.AreEqual(2, my_layout.get_array_position(0, 2))

            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_layout.get_array_position(0, 3))

            Assert.AreEqual(0, my_layout.get_array_position(0, 0))
            Assert.AreEqual(3, my_layout.get_array_position(1, 0))
            Assert.AreEqual(6, my_layout.get_array_position(2, 0))

            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_layout.get_array_position(3, 0))

            Assert.AreEqual(8, my_layout.get_array_position(2, 2))
            Assert.AreEqual(7, my_layout.get_array_position(2, 1))
            Assert.AreEqual(5, my_layout.get_array_position(1, 2))


            my_layout.fixed_dimension = board_layout.dimension.column

            Assert.AreEqual(0, my_layout.get_array_position(0, 0))
            Assert.AreEqual(3, my_layout.get_array_position(0, 1))
            Assert.AreEqual(6, my_layout.get_array_position(0, 2))

            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_layout.get_array_position(0, 3))

            Assert.AreEqual(0, my_layout.get_array_position(0, 0))
            Assert.AreEqual(1, my_layout.get_array_position(1, 0))
            Assert.AreEqual(2, my_layout.get_array_position(2, 0))

            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_layout.get_array_position(3, 0))

            Assert.AreEqual(8, my_layout.get_array_position(2, 2))
            Assert.AreEqual(5, my_layout.get_array_position(2, 1))
            Assert.AreEqual(7, my_layout.get_array_position(1, 2))

            my_layout.position_count = 8
            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_layout.get_array_position(2, 2))

        End Sub

        <TestMethod>
        Public Sub test_matrix_position_calculation()

            Dim my_layout As New board_layout(9, board_layout.dimension.row, 3)

            Assert.AreEqual(New Tuple(Of Integer, Integer)(0, 0), my_layout.get_matrix_position(0))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(0, 1), my_layout.get_matrix_position(1))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(0, 2), my_layout.get_matrix_position(2))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(1, 0), my_layout.get_matrix_position(3))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(1, 1), my_layout.get_matrix_position(4))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(1, 2), my_layout.get_matrix_position(5))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(2, 0), my_layout.get_matrix_position(6))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(2, 1), my_layout.get_matrix_position(7))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(2, 2), my_layout.get_matrix_position(8))

            my_layout.fixed_dimension = board_layout.dimension.column

            Assert.AreEqual(New Tuple(Of Integer, Integer)(0, 0), my_layout.get_matrix_position(0))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(1, 0), my_layout.get_matrix_position(1))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(2, 0), my_layout.get_matrix_position(2))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(0, 1), my_layout.get_matrix_position(3))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(1, 1), my_layout.get_matrix_position(4))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(2, 1), my_layout.get_matrix_position(5))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(0, 2), my_layout.get_matrix_position(6))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(1, 2), my_layout.get_matrix_position(7))
            Assert.AreEqual(New Tuple(Of Integer, Integer)(2, 2), my_layout.get_matrix_position(8))

            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_layout.get_matrix_position(9))
            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_layout.get_matrix_position(-1))

        End Sub

    End Class

End Namespace
