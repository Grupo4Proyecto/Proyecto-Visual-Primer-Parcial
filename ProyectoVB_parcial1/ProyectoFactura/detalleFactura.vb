Public Class detalleFactura

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _articulo As New articulo
    Public Property articulo() As articulo
        Get
            Return _articulo
        End Get
        Set(ByVal value As articulo)
            _articulo = value
        End Set

    End Property

    Private _cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _precioUnit As Decimal
    Public Property PrecioUnit() As Decimal
        Get
            Return _precioUnit
        End Get
        Set(ByVal value As Decimal)
            _precioUnit = value
        End Set
    End Property

    Private _subTotal As Decimal
    Public Property Costo() As Decimal
        Get
            Return _subTotal
        End Get
        Set(ByVal value As Decimal)
            _subTotal = value
        End Set
    End Property

    Private _iva As Decimal
    Public Property Iva() As Decimal
        Get
            Return _iva
        End Get
        Set(ByVal value As Decimal)
            _iva = value
        End Set
    End Property




End Class
