<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransOrder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransOrder))
        Me.dgvOrderDetail = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.CustomersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NorthwindDataSet1 = New WindowsApplication4.NorthwindDataSet1()
        Me.cmbEmployee = New System.Windows.Forms.ComboBox()
        Me.EmployeesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbShipVia = New System.Windows.Forms.ComboBox()
        Me.ShippersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpRequireDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpShippedDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.numDiscount = New System.Windows.Forms.NumericUpDown()
        Me.numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.NumUnitPrice = New System.Windows.Forms.NumericUpDown()
        Me.btnRemoveFromChart = New System.Windows.Forms.Button()
        Me.btnAddToChart = New System.Windows.Forms.Button()
        Me.cmbProduct = New System.Windows.Forms.ComboBox()
        Me.ProductsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.CustomersTableAdapter = New WindowsApplication4.NorthwindDataSet1TableAdapters.CustomersTableAdapter()
        Me.EmployeesTableAdapter = New WindowsApplication4.NorthwindDataSet1TableAdapters.EmployeesTableAdapter()
        Me.ShippersTableAdapter = New WindowsApplication4.NorthwindDataSet1TableAdapters.ShippersTableAdapter()
        Me.ProductsTableAdapter = New WindowsApplication4.NorthwindDataSet1TableAdapters.ProductsTableAdapter()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtShipCountry = New System.Windows.Forms.TextBox()
        Me.txtShipPostalCode = New System.Windows.Forms.TextBox()
        Me.txtShipRegion = New System.Windows.Forms.TextBox()
        Me.txtShipCity = New System.Windows.Forms.TextBox()
        Me.txtShipAddress = New System.Windows.Forms.TextBox()
        Me.txtShipName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.dgvOrderDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShippersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvOrderDetail
        '
        Me.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderDetail.Location = New System.Drawing.Point(6, 64)
        Me.dgvOrderDetail.Name = "dgvOrderDetail"
        Me.dgvOrderDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvOrderDetail.Size = New System.Drawing.Size(631, 119)
        Me.dgvOrderDetail.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Employee"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Order Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Require Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Shipped Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Ship Via"
        '
        'cmbCustomer
        '
        Me.cmbCustomer.DataSource = Me.CustomersBindingSource
        Me.cmbCustomer.DisplayMember = "CompanyName"
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(92, 9)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(200, 21)
        Me.cmbCustomer.TabIndex = 14
        Me.cmbCustomer.ValueMember = "CustomerID"
        '
        'CustomersBindingSource
        '
        Me.CustomersBindingSource.DataMember = "Customers"
        Me.CustomersBindingSource.DataSource = Me.NorthwindDataSet1
        '
        'NorthwindDataSet1
        '
        Me.NorthwindDataSet1.DataSetName = "NorthwindDataSet1"
        Me.NorthwindDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbEmployee
        '
        Me.cmbEmployee.DataSource = Me.EmployeesBindingSource
        Me.cmbEmployee.DisplayMember = "FirstName"
        Me.cmbEmployee.FormattingEnabled = True
        Me.cmbEmployee.Location = New System.Drawing.Point(92, 35)
        Me.cmbEmployee.Name = "cmbEmployee"
        Me.cmbEmployee.Size = New System.Drawing.Size(110, 21)
        Me.cmbEmployee.TabIndex = 15
        Me.cmbEmployee.ValueMember = "EmployeeID"
        '
        'EmployeesBindingSource
        '
        Me.EmployeesBindingSource.DataMember = "Employees"
        Me.EmployeesBindingSource.DataSource = Me.NorthwindDataSet1
        '
        'cmbShipVia
        '
        Me.cmbShipVia.DataSource = Me.ShippersBindingSource
        Me.cmbShipVia.DisplayMember = "CompanyName"
        Me.cmbShipVia.FormattingEnabled = True
        Me.cmbShipVia.Location = New System.Drawing.Point(92, 148)
        Me.cmbShipVia.Name = "cmbShipVia"
        Me.cmbShipVia.Size = New System.Drawing.Size(110, 21)
        Me.cmbShipVia.TabIndex = 16
        Me.cmbShipVia.ValueMember = "ShipperID"
        '
        'ShippersBindingSource
        '
        Me.ShippersBindingSource.DataMember = "Shippers"
        Me.ShippersBindingSource.DataSource = Me.NorthwindDataSet1
        '
        'dtpOrderDate
        '
        Me.dtpOrderDate.Location = New System.Drawing.Point(92, 62)
        Me.dtpOrderDate.Name = "dtpOrderDate"
        Me.dtpOrderDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpOrderDate.TabIndex = 17
        '
        'dtpRequireDate
        '
        Me.dtpRequireDate.Location = New System.Drawing.Point(92, 89)
        Me.dtpRequireDate.Name = "dtpRequireDate"
        Me.dtpRequireDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpRequireDate.TabIndex = 18
        '
        'dtpShippedDate
        '
        Me.dtpShippedDate.Location = New System.Drawing.Point(92, 118)
        Me.dtpShippedDate.Name = "dtpShippedDate"
        Me.dtpShippedDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpShippedDate.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numDiscount)
        Me.GroupBox1.Controls.Add(Me.numQuantity)
        Me.GroupBox1.Controls.Add(Me.NumUnitPrice)
        Me.GroupBox1.Controls.Add(Me.btnRemoveFromChart)
        Me.GroupBox1.Controls.Add(Me.btnAddToChart)
        Me.GroupBox1.Controls.Add(Me.cmbProduct)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dgvOrderDetail)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 210)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(643, 197)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Order Detail"
        '
        'numDiscount
        '
        Me.numDiscount.Location = New System.Drawing.Point(310, 38)
        Me.numDiscount.Name = "numDiscount"
        Me.numDiscount.Size = New System.Drawing.Size(72, 20)
        Me.numDiscount.TabIndex = 13
        '
        'numQuantity
        '
        Me.numQuantity.Location = New System.Drawing.Point(226, 38)
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(67, 20)
        Me.numQuantity.TabIndex = 12
        '
        'NumUnitPrice
        '
        Me.NumUnitPrice.Location = New System.Drawing.Point(140, 38)
        Me.NumUnitPrice.Name = "NumUnitPrice"
        Me.NumUnitPrice.Size = New System.Drawing.Size(69, 20)
        Me.NumUnitPrice.TabIndex = 11
        '
        'btnRemoveFromChart
        '
        Me.btnRemoveFromChart.Location = New System.Drawing.Point(511, 35)
        Me.btnRemoveFromChart.Name = "btnRemoveFromChart"
        Me.btnRemoveFromChart.Size = New System.Drawing.Size(111, 23)
        Me.btnRemoveFromChart.TabIndex = 10
        Me.btnRemoveFromChart.Text = "Remove From Chart"
        Me.btnRemoveFromChart.UseVisualStyleBackColor = True
        '
        'btnAddToChart
        '
        Me.btnAddToChart.Location = New System.Drawing.Point(394, 35)
        Me.btnAddToChart.Name = "btnAddToChart"
        Me.btnAddToChart.Size = New System.Drawing.Size(93, 23)
        Me.btnAddToChart.TabIndex = 9
        Me.btnAddToChart.Text = "Add To Chart"
        Me.btnAddToChart.UseVisualStyleBackColor = True
        '
        'cmbProduct
        '
        Me.cmbProduct.DataSource = Me.ProductsBindingSource
        Me.cmbProduct.DisplayMember = "ProductName"
        Me.cmbProduct.FormattingEnabled = True
        Me.cmbProduct.Location = New System.Drawing.Point(10, 37)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(102, 21)
        Me.cmbProduct.TabIndex = 5
        Me.cmbProduct.ValueMember = "ProductID"
        '
        'ProductsBindingSource
        '
        Me.ProductsBindingSource.DataMember = "Products"
        Me.ProductsBindingSource.DataSource = Me.NorthwindDataSet1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(307, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Discount"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(223, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Quantity"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(137, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Unit Price"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Product"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(326, 429)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(458, 429)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 30)
        Me.btnUpdate.TabIndex = 28
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(580, 429)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 30)
        Me.btnDelete.TabIndex = 29
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'CustomersTableAdapter
        '
        Me.CustomersTableAdapter.ClearBeforeFill = True
        '
        'EmployeesTableAdapter
        '
        Me.EmployeesTableAdapter.ClearBeforeFill = True
        '
        'ShippersTableAdapter
        '
        Me.ShippersTableAdapter.ClearBeforeFill = True
        '
        'ProductsTableAdapter
        '
        Me.ProductsTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtShipCountry)
        Me.GroupBox2.Controls.Add(Me.txtShipPostalCode)
        Me.GroupBox2.Controls.Add(Me.txtShipRegion)
        Me.GroupBox2.Controls.Add(Me.txtShipCity)
        Me.GroupBox2.Controls.Add(Me.txtShipAddress)
        Me.GroupBox2.Controls.Add(Me.txtShipName)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(322, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(333, 192)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ship To :"
        '
        'txtShipCountry
        '
        Me.txtShipCountry.Enabled = False
        Me.txtShipCountry.Location = New System.Drawing.Point(136, 156)
        Me.txtShipCountry.Name = "txtShipCountry"
        Me.txtShipCountry.Size = New System.Drawing.Size(100, 20)
        Me.txtShipCountry.TabIndex = 37
        '
        'txtShipPostalCode
        '
        Me.txtShipPostalCode.Enabled = False
        Me.txtShipPostalCode.Location = New System.Drawing.Point(136, 126)
        Me.txtShipPostalCode.Name = "txtShipPostalCode"
        Me.txtShipPostalCode.Size = New System.Drawing.Size(67, 20)
        Me.txtShipPostalCode.TabIndex = 36
        '
        'txtShipRegion
        '
        Me.txtShipRegion.Enabled = False
        Me.txtShipRegion.Location = New System.Drawing.Point(136, 97)
        Me.txtShipRegion.Name = "txtShipRegion"
        Me.txtShipRegion.Size = New System.Drawing.Size(67, 20)
        Me.txtShipRegion.TabIndex = 35
        '
        'txtShipCity
        '
        Me.txtShipCity.Enabled = False
        Me.txtShipCity.Location = New System.Drawing.Point(136, 70)
        Me.txtShipCity.Name = "txtShipCity"
        Me.txtShipCity.Size = New System.Drawing.Size(100, 20)
        Me.txtShipCity.TabIndex = 34
        '
        'txtShipAddress
        '
        Me.txtShipAddress.Enabled = False
        Me.txtShipAddress.Location = New System.Drawing.Point(136, 43)
        Me.txtShipAddress.Name = "txtShipAddress"
        Me.txtShipAddress.Size = New System.Drawing.Size(160, 20)
        Me.txtShipAddress.TabIndex = 33
        '
        'txtShipName
        '
        Me.txtShipName.Enabled = False
        Me.txtShipName.Location = New System.Drawing.Point(136, 17)
        Me.txtShipName.Name = "txtShipName"
        Me.txtShipName.Size = New System.Drawing.Size(122, 20)
        Me.txtShipName.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(37, 159)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Country"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(37, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Postal Code"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(37, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Region"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "City"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Address"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(37, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Name"
        '
        'FrmTransOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(667, 461)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtpShippedDate)
        Me.Controls.Add(Me.dtpRequireDate)
        Me.Controls.Add(Me.dtpOrderDate)
        Me.Controls.Add(Me.cmbShipVia)
        Me.Controls.Add(Me.cmbEmployee)
        Me.Controls.Add(Me.cmbCustomer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmTransOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Halaman Transaksi"
        CType(Me.dgvOrderDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShippersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvOrderDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents cmbShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents dtpOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRequireDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpShippedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemoveFromChart As System.Windows.Forms.Button
    Friend WithEvents btnAddToChart As System.Windows.Forms.Button
    Friend WithEvents cmbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents numDiscount As System.Windows.Forms.NumericUpDown
    Friend WithEvents numQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumUnitPrice As System.Windows.Forms.NumericUpDown
    Friend WithEvents NorthwindDataSet1 As WindowsApplication4.NorthwindDataSet1
    Friend WithEvents CustomersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomersTableAdapter As WindowsApplication4.NorthwindDataSet1TableAdapters.CustomersTableAdapter
    Friend WithEvents EmployeesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeesTableAdapter As WindowsApplication4.NorthwindDataSet1TableAdapters.EmployeesTableAdapter
    Friend WithEvents ShippersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShippersTableAdapter As WindowsApplication4.NorthwindDataSet1TableAdapters.ShippersTableAdapter
    Friend WithEvents ProductsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProductsTableAdapter As WindowsApplication4.NorthwindDataSet1TableAdapters.ProductsTableAdapter
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtShipCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtShipPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents txtShipRegion As System.Windows.Forms.TextBox
    Friend WithEvents txtShipCity As System.Windows.Forms.TextBox
    Friend WithEvents txtShipAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtShipName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
