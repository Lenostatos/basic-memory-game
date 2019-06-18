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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.table_layout_panel_added_players = New System.Windows.Forms.TableLayoutPanel()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Add Player:"
        '
        'text_box_add_player
        '
        Me.text_box_add_player.Location = New System.Drawing.Point(12, 150)
        Me.text_box_add_player.Name = "text_box_add_player"
        Me.text_box_add_player.Size = New System.Drawing.Size(138, 22)
        Me.text_box_add_player.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(133, 121)
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
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 68)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(173, 28)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Choose another tile set"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(212, 68)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(30, 28)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "?"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 17)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "NA"
        '
        'table_layout_panel_added_players
        '
        Me.table_layout_panel_added_players.AutoSize = True
        Me.table_layout_panel_added_players.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.table_layout_panel_added_players.BackColor = System.Drawing.SystemColors.Control
        Me.table_layout_panel_added_players.ColumnCount = 2
        Me.table_layout_panel_added_players.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195.0!))
        Me.table_layout_panel_added_players.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.table_layout_panel_added_players.Location = New System.Drawing.Point(12, 178)
        Me.table_layout_panel_added_players.Name = "table_layout_panel_added_players"
        Me.table_layout_panel_added_players.RowCount = 1
        Me.table_layout_panel_added_players.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.table_layout_panel_added_players.Size = New System.Drawing.Size(230, 0)
        Me.table_layout_panel_added_players.TabIndex = 13
        '
        'game_setup_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(254, 231)
        Me.Controls.Add(Me.table_layout_panel_added_players)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.text_box_add_player)
        Me.Controls.Add(Me.Label2)
        Me.Name = "game_setup_form"
        Me.Text = "Game Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents text_box_add_player As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents add_player_help_ToolTip As ToolTip
    Friend WithEvents Label5 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents table_layout_panel_added_players As TableLayoutPanel
End Class
