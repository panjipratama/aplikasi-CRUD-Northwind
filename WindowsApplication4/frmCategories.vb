Imports System.Data.SqlClient

Public Class frmCategories
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

            If (TypeOf Control Is RichTextBox) Then
                Control.Text = ""
            End If

            pbPictures.Image = Nothing

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
            cmd.CommandText = "Select * from Categories where CategoryID = " & ID & ""
            reader = cmd.ExecuteReader

            reader.Read()
            ClearForm()

            Me.txtCategoryID.Text = reader(0).ToString
            Me.txtCategoryName.Text = reader(1).ToString
            Me.rtbDescription.Text = reader(2).ToString
            Me.txtFileName.Text = reader(3).ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub isiGridCategori()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            If IsNothing(ds.Tables("tbCategori")) = False Then
                ds.Tables("tbCategori").Rows.Clear()
            End If

            query = "select * from Categories"
            da = New SqlDataAdapter(query, conn)

            If da.Fill(ds, "tbCategori") Then
                dgvCategori.DataSource = ds.Tables("tbCategori")
            End If

            conn.Close()
            da.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn = New SqlConnection("Data Source = PANJIPRATAMA\SQLEXPRESS;" &
                                     "Initial Catalog = Northwind;" &
                                     "Integrated Security = True")
            ClearForm()
            isiGridCategori()
        Catch ex As Exception
            MessageBox.Show("Error Form Load!")
        End Try
    End Sub

    Private Sub btnCariCategories_Click(sender As Object, e As EventArgs) Handles btnCariCategories.Click
        Dim ID As String
        ID = Me.txtCategoryID.Text
        If (Me.txtCategoryID.Text = "") Then
            MessageBox.Show("ID is Empty!")
        Else
            cari(ID)
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If (Me.txtCategoryName.Text = "") Then
                MessageBox.Show("Category Name is Empty!")
            Else
                query = "INSERT INTO Categories (CategoryName,Description,Picture) values ('" & Me.txtCategoryName.Text & "','" & Me.rtbDescription.Text & "','" & Me.txtFileName.Text & "')"
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Category have been Save!")
                    isiGridCategori()
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Category have not been Save! Please Try again!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If (Me.txtCategoryID.Text = "") Then
                MessageBox.Show("Category ID is Empty!")
            Else
                query = "UPDATE Categories SET CategoryName = '" & Me.txtCategoryName.Text & "',Description = '" & Me.rtbDescription.Text & "',Picture = '" & Me.txtFileName.Text & "' where CategoryID = '" & Me.txtCategoryID.Text & "'"
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                cmd = New SqlCommand(query, conn)

                If (cmd.ExecuteNonQuery() > 0) Then
                    MessageBox.Show("Category have been Update!")
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    isiGridCategori()
                    ClearForm()

                    conn.Close()
                    cmd.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("Category have not been Update! Please Try again!")
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If (Me.txtCategoryID.Text = "") Then
                MessageBox.Show("Category ID is Empty!")
            Else
                If MessageBox.Show("Are you sure to delete this Category ID (" & Me.txtCategoryID.Text & ") ?", "confirm delete",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    query = "DELETE FROM Categories WHERE CategoryID = " & Me.txtCategoryID.Text & ""
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

                    cmd = New SqlCommand(query, conn)

                    If (cmd.ExecuteNonQuery() > 0) Then
                        MessageBox.Show("Category have been delete!")
                        btnUpdate.Enabled = False
                        btnDelete.Enabled = False
                        isiGridCategori()
                        ClearForm()

                        conn.Close()
                        cmd.Dispose()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Category have not been delete! Please Try again!")
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim openFile As New OpenFileDialog
        openFile.Title = "Open Image"
        openFile.Filter = "jpg (*.jpg)|*.jpg|png (*.png)|*.png|gif (*.gif)|*.gif|All File (*.*)|*.*"
        openFile.ShowDialog()
        Me.pbPictures.ImageLocation = openFile.FileName
        Me.txtFileName.Text = openFile.FileName
    End Sub

    Private Sub dgvCategori_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategori.CellContentClick
        Try
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            Me.txtCategoryID.Text = dgvCategori.Rows(dgvCategori.CurrentCell.RowIndex).Cells("CategoryID").Value.ToString
            Me.txtCategoryName.Text = dgvCategori.Rows(dgvCategori.CurrentCell.RowIndex).Cells("CategoryName").Value.ToString
            Me.rtbDescription.Text = dgvCategori.Rows(dgvCategori.CurrentCell.RowIndex).Cells("Description").Value.ToString
            Me.txtFileName.Text = dgvCategori.Rows(dgvCategori.CurrentCell.RowIndex).Cells("Picture").Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class