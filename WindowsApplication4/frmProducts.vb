Imports System.Data.SqlClient

Public Class frmProducts
    Dim conn As SqlConnection
    Dim ds As New DataSet("dsNorthwind")
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim reader As SqlDataReader
    Dim query As String

    Private Sub isiComboSupplier()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbSupplier")) = False Then
                ds.Tables("tbSupplier").Rows.Clear()
            End If

            query = "Select * from Suppliers order by CompanyName ASC"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbSupplier") Then
                CmbSupplier.DataSource = ds.Tables("tbSupplier")
            End If

            CmbSupplier.DisplayMember = "CompanyName"
            CmbSupplier.ValueMember = "SupplierID"

            da.Dispose()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Ada Error Saat Mengisi Combo Supplier")
        End Try
    End Sub

    Private Sub isiGridProduct()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbProduct")) = False Then
                ds.Tables("tbProduct").Rows.Clear()
            End If

            query = "SELECT p.ProductID, p.ProductName , " &
                "s.CompanyName, c.CategoryName, p.QuantityPerUnit, " &
                "p.UnitPrice, p.UnitsInStock, p.UnitsOnOrder, p.ReorderLevel, p.Discontinued  FROM Products p " &
                "join Categories c on p.CategoryID = c.CategoryID " &
                "join Suppliers s on p.SupplierID = s.SupplierID"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbProduct") Then
                dgvProduct.DataSource = ds.Tables("tbProduct")
            End If

            conn.Close()
            da.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    

    Private Sub frmProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Categories' table. You can move, or remove it, as needed.
        Me.CategoriesTableAdapter.Fill(Me.NorthwindDataSet1.Categories)
        Try
            'TODO: This line of code loads data into the 'NorthwindDataSet.Categories' table. You can move, or remove it, as needed.
            Me.CategoriesTableAdapter.Fill(Me.NorthwindDataSet1.Categories)

            conn = New SqlConnection("Data Source = PANJIPRATAMA\SQLEXPRESS;" &
                                     "Initial Catalog=Northwind;" &
                                     "Integrated Security=True")
            isiComboSupplier()
            isiGridProduct()

            ClearForm()

        Catch ex As Exception
            MessageBox.Show("Ada Error Saat Form Load!")
        End Try

    End Sub

    'membuat prosedure clear form
    Private Sub ClearForm()
        For Each Control In Me.Controls
            If (TypeOf Control Is TextBox) Then
                Control.Text = ""
            End If

            If (TypeOf Control Is ComboBox) Then
                Control.SelectedIndex = -1
            End If

            If (TypeOf Control Is NumericUpDown) Then
                Control.value = 0
            End If

            If (TypeOf Control Is CheckBox) Or (TypeOf Control Is RadioButton) Then
                Control.Checked = False
            End If

        Next
    End Sub

    Private Sub dgvProduct_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProduct.CellContentClick
        Try
            Me.TxtID.Text = dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("ProductID").Value.ToString
            Me.TxtName.Text = dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("ProductName").Value.ToString

            If Not IsDBNull(dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("CategoryName").Value) Then
                Me.CmbCategory.Text = dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("CategoryName").Value
            Else
                Me.CmbCategory.SelectedIndex = -1
            End If

            Me.CmbSupplier.Text = dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("CompanyName").Value
            Me.NumPrice.Minimum = dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("UnitPrice").Value
            Me.NumStock.Minimum = dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("UnitsInStock").Value
            Me.txtQTperUnit.Text = dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("QuantityPerUnit").Value.ToString
            Me.NumOrder.Minimum = dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("UnitsOnOrder").Value
            Me.NumReorder.Minimum = dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("ReorderLevel").Value

            If (dgvProduct.Rows(dgvProduct.CurrentCell.RowIndex).Cells("Discontinued").Value = True) Then
                Me.cbDiscontinued.Checked = True
            Else
                Me.cbDiscontinued.Checked = False
            End If

            BtnDelete.Enabled = True
            BtnUpdate.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim cek As Boolean
        If (cbDiscontinued.Checked = True) Then
            cek = True
        Else
            cek = False
        End If
        Try
            If (Me.TxtName.Text = "") Then
                MessageBox.Show("Product Name is Empty!")
            Else
                query = "insert into products (ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued) " &
                        "values ('" & Me.TxtName.Text & "','" & Me.CmbSupplier.SelectedIndex & "','" & Me.CmbCategory.SelectedValue & "','" & Me.txtQTperUnit.Text & "'," &
                        "'" & Me.NumPrice.Minimum & "','" & Me.NumStock.Minimum & "','" & Me.NumOrder.Minimum & "','" & Me.NumReorder.Minimum & "','" & cek & "')"

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Product have been Save!")
                    ClearForm()
                    isiGridProduct()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Product have not been Save! Please Try again!")
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try
            If (Me.TxtID.Text = "") Then
                MessageBox.Show("Product ID is Empty!")
            Else
                If MessageBox.Show("Are you sure to delete this Product ID (" & Me.TxtID.Text & ") ?", "confirm delete",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    query = "DELETE FROM Products WHERE ProductID = " & Me.TxtID.Text & ""
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    cmd = New SqlCommand(query, conn)

                    If (cmd.ExecuteNonQuery() > 0) Then
                        MessageBox.Show("Product have been delete!")
                        BtnUpdate.Enabled = False
                        BtnDelete.Enabled = False

                        ClearForm()

                        isiGridProduct()
                        conn.Close()
                        cmd.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Product have not been delete! Please Try again!")
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim cek As Boolean
        If (cbDiscontinued.Checked = True) Then
            cek = True
        Else
            cek = False
        End If
        Try
            If (Me.TxtID.Text = "") Then
                MessageBox.Show("ID Product is Empty!")
            Else
                query = "update products set ProductName = '" & Me.TxtName.Text & "',SupplierID = '" & Me.CmbSupplier.SelectedIndex & "',CategoryID = '" & Me.CmbCategory.SelectedValue & "',QuantityPerUnit = '" & Me.txtQTperUnit.Text & "',UnitPrice = '" & Me.NumPrice.Minimum & "',UnitsInStock = '" & Me.NumStock.Minimum & "',UnitsOnOrder = '" & Me.NumOrder.Minimum & "',ReorderLevel = '" & Me.NumReorder.Minimum & "',Discontinued = '" & cek & "' " &
                        "Where ProductID = '" & Me.TxtID.Text & "'"

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Product have been Save!")

                    ClearForm()
                    isiGridProduct()
                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Dim ID As String
        ID = Me.TxtID.Text
        If (Me.TxtID.Text = "") Then
            MessageBox.Show("ID is Empty!")
        Else
            cari(ID)
            BtnUpdate.Enabled = True
            BtnDelete.Enabled = True
        End If

    End Sub
    'create search prosedure
    Private Sub cari(ID)

        Try
            conn.Open()
            'mengambil data mhs
            cmd = New SqlCommand()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select * from products where productID = " & ID & ""
            reader = cmd.ExecuteReader

            reader.Read()
            ClearForm()

            Me.TxtID.Text = reader(0).ToString
            Me.TxtName.Text = reader(1).ToString

            If Not IsDBNull(reader(3)) Then
                Me.CmbCategory.SelectedIndex = reader(3) - 1
            Else
                Me.CmbCategory.SelectedIndex = -1
            End If

            Me.CmbSupplier.SelectedValue = reader(2)
            Me.NumPrice.Value = reader(5)
            Me.NumStock.Value = reader(6)
            Me.txtQTperUnit.Text = reader(4).ToString
            Me.NumOrder.Value = reader(7)
            Me.NumReorder.Value = reader(8)

            If (reader(9) = True) Then
                Me.cbDiscontinued.Checked = True
            Else
                Me.cbDiscontinued.Checked = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub
End Class