<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class game_setup_form
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
        Me.components = New System.ComponentModel.Container()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.text_box_add_player = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.add_player_help_ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.button_choose_tile_set = New System.Windows.Forms.Button()
        Me.button_display_database_choosing_help = New System.Windows.Forms.Button()
        Me.label_database_file_path = New System.Windows.Forms.Label()
        Me.table_layout_panel_added_players = New System.Windows.Forms.TableLayoutPanel()
        Me.button_tile_set_options = New System.Windows.Forms.Button()
        Me.button_start_game = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Add Player:"
        '
        'text_box_add_player
        '
        Me.text_box_add_player.Location = New System.Drawing.Point(12, 228)
        Me.text_box_add_player.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.text_box_add_player.Name = "text_box_add_player"
        Me.text_box_add_player.Size = New System.Drawing.Size(137, 22)
        Me.text_box_add_player.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(133, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "?"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.add_player_help_ToolTip.SetToolTip(Me.Label3, "Add a player by typing their name into the text box below and pressing enter.")
        '
        'add_player_help_ToolTip
        '
        Me.add_player_help_ToolTip.AutoPopDelay = 10000
        Me.add_player_help_ToolTip.InitialDelay = 0
        Me.add_player_help_ToolTip.ReshowDelay = 0
        Me.add_player_help_ToolTip.ToolTipTitle = "How to add a player:"
        Me.add_player_help_ToolTip.UseAnimation = False
        Me.add_player_help_ToolTip.UseFading = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(177, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "The tile set to be used:"
        '
        'button_choose_tile_set
        '
        Me.button_choose_tile_set.Location = New System.Drawing.Point(12, 68)
        Me.button_choose_tile_set.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.button_choose_tile_set.Name = "button_choose_tile_set"
        Me.button_choose_tile_set.Size = New System.Drawing.Size(173, 28)
        Me.button_choose_tile_set.TabIndex = 0
        Me.button_choose_tile_set.Text = "Choose another tile set"
        Me.button_choose_tile_set.UseVisualStyleBackColor = True
        '
        'button_display_database_choosing_help
        '
        Me.button_display_database_choosing_help.Location = New System.Drawing.Point(212, 68)
        Me.button_display_database_choosing_help.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.button_display_database_choosing_help.Name = "button_display_database_choosing_help"
        Me.button_display_database_choosing_help.Size = New System.Drawing.Size(29, 28)
        Me.button_display_database_choosing_help.TabIndex = 1
        Me.button_display_database_choosing_help.Text = "?"
        Me.button_display_database_choosing_help.UseVisualStyleBackColor = True
        '
        'label_database_file_path
        '
        Me.label_database_file_path.AutoSize = True
        Me.label_database_file_path.Location = New System.Drawing.Point(15, 39)
        Me.label_database_file_path.Name = "label_database_file_path"
        Me.label_database_file_path.Size = New System.Drawing.Size(27, 17)
        Me.label_database_file_path.TabIndex = 9
        Me.label_database_file_path.Text = "NA"
        '
        'table_layout_panel_added_players
        '
        Me.table_layout_panel_added_players.AutoSize = True
        Me.table_layout_panel_added_players.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.table_layout_panel_added_players.BackColor = System.Drawing.SystemColors.Control
        Me.table_layout_panel_added_players.ColumnCount = 2
        Me.table_layout_panel_added_players.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195.0!))
        Me.table_layout_panel_added_players.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.table_layout_panel_added_players.Location = New System.Drawing.Point(12, 256)
        Me.table_layout_panel_added_players.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.table_layout_panel_added_players.Name = "table_layout_panel_added_players"
        Me.table_layout_panel_added_players.RowCount = 1
        Me.table_layout_panel_added_players.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.table_layout_panel_added_players.Size = New System.Drawing.Size(230, 0)
        Me.table_layout_panel_added_players.TabIndex = 13
        '
        'button_tile_set_options
        '
        Me.button_tile_set_options.Location = New System.Drawing.Point(12, 110)
        Me.button_tile_set_options.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.button_tile_set_options.Name = "button_tile_set_options"
        Me.button_tile_set_options.Size = New System.Drawing.Size(229, 28)
        Me.button_tile_set_options.TabIndex = 2
        Me.button_tile_set_options.Text = "Advanced tile set options"
        Me.button_tile_set_options.UseVisualStyleBackColor = True
        '
        'button_start_game
        '
        Me.button_start_game.Enabled = False
        Me.button_start_game.Location = New System.Drawing.Point(12, 153)
        Me.button_start_game.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.button_start_game.Name = "button_start_game"
        Me.button_start_game.Size = New System.Drawing.Size(89, 28)
        Me.button_start_game.TabIndex = 3
        Me.button_start_game.Text = "Start"
        Me.button_start_game.UseVisualStyleBackColor = True
        '
        'game_setup_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(260, 271)
        Me.Controls.Add(Me.button_start_game)
        Me.Controls.Add(Me.button_tile_set_options)
        Me.Controls.Add(Me.table_layout_panel_added_players)
        Me.Controls.Add(Me.label_database_file_path)
        Me.Controls.Add(Me.button_display_database_choosing_help)
        Me.Controls.Add(Me.button_choose_tile_set)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.text_box_add_player)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "game_setup_form"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 9, 9)
        Me.Text = "Game Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents text_box_add_player As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents add_player_help_ToolTip As ToolTip
    Friend WithEvents Label5 As Label
    Friend WithEvents button_choose_tile_set As Button
    Friend WithEvents button_display_database_choosing_help As Button
    Friend WithEvents label_database_file_path As Label
    Friend WithEvents table_layout_panel_added_players As TableLayoutPanel
    Friend WithEvents button_tile_set_options As Button
    Friend WithEvents button_start_game As Button
End Class
