<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProducts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProducts))
        Me.dgvProduct = New System.Windows.Forms.DataGridView()
        Me.TxtID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumPrice = New System.Windows.Forms.NumericUpDown()
        Me.CmbSupplier = New System.Windows.Forms.ComboBox()
        Me.CmbCategory = New System.Windows.Forms.ComboBox()
        Me.CategoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NorthwindDataSet1 = New WindowsApplication4.NorthwindDataSet1()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQTperUnit = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CategoriesTableAdapter = New WindowsApplication4.NorthwindDataSet1TableAdapters.CategoriesTableAdapter()
        Me.cbDiscontinued = New System.Windows.Forms.CheckBox()
        Me.NumStock = New System.Windows.Forms.NumericUpDown()
        Me.NumOrder = New System.Windows.Forms.NumericUpDown()
        Me.NumReorder = New System.Windows.Forms.NumericUpDown()
        Me.btnCari = New System.Windows.Forms.Button()
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CategoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumReorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProduct
        '
        Me.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduct.Location = New System.Drawing.Point(12, 12)
        Me.dgvProduct.Name = "dgvProduct"
        Me.dgvProduct.Size = New System.Drawing.Size(444, 177)
        Me.dgvProduct.TabIndex = 29
        '
        'TxtID
        '
        Me.TxtID.Location = New System.Drawing.Point(121, 199)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(100, 20)
        Me.TxtID.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "ID Product"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(119, 351)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "$"
        '
        'NumPrice
        '
        Me.NumPrice.Location = New System.Drawing.Point(138, 349)
        Me.NumPrice.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.NumPrice.Name = "NumPrice"
        Me.NumPrice.Size = New System.Drawing.Size(104, 20)
        Me.NumPrice.TabIndex = 25
        '
        'CmbSupplier
        '
        Me.CmbSupplier.FormattingEnabled = True
        Me.CmbSupplier.Location = New System.Drawing.Point(121, 287)
        Me.CmbSupplier.Name = "CmbSupplier"
        Me.CmbSupplier.Size = New System.Drawing.Size(207, 21)
        Me.CmbSupplier.TabIndex = 24
        '
        'CmbCategory
        '
        Me.CmbCategory.DataSource = Me.CategoriesBindingSource
        Me.CmbCategory.DisplayMember = "CategoryName"
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(121, 258)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(255, 21)
        Me.CmbCategory.TabIndex = 23
        Me.CmbCategory.ValueMember = "CategoryID"
        '
        'CategoriesBindingSource
        '
        Me.CategoriesBindingSource.DataMember = "Categories"
        Me.CategoriesBindingSource.DataSource = Me.NorthwindDataSet1
        '
        'NorthwindDataSet1
        '
        Me.NorthwindDataSet1.DataSetName = "NorthwindDataSet1"
        Me.NorthwindDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(121, 228)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(308, 20)
        Me.TxtName.TabIndex = 22
        '
        'BtnDelete
        '
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Location = New System.Drawing.Point(381, 488)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 35)
        Me.BtnDelete.TabIndex = 21
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Enabled = False
        Me.BtnUpdate.Location = New System.Drawing.Point(283, 488)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(75, 35)
        Me.BtnUpdate.TabIndex = 20
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(189, 488)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 35)
        Me.BtnSave.TabIndex = 19
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 353)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Unit Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Supplier"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Product Category"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 231)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Product Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 320)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Quantity PerUnit"
        '
        'txtQTperUnit
        '
        Me.txtQTperUnit.Location = New System.Drawing.Point(121, 317)
        Me.txtQTperUnit.Name = "txtQTperUnit"
        Me.txtQTperUnit.Size = New System.Drawing.Size(255, 20)
        Me.txtQTperUnit.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 388)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Unit In Stock"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 421)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Unit On Order"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 453)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Reorder Level"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 488)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 13)
        Me.Label12.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(232, 389)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Unit"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(230, 423)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 13)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Unit"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(232, 456)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Unit"
        '
        'CategoriesTableAdapter
        '
        Me.CategoriesTableAdapter.ClearBeforeFill = True
        '
        'cbDiscontinued
        '
        Me.cbDiscontinued.AutoSize = True
        Me.cbDiscontinued.Location = New System.Drawing.Point(283, 456)
        Me.cbDiscontinued.Name = "cbDiscontinued"
        Me.cbDiscontinued.Size = New System.Drawing.Size(88, 17)
        Me.cbDiscontinued.TabIndex = 49
        Me.cbDiscontinued.Text = "Discontinued"
        Me.cbDiscontinued.UseVisualStyleBackColor = True
        '
        'NumStock
        '
        Me.NumStock.Location = New System.Drawing.Point(122, 386)
        Me.NumStock.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.NumStock.Name = "NumStock"
        Me.NumStock.Size = New System.Drawing.Size(104, 20)
        Me.NumStock.TabIndex = 50
        '
        'NumOrder
        '
        Me.NumOrder.Location = New System.Drawing.Point(122, 419)
        Me.NumOrder.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.NumOrder.Name = "NumOrder"
        Me.NumOrder.Size = New System.Drawing.Size(104, 20)
        Me.NumOrder.TabIndex = 51
        '
        'NumReorder
        '
        Me.NumReorder.Location = New System.Drawing.Point(122, 451)
        Me.NumReorder.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.NumReorder.Name = "NumReorder"
        Me.NumReorder.Size = New System.Drawing.Size(104, 20)
        Me.NumReorder.TabIndex = 52
        '
        'btnCari
        '
        Me.btnCari.Location = New System.Drawing.Point(235, 197)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(48, 23)
        Me.btnCari.TabIndex = 53
        Me.btnCari.Text = "Cari"
        Me.btnCari.UseVisualStyleBackColor = True
        '
        'frmProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(470, 536)
        Me.Controls.Add(Me.btnCari)
        Me.Controls.Add(Me.NumReorder)
        Me.Controls.Add(Me.NumOrder)
        Me.Controls.Add(Me.NumStock)
        Me.Controls.Add(Me.cbDiscontinued)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtQTperUnit)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgvProduct)
        Me.Controls.Add(Me.TxtID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NumPrice)
        Me.Controls.Add(Me.CmbSupplier)
        Me.Controls.Add(Me.CmbCategory)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmProducts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Products"
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CategoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumReorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProduct As System.Windows.Forms.DataGridView
    Friend WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NumPrice As System.Windows.Forms.NumericUpDown
    Friend WithEvents CmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtQTperUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents NorthwindDataSet1 As WindowsApplication4.NorthwindDataSet1
    Friend WithEvents CategoriesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CategoriesTableAdapter As WindowsApplication4.NorthwindDataSet1TableAdapters.CategoriesTableAdapter
    Friend WithEvents cbDiscontinued As System.Windows.Forms.CheckBox
    Friend WithEvents NumStock As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumOrder As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumReorder As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnCari As System.Windows.Forms.Button
End Class
