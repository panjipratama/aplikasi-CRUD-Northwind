Public Class frmUtama

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        frmSupplier.MdiParent = Me
        frmSupplier.Show()
        frmSupplier.Activate()
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        frmEmployee.MdiParent = Me
        frmEmployee.Show()
        frmEmployee.Activate()
    End Sub

    Private Sub CategoriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriesToolStripMenuItem.Click
        frmCategories.MdiParent = Me
        frmCategories.Show()
        frmCategories.Activate()
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        MessageBox.Show("Solution Name : " & Application.ProductName.ToString &
                        " Version : " & Application.ProductVersion.ToString &
                        " Company : " & Application.CompanyName.ToString)
    End Sub

    Private Sub ShippersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShippersToolStripMenuItem.Click
        frmShippers.MdiParent = Me
        frmShippers.Show()
        frmShippers.Activate()
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem.Click
        frmProducts.MdiParent = Me
        frmProducts.Show()
        frmProducts.Activate()
    End Sub

    Private Sub CustomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomersToolStripMenuItem.Click
        frmCustomers.MdiParent = Me
        frmCustomers.Show()
        frmCustomers.Activate()
    End Sub

    Private Sub OrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdersToolStripMenuItem.Click
        frmOrder.MdiParent = Me
        frmOrder.Show()
        frmOrder.Activate()
    End Sub

    Private Sub OrderDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderDetailToolStripMenuItem.Click
        frmOrderDetail.MdiParent = Me
        frmOrderDetail.Show()
        frmOrderDetail.Activate()
    End Sub

    Private Sub frmUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TesGabungToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TesGabungToolStripMenuItem.Click
        FrmTransOrder.MdiParent = Me
        FrmTransOrder.Show()
        FrmTransOrder.Activate()
    End Sub
End Class