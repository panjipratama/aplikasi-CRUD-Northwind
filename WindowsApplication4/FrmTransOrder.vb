Imports System.Data.SqlClient

Public Class FrmTransOrder
    Dim conn As SqlConnection
    Dim ds As New DataSet
    Dim da As SqlDataAdapter
    Dim reader As SqlDataReader
    Dim query As String
    Dim index As String
    Dim cmd As SqlCommand
    Dim dtTransaksi As New DataTable
    Dim colProduct As DataColumn
    Dim colUnitPrice As DataColumn
    Dim colQuantity As DataColumn
    Dim colDiscount As DataColumn


    Private Sub ClearForm()
        For Each Control In Me.Controls
            If (TypeOf Control Is TextBox) Then
                Control.Text = ""
            End If
       
        If (TypeOf Control Is DateTimePicker) Then
            Control.value = Now
            End If

            If (TypeOf Control Is NumericUpDown) Then
                Control.value = 0
            End If
        Next

        Me.txtShipName.Text = ""
        Me.txtShipCity.Text = ""
        Me.txtShipAddress.Text = ""
        Me.txtShipRegion.Text = ""
        Me.txtShipPostalCode.Text = ""
        Me.txtShipCountry.Text = ""
    End Sub

    Private Sub tabelTrans()
        'pembentukan basis data Transaksi
        ds = New DataSet("Transaksi")
        'pembentukan tabel transaksi
        dtTransaksi = New DataTable("Transaksi")
        'pembentukan colom tabel
        colProduct = New DataColumn("ProductName")
        colProduct.DataType = Type.GetType("System.String")
        colProduct.MaxLength = 100
        colProduct.AllowDBNull = False

        colUnitPrice = New DataColumn("UnitPrice")
        colUnitPrice.DataType = Type.GetType("System.String")
        colUnitPrice.MaxLength = 50
        colUnitPrice.AllowDBNull = False

        colQuantity = New DataColumn("Quantity")
        colQuantity.DataType = Type.GetType("System.String")
        colQuantity.MaxLength = 50
        colQuantity.AllowDBNull = False

        colDiscount = New DataColumn("Discount")
        colDiscount.DataType = Type.GetType("System.String")
        colDiscount.MaxLength = 50
        colDiscount.AllowDBNull = False

        dtTransaksi.Columns.Add(colProduct)
        dtTransaksi.Columns.Add(colUnitPrice)
        dtTransaksi.Columns.Add(colQuantity)
        dtTransaksi.Columns.Add(colDiscount)
        ds.Tables.Add(dtTransaksi)

        dgvOrderDetail.DataSource = dtTransaksi
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

            Me.txtShipName.Text = reader(1).ToString
            Me.txtShipAddress.Text = reader(4).ToString
            Me.txtShipCity.Text = reader(5).ToString
            Me.txtShipRegion.Text = reader(6).ToString
            Me.txtShipPostalCode.Text = reader(7).ToString
            Me.txtShipCountry.Text = reader(8).ToString

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub FrmTransOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwindDataSet1.Products)
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Shippers' table. You can move, or remove it, as needed.
        Me.ShippersTableAdapter.Fill(Me.NorthwindDataSet1.Shippers)
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Employees' table. You can move, or remove it, as needed.
        Me.EmployeesTableAdapter.Fill(Me.NorthwindDataSet1.Employees)
        'TODO: This line of code loads data into the 'NorthwindDataSet1.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet1.Customers)
        conn = New SqlConnection("Data Source = PANJIPRATAMA\SQLEXPRESS;" &
                                    "Initial Catalog = Northwind;" &
                                    "Integrated Security = True")

        tabelTrans()
        ClearForm()
    End Sub

    Private Sub cmbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        index = Me.cmbCustomer.SelectedValue()
        customer()
    End Sub

    Private Sub btnAddToChart_Click(sender As Object, e As EventArgs)
        Dim row As DataRow = dtTransaksi.NewRow()
        row("ProductName") = cmbProduct.SelectedValue
        row("UnitPrace") = NumUnitPrice.Text
        row("Quantity") = numQuantity.Text
        row("Discount") = numDiscount.Text
        dtTransaksi.Rows.Add(row)
    End Sub

End Class