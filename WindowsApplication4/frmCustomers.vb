Imports System.Data.SqlClient

Public Class frmCustomers
    Dim conn As SqlConnection
    Dim ds As New DataSet
    Dim da As SqlDataAdapter
    Dim reader As SqlDataReader
    Dim query As String
    Dim cmd As SqlCommand

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
            cmd.CommandText = "Select * from Customers where CustomerID = " & ID & ""
            reader = cmd.ExecuteReader

            reader.Read()
            ClearForm()

            Me.txtCustomerID.Text = reader(0).ToString
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

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub isiGridCustomer()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbCustomer")) = False Then
                ds.Tables("tbCustomer").Rows.Clear()
            End If

            query = "select * from Customers"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbCustomer") Then
                dgvCustomer.DataSource = ds.Tables("tbCustomer")
            End If

            conn.Close()
            da.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New SqlConnection("Data Source = PANJIPRATAMA\SQLEXPRESS;" &
                                     "Initial Catalog = Northwind;" &
                                     "Integrated Security = True")

            ClearForm()
            isiGridCustomer()
        Catch ex As Exception
            MessageBox.Show("Error Form Load!")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If (Me.txtCompanyName.Text = "" Or Me.txtCustomerID.Text = "") Then
                MessageBox.Show("Company Name or Customers ID is Empty!")
            Else
                query = "INSERT INTO Customers VALUES ('" & Me.txtCustomerID.Text & "','" & Me.txtCompanyName.Text & "','" & Me.txtContactName.Text & "','" & Me.txtContactTitle.Text & "','" & Me.txtAddress.Text & "','" & Me.txtCity.Text & "','" & Me.txtRegion.Text & "','" & Me.txtPostalCode.Text & "','" & Me.txtCountry.Text & "','" & Me.txtPhone.Text & "','" & Me.txtFax.Text & "')"
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Customers have been Save!")
                    isiGridCustomer()
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Customers have not been Save! Please Try again!")
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If (Me.txtCustomerID.Text = "") Then
                MessageBox.Show("Customers ID is Empty!")
            Else
                If MessageBox.Show("Are you sure to delete this customer ID (" & Me.txtCustomerID.Text & ") ?", "confirm delete",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    query = "DELETE FROM Customers WHERE CustomerID = '" & Me.txtCustomerID.Text & "'"
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    cmd = New SqlCommand(query, conn)

                    If (cmd.ExecuteNonQuery() > 0) Then
                        MessageBox.Show("Customers have been delete!")
                        btnUpdate.Enabled = False
                        btnDelete.Enabled = False
                        isiGridCustomer()
                        ClearForm()

                        conn.Close()
                        cmd.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("Customers have not been delete! Please Try again!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If (Me.txtCompanyName.Text = "") Then
                MessageBox.Show("Company Name is Empty!")
            Else
                query = "UPDATE Customers SET CompanyName ='" & Me.txtCompanyName.Text &
                                                            "', ContactName = '" & Me.txtContactName.Text &
                                                            "',ContactTitle = '" & Me.txtContactTitle.Text &
                                                            "',Address = '" & Me.txtAddress.Text &
                                                            "',City = '" & Me.txtCity.Text &
                                                            "',Region = '" & Me.txtRegion.Text &
                                                            "',PostalCode = '" & Me.txtPostalCode.Text &
                                                            "',Country = '" & Me.txtCountry.Text &
                                                            "',Phone = '" & Me.txtPhone.Text &
                                                            "',Fax = '" & Me.txtFax.Text &
                                                            "' WHERE CustomerID = '" & Me.txtCustomerID.Text & "'"
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Customers have been Update and Save!")
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    isiGridCustomer()
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Customers have not been Update! Please Try again!")
        End Try
    End Sub

    Private Sub btnCariSupplier_Click(sender As Object, e As EventArgs) Handles btnCariSupplier.Click
        Dim ID As String
        ID = Me.txtCustomerID.Text
        If (Me.txtCustomerID.Text = "") Then
            MessageBox.Show("ID is Empty!")
        Else
            cari(ID)
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub dgvCustomer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomer.CellContentClick
        Try
            btnUpdate.Enabled = True
            btnDelete.Enabled = True

            Me.txtCustomerID.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("CustomerID").Value.ToString
            Me.txtCompanyName.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("CompanyName").Value.ToString
            Me.txtContactName.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("ContactName").Value.ToString
            Me.txtContactTitle.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("ContactTitle").Value.ToString
            Me.txtAddress.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("Address").Value.ToString
            Me.txtCity.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("City").Value.ToString
            Me.txtRegion.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("Region").Value.ToString
            Me.txtPostalCode.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("PostalCode").Value.ToString
            Me.txtCountry.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("Country").Value.ToString
            Me.txtPhone.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("Phone").Value.ToString
            Me.txtFax.Text = dgvCustomer.Rows(dgvCustomer.CurrentCell.RowIndex).Cells("Fax").Value.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class