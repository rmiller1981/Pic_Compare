Imports System.IO
Imports System.ComponentModel

Public Class Form1
    Public worker As BackgroundWorker
    Public worker2 As BackgroundWorker
    Dim matchcount As Integer = 0
    Dim mismatchcount As Integer = 0
    Dim image1hold As Byte()
    Dim file1 As String = "C:\test\1.jpg"
    Dim file2 As String = "C:\test\2.jpg"
    Dim filestatus() As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        progressOverall.Minimum = 0
        worker = New System.ComponentModel.BackgroundWorker
        worker.WorkerReportsProgress = True
        worker.WorkerSupportsCancellation = True
        AddHandler worker.DoWork, AddressOf worker_DoWork

        worker2 = New System.ComponentModel.BackgroundWorker
        worker2.WorkerReportsProgress = True
        worker2.WorkerSupportsCancellation = True
        AddHandler worker2.DoWork, AddressOf worker2_DoWork

    End Sub

    Private Sub worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        If worker.CancellationPending Then
            Exit Sub
        End If
        pic1.Image = New Bitmap(file1)
        pic2.Image = New Bitmap(file2)
        compare(getImage(file1), getImage(file2))
        Dim percent As Decimal = 0
        percent = matchcount / image1hold.Length * 100
        'filestatus(file2) = percent
        MsgBox(percent & " Percent")
        percent = 0
        matchcount = 0
        mismatchcount = 0
        ' Seams like something is missing here

    End Sub

    Private Function getImage(ByVal imagefile As String) As Byte()
        Dim bytes As Byte()
        bytes = File.ReadAllBytes(imagefile)
        SetFileProgressmax(bytes)
        'SetFileProgress(ProgressFile, ProgressFile.Maximum)
        Return bytes
    End Function

    Delegate Sub SetFileProgressmaxCallback(ByVal bytes As Byte())
    Private Sub SetFileProgressmax(ByVal bytes As Byte())

        'InvokeRequired required compares the thread ID of the
        'calling thread to the thread ID of the creating thread.
        'If these threads are different, it returns true.
        If ProgressFile.InvokeRequired Then
            Dim d As New SetFileProgressmaxCallback(AddressOf SetFileProgressmax)
            Me.Invoke(d, New Object() {bytes})
        Else
            ProgressFile.Maximum = bytes.Length
        End If
    End Sub

    Delegate Sub SetFileProgressCallback(ByVal bar As ProgressBar, ByVal value As Integer)
    Private Sub SetFileProgress(ByVal bar As ProgressBar, ByVal value As Integer)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If bar.InvokeRequired Then
            Dim d As New SetFileProgressCallback(AddressOf SetFileProgress)
            Me.Invoke(d, New Object() {bar, value})
        Else
            bar.Value = value
        End If
    End Sub

    Private Sub compare(ByVal image1 As Byte(), ByVal image2 As Byte())
        image1hold = image1
        For count As Integer = 0 To image1.Length
            If count = image1.Length Or count = image2.Length Then
                Exit For
            End If

            If image1(count) = image2(count) Then
                matchcount += 1
            Else
                mismatchcount += 1
            End If
            SetFileProgress(ProgressFile, ProgressFile.Value + 1)
        Next
        SetFileProgress(ProgressFile, ProgressFile.Maximum)
    End Sub

    Dim files As FileInfo()

    Private Sub btnDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectory.Click
        Dim FolderDialog As New FolderBrowserDialog
        If FolderDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim directory As New DirectoryInfo(FolderDialog.SelectedPath)
        files = directory.GetFiles("*.jpg")
        If files.Length < 2 Then Exit Sub
        progressOverall.Maximum = files.Length
        Label1.Visible = True
        

        worker2.RunWorkerAsync()
    End Sub
    Private Sub worker2_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim filecount As Integer = 0
        Dim filePosition As Integer = 1
        Do
            file1 = files(filecount).FullName
            Do
                file2 = files(filePosition).FullName
                worker.RunWorkerAsync()
                Do While worker.IsBusy

                Loop
                SetFileProgress(ProgressFile, 0)
                filePosition += 1
            Loop While filePosition < files.Length
            'progressOverall.Value = filecount
            SetFileProgress(progressOverall, progressOverall.Value + 1)
            filecount += 1
            filePosition = 0 + filecount
        Loop While filecount < files.Length

    End Sub

    Private Sub btnFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiles.Click
        Dim filedialog As New OpenFileDialog
        ' Select First File
        filedialog.Title = "Please select first file to compare."
        filedialog.InitialDirectory = "C:\test"
        filedialog.ShowDialog()
        file1 = filedialog.FileName
        ' Select second file
        filedialog.Title = "Please select second file to compare."
        filedialog.ShowDialog()
        file2 = filedialog.FileName
        Label1.Visible = True
        worker.RunWorkerAsync()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ProgressFile.Value = 0
        progressOverall.Value = 0
        Label1.Visible = False
    End Sub
End Class

Class holder
    Private Sub compare(ByVal image1 As String, ByVal image2 As String)
        'Cursor = Cursors.WaitCursor
        Application.DoEvents()

        ' Load the images.
        Dim bm1 As Bitmap = Image.FromFile(image1)
        Dim bm2 As Bitmap = Image.FromFile(image2)

        ' Make a difference image.
        Dim wid As Integer = Math.Min(bm1.Width, bm2.Width)
        Dim hgt As Integer = Math.Min(bm1.Height, bm2.Height)
        Dim bm3 As New Bitmap(wid, hgt)

        ' Create the difference image.
        Dim are_identical As Boolean = True
        'Dim r1, g1, b1, r2, g2, b2, r3, g3, b3 As Integer
        Dim eq_color As Color = Color.White
        Dim ne_color As Color = Color.Red
        For x As Integer = 0 To wid - 1
            For y As Integer = 0 To hgt - 1
                If bm1.GetPixel(x, y).Equals(bm2.GetPixel(x, y)) Then
                    bm3.SetPixel(x, y, eq_color)
                Else
                    bm3.SetPixel(x, y, ne_color)
                    are_identical = False
                End If
            Next y
        Next x

        ' Display the result.
        'Form1.picResult.Image = bm3

        'Cursor = Cursors.Default
        If (bm1.Width <> bm2.Width) OrElse (bm1.Height <> _
            bm2.Height) Then are_identical = False
        If are_identical Then
            MessageBox.Show("The images are identical")
        Else
            MessageBox.Show("The images are different")
        End If

        bm1.Dispose()
        bm2.Dispose()
    End Sub
End Class