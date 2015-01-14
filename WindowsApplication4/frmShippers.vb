Imports System.Data.SqlClient

Public Class frmShippers
    Dim conn As SqlConnection
    Dim ds As New DataSet
    Dim da As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim reader As SqlDataReader
    Dim query As String

    Private Sub ClearForm()
        For Each Control In Me.Controls
            If (TypeOf Control Is TextBox) Then
                Control.Text = ""
            End If
        Next
    End Sub

    Private Sub cari(ID)

        Try
            conn.Open()
            'mengambil data mhs
            cmd = New SqlCommand()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select * from Shippers where ShipperID = " & ID & ""
            reader = cmd.ExecuteReader

            reader.Read()
            ClearForm()

            Me.txtShipperID.Text = reader(0).ToString
            Me.txtCompanyName.Text = reader(1).ToString
            Me.txtPhone.Text = reader(2).ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub isiGridShipper()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbShipper")) = False Then
                ds.Tables("tbShipper").Rows.Clear()
            End If

            query = "select * from Shippers"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbShipper") Then
                dgvShipper.DataSource = ds.Tables("tbShipper")
            End If

            conn.Close()
            da.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmShippers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New SqlConnection("Data Source = PANJIPRATAMA\SQLEXPRESS;" &
                                     "Initial Catalog = Northwind;" &
                                     "Integrated Security = True")
            ClearForm()
            isiGridShipper()

        Catch ex As Exception
            MessageBox.Show("Error Form Load!")
        End Try
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Dim ID As String
        ID = Me.txtShipperID.Text
        If (Me.txtShipperID.Text = "") Then
            MessageBox.Show("ID is Empty!")
        Else
            cari(ID)
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If (Me.txtCompanyName.Text = "") Then
                MessageBox.Show("Shipper Name is Empty!")
            Else
                query = "INSERT INTO Shippers (CompanyName,Phone) values ('" & Me.txtCompanyName.Text & "','" & Me.txtPhone.Text & "')"
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Shipper have been Save!")
                    isiGridShipper()
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Shipper have not been Save! Please Try again!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If (Me.txtShipperID.Text = "") Then
                MessageBox.Show("Shipper ID is Empty!")
            Else
                query = "UPDATE Shippers SET CompanyName = '" & Me.txtCompanyName.Text & "',Phone = '" & Me.txtPhone.Text & "' where ShipperID = '" & Me.txtShipperID.Text & "'"
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Shipper have been Update!")
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    isiGridShipper()
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Shipper have not been Update! Please Try again!")
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If (Me.txtShipperID.Text = "") Then
                MessageBox.Show("Shipper ID is Empty!")
            Else
                If MessageBox.Show("Are you sure to delete this Shipper ID (" & Me.txtShipperID.Text & ") ?", "confirm delete",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    query = "DELETE FROM Shippers WHERE ShipperID = " & Me.txtShipperID.Text & ""
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    cmd = New SqlCommand(query, conn)

                    If (cmd.ExecuteNonQuery() > 0) Then
                        MessageBox.Show("Shipper have been delete!")
                        btnUpdate.Enabled = False
                        btnDelete.Enabled = False
                        isiGridShipper()
                        ClearForm()

                        conn.Close()
                        cmd.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Shipper have not been delete! Please Try again!")
        End Try
    End Sub

    Private Sub dgvShipper_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShipper.CellContentClick
        Try
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            Me.txtShipperID.Text = dgvShipper.Rows(dgvShipper.CurrentCell.RowIndex).Cells("ShipperID").Value.ToString
            Me.txtCompanyName.Text = dgvShipper.Rows(dgvShipper.CurrentCell.RowIndex).Cells("CompanyName").Value.ToString
            Me.txtPhone.Text = dgvShipper.Rows(dgvShipper.CurrentCell.RowIndex).Cells("Phone").Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class