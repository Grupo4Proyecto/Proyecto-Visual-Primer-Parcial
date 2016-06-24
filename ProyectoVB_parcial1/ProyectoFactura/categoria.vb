Public Class categoria

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _productos As New List(Of articulo)
    Public Property Articulos As List(Of articulo)
        Get
            Return _productos
        End Get
        Set(ByVal value As List(Of articulo))
            _productos = value
        End Set
    End Property






End Class
