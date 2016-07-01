Imports System.Xml
Imports System.Configuration

Public Class articulo
    Private _id As Integer
    Public rutaDatos As String = ConfigurationManager.AppSettings("archivoArticulos")
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

    Private _marca As String
    Public Property Marca() As String
        Get
            Return _marca
        End Get
        Set(ByVal value As String)
            _marca = value
        End Set
    End Property

    Private _modelo As String
    Public Property Modelo() As String
        Get
            Return _modelo
        End Get
        Set(ByVal value As String)
            _modelo = value
        End Set
    End Property

    Private _precio As Decimal
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property

    Private _stock As Integer
    Public Property Stock() As Integer
        Get
            Return _stock
        End Get
        Set(ByVal value As Integer)
            _stock = value
        End Set
    End Property

    Private _aplicaIva As Boolean
    Public Property AplicaIva() As Boolean
        Get
            Return _aplicaIva
        End Get
        Set(ByVal value As Boolean)
            _aplicaIva = value
        End Set
    End Property

    Private _estado As Char
    Public Property Estado() As Char
        Get
            Return _estado
        End Get
        Set(ByVal value As Char)
            _estado = value
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


    Private _categoria As New categoria
    Public Property Categoria() As categoria
        Get
            Return _categoria
        End Get
        Set(ByVal value As categoria)
            _categoria = value
        End Set
    End Property

    Public Function GenerarXml(xmlDoc As XmlDocument)
        Dim articulo As XmlNode = xmlDoc.CreateElement("categoria")
        Return articulo
    End Function

    Public Function GuardarArticulo() As Boolean
        Try

            Dim doc As New XmlDocument
            doc.Load(rutaDatos)

            Dim elementoArticulo As XmlElement = doc.CreateElement("articulo")

            Dim nodoId As XmlNode = doc.CreateElement("id")
            Dim nodoNombre As XmlNode = doc.CreateElement("nombre")
            Dim nodoMarca As XmlNode = doc.CreateElement("marca")
            Dim nodoPrecio As XmlNode = doc.CreateElement("precio")
            Dim nodoDescripcion As XmlNode = doc.CreateElement("descripcion")
            Dim nodoModelo As XmlNode = doc.CreateElement("modelo")
            Dim nodoStock As XmlNode = doc.CreateElement("stock")
            Dim nodoAplicaIva As XmlNode = doc.CreateElement("aplicaIva")
            Dim nodoEstado As XmlNode = doc.CreateElement("estado")
            Dim nodoCategoria As XmlNode = doc.CreateElement("categoria")

            nodoId.InnerText = Me.Id
            nodoNombre.InnerText = Me.Nombre
            nodoMarca.InnerText = Me.Marca
            nodoPrecio.InnerText = Me.Precio
            nodoDescripcion.InnerText = Me.Descripcion
            nodoModelo.InnerText = Me.Modelo
            nodoStock.InnerText = Me.Stock
            nodoAplicaIva.InnerText = Me.AplicaIva
            nodoEstado.InnerText = Me.Estado
            nodoCategoria.InnerText = Me.Categoria.Id

            elementoArticulo.AppendChild(nodoId)
            elementoArticulo.AppendChild(nodoNombre)
            elementoArticulo.AppendChild(nodoMarca)
            elementoArticulo.AppendChild(nodoPrecio)
            elementoArticulo.AppendChild(nodoDescripcion)
            elementoArticulo.AppendChild(nodoModelo)
            elementoArticulo.AppendChild(nodoStock)
            elementoArticulo.AppendChild(nodoAplicaIva)
            elementoArticulo.AppendChild(nodoEstado)
            elementoArticulo.AppendChild(nodoCategoria)

            doc.DocumentElement.AppendChild(elementoArticulo)
            doc.Save(rutaDatos)




            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
