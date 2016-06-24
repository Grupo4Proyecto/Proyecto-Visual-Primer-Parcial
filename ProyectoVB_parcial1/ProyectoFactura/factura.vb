Public Class factura

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _nroFactura As Integer
    Public Property NumeroFactura() As Integer
        Get
            Return _nroFactura
        End Get
        Set(ByVal value As Integer)
            _nroFactura = value
        End Set
    End Property


    Private _nombreCliente As String
    Public Property NombreCliente() As String
        Get
            Return _nombreCliente
        End Get
        Set(ByVal value As String)
            _nombreCliente = value
        End Set
    End Property


    Private _ruc As String
    Public Property Ruc() As String
        Get
            Return _ruc
        End Get
        Set(ByVal value As String)
            _ruc = value
        End Set
    End Property

    Private _telefono As String
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Private _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _fechaEmision As DateTime
    Public Property FechaEmision() As DateTime
        Get
            Return _fechaEmision
        End Get
        Set(ByVal value As DateTime)
            _fechaEmision = value
        End Set
    End Property

    Private _totalPagar As Decimal
    Public Property TotalPagar() As Decimal
        Get
            Return _totalPagar
        End Get
        Set(ByVal value As Decimal)
            _totalPagar = value
        End Set
    End Property

    Private _subtotal As Decimal
    Public Property SubTotal() As Decimal
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Decimal)
            _subtotal = value
        End Set
    End Property



    Private _totalIva As Decimal
    Public Property TotalIva() As Decimal
        Get
            Return _totalIva
        End Get
        Set(ByVal value As Decimal)
            _totalIva = value
        End Set
    End Property

    Private _detalle As New List(Of detalleFactura)
    Public Property Detalle() As List(Of detalleFactura)
        Get
            Return _detalle
        End Get
        Set(ByVal value As List(Of detalleFactura))
            _detalle = value
        End Set
    End Property



End Class
