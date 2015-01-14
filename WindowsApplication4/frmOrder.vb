Imports System.Data.SqlClient
Public Class frmOrder
    Dim conn As SqlConnection
    Dim ds As New DataSet
    Dim da As SqlDataAdapter
    Dim reader As SqlDataReader
    Dim query As String
    Dim cmd As SqlCommand
    Dim index As String

    Private Sub ClearForm()
        For Each Control In Me.Controls
            If (TypeOf Control Is TextBox) Then
                Control.Text = ""
            End If

            If (TypeOf Control Is DateTimePicker) Then
                Control.value = Now
            End If
        Next

        Me.txtName.Text = ""
        Me.txtCity.Text = ""
        Me.txtAddress.Text = ""
        Me.txtRegion.Text = ""
        Me.txtPostalCode.Text = ""
        Me.txtCountry.Text = ""
        
    End Sub

    Private Sub isiComboEmployee()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbEmployee")) = False Then
                ds.Tables("tbEmployee").Rows.Clear()
            End If

            query = "Select * from Employees order by FirstName ASC"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbEmployee") Then
                cmbEmployeeID.DataSource = ds.Tables("tbEmployee")
            End If

            cmbEmployeeID.DisplayMember = "FirstName"
            cmbEmployeeID.ValueMember = "EmployeeID"

            da.Dispose()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Ada Error Saat Mengisi Combo Employee")
        End Try
    End Sub

    Private Sub customer()

        Try
            conn.Open()
            'mengambil data mhs
            cmd = New SqlCommand()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select * from Customers where CustomerID = '" & index & "'"
            reader = cmd.ExecuteReader

            reader.Read()
            
            Me.txtName.Text = reader(1).ToString
            Me.txtAddress.Text = reader(4).ToString
            Me.txtCity.Text = reader(5).ToString
            Me.txtRegion.Text = reader(6).ToString
            Me.txtPostalCode.Text = reader(7).ToString
            Me.txtCountry.Text = reader(8).ToString

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub isiGridOrder()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbOrder")) = False Then
                ds.Tables("tbOrder").Rows.Clear()
            End If

            query = "select o.OrderID ,c.CompanyName as CustomerName,e.FirstName+' '+e.LastName as EmployeeName,o.OrderDate ,o.RequiredDate ,o.ShippedDate ,s.CompanyName as ShipVia,o.Freight ,o.ShipName ,o.ShipAddress , o.ShipCity ,o.ShipRegion ,o.ShipPostalCode ,o.ShipCountry from Orders o join Customers c on o.CustomerID = c.CustomerID join Employees e on e.EmployeeID = o.EmployeeID join Shippers s on s.ShipperID = o.ShipVia"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbOrder") Then
                dgvOrder.DataSource = ds.Tables("tbOrder")
            End If

            conn.Close()
            da.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Shippers' table. You can move, or remove it, as needed.
        Me.ShippersTableAdapter.Fill(Me.NorthwindDataSet1.Shippers)
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet1.Customers)
        Try
            conn = New SqlConnection("Data Source = PANJIPRATAMA\SQLEXPRESS;" &
                                     "Initial Catalog = Northwind;" &
                                     "Integrated Security = True")
            ClearForm()
            isiGridOrder()
            isiComboEmployee()

        Catch ex As Exception
            MessageBox.Show("Error Form Load!")
        End Try
    End Sub

    Private Sub cmbCostumerID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCostumerID.SelectedIndexChanged
        index = Me.cmbCostumerID.SelectedValue
        customer()
    End Sub

    Private Sub dgvOrder_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrder.CellContentClick
        Try
            BtnDelete.Enabled = True
            BtnUpdate.Enabled = True

            Me.txtOrderID.Text = dgvOrder.Rows(dgvOrder.CurrentCell.RowIndex).Cells("OrderID").Value.ToString
            Me.cmbCostumerID.Text = dgvOrder.Rows(dgvOrder.CurrentCell.RowIndex).Cells("CustomerName").Value

            If Not IsDBNull(dgvOrder.Rows(dgvOrder.CurrentCell.RowIndex).Cells("EmployeeName").Value) Then
                Me.cmbEmployeeID.Text = dgvOrder.Rows(dgvOrder.CurrentCell.RowIndex).Cells("EmployeeName").Value
            Else
                Me.cmbEmployeeID.SelectedIndex = -1
            End If

            Me.dtpOrderDate.Value = dgvOrder.Rows(dgvOrder.CurrentCell.RowIndex).Cells("OrderDate").Value
            Me.dtpRequaireDate.Value = dgvOrder.Rows(dgvOrder.CurrentCell.RowIndex).Cells("RequiredDate").Value
            Me.dtpShippedDate.Value = dgvOrder.Rows(dgvOrder.CurrentCell.RowIndex).Cells("ShippedDate").Value
            Me.cmbShipperID.Text = dgvOrder.Rows(dgvOrder.CurrentCell.RowIndex).Cells("ShipVia").Value
            Me.txtFreight.Minimum = dgvOrder.Rows(dgvOrder.CurrentCell.RowIndex).Cells("Freight").Value


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            If (Me.txtName.Text = "") Then
                MessageBox.Show("Customer Name is Empty!")
            Else
                query = "insert into Orders (CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry) values " &
                        "('" & Me.cmbCostumerID.SelectedValue & "','" & Me.cmbEmployeeID.SelectedValue & "','" & Me.dtpOrderDate.Value & "','" & Me.dtpRequaireDate.Value & "','" & Me.dtpShippedDate.Value & "','" & Me.cmbShipperID.SelectedValue & "'" &
                        ",'" & Me.txtFreight.Value & "','" & Me.txtName.Text & "','" & Me.txtAddress.Text & "','" & Me.txtCity.Text & "','" & Me.txtRegion.Text & "','" & Me.txtPostalCode.Text & "','" & Me.txtCountry.Text & "')"

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Order have been Save!")
                    ClearForm()
                    isiGridOrder()
                    isiComboEmployee()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("Order have not been Save! Please Try again!")
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try
            If (Me.txtOrderID.Text = "") Then
                MessageBox.Show("Order ID is Empty!")
            Else
                If MessageBox.Show("Are you sure to delete this order ID (" & Me.txtOrderID.Text & ") ?", "confirm delete",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    query = "DELETE FROM Orders WHERE OrderID = " & Me.txtOrderID.Text & ""
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    cmd = New SqlCommand(query, conn)

                    If (cmd.ExecuteNonQuery() > 0) Then
                        MessageBox.Show("Order have been delete!")
                        BtnUpdate.Enabled = False
                        BtnDelete.Enabled = False

                        ClearForm()
                        isiGridOrder()
                        isiComboEmployee()

                        conn.Close()
                        cmd.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Order have not been delete! Please Try again!")
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Try
            If (Me.txtOrderID.Text = "") Then
                MessageBox.Show("ID Orders is Empty!")
            Else
                query = "Update Orders set CustomerID = '" & Me.cmbCostumerID.SelectedValue & "',EmployeeID = '" & Me.cmbEmployeeID.SelectedValue & "',OrderDate = '" & Me.dtpOrderDate.Value & "',RequiredDate = '" & Me.dtpRequaireDate.Value & "',ShippedDate = '" & Me.dtpShippedDate.Value & "',ShipVia = '" & Me.cmbShipperID.SelectedValue & "',Freight = '" & Me.txtFreight.Value & "',ShipName = '" & Me.txtName.Text & "',ShipAddress = '" & Me.txtAddress.Text & "',ShipCity = '" & Me.txtCity.Text & "',ShipRegion = '" & Me.txtRegion.Text & "',ShipPostalCode = '" & Me.txtPostalCode.Text & "',ShipCountry = '" & Me.txtCountry.Text & "' where OrderID = '" & Me.txtOrderID.Text & "'"

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Orders have been Save!")
                    BtnUpdate.Enabled = False
                    BtnDelete.Enabled = False
                    ClearForm()
                    isiGridOrder()
                    isiComboEmployee()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class