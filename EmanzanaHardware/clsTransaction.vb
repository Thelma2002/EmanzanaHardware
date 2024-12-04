Public Class clsTransaction
    Private _TransactionID As Integer
    Private _Dates As Date
    Private _objCustomer As clsCustomer
    Private _objProducts As List(Of clsProduct)

    ' Parameterized constructor
    Public Sub New(TransactionID As Integer, Dates As Date, objCustomer As clsCustomer, objProducts As List(Of clsProduct))
        _TransactionID = TransactionID
        _Dates = Dates
        _objCustomer = objCustomer
        _objProducts = objProducts
    End Sub

    ' Accessor/Mutator methods
    Public Property TransactionID() As Integer
        Get
            Return _TransactionID
        End Get
        Set(ByVal value As Integer)
            _TransactionID = value
        End Set
    End Property

    Public Property Dates() As Date
        Get
            Return _Dates
        End Get
        Set(ByVal value As Date)
            _Dates = value
        End Set
    End Property

    Public Property Customer() As clsCustomer
        Get
            Return _objCustomer
        End Get
        Set(ByVal value As clsCustomer)
            _objCustomer = value
        End Set
    End Property

    Public Property Products() As List(Of clsProduct)
        Get
            Return _objProducts
        End Get
        Set(ByVal value As List(Of clsProduct))
            _objProducts = value
        End Set
    End Property

    ' Auxiliary Method
    Public Function CalculateTotalAmount() As Decimal
        Return CalculateTotalAmount(_objProducts)
    End Function

    Public Function CalculateTotalAmount(objProducts As List(Of clsProduct)) As Decimal
        Dim TotalAmount As Decimal = 0
        For Each objProduct In objProducts
            TotalAmount += objProduct.CalculateTotalPrice()
        Next
        Return TotalAmount
    End Function
End Class