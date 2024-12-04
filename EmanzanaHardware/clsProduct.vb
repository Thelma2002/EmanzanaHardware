Public Class clsProduct
    Private _ProductID As Integer
    Private _ProductName As String
    Private _Price As Decimal
    Private _Quantity As Integer


    ' Default constructor
    Public Sub New()
        ' Initialize fields to default values
        _ProductID = 0
        _ProductName = ""
        _Price = 0
        _Quantity = 0
    End Sub

    'Parameterised Constructors
    Public Sub New(ProductID As Integer, ProductName As String, Price As Decimal, Quantity As Integer)
        _ProductID = ProductID
        _ProductName = ProductName
        _Price = Price
        _Quantity = Quantity
    End Sub

    'Accessor/Mutator methods

    Public Property ProductID() As Integer
        Get
            Return _ProductID
        End Get
        Set(ByVal value As Integer)
            _ProductID = value
        End Set
    End Property

    Public Property ProductName() As String
        Get
            Return _ProductName
        End Get
        Set(ByVal value As String)
            _ProductName = value
        End Set
    End Property

    Public Property Price() As Decimal
        Get
            Return _Price
        End Get
        Set(ByVal value As Decimal)
            _Price = value
        End Set
    End Property

    Public Property Quantity() As Integer
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Integer)
            _Quantity = value
        End Set
    End Property

    'Auxiliary Method
    Public Function CalculateTotalPrice() As Decimal
        Return _Price * _Quantity
    End Function
End Class
