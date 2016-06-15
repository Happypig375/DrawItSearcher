<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrawItSearcher
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
        Me.Input = New System.Windows.Forms.TextBox()
        Me.List = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Input
        '
        Me.Input.Dock = System.Windows.Forms.DockStyle.Top
        Me.Input.Location = New System.Drawing.Point(0, 0)
        Me.Input.Name = "Input"
        Me.Input.Size = New System.Drawing.Size(284, 20)
        Me.Input.TabIndex = 0
        '
        'List
        '
        Me.List.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.List.FormattingEnabled = True
        Me.List.Location = New System.Drawing.Point(0, 23)
        Me.List.Name = "List"
        Me.List.Size = New System.Drawing.Size(284, 238)
        Me.List.TabIndex = 1
        '
        'DrawItSearcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.List)
        Me.Controls.Add(Me.Input)
        Me.Name = "DrawItSearcher"
        Me.Text = "DrawItSearcher"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Input As TextBox
    Friend WithEvents List As ListBox
End Class
