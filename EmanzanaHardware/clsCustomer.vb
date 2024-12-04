Public Class clsCustomer
    Private _CustomerID As Integer
    Private _CustomerFirstName As String
    Private _CustomerLastName As String

    ' Parameterized Constructor with Optional and Reference Parameters
    Public Sub New(CustomerID As Integer, CustomerFirstName As String, Optional ByRef CustomerLastName As String = "Unknown")
        Try
            If CustomerID <= 0 Then
                Throw New ArgumentException("CustomerID must be a positive integer.")
            End If

            If String.IsNullOrEmpty(CustomerFirstName) Then
                Throw New ArgumentException("CustomerFirstName cannot be null or empty.")
            End If

            _CustomerID = CustomerID
            _CustomerFirstName = CustomerFirstName
            _CustomerLastName = CustomerLastName

        Catch ex As Exception
            ' Handle the exception here
            MessageBox.Show("An error occurred while creating the customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Accessor/Mutator methods
    Public Property CustomerID() As Integer
        Get
            Return _CustomerID
        End Get
        Set(ByVal value As Integer)
            _CustomerID = value
        End Set
    End Property

    Public Property CustomerFirstName() As String
        Get
            Return _CustomerFirstName
        End Get
        Set(ByVal value As String)
            _CustomerFirstName = value
        End Set
    End Property

    Public Property CustomerLastName() As String
        Get
            Return _CustomerLastName
        End Get
        Set(ByVal value As String)
            _CustomerLastName = value
        End Set
    End Property

    'Auxiliary method
    Public Sub DisplayCustomerDetails()
        Dim details As String = "Customer ID: " & _CustomerID & vbCrLf &
                                "Customer FirstName: " & _CustomerFirstName & vbCrLf &
                                "Customer Surname: " & _CustomerLastName
        MessageBox.Show(details, "Customer information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class
