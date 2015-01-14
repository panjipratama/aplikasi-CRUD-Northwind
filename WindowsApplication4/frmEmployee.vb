Imports System.Data.SqlClient

Public Class frmEmployee
    Dim conn As SqlConnection
    Dim ds As New DataSet
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim reader As SqlDataReader
    Dim query As String

    'create clear form prosedure 
    Private Sub ClearForm()
        For Each Control In Me.Controls
            If (TypeOf Control Is TextBox) Then
                Control.Text = ""
            End If

            If (TypeOf Control Is RichTextBox) Then
                Control.Text = ""
            End If

            If (TypeOf Control Is DateTimePicker) Then
                Control.value = Now
            End If

            If (TypeOf Control Is NumericUpDown) Then
                Control.value = 0
            End If

            pbPhoto.Image = Nothing

        Next
    End Sub

    'create search prosedure
    Private Sub cari(ID)

        Try
            conn.Open()
            'mengambil data mhs
            cmd = New SqlCommand()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select * from Employees where EmployeeID = " & ID & ""
            reader = cmd.ExecuteReader

            reader.Read()
            ClearForm()

            Me.txtEmployeeID.Text = reader(0).ToString
            Me.TxtLastName.Text = reader(1).ToString
            Me.txtFirstName.Text = reader(2).ToString
            Me.txtTitle.Text = reader(3).ToString
            Me.txtTitleOfCourtesy.Text = reader(4).ToString
            Me.dtpBirthDate.Value = reader(5).ToString
            Me.dtpHireDate.Value = reader(6).ToString
            Me.txtAddress.Text = reader(7).ToString
            Me.txtCity.Text = reader(8).ToString
            Me.txtRegion.Text = reader(9).ToString
            Me.txtPostalCode.Text = reader(10).ToString
            Me.txtCountry.Text = reader(11).ToString
            Me.txtHomePhone.Text = reader(12).ToString
            Me.txtExtension.Text = reader(13).ToString

            Me.txtFileName.Text = reader(14).ToString
            'Me.pbPhoto.Image = Image.FromFile(reader(14))

            Me.rtxtNotes.Text = reader(15).ToString
            Me.txtReportsTo.Text = reader(16).ToString
            Me.txtphotoPath.Text = reader(17).ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub isiGridEmployee()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbEmployee")) = False Then
                ds.Tables("tbEmployee").Rows.Clear()
            End If

            query = "select * from Employees"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbEmployee") Then
                dgvEmployee.DataSource = ds.Tables("tbEmployee")
            End If

            conn.Close()
            da.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet.Employees' table. You can move, or remove it, as needed.
        Me.EmployeesTableAdapter.Fill(Me.NorthwindDataSet.Employees)
        Try
            conn = New SqlConnection("Data Source = PANJIPRATAMA\SQLEXPRESS;" &
                                     "Initial Catalog = Northwind;" &
                                     "Integrated Security = True")
            ClearForm()
            isiGridEmployee()
        Catch ex As Exception
            MessageBox.Show("Error Form Load!")
        End Try
    End Sub

    Private Sub btnCariSupplier_Click(sender As Object, e As EventArgs) Handles btnCariSupplier.Click
        Dim ID As String
        ID = Me.txtEmployeeID.Text
        If (Me.txtEmployeeID.Text = "") Then
            MessageBox.Show("ID is Empty!")
        Else
            cari(ID)
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If (Me.txtFirstName.Text = "" Or Me.TxtLastName.Text = "") Then
                MessageBox.Show("Name is Empty!")
            Else
                query = "insert into Employees (FirstName," &
                                                "LastName," &
                                                "Title," &
                                                "TitleOfCourtesy," &
                                                "BirthDate," &
                                                "HireDate," &
                                                "Address," &
                                                "City," &
                                                "Region," &
                                                "PostalCode," &
                                                "Country," &
                                                "HomePhone," &
                                                "Extension," &
                                                "Photo," &
                                                "Notes," &
                                                "ReportsTo" &
                                                ",PhotoPath) values " &
                                                "('" & Me.txtFirstName.Text & "','" & Me.TxtLastName.Text & "'," &
                                                "'" & Me.txtTitle.Text & "','" & Me.txtTitleOfCourtesy.Text & "'," &
                                                "'" & Me.dtpBirthDate.Value & "','" & Me.dtpHireDate.Value & "','" & Me.txtAddress.Text & "','" & Me.txtCity.Text & "'," &
                                                "'" & Me.txtRegion.Text & "','" & Me.txtPostalCode.Text & "','" & Me.txtCountry.Text & "','" & Me.txtHomePhone.Text & "'," &
                                                "'" & Me.txtExtension.Text & "','" & Me.txtFileName.Text & "','" & Me.rtxtNotes.Text & "','" & Me.txtReportsTo.Value & "'," &
                                                "'" & Me.txtphotoPath.Text & "')"
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Employee have been Save!")
                    isiGridEmployee()
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Employee have not been Save! Please Try again!")
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        OpenFileDialog1.Filter = "Image Files (*.png,*jpg)*.png|*.jpg|All files (*.*)|*.*"
        OpenFileDialog1.ShowDialog()
        Me.txtFileName.Text = OpenFileDialog1.FileName
        Me.txtFileName.SelectionStart = Me.txtFileName.Text.Length
        If Trim(Me.txtFileName.Text) <> "" Then
            pbPhoto.Image = Image.FromFile(Me.txtFileName.Text)

        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If (Me.txtFirstName.Text = "" Or Me.TxtLastName.Text = "" Or Me.txtEmployeeID.Text = "") Then
                MessageBox.Show("Name or ID is Empty!")
            Else
                query = "Update Employees Set FirstName = '" & Me.txtFirstName.Text & "'," &
                                                "LastName = '" & Me.TxtLastName.Text & "'," &
                                                "Title = '" & Me.txtTitle.Text & "'," &
                                                "TitleOfCourtesy = '" & Me.txtTitleOfCourtesy.Text & "'," &
                                                "BirthDate = '" & Me.dtpBirthDate.Value & "'," &
                                                "HireDate = '" & Me.dtpHireDate.Value & "'," &
                                                "Address = '" & Me.txtAddress.Text & "'," &
                                                "City = '" & Me.txtCity.Text & "'," &
                                                "Region = '" & Me.txtRegion.Text & "'," &
                                                "PostalCode = '" & Me.txtPostalCode.Text & "'," &
                                                "Country = '" & Me.txtCountry.Text & "'," &
                                                "HomePhone = '" & Me.txtHomePhone.Text & "'," &
                                                "Extension = '" & Me.txtExtension.Text & "'," &
                                                "Photo = '" & Me.txtFileName.Text & "'," &
                                                "Notes = '" & Me.rtxtNotes.Text & "'," &
                                                "ReportsTo = '" & Me.txtReportsTo.Value & "'" &
                                                ",PhotoPath = '" & Me.txtphotoPath.Text & "' where EmployeeID = '" & Me.txtEmployeeID.Text & "'"
                   
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Employee " & Me.txtEmployeeID.Text & " have been Update!")
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    isiGridEmployee()
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Employee have not been Update! Please Try again!")
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If (Me.txtEmployeeID.Text = "") Then
                MessageBox.Show("Employee ID is Empty!")
            Else
                If MessageBox.Show("Are you sure to delete this Employee ID (" & Me.txtEmployeeID.Text & ") ?", "confirm delete",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    query = "DELETE FROM Employees WHERE EmployeeID = " & Me.txtEmployeeID.Text & ""
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    cmd = New SqlCommand(query, conn)

                    If (cmd.ExecuteNonQuery() > 0) Then
                        MessageBox.Show("Employee have been delete!")
                        btnUpdate.Enabled = False
                        btnDelete.Enabled = False
                        isiGridEmployee()

                        ClearForm()

                        conn.Close()
                        cmd.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Employee have not been delete! Please Try again!")
        End Try
    End Sub

    Private Sub dgvEmployee_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployee.CellContentClick
        Try
            btnUpdate.Enabled = True
            btnDelete.Enabled = True

            Me.txtEmployeeID.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("EmployeeID").Value.ToString
            Me.TxtLastName.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("LastName").Value.ToString
            Me.txtFirstName.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("FirstName").Value.ToString
            Me.txtTitle.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("Title").Value.ToString
            Me.txtTitleOfCourtesy.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("TitleOfCourtesy").Value.ToString
            Me.dtpBirthDate.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("BirthDate").Value.ToString
            Me.dtpHireDate.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("HireDate").Value.ToString
            Me.txtAddress.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("Address").Value.ToString
            Me.txtCity.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("City").Value.ToString
            Me.txtRegion.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("Region").Value.ToString
            Me.txtPostalCode.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("PostalCode").Value.ToString
            Me.txtCountry.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("Country").Value.ToString
            Me.txtHomePhone.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("HomePhone").Value.ToString
            Me.txtExtension.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("Extension").Value.ToString
            Me.rtxtNotes.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("Notes").Value.ToString
            Me.txtReportsTo.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("ReportsTo").Value.ToString
            Me.txtphotoPath.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("PhotoPath").Value.ToString
            Me.txtFileName.Text = dgvEmployee.Rows(dgvEmployee.CurrentCell.RowIndex).Cells("Photo").Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class