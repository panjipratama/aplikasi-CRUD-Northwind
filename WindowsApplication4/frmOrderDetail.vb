Imports System.Data.SqlClient

Public Class frmOrderDetail
    Dim conn As SqlConnection
    Dim ds As New DataSet
    Dim da As SqlDataAdapter
    Dim reader As SqlDataReader
    Dim query As String
    Dim cmd As SqlCommand

    Private Sub ClearForm()
        For Each Control In Me.Controls
            If (TypeOf Control Is TextBox) Then
                Control.Text = ""
            End If
        Next
    End Sub

    Private Sub isiComboOrderID()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbOrder")) = False Then
                ds.Tables("tbOrder").Rows.Clear()
            End If

            query = "Select * from Orders order by OrderID ASC"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbOrder") Then
                cmbOrderID.DataSource = ds.Tables("tbOrder")
            End If

            cmbOrderID.DisplayMember = "OrderID"
            cmbOrderID.ValueMember = "OrderID"

            da.Dispose()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Ada Error Saat Mengisi Combo OrderID")
        End Try
    End Sub

    Private Sub isiGridOrderDetail()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbOrderDetail")) = False Then
                ds.Tables("tbOrderDetail").Rows.Clear()
            End If

            query = "select od.OrderID,p.ProductName,od.UnitPrice,od.Quantity,od.Discount  from [Order Details] od join Products p on p.productID = od.productID"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbOrderDetail") Then
                dgvOrderDetail.DataSource = ds.Tables("tbOrderDetail")
            End If

            conn.Close()
            da.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmOrderDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwindDataSet1.Products)
        Try
            conn = New SqlConnection("Data Source = PANJIPRATAMA\SQLEXPRESS;" &
                                     "Initial Catalog = Northwind;" &
                                     "Integrated Security = True")
            ClearForm()
            isiGridOrderDetail()
            isiComboOrderID()
        Catch ex As Exception
            MessageBox.Show("Error Form Load!")
        End Try
    End Sub


    Private Sub dgvOrderDetail_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrderDetail.CellContentClick
        Try
            BtnDelete.Enabled = True
            BtnUpdate.Enabled = True

            Me.cmbOrderID.Text = dgvOrderDetail.Rows(dgvOrderDetail.CurrentCell.RowIndex).Cells("OrderID").Value.ToString
            Me.cmbProductID.Text = dgvOrderDetail.Rows(dgvOrderDetail.CurrentCell.RowIndex).Cells("ProductName").Value.ToString

            Me.numUnitPrice.Text = dgvOrderDetail.Rows(dgvOrderDetail.CurrentCell.RowIndex).Cells("UnitPrice").Value.ToString
            Me.numQuantity.Text = dgvOrderDetail.Rows(dgvOrderDetail.CurrentCell.RowIndex).Cells("Quantity").Value.ToString
            Me.numDiscount.Text = dgvOrderDetail.Rows(dgvOrderDetail.CurrentCell.RowIndex).Cells("Discount").Value.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            If (Me.cmbProductID.Text = "") Then
                MessageBox.Show("Order detail ID is Empty!")
            Else
                query = "insert into [Order Details] (OrderID,ProductID,UnitPrice,Quantity,Discount) values ('" & Me.cmbOrderID.SelectedValue & "','" & Me.cmbProductID.SelectedValue & "','" & Me.numUnitPrice.Text & "','" & Me.numQuantity.Text & "','" & Me.numDiscount.Text & "')"

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Order detail have been Save!")
                    ClearForm()
                    isiGridOrderDetail()
                    isiComboOrderID()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("Order detail have not been Save! Please Try again!")
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try
            If (Me.cmbOrderID.Text = "") Then
                MessageBox.Show("Order ID is Empty!")
            Else
                If MessageBox.Show("Are you sure to delete this order ID (" & Me.cmbOrderID.Text & ") ?", "confirm delete",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    query = "DELETE FROM [Order Details] WHERE OrderID = " & Me.cmbOrderID.SelectedValue & " and ProductID = " & Me.cmbProductID.SelectedValue & ""
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    cmd = New SqlCommand(query, conn)

                    If (cmd.ExecuteNonQuery() > 0) Then
                        MessageBox.Show("Order have been delete!")
                        BtnUpdate.Enabled = False
                        BtnDelete.Enabled = False

                        ClearForm()
                        isiGridOrderDetail()
                        isiComboOrderID()

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
            If (Me.cmbOrderID.Text = "") Then
                MessageBox.Show("ID Orders is Empty!")
            Else
                query = "Update [Order Details] set UnitPrice ='" & Me.numUnitPrice.Text & "',Quantity = '" & Me.numQuantity.Text & "',Discount = '" & Me.numDiscount.Text & "' WHERE OrderID = " & Me.cmbOrderID.SelectedValue & " and ProductID = " & Me.cmbProductID.SelectedValue & ""

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Orders have been Update!")

                    ClearForm()
                    isiGridOrderDetail()
                    isiComboOrderID()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class