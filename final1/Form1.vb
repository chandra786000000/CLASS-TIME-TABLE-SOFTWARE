Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conn As OleDbConnection
    Dim dta As OleDbDataAdapter
    Dim dts As DataSet
    Dim mysqlcon As SqlConnection
    Dim command As SqlCommand
    Dim fd As New OpenFileDialog
    Dim strFileName As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "E:\"
            fd.Filter = "All Files (*.*)|*.*|Excel Files(*.xlsx)|*.xlsx|Xls Files (*.xls)|*.xls "
            fd.RestoreDirectory = True

            If fd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(fd.FileName)
                Dim FileName As String = fd.FileName
                strFileName = fi.FullName
                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + ";Extended Properties=Excel 12.0;")
                dta = New OleDbDataAdapter("select * from [Sheet1$]", conn)
                dts = New DataSet
                dta.Fill(dts, "[Sheet1$]")
                DGV1.DataSource = dts
                DGV1.DataMember = "[Sheet1$]"
                conn.Close()
                MessageBox.Show("You selected " & fd.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Time-Table is already imported")
            conn.Close()
            Exit Sub
        End Try


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub
    Dim connection As New MySqlConnection("datasource='localhost';username='com786000000';password='chandra@123';database='cs243'")
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim cmd As MySqlCommand
            connection.Open()
            For i As Integer = 0 To DGV1.Rows.Count - 2 Step +1
                cmd = New MySqlCommand("insert into department values(@Id,@D_ay,@Start_Time,@End_Time,@Course)", connection)
                cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = DGV1.Rows(i).Cells(0).Value.ToString()
                cmd.Parameters.Add("@D_ay", MySqlDbType.VarChar).Value = DGV1.Rows(i).Cells(1).Value.ToString()
                cmd.Parameters.Add("@Start_Time", MySqlDbType.VarChar).Value = DGV1.Rows(i).Cells(2).Value.ToString()
                cmd.Parameters.Add("@End_Time", MySqlDbType.VarChar).Value = DGV1.Rows(i).Cells(3).Value.ToString()
                cmd.Parameters.Add("@Course", MySqlDbType.VarChar).Value = DGV1.Rows(i).Cells(4).Value.ToString()
                cmd.ExecuteNonQuery()
            Next
            connection.Close()
            MsgBox("Data Successfully Imported !")
        Catch ex As Exception
            MsgBox(ex.Message)
            connection.Close()
            Exit Sub
        End Try
    End Sub
    Dim connection1 As New MySqlConnection("datasource='localhost';username='com786000000';password='chandra@123';database='cs243'")
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim cmd1 As MySqlCommand
            connection1.Open()
            For i As Integer = 0 To DGV1.Rows.Count - 2 Step +1
                cmd1 = New MySqlCommand("insert into student_course_registered_table  values(@SCR_Id,@Stud_Id,@Course)", connection1)
                cmd1.Parameters.Add("@SCR_Id", MySqlDbType.VarChar).Value = DGV1.Rows(i).Cells(0).Value.ToString()
                cmd1.Parameters.Add("@Stud_Id", MySqlDbType.VarChar).Value = DGV1.Rows(i).Cells(1).Value.ToString()
                cmd1.Parameters.Add("@Course", MySqlDbType.VarChar).Value = DGV1.Rows(i).Cells(2).Value.ToString()
                cmd1.ExecuteNonQuery()
            Next
            connection1.Close()
            MsgBox("Data Successfully Imported !")
        Catch ex As Exception
            MsgBox(ex.Message)
            connection1.Close()
            Exit Sub
        End Try
    End Sub
    Dim conn1 As OleDbConnection
    Dim dta1 As OleDbDataAdapter
    Dim dts1 As DataSet
    Dim mysqlcon1 As SqlConnection
    Dim command1 As SqlCommand
    Dim fd1 As New OpenFileDialog
    Dim strFileName1 As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            fd1.Title = "Open File Dialog"
            fd1.InitialDirectory = "E:\"
            fd1.Filter = "All Files (*.*)|*.*|Excel Files(*.xlsx)|*.xlsx|Xls Files (*.xls)|*.xls "
            fd1.RestoreDirectory = True

            If fd1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Dim fi1 As New IO.FileInfo(fd1.FileName)
                Dim FileName1 As String = fd1.FileName
                strFileName1 = fi1.FullName
                conn1 = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName1 + ";Extended Properties=Excel 12.0;")
                dta1 = New OleDbDataAdapter("select * from [Sheet1$]", conn1)
                dts1 = New DataSet
                dta1.Fill(dts1, "[Sheet1$]")
                DGV1.DataSource = dts1
                DGV1.DataMember = "[Sheet1$]"
                conn1.Close()
                MessageBox.Show("You selected " & fd1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Time-Table is already imported")
            conn.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Dim command5 As MySqlCommand
    Dim connection5 As New MySqlConnection("datasource='localhost';username='com786000000';password='chandra@123';database='cs243'")
    Dim reader As MySqlDataReader
    Private Sub bt5_Click(sender As Object, e As EventArgs) Handles bt5.Click
        Try
            Dim query As String
            connection5.Open()
            query = "select D_ay,Start_Time,End_Time,Course from department natural join Student_Course_Registered_Table where Stud_Id='" & TextBox1.Text & "' ORDER BY D_ay ASC"
            command5 = New MySqlCommand(query, connection5)
            reader = command5.ExecuteReader
            Dim dt = New DataTable()
            dt.Load(reader)

            DGV2.AutoGenerateColumns = True
            DGV2.DataSource = dt
            DGV2.Refresh()
            connection5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            connection5.Close()
        End Try

    End Sub
    Dim cmd6 As MySqlCommand
    Dim conn6 As New MySqlConnection("datasource='localhost';username='com786000000';password='chandra@123';database='cs243'")

    Private Sub bt6_Click(sender As Object, e As EventArgs) Handles bt6.Click
        Try
            Dim qry As String
            qry = "delete FROM cs243.department"
            Dim qry1 As String
            qry1 = "delete FROM cs243.Student_Course_Registered_Table"
            conn6.Open()
            cmd6 = New MySqlCommand(qry, conn6)
            If cmd6.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Item deleted")
            End If
            cmd6 = New MySqlCommand(qry1, conn6)
            cmd6.ExecuteNonQuery()
            conn6.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn6.Close()
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class