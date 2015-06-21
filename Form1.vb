Imports System.Data.OleDb
Public Class Form1
    Public orderid As Integer = 0
    Public box1, box2, box3, box4, box5, box6, box7, box8, box9, box10, box11, box12, box13 As String

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If box1 <> TextBox4.Text Or box2 <> TextBox3.Text Or box3 <> TextBox5.Text Or box4 <> TextBox6.Text Or box5 <> TextBox9.Text Or box6 <> TextBox10.Text Or box7 <> ComboBox1.Text Or box8 <> TextBox7.Text Or box9 <> TextBox11.Text Or box10 <> TextBox12.Text Or box11 <> TextBox13.Text Or box12 <> TextBox14.Text Or box13 <> TextBox15.Text Then
            If MsgBox("Save Changes?", MsgBoxStyle.YesNo) = 6 Then Call savechanges()
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        scrollingposition = 0
        scrollingposition2 = 0
        'TODO: This line of code loads data into the 'Database3DataSet.Notes' table. You can move, or remove it, as needed.
        OleDbDataAdapter1.Fill(DataSet11)
        Me.NotesTableAdapter.Fill(Me.Database3DataSet.Notes)
        Dim County, SQLString As String
        Dim dtProperties As New DataTable() 'Data table will fill the data grid
        Dim dbDataAdapter As OleDbDataAdapter
        Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
        County = "OPEN"
        SQLString = "SELECT * FROM Orders WHERE OPENCLOSE = " & "'" & County & "'" & ""
        dbDataAdapter = New OleDbDataAdapter(SQLString, ConnectString)
        dbDataAdapter.Fill(dtProperties)
        DataGridView1.DataSource = dtProperties
        Dim newYear As Integer
        Dim oldYear As Integer
        Dim oldMonth As Integer
        Dim oldDay As Integer
        newYear = DateTimePicker1.Value.Year - 1
        oldYear = DateTimePicker1.Value.Year
        oldMonth = DateTimePicker1.Value.Month
        oldDay = DateTimePicker1.Value.Day
        If DateTime.IsLeapYear(oldYear) AndAlso oldMonth = 2 AndAlso oldDay = 29 Then
            If Not DateTime.IsLeapYear(newYear) Then
                oldDay = 28
            End If
        End If
        DateTimePicker1.Value = New DateTime(newYear, oldMonth, oldDay)
        DateTimePicker2.Value = Today
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        On Error Resume Next
        Dim Search, SQLString, SQLString2, SQLString3, SQLString4, SQLString5, SQLString6, SQLString7 As String
        Dim dtProperties As New DataTable() 'Data table will fill the data grid
        Dim dbDataAdapter As OleDbDataAdapter
        Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
        Search = Replace(TextBox1.Text, "'", "''")
        SQLString = "SELECT * FROM Orders WHERE OPENCLOSE = " & "'" & "OPEN" & "'" & ""
        SQLString2 = "AND (CustNum LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString3 = "OR IMPAC LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString4 = "OR TELNET LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString5 = "OR Requester LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString6 = "OR Desc LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString7 = "OR Custname LIKE " & "'" & "%" & Search & "%" & "')" & ""
        dbDataAdapter = New OleDbDataAdapter(SQLString & SQLString2 & SQLString3 & SQLString4 & SQLString5 & SQLString6 & SQLString7, ConnectString)
        dbDataAdapter.Fill(dtProperties)
        DataGridView1.DataSource = dtProperties
        For i = 0 To DataGridView1.RowCount - 1
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Red" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "LightBlue" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "LightGreen" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Yellow" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Orange" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "MediumPurple" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.MediumPurple
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Pink" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Pink
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        orderid = 0
        Button11.Text = "CLOSE"
        Button7.Text = "ADD"
        box1 = ""
        box2 = ""
        box3 = ""
        box4 = ""
        box5 = ""
        box6 = ""
        box7 = ""
        box8 = ""
        box9 = ""
        box10 = ""
        box11 = ""
        box12 = ""
        box13 = ""
        TextBox4.Text = box1
        TextBox3.Text = box2
        TextBox5.Text = box3
        TextBox6.Text = box4
        TextBox9.Text = box5
        TextBox10.Text = box6
        ComboBox1.Text = box7
        TextBox7.Text = box8
        TextBox11.Text = box9
        TextBox12.Text = box10
        TextBox13.Text = box11
        TextBox14.Text = box12
        TextBox15.Text = box13
        TabControl1.SelectTab(TabPage3)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        On Error Resume Next
        Dim Search, SQLString, SQLString8, SQLString2, SQLString3, SQLString4, SQLString5, SQLString6, SQLString7 As String
        Dim fromdate, todate As String
        Dim dtProperties As New DataTable() 'Data table will fill the data grid
        Dim dbDataAdapter As OleDbDataAdapter
        Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
        Search = Replace(TextBox2.Text, "'", "''")
        fromdate = FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate)
        todate = FormatDateTime(DateTimePicker2.Value, DateFormat.ShortDate)
        SQLString = "SELECT * FROM Orders WHERE Date >= " & "#" & fromdate & "#" & ""
        SQLString8 = "AND Date <= " & "#" & todate & "#" & ""
        SQLString2 = "AND (CustNum LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString3 = "OR IMPAC LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString4 = "OR TELNET LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString5 = "OR Requester LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString6 = "OR Desc LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString7 = "OR Custname LIKE " & "'" & "%" & Search & "%" & "')" & ""
        dbDataAdapter = New OleDbDataAdapter(SQLString & SQLString8 & SQLString2 & SQLString3 & SQLString4 & SQLString5 & SQLString6 & SQLString7, ConnectString)
        dbDataAdapter.Fill(dtProperties)
        DataGridView2.DataSource = dtProperties
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox2.Text = ""
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        On Error Resume Next
        Dim Search, SQLString, SQLString8, SQLString2, SQLString3, SQLString4, SQLString5, SQLString6, SQLString7 As String
        Dim fromdate, todate As String
        Dim dtProperties As New DataTable() 'Data table will fill the data grid
        Dim dbDataAdapter As OleDbDataAdapter
        Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
        Search = Replace(TextBox2.Text, "'", "''")
        fromdate = FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate)
        todate = FormatDateTime(DateTimePicker2.Value, DateFormat.ShortDate)
        SQLString = "SELECT * FROM Orders WHERE Date >= " & "#" & fromdate & "#" & ""
        SQLString8 = "AND Date <= " & "#" & todate & "#" & ""
        SQLString2 = "AND (CustNum LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString3 = "OR IMPAC LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString4 = "OR TELNET LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString5 = "OR Requester LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString6 = "OR Desc LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString7 = "OR Custname LIKE " & "'" & "%" & Search & "%" & "')" & ""
        dbDataAdapter = New OleDbDataAdapter(SQLString & SQLString8 & SQLString2 & SQLString3 & SQLString4 & SQLString5 & SQLString6 & SQLString7, ConnectString)
        dbDataAdapter.Fill(dtProperties)
        DataGridView2.DataSource = dtProperties
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        On Error Resume Next
        Dim Search, SQLString, SQLString8, SQLString2, SQLString3, SQLString4, SQLString5, SQLString6, SQLString7 As String
        Dim fromdate, todate As String
        Dim dtProperties As New DataTable() 'Data table will fill the data grid
        Dim dbDataAdapter As OleDbDataAdapter
        Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
        Search = Replace(TextBox2.Text, "'", "''")
        fromdate = FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate)
        todate = FormatDateTime(DateTimePicker2.Value, DateFormat.ShortDate)
        SQLString = "SELECT * FROM Orders WHERE Date >= " & "#" & fromdate & "#" & ""
        SQLString8 = "AND Date <= " & "#" & todate & "#" & ""
        SQLString2 = "AND (CustNum LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString3 = "OR IMPAC LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString4 = "OR TELNET LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString5 = "OR Requester LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString6 = "OR Desc LIKE " & "'" & "%" & Search & "%" & "'" & ""
        SQLString7 = "OR Custname LIKE " & "'" & "%" & Search & "%" & "')" & ""
        dbDataAdapter = New OleDbDataAdapter(SQLString & SQLString8 & SQLString2 & SQLString3 & SQLString4 & SQLString5 & SQLString6 & SQLString7, ConnectString)
        dbDataAdapter.Fill(dtProperties)
        DataGridView2.DataSource = dtProperties
    End Sub
    Public scrollingposition As Integer
    Public scrollingposition2 As Integer
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            scrollingposition = DataGridView1.FirstDisplayedScrollingRowIndex
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            orderid = selectedRow.Cells("Column1").Value()
            TabControl1.SelectTab(TabPage3)
            On Error Resume Next
            If selectedRow.Cells("CustNumDataGridViewTextBoxColumn").Value() = "" Then TextBox4.Text = "" Else  : TextBox4.Text = selectedRow.Cells("CustNumDataGridViewTextBoxColumn").Value()
            If selectedRow.Cells("CustNameDataGridViewTextBoxColumn").Value() = "" Then TextBox3.Text = "" Else  : TextBox3.Text = selectedRow.Cells("CustNameDataGridViewTextBoxColumn").Value()
            If selectedRow.Cells("RequesterDataGridViewTextBoxColumn").Value() = "" Then TextBox5.Text = "" Else  : TextBox5.Text = selectedRow.Cells("RequesterDataGridViewTextBoxColumn").Value()
            If selectedRow.Cells("DescDataGridViewTextBoxColumn").Value() = "" Then TextBox6.Text = "" Else  : TextBox6.Text = selectedRow.Cells("DescDataGridViewTextBoxColumn").Value()
            If selectedRow.Cells("ImpacDataGridViewTextBoxColumn").Value() = "" Then TextBox9.Text = "" Else  : TextBox9.Text = selectedRow.Cells("ImpacDataGridViewTextBoxColumn").Value()
            If selectedRow.Cells("TelnetDataGridViewTextBoxColumn").Value() = "" Then TextBox10.Text = "" Else  : TextBox10.Text = selectedRow.Cells("TelnetDataGridViewTextBoxColumn").Value()
            If selectedRow.Cells("Status").Value() = "" Then ComboBox1.Text = "" Else  : ComboBox1.Text = selectedRow.Cells("Status").Value()
            If selectedRow.Cells("Special").Value() = "" Then TextBox7.Text = "" Else  : TextBox7.Text = selectedRow.Cells("Special").Value()
            If selectedRow.Cells("COM1").Value() = "" Then TextBox11.Text = "" Else  : TextBox11.Text = selectedRow.Cells("COM1").Value()
            If selectedRow.Cells("COM2").Value() = "" Then TextBox12.Text = "" Else  : TextBox12.Text = selectedRow.Cells("COM2").Value()
            If selectedRow.Cells("COM3").Value() = "" Then TextBox13.Text = "" Else  : TextBox13.Text = selectedRow.Cells("COM3").Value()
            If selectedRow.Cells("COM4").Value() = "" Then TextBox14.Text = "" Else  : TextBox14.Text = selectedRow.Cells("COM4").Value()
            If selectedRow.Cells("COM5").Value() = "" Then TextBox15.Text = "" Else  : TextBox15.Text = selectedRow.Cells("COM5").Value()
            box1 = TextBox4.Text
            box2 = TextBox3.Text
            box3 = TextBox5.Text
            box4 = TextBox6.Text
            box5 = TextBox9.Text
            box6 = TextBox10.Text
            box7 = ComboBox1.Text
            box8 = TextBox7.Text
            box9 = TextBox11.Text
            box10 = TextBox12.Text
            box11 = TextBox13.Text
            box12 = TextBox14.Text
            box13 = TextBox15.Text
            If selectedRow.Cells("OPENCLOSE").Value() = "OPEN" Then
                Button11.Text = "CLOSE"
            Else
                Button11.Text = "OPEN"
            End If
            Button7.Text = "UPDATE"
        End If
    End Sub
    Private Sub DataGridView2_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            scrollingposition2 = DataGridView2.FirstDisplayedScrollingRowIndex
            Dim selectedRow = DataGridView2.Rows(e.RowIndex)
            On Error Resume Next
            orderid = selectedRow.Cells("Column2").Value()
            TabControl1.SelectTab(TabPage3)
            If selectedRow.Cells("CustNumDataGridViewTextBoxColumn1").Value() = "" Then TextBox4.Text = "" Else  : TextBox4.Text = selectedRow.Cells("CustNumDataGridViewTextBoxColumn1").Value()
            If selectedRow.Cells("CustNameDataGridViewTextBoxColumn1").Value() = "" Then TextBox3.Text = "" Else  : TextBox3.Text = selectedRow.Cells("CustNameDataGridViewTextBoxColumn1").Value()
            If selectedRow.Cells("RequesterDataGridViewTextBoxColumn1").Value() = "" Then TextBox5.Text = "" Else  : TextBox5.Text = selectedRow.Cells("RequesterDataGridViewTextBoxColumn1").Value()
            If selectedRow.Cells("DescDataGridViewTextBoxColumn1").Value() = "" Then TextBox6.Text = "" Else  : TextBox6.Text = selectedRow.Cells("DescDataGridViewTextBoxColumn1").Value()
            If selectedRow.Cells("ImpacDataGridViewTextBoxColumn1").Value() = "" Then TextBox9.Text = "" Else  : TextBox9.Text = selectedRow.Cells("ImpacDataGridViewTextBoxColumn1").Value()
            If selectedRow.Cells("TelnetDataGridViewTextBoxColumn1").Value() = "" Then TextBox10.Text = "" Else  : TextBox10.Text = selectedRow.Cells("TelnetDataGridViewTextBoxColumn1").Value()
            If selectedRow.Cells("StatusDataGridViewTextBoxColumn").Value() = "" Then ComboBox1.Text = "" Else  : ComboBox1.Text = selectedRow.Cells("StatusDataGridViewTextBoxColumn").Value()
            If selectedRow.Cells("Special3").Value() = "" Then TextBox7.Text = "" Else  : TextBox7.Text = selectedRow.Cells("Special3").Value()
            If selectedRow.Cells("COM12").Value() = "" Then TextBox11.Text = "" Else  : TextBox11.Text = selectedRow.Cells("COM12").Value()
            If selectedRow.Cells("COM22").Value() = "" Then TextBox12.Text = "" Else  : TextBox12.Text = selectedRow.Cells("COM22").Value()
            If selectedRow.Cells("COM32").Value() = "" Then TextBox13.Text = "" Else  : TextBox13.Text = selectedRow.Cells("COM32").Value()
            If selectedRow.Cells("COM42").Value() = "" Then TextBox14.Text = "" Else  : TextBox14.Text = selectedRow.Cells("COM42").Value()
            If selectedRow.Cells("COM52").Value() = "" Then TextBox15.Text = "" Else  : TextBox15.Text = selectedRow.Cells("COM52").Value()
            box1 = TextBox4.Text
            box2 = TextBox3.Text
            box3 = TextBox5.Text
            box4 = TextBox6.Text
            box5 = TextBox9.Text
            box6 = TextBox10.Text
            box7 = ComboBox1.Text
            box8 = TextBox7.Text
            box9 = TextBox11.Text
            box10 = TextBox12.Text
            box11 = TextBox13.Text
            box12 = TextBox14.Text
            box13 = TextBox15.Text
            If selectedRow.Cells("OPENCLOSEDataGridViewTextBoxColumn").Value() = "OPEN" Then
                Button11.Text = "CLOSE"
            Else
                Button11.Text = "OPEN"
            End If
            Button7.Text = "UPDATE"
        End If
    End Sub
    Sub savechanges()
        If orderid = 0 Then
            box1 = TextBox4.Text
            box2 = TextBox3.Text
            box3 = TextBox5.Text
            box4 = TextBox6.Text
            box5 = TextBox9.Text
            box6 = TextBox10.Text
            box7 = ComboBox1.Text
            box8 = TextBox7.Text
            box9 = TextBox11.Text
            box10 = TextBox12.Text
            box11 = TextBox13.Text
            box12 = TextBox14.Text
            box13 = TextBox15.Text
            OrdersTableAdapter.Insert(box1, box2, box4, box5, box6, box3, box8, box7, Today, "OPEN", box9, box10, box11, box12, box13)
            OleDbDataAdapter1.Fill(DataSet11)
            orderid = DataSet11.Tables(0).Rows(DataSet11.Tables(0).Rows.Count - 1)(0)
            Button7.Text = "UPDATE"
            NotesTableAdapter.Insert(orderid, Today & " " & TimeOfDay, GetUserName, "** ORDER CREATED **")
            NotesTableAdapter.Fill(Database3DataSet.Notes)
            Dim SQLString9 As String
            Dim dtProperties2 As New DataTable() 'Data table will fill the data grid
            Dim dbDataAdapter2 As OleDbDataAdapter
            Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
            SQLString9 = "SELECT * FROM Notes WHERE OrderID = " & "'" & orderid & "'" & ""
            dbDataAdapter2 = New OleDbDataAdapter(SQLString9, ConnectString)
            dbDataAdapter2.Fill(dtProperties2)
            DataGridView3.DataSource = dtProperties2
            DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        Else
            Dim string1 As String = ""
            Dim string2 As String = ""
            Dim string3 As String = ""
            Dim string4 As String = ""
            Dim string5 As String = ""
            Dim string6 As String = ""
            Dim string7 As String = ""
            Dim string8 As String = ""
            Dim string9 As String = ""
            Dim string10 As String = ""
            Dim string11 As String = ""
            Dim string12 As String = ""
            Dim string13 As String = ""
            If box1 <> TextBox4.Text Then string1 = "CUSTOMER NUMBER changed from '" & box1 & "' to '" & TextBox4.Text & "' "
            If box2 <> TextBox3.Text Then string2 = "CUSTOMER NAME changed from '" & box2 & "' to '" & TextBox3.Text & "' "
            If box3 <> TextBox5.Text Then string3 = "REQUESTER changed from '" & box3 & "' to '" & TextBox5.Text & "' "
            If box4 <> TextBox6.Text Then string4 = "DESCRIPTION changed from '" & box4 & "' to '" & TextBox6.Text & "' "
            If box5 <> TextBox9.Text Then string5 = "IMPAC # changed from '" & box5 & "' to '" & TextBox9.Text & "' "
            If box6 <> TextBox10.Text Then string6 = "TELNET # changed from '" & box6 & "' to '" & TextBox10.Text & "' "
            If box7 <> ComboBox1.Text Then string7 = "STATUS changed from '" & box7 & "' to '" & ComboBox1.Text & "' "
            If box8 <> TextBox7.Text Then string8 = "SPECIAL INSTRUCTIONS changed from '" & box8 & "' to '" & TextBox7.Text & "' "
            If box9 <> TextBox11.Text Then string9 = "COMMISSION NAME 1 changed from '" & box9 & "' to '" & TextBox11.Text & "' "
            If box10 <> TextBox12.Text Then string10 = "COMMISSION AMT 1 changed from '" & box10 & "' to '" & TextBox12.Text & "' "
            If box11 <> TextBox13.Text Then string11 = "COMMISSION NAME 2 changed from '" & box11 & "' to '" & TextBox13.Text & "' "
            If box12 <> TextBox14.Text Then string12 = "COMMISSION AMT 2 changed from '" & box12 & "' to '" & TextBox14.Text & "' "
            If box13 <> TextBox15.Text Then string13 = "VALUE changed from '" & box13 & "' to '" & TextBox15.Text & "' "
            box1 = TextBox4.Text
            box2 = TextBox3.Text
            box3 = TextBox5.Text
            box4 = TextBox6.Text
            box5 = TextBox9.Text
            box6 = TextBox10.Text
            box7 = ComboBox1.Text
            box8 = TextBox7.Text
            box9 = TextBox11.Text
            box10 = TextBox12.Text
            box11 = TextBox13.Text
            box12 = TextBox14.Text
            box13 = TextBox15.Text
            OrdersTableAdapter.UpdateQuery(box1, box2, box4, box5, box6, box3, box8, box7, box9, box10, box11, box12, box13, orderid)
            NotesTableAdapter.Insert(orderid, Today & " " & TimeOfDay, GetUserName, "**ORDER UPDATED** " & string1 & string2 & string3 & string4 & string5 & string6 & string7 & string8 & string9 & string10 & string11 & string12 & string13)
            NotesTableAdapter.Fill(Database3DataSet.Notes)
            Dim SQLString9 As String
            Dim dtProperties2 As New DataTable() 'Data table will fill the data grid
            Dim dbDataAdapter2 As OleDbDataAdapter
            Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
            SQLString9 = "SELECT * FROM Notes WHERE OrderID = " & "'" & orderid & "'" & ""
            dbDataAdapter2 = New OleDbDataAdapter(SQLString9, ConnectString)
            dbDataAdapter2.Fill(dtProperties2)
            DataGridView3.DataSource = dtProperties2
            DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        End If
    End Sub
    Public colours(99999) As String
    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) _
     Handles TabControl1.Selecting
        If DataGridView1.FirstDisplayedScrollingRowIndex >= 0 Then scrollingposition = DataGridView1.FirstDisplayedScrollingRowIndex
        If DataGridView2.FirstDisplayedScrollingRowIndex >= 0 Then scrollingposition2 = DataGridView2.FirstDisplayedScrollingRowIndex
        If TabControl1.SelectedTab.Text = "Order Details" Then
            Dim SQLString9 As String
            Dim dtProperties2 As New DataTable() 'Data table will fill the data grid
            Dim dbDataAdapter2 As OleDbDataAdapter
            Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
            SQLString9 = "SELECT * FROM Notes WHERE OrderID = " & "'" & orderid & "'" & ""
            dbDataAdapter2 = New OleDbDataAdapter(SQLString9, ConnectString)
            dbDataAdapter2.Fill(dtProperties2)
            DataGridView3.DataSource = dtProperties2
            DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        Else
            If box1 <> TextBox4.Text Or box2 <> TextBox3.Text Or box3 <> TextBox5.Text Or box4 <> TextBox6.Text Or box5 <> TextBox9.Text Or box6 <> TextBox10.Text Or box7 <> ComboBox1.Text Or box8 <> TextBox7.Text Or box9 <> TextBox11.Text Or box10 <> TextBox12.Text Or box11 <> TextBox13.Text Or box12 <> TextBox14.Text Or box13 <> TextBox15.Text Then
                If MsgBox("Save Changes?", MsgBoxStyle.YesNo) = 6 Then Call savechanges() Else  : Call dontsave()
            End If
            If TabControl1.SelectedTab.Text = "Open Orders" Then
                On Error Resume Next
                Dim Search, SQLString, SQLString2, SQLString3, SQLString4, SQLString5, SQLString6, SQLString7 As String
                Dim dtProperties As New DataTable() 'Data table will fill the data grid
                Dim dbDataAdapter As OleDbDataAdapter
                Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
                Search = Replace(TextBox1.Text, "'", "''")
                SQLString = "SELECT * FROM Orders WHERE OPENCLOSE = " & "'" & "OPEN" & "'" & ""
                SQLString2 = "AND (CustNum LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString3 = "OR IMPAC LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString4 = "OR TELNET LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString5 = "OR Requester LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString6 = "OR Desc LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString7 = "OR Custname LIKE " & "'" & "%" & Search & "%" & "')" & ""
                dbDataAdapter = New OleDbDataAdapter(SQLString & SQLString2 & SQLString3 & SQLString4 & SQLString5 & SQLString6 & SQLString7, ConnectString)
                dbDataAdapter.Fill(dtProperties)
                DataGridView1.DataSource = dtProperties
                DataGridView1.FirstDisplayedScrollingRowIndex = scrollingposition
                For i = 0 To DataGridView1.RowCount - 1
                    If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Red" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "LightBlue" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                    If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "LightGreen" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Yellow" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Orange" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange
                    If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "MediumPurple" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.MediumPurple
                    If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Pink" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Pink
                Next
            End If
            If TabControl1.SelectedTab.Text = "All Orders" Then
                On Error Resume Next
                Dim Search, SQLString, SQLString8, SQLString2, SQLString3, SQLString4, SQLString5, SQLString6, SQLString7 As String
                Dim fromdate, todate As String
                Dim dtProperties As New DataTable() 'Data table will fill the data grid
                Dim dbDataAdapter As OleDbDataAdapter
                Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
                Search = Replace(TextBox2.Text, "'", "''")
                fromdate = FormatDateTime(DateTimePicker1.Value, DateFormat.ShortDate)
                todate = FormatDateTime(DateTimePicker2.Value, DateFormat.ShortDate)
                SQLString = "SELECT * FROM Orders WHERE Date >= " & "#" & fromdate & "#" & ""
                SQLString8 = "AND Date <= " & "#" & todate & "#" & ""
                SQLString2 = "AND (CustNum LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString3 = "OR IMPAC LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString4 = "OR TELNET LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString5 = "OR Requester LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString6 = "OR Desc LIKE " & "'" & "%" & Search & "%" & "'" & ""
                SQLString7 = "OR Custname LIKE " & "'" & "%" & Search & "%" & "')" & ""
                dbDataAdapter = New OleDbDataAdapter(SQLString & SQLString8 & SQLString2 & SQLString3 & SQLString4 & SQLString5 & SQLString6 & SQLString7, ConnectString)
                dbDataAdapter.Fill(dtProperties)
                DataGridView2.DataSource = dtProperties
                DataGridView2.FirstDisplayedScrollingRowIndex = scrollingposition2
            End If
        End If
    End Sub
    Sub dontsave()
        TextBox4.Text = box1
        TextBox3.Text = box2
        TextBox5.Text = box3
        TextBox6.Text = box4
        TextBox9.Text = box5
        TextBox10.Text = box6
        ComboBox1.Text = box7
        TextBox7.Text = box8
        TextBox11.Text = box9
        TextBox12.Text = box10
        TextBox13.Text = box11
        TextBox14.Text = box12
        TextBox15.Text = box13
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If box1 <> TextBox4.Text Or box2 <> TextBox3.Text Or box3 <> TextBox5.Text Or box4 <> TextBox6.Text Or box5 <> TextBox9.Text Or box6 <> TextBox10.Text Or box7 <> ComboBox1.Text Or box8 <> TextBox7.Text Or box9 <> TextBox11.Text Or box10 <> TextBox12.Text Or box11 <> TextBox13.Text Or box12 <> TextBox14.Text Or box13 <> TextBox15.Text Then
            If MsgBox("Save Changes?", MsgBoxStyle.YesNo) = 6 Then Call savechanges()
        End If
        orderid = 0
        Button11.Text = "CLOSE"
        Button7.Text = "ADD"
        box1 = ""
        box2 = ""
        box3 = ""
        box4 = ""
        box5 = ""
        box6 = ""
        box7 = ""
        box8 = ""
        box9 = ""
        box10 = ""
        box11 = ""
        box12 = ""
        box13 = ""
        TextBox4.Text = box1
        TextBox3.Text = box2
        TextBox5.Text = box3
        TextBox6.Text = box4
        TextBox9.Text = box5
        TextBox10.Text = box6
        ComboBox1.Text = box7
        TextBox7.Text = box8
        TextBox11.Text = box9
        TextBox12.Text = box10
        TextBox13.Text = box11
        TextBox14.Text = box12
        TextBox15.Text = box13
        Dim SQLString9 As String
        Dim dtProperties2 As New DataTable() 'Data table will fill the data grid
        Dim dbDataAdapter2 As OleDbDataAdapter
        Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
        SQLString9 = "SELECT * FROM Notes WHERE OrderID = " & "'" & orderid & "'" & ""
        dbDataAdapter2 = New OleDbDataAdapter(SQLString9, ConnectString)
        dbDataAdapter2.Fill(dtProperties2)
        DataGridView3.DataSource = dtProperties2
        DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If box1 <> TextBox4.Text Or box2 <> TextBox3.Text Or box3 <> TextBox5.Text Or box4 <> TextBox6.Text Or box5 <> TextBox9.Text Or box6 <> TextBox10.Text Or box7 <> ComboBox1.Text Or box8 <> TextBox7.Text Or box9 <> TextBox11.Text Or box10 <> TextBox12.Text Or box11 <> TextBox13.Text Or box12 <> TextBox14.Text Or box13 <> TextBox15.Text Then
            If MsgBox("Save Changes?", MsgBoxStyle.YesNo) = 6 Then Call savechanges()
        End If
        orderid = 0
        Button11.Text = "CLOSE"
        Button7.Text = "ADD"
        box1 = ""
        box2 = ""
        box3 = ""
        box4 = ""
        box5 = ""
        box6 = ""
        box7 = ""
        box8 = ""
        box9 = ""
        box10 = ""
        box11 = ""
        box12 = ""
        box13 = ""
        Dim SQLString9 As String
        Dim dtProperties2 As New DataTable() 'Data table will fill the data grid
        Dim dbDataAdapter2 As OleDbDataAdapter
        Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
        SQLString9 = "SELECT * FROM Notes WHERE OrderID = " & "'" & orderid & "'" & ""
        dbDataAdapter2 = New OleDbDataAdapter(SQLString9, ConnectString)
        dbDataAdapter2.Fill(dtProperties2)
        DataGridView3.DataSource = dtProperties2
        DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If orderid = 0 Then
            MsgBox("Order must be saved")
        Else
            If Button11.Text = "OPEN" Then
                Button11.Text = "CLOSE"
                OrdersTableAdapter.OpenCloseQuery("OPEN", orderid)
                NotesTableAdapter.Insert(orderid, Today & " " & TimeOfDay, GetUserName, "** ORDER OPENED **")
                NotesTableAdapter.Fill(Database3DataSet.Notes)
                Dim SQLString9 As String
                Dim dtProperties2 As New DataTable() 'Data table will fill the data grid
                Dim dbDataAdapter2 As OleDbDataAdapter
                Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
                SQLString9 = "SELECT * FROM Notes WHERE OrderID = " & "'" & orderid & "'" & ""
                dbDataAdapter2 = New OleDbDataAdapter(SQLString9, ConnectString)
                dbDataAdapter2.Fill(dtProperties2)
                DataGridView3.DataSource = dtProperties2
                DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
            Else
                Button11.Text = "OPEN"
                OrdersTableAdapter.OpenCloseQuery("CLOSE", orderid)
                NotesTableAdapter.Insert(orderid, Today & " " & TimeOfDay, GetUserName, "** ORDER CLOSED **")
                NotesTableAdapter.Fill(Database3DataSet.Notes)
                Dim SQLString9 As String
                Dim dtProperties2 As New DataTable() 'Data table will fill the data grid
                Dim dbDataAdapter2 As OleDbDataAdapter
                Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
                SQLString9 = "SELECT * FROM Notes WHERE OrderID = " & "'" & orderid & "'" & ""
                dbDataAdapter2 = New OleDbDataAdapter(SQLString9, ConnectString)
                dbDataAdapter2.Fill(dtProperties2)
                DataGridView3.DataSource = dtProperties2
                DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form2.Show()
        Form2.TextBox1.Text = TextBox7.Text
    End Sub
    Private Sub DataGridView3_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView3.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow = DataGridView3.Rows(e.RowIndex)
            On Error Resume Next
            Form3.Show()
            Form3.TextBox1.Text = selectedRow.Cells("NoteDataGridViewTextBoxColumn").Value()
            Form3.TextBox2.Text = selectedRow.Cells("DateandTimeDataGridViewTextBoxColumn").Value()
            Form3.TextBox3.Text = selectedRow.Cells("UserDataGridViewTextBoxColumn").Value()
        End If
    End Sub
    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is  _
        Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If orderid = 0 Then
            MsgBox("Order must be saved first")
        Else
            NotesTableAdapter.Insert(orderid, Today & " " & TimeOfDay, GetUserName, TextBox8.Text)
            NotesTableAdapter.Fill(Database3DataSet.Notes)
            Dim SQLString9 As String
            Dim dtProperties2 As New DataTable() 'Data table will fill the data grid
            Dim dbDataAdapter2 As OleDbDataAdapter
            Dim ConnectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=|DataDirectory|\Database3.mdb"
            SQLString9 = "SELECT * FROM Notes WHERE OrderID = " & "'" & orderid & "'" & ""
            dbDataAdapter2 = New OleDbDataAdapter(SQLString9, ConnectString)
            dbDataAdapter2.Fill(dtProperties2)
            DataGridView3.DataSource = dtProperties2
            DataGridView3.Sort(DataGridView3.Columns(0), System.ComponentModel.ListSortDirection.Descending)
            TextBox8.Text = ""
        End If
    End Sub

    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.OrdersTableAdapter.FillBy(Me.Database3DataSet.Orders)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
 Call savechanges()
    End Sub

    Private Sub FillBy1ToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.OrdersTableAdapter.FillBy1(Me.Database3DataSet.Orders)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim location As String
        SaveFileDialog1.FileName = "*.xls"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            location = SaveFileDialog1.FileName
        Else
            Exit Sub
        End If
        Form4.Show()
        Dim xlApp As Object
        Dim xlWorkBook As Object
        Dim xlWorkSheet As Object
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer
        xlApp = CreateObject("Excel.Application")
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        For i = 0 To DataGridView2.RowCount - 1
            For j = 0 To DataGridView2.ColumnCount - 1
                For k As Integer = 1 To DataGridView2.Columns.Count
                    xlWorkSheet.Cells(1, k) = DataGridView2.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j + 1) = DataGridView2(j, i).Value.ToString()
                Next
            Next
        Next
        On Error Resume Next
        xlWorkSheet.SaveAs("" & location & "")
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
        Dim res As MsgBoxResult
        res = MsgBox("Process completed, Would you like to open file?", MsgBoxStyle.YesNo)
        If (res = MsgBoxResult.Yes) Then
            Process.Start("" & location & "")
        End If
        Form4.Hide()
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Public Shared MouseX As Integer
    Public Shared MouseY As Integer
    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        MouseX = e.X
        MouseY = e.Y
    End Sub
    Private Sub DataGridview1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim rowClicked As DataGridView.HitTestInfo = DataGridView1.HitTest(e.X, e.Y)
        'Select Right Clicked Row if its not the header row
        If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.RowIndex > -1 Then
            'Clear any currently sellected rows
            'DataGridView1.ClearSelection()
            If Me.DataGridView1.Rows(e.RowIndex).Selected = False Then DataGridView1.ClearSelection() : Me.DataGridView1.Rows(e.RowIndex).Selected = True
            ContextMenuStrip1.Show(DataGridView1, New System.Drawing.Point(MouseX, MouseY))
        End If
    End Sub
    Private Sub ThingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThingToolStripMenuItem.Click
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red : colours(DataGridView1.Rows(i).Cells("Column1").Value()) = "Red"
        Next
    End Sub

    Private Sub BlueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlueToolStripMenuItem.Click
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue : colours(DataGridView1.Rows(i).Cells("Column1").Value()) = "LightBlue"
        Next
    End Sub
    Private Sub GreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GreenToolStripMenuItem.Click
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen : colours(DataGridView1.Rows(i).Cells("Column1").Value()) = "LightGreen"
        Next
    End Sub

    Private Sub OrangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrangeToolStripMenuItem.Click
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange : colours(DataGridView1.Rows(i).Cells("Column1").Value()) = "Orange"
        Next
    End Sub

    Private Sub PurpleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurpleToolStripMenuItem.Click
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.MediumPurple : colours(DataGridView1.Rows(i).Cells("Column1").Value()) = "MediumPurple"
        Next
    End Sub

    Private Sub PinkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PinkToolStripMenuItem.Click
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Pink : colours(DataGridView1.Rows(i).Cells("Column1").Value()) = "Pink"
        Next
    End Sub

    Private Sub YellowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YellowToolStripMenuItem.Click
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow : colours(DataGridView1.Rows(i).Cells("Column1").Value()) = "Yellow"
        Next
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White : colours(DataGridView1.Rows(i).Cells("Column1").Value()) = ""
        Next
    End Sub
    Private Sub DataGridView1_Sorted(sender As Object, e As EventArgs) Handles DataGridView1.Sorted
        For i = 0 To DataGridView1.RowCount - 1
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Red" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "LightBlue" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "LightGreen" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Yellow" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Orange" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Orange
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "MediumPurple" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.MediumPurple
            If colours(DataGridView1.Rows(i).Cells("Column1").Value) = "Pink" Then DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Pink
        Next
    End Sub
End Class

