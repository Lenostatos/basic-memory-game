<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tile_set_options_form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.combo_box_num_tiles_per_item = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.combo_box_tile_selection_pattern = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.button_submit_tile_options = New System.Windows.Forms.Button()
        Me.combo_box_num_random_items = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'combo_box_num_tiles_per_item
        '
        Me.combo_box_num_tiles_per_item.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.combo_box_num_tiles_per_item.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_box_num_tiles_per_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_box_num_tiles_per_item.Enabled = False
        Me.combo_box_num_tiles_per_item.FormattingEnabled = True
        Me.combo_box_num_tiles_per_item.Location = New System.Drawing.Point(631, 97)
        Me.combo_box_num_tiles_per_item.Name = "combo_box_num_tiles_per_item"
        Me.combo_box_num_tiles_per_item.Size = New System.Drawing.Size(59, 24)
        Me.combo_box_num_tiles_per_item.Sorted = True
        Me.combo_box_num_tiles_per_item.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "How many tiles per item should be used?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(315, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "How many different items should be used?"
        '
        'combo_box_tile_selection_pattern
        '
        Me.combo_box_tile_selection_pattern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.combo_box_tile_selection_pattern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_box_tile_selection_pattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_box_tile_selection_pattern.FormattingEnabled = True
        Me.combo_box_tile_selection_pattern.Location = New System.Drawing.Point(409, 17)
        Me.combo_box_tile_selection_pattern.Name = "combo_box_tile_selection_pattern"
        Me.combo_box_tile_selection_pattern.Size = New System.Drawing.Size(281, 24)
        Me.combo_box_tile_selection_pattern.Sorted = True
        Me.combo_box_tile_selection_pattern.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(338, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Which tiles should be selected for each item?"
        '
        'button_submit_tile_options
        '
        Me.button_submit_tile_options.Location = New System.Drawing.Point(12, 142)
        Me.button_submit_tile_options.Name = "button_submit_tile_options"
        Me.button_submit_tile_options.Size = New System.Drawing.Size(77, 32)
        Me.button_submit_tile_options.TabIndex = 3
        Me.button_submit_tile_options.Text = "OK"
        Me.button_submit_tile_options.UseVisualStyleBackColor = True
        '
        'combo_box_num_random_items
        '
        Me.combo_box_num_random_items.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.combo_box_num_random_items.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.combo_box_num_random_items.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_box_num_random_items.Enabled = False
        Me.combo_box_num_random_items.FormattingEnabled = True
        Me.combo_box_num_random_items.Location = New System.Drawing.Point(631, 68)
        Me.combo_box_num_random_items.Name = "combo_box_num_random_items"
        Me.combo_box_num_random_items.Size = New System.Drawing.Size(59, 24)
        Me.combo_box_num_random_items.Sorted = True
        Me.combo_box_num_random_items.TabIndex = 1
        '
        'tile_set_options_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 186)
        Me.Controls.Add(Me.combo_box_num_random_items)
        Me.Controls.Add(Me.button_submit_tile_options)
        Me.Controls.Add(Me.combo_box_tile_selection_pattern)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.combo_box_num_tiles_per_item)
        Me.Name = "tile_set_options_form"
        Me.Text = "Tile Set Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents combo_box_num_tiles_per_item As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents combo_box_tile_selection_pattern As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents button_submit_tile_options As Button
    Friend WithEvents combo_box_num_random_items As ComboBox
End Class
