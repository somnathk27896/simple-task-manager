Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Process As New Process()
        Dim Count As Integer = 0
        ListView1.Items.Clear()
        For Each Process In Process.GetProcesses(My.Computer.Name)
            On Error Resume Next
            ListView1.Items.Add(Process.ProcessName)
            ListView1.Items(Count).SubItems.Add(Process.Id)
            ListView1.Items(Count).SubItems.Add(FormatNumber(Math.Round(Process.PrivateMemorySize64 / 1024), 0))
            ListView1.Items(Count).SubItems.Add(Process.Responding)
            ListView1.Items(Count).SubItems.Add(Process.StartTime.ToString.Trim)
            ListView1.Items(Count).SubItems.Add(Process.ExitTime)
            Count += 1
        Next
        ToolStripStatusLabel1.Text = "Processes: " & ListView1.Items.Count

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        For Each Process As ListViewItem In ListView1.SelectedItems
            System.Diagnostics.Process.GetProcessById(Process.SubItems(1).Text).Kill()
        Next
        Form1_Load(Nothing, Nothing)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Form1_Load(Nothing, Nothing)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Form1_Load(Nothing, Nothing)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Process.Start(TextBox1.Text)
    End Sub
End Class

