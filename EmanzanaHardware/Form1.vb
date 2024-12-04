Public Class Form1

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
    Private CustomerIDCounter As Integer = 1
    Private TransactionIDCounter As Integer = 1
    ' Define a list to store product objects
    Private products As New List(Of clsProduct)
    'Define list to store tracsaction objects
    Private Transaction As New List(Of clsTransaction)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate the products list with sample data

        products.Add(New clsProduct(1, "Building Materials", 500.0, 1))
        products.Add(New clsProduct(2, "Construction Supplies", 200.0, 1))
        products.Add(New clsProduct(3, "Construction Aggregates", 400.0, 1))
        products.Add(New clsProduct(4, "Masonry Products", 600.0, 1))

        ' Populate the combo box with the product names
        cmbProduct.DataSource = products
        cmbProduct.DisplayMember = "ProductName"

    End Sub

   
    Private Sub DisplayCustomerDetails()
        ' Validate if first name and last name are provided
        If txtFirstName.Text = "" Or txtLastName.Text = "" Then
            MessageBox.Show("Please enter a first and last name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        ' Create a new customer object
        Dim objCustomer As New clsCustomer(CustomerIDCounter, txtFirstName.Text, txtLastName.Text)
        ' Increment the counter for the next customer
        CustomerIDCounter += 1
        ' Display the customer details
        objCustomer.DisplayCustomerDetails()

        txtFirstName.Clear()
        txtLastName.Clear()
        txtFirstName.Focus()
    End Sub

    Private Function CalculateTotalPrice() As Decimal
        Dim totalPrice As Decimal = 0

        For Each product In products
            totalPrice += product.CalculateTotalPrice()
        Next

        Return totalPrice
    End Function

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        ' Call Customer details
        Dim objCustomer As clsCustomer = New clsCustomer(CustomerIDCounter, txtFirstName.Text, txtLastName.Text)
        DisplayCustomerDetails()
      
        Try
            ' Create a new transaction object
            Dim objTransaction As New clsTransaction(TransactionIDCounter, DateTime.Now, objCustomer, products)

            ' Increment the counter for the next transaction
            TransactionIDCounter += 1
            ' Calculate the total amount for the transaction
            Dim totalAmount As Decimal = objTransaction.CalculateTotalAmount(objTransaction.Products)

            ' Display the transaction details
            lstDisplay.Items.Add("Transaction ID: " & objTransaction.TransactionID)
            lstDisplay.Items.Add("Date: " & objTransaction.Dates.ToString("dd/MM/yyyy HH:mm:ss"))
            lstDisplay.Items.Add("Customer: " & objTransaction.Customer.CustomerFirstName & " " & objTransaction.Customer.CustomerLastName)
            lstDisplay.Items.Add("Total Amount: " & totalAmount.ToString("C"))
                               
            ' Add the transaction to the list
            Transaction.Add(objTransaction)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub cmbQuantity_ValueChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        ' Get the selected product
        Dim selectedProduct As clsProduct = TryCast(cmbProduct.SelectedItem, clsProduct)

        ' Display the product details
        MessageBox.Show("Product Name: " & selectedProduct.ProductName & vbCrLf &
                        "Price: " & selectedProduct.Price & vbCrLf &
                        "Quantity: " & selectedProduct.Quantity, "Product information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Display an input box for the user to select the quantity
        Dim result As DialogResult = InputBox("Enter the quantity of " & selectedProduct.ProductName, "Quantity Selection")

        ' Convert the input to an integer
        Dim quantity As Integer
        If Integer.TryParse(result, quantity) Then
            ' Set the quantity of the selected product
            selectedProduct.Quantity = quantity
        End If
    End Sub

End Class
