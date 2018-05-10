<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.progressOverall = New System.Windows.Forms.ProgressBar()
        Me.ProgressFile = New System.Windows.Forms.ProgressBar()
        Me.btnFiles = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDirectory = New System.Windows.Forms.Button()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.pic2 = New System.Windows.Forms.PictureBox()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Processing images"
        Me.Label1.Visible = False
        '
        'progressOverall
        '
        Me.progressOverall.Location = New System.Drawing.Point(6, 140)
        Me.progressOverall.Name = "progressOverall"
        Me.progressOverall.Size = New System.Drawing.Size(254, 23)
        Me.progressOverall.TabIndex = 1
        '
        'ProgressFile
        '
        Me.ProgressFile.Location = New System.Drawing.Point(6, 169)
        Me.ProgressFile.Name = "ProgressFile"
        Me.ProgressFile.Size = New System.Drawing.Size(254, 23)
        Me.ProgressFile.TabIndex = 2
        '
        'btnFiles
        '
        Me.btnFiles.Location = New System.Drawing.Point(29, 227)
        Me.btnFiles.Name = "btnFiles"
        Me.btnFiles.Size = New System.Drawing.Size(127, 23)
        Me.btnFiles.TabIndex = 3
        Me.btnFiles.Text = "Compare files"
        Me.btnFiles.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(162, 212)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDirectory
        '
        Me.btnDirectory.Location = New System.Drawing.Point(29, 198)
        Me.btnDirectory.Name = "btnDirectory"
        Me.btnDirectory.Size = New System.Drawing.Size(127, 23)
        Me.btnDirectory.TabIndex = 5
        Me.btnDirectory.Text = "Compare Directory files"
        Me.btnDirectory.UseVisualStyleBackColor = True
        '
        'pic1
        '
        Me.pic1.Location = New System.Drawing.Point(12, 12)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(119, 109)
        Me.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic1.TabIndex = 6
        Me.pic1.TabStop = False
        '
        'pic2
        '
        Me.pic2.Location = New System.Drawing.Point(141, 12)
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(119, 109)
        Me.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic2.TabIndex = 7
        Me.pic2.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 262)
        Me.Controls.Add(Me.pic2)
        Me.Controls.Add(Me.pic1)
        Me.Controls.Add(Me.btnDirectory)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnFiles)
        Me.Controls.Add(Me.ProgressFile)
        Me.Controls.Add(Me.progressOverall)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents progressOverall As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressFile As System.Windows.Forms.ProgressBar
    Friend WithEvents btnFiles As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDirectory As System.Windows.Forms.Button
    Friend WithEvents pic1 As System.Windows.Forms.PictureBox
    Friend WithEvents pic2 As System.Windows.Forms.PictureBox

End Class
