Imports System.Data.SqlClient

Public Class frmSupplier
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
            cmd.CommandText = "Select * from Suppliers where SupplierID = " & ID & ""
            reader = cmd.ExecuteReader

            reader.Read()
            ClearForm()

            Me.txtSupplierID.Text = reader(0).ToString
            Me.txtCompanyName.Text = reader(1).ToString
            Me.txtContactName.Text = reader(2).ToString
            Me.txtContactTitle.Text = reader(3).ToString
            Me.txtAddress.Text = reader(4).ToString
            Me.txtCity.Text = reader(5).ToString
            Me.txtRegion.Text = reader(6).ToString
            Me.txtPostalCode.Text = reader(7).ToString
            Me.txtCountry.Text = reader(8).ToString
            Me.txtPhone.Text = reader(9).ToString
            Me.txtFax.Text = reader(10).ToString
            Me.txtHomePage.Text = reader(11).ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub isiGridSupplier()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbSupplier")) = False Then
                ds.Tables("tbSupplier").Rows.Clear()
            End If

            query = "select * from Suppliers"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbSupplier") Then
                dgvSupplier.DataSource = ds.Tables("tbSupplier")
            End If

            conn.Close()
            da.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Suppliers' table. You can move, or remove it, as needed.

        Try
            conn = New SqlConnection("Data Source = PANJIPRATAMA\SQLEXPRESS;" &
                                     "Initial Catalog = Northwind;" &
                                     "Integrated Security = True")

            ClearForm()
            isiGridSupplier()
        Catch ex As Exception
            MessageBox.Show("Error Form Load!")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If (Me.txtCompanyName.Text = "") Then
                MessageBox.Show("Company Name is Empty!")
            Else
                query = "INSERT INTO Suppliers (CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage) VALUES ('" & Me.txtCompanyName.Text & "','" & Me.txtContactName.Text & "','" & Me.txtContactTitle.Text & "','" & Me.txtAddress.Text & "','" & Me.txtCity.Text & "','" & Me.txtRegion.Text & "','" & Me.txtPostalCode.Text & "','" & Me.txtCountry.Text & "','" & Me.txtPhone.Text & "','" & Me.txtFax.Text & "','" & Me.txtHomePage.Text & "')"
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Supplier have been Save!")
                    isiGridSupplier()
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Supplier have not been Save! Please Try again!")
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If (Me.txtSupplierID.Text = "") Then
                MessageBox.Show("Supplier ID is Empty!")
            Else
                If MessageBox.Show("Are you sure to delete this Supplier ID (" & Me.txtSupplierID.Text & ") ?", "confirm delete",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    query = "DELETE FROM Suppliers WHERE SupplierID = " & Me.txtSupplierID.Text & ""
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    cmd = New SqlCommand(query, conn)

                    If (cmd.ExecuteNonQuery() > 0) Then
                        MessageBox.Show("Supplier have been delete!")
                        btnUpdate.Enabled = False
                        btnDelete.Enabled = False
                        isiGridSupplier()
                        ClearForm()

                        conn.Close()
                        cmd.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Supplier have not been delete! Please Try again!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If (Me.txtCompanyName.Text = "") Then
                MessageBox.Show("Company Name is Empty!")
            Else
                query = "UPDATE Suppliers SET CompanyName ='" & Me.txtCompanyName.Text &
                                                            "', ContactName = '" & Me.txtContactName.Text &
                                                            "',ContactTitle = '" & Me.txtContactTitle.Text &
                                                            "',Address = '" & Me.txtAddress.Text &
                                                            "',City = '" & Me.txtCity.Text &
                                                            "',Region = '" & Me.txtRegion.Text &
                                                            "',PostalCode = '" & Me.txtPostalCode.Text &
                                                            "',Country = '" & Me.txtCountry.Text &
                                                            "',Phone = '" & Me.txtPhone.Text &
                                                            "',Fax = '" & Me.txtFax.Text &
                                                            "',HomePage = '" & Me.txtHomePage.Text &
                                                            "' WHERE SupplierID = '" & Me.txtSupplierID.Text & "'"
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Supplier have been Update and Save!")
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    isiGridSupplier()
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Supplier have not been Update! Please Try again!")
        End Try
    End Sub

    Private Sub btnCariSupplier_Click(sender As Object, e As EventArgs) Handles btnCariSupplier.Click
        Dim ID As String
        ID = Me.txtSupplierID.Text
        If (Me.txtSupplierID.Text = "") Then
            MessageBox.Show("ID is Empty!")
        Else
            cari(ID)
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub dgvSupplier_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSupplier.CellContentClick
        Try
            btnUpdate.Enabled = True
            btnDelete.Enabled = True

            Me.txtSupplierID.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("SupplierID").Value.ToString
            Me.txtCompanyName.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("CompanyName").Value.ToString
            Me.txtContactName.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("ContactName").Value.ToString
            Me.txtContactTitle.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("ContactTitle").Value.ToString
            Me.txtAddress.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("Address").Value.ToString
            Me.txtCity.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("City").Value.ToString
            Me.txtRegion.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("Region").Value.ToString
            Me.txtPostalCode.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("PostalCode").Value.ToString
            Me.txtCountry.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("Country").Value.ToString
            Me.txtPhone.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("Phone").Value.ToString
            Me.txtFax.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("Fax").Value.ToString
            Me.txtHomePage.Text = dgvSupplier.Rows(dgvSupplier.CurrentCell.RowIndex).Cells("HomePage").Value.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
