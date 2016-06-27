Imports System.Configuration
Imports System.Xml

Public Class categoria


    Private rutaDatos As String = ConfigurationManager.AppSettings("archivoCategorias")

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

    Public Function GuardarCategoria() As Boolean
        Try
            Dim doc As New XmlDocument()
            doc.Load(rutaDatos)

            Dim elementoCategoria As XmlElement = doc.CreateElement("categoria")

            Dim nodoId As XmlNode = doc.CreateElement("id")
            Dim nodoNombre As XmlNode = doc.CreateElement("nombre")
            Dim nodoProducto As XmlNode = doc.CreateElement("producto")

            nodoId.InnerText = Me.Id
            nodoNombre.InnerText = Me.Nombre

            elementoCategoria.AppendChild(nodoId)
            elementoCategoria.AppendChild(nodoNombre)
            elementoCategoria.AppendChild(nodoProducto)

            doc.AppendChild(elementoCategoria)
            doc.Save(rutaDatos)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function




End Class
