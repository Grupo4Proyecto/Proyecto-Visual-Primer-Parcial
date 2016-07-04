Imports System.Configuration
Imports System.Xml

Public Class factura

    Public detalleFatura As New detalleFactura()

    Private _precioUni As Integer
    Public Property procioUni() As Integer
        Get
            Return _precioUni
        End Get
        Set(ByVal value As Integer)
            _precioUni = value
        End Set
    End Property

    Private _cantidad As String
    Public Property cantidad() As String
        Get
            Return _cantidad
        End Get
        Set(ByVal value As String)
            _cantidad = value
        End Set
    End Property

    Private _articulo As String
    Public Property articulo() As String
        Get
            Return _articulo
        End Get
        Set(ByVal value As String)
            _articulo = value
        End Set
    End Property

    Private rutaDatos As String = ConfigurationManager.AppSettings("archivoFacturas")


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

    Private _provincia As String
    Public Property provincia() As String
        Get
            Return _provincia
        End Get
        Set(ByVal value As String)
            _provincia = value
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


    Public Function GuardarFactura() As Boolean

        Try
            Dim xmlDom As New XmlDocument()
            xmlDom.Load(rutaDatos)

            Dim elememtoFactura As XmlElement = xmlDom.CreateElement("factura")

            Dim nodoId As XmlNode = xmlDom.CreateElement("id")
            Dim nodoNumero As XmlNode = xmlDom.CreateElement("numeroFactura")
            Dim nodoNombreCliente As XmlNode = xmlDom.CreateElement("nombreCliente")
            Dim nodoRuc As XmlNode = xmlDom.CreateElement("ruc")
            Dim nodoTelefono As XmlNode = xmlDom.CreateElement("telefono")
            Dim nodoProvincia As XmlNode = xmlDom.CreateElement("provincia")
            Dim nodoDieccion As XmlNode = xmlDom.CreateElement("direccion")
            Dim nodoFechaEmision As XmlNode = xmlDom.CreateElement("fechaEmision")
            Dim nodoSubtotal As XmlNode = xmlDom.CreateElement("subtotal")
            Dim nodoTotalIva As XmlNode = xmlDom.CreateElement("totalIva")
            Dim nodoTotalAPagar As XmlNode = xmlDom.CreateElement("pagoTotal")
            Dim nodoDescripcion As XmlNode = xmlDom.CreateElement("descripcion")


            nodoId.InnerText = Me.Id
            nodoNumero.InnerText = Me.NumeroFactura
            nodoNombreCliente.InnerText = Me.NombreCliente
            nodoRuc.InnerText = Me.Ruc
            nodoTelefono.InnerText = Me.Telefono
            nodoProvincia.InnerText = Me.provincia
            nodoDieccion.InnerText = Me.Direccion
            nodoFechaEmision.InnerText = Me.FechaEmision
            nodoSubtotal.InnerText = Me.SubTotal
            nodoTotalIva.InnerText = Me.TotalIva
            nodoTotalAPagar.InnerText = Me.TotalPagar

            elememtoFactura.AppendChild(nodoId)
            elememtoFactura.AppendChild(nodoNumero)
            elememtoFactura.AppendChild(nodoNombreCliente)
            elememtoFactura.AppendChild(nodoRuc)
            elememtoFactura.AppendChild(nodoTelefono)
            elememtoFactura.AppendChild(nodoProvincia)
            elememtoFactura.AppendChild(nodoDieccion)
            elememtoFactura.AppendChild(nodoFechaEmision)
            elememtoFactura.AppendChild(nodoSubtotal)
            elememtoFactura.AppendChild(nodoTotalIva)
            elememtoFactura.AppendChild(nodoTotalAPagar)

            xmlDom.DocumentElement.AppendChild(elememtoFactura)
            xmlDom.Save(rutaDatos)
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function


    Public Sub ElegirArticuloAFacturar()


        Dim xmlDom As New XmlDocument()
        xmlDom.Load(ConfigurationManager.AppSettings("archivoArticulos"))
        Dim listaDeArticulos As XmlNodeList = xmlDom.GetElementsByTagName("articulos")



        For Each nodoArticulo As XmlNode In listaDeArticulos
            For Each elementosArticulo As XmlNode In nodoArticulo.ChildNodes
                Dim id As String = elementosArticulo.Item("id").InnerText
                Dim nombre As String = elementosArticulo.Item("nombre").InnerText
                Console.Write(vbTab & vbTab & vbTab & id)
                Console.WriteLine(nombre)
            Next


        Next



        Console.WriteLine(vbTab & vbTab & vbTab & "Ingrese Id del articulo")
        Me.articulo = Console.ReadLine()

        Console.WriteLine("ingrese cantidad")
        Me.cantidad = Console.ReadLine()

        For Each articulos As XmlNode In listaDeArticulos
            For Each elementosDeArticulos As XmlNode In articulos.ChildNodes
                Try

                    'cantidad < articulos.Item("stock").InnerText

                    If (elementosDeArticulos.Item("id").InnerText = Me.articulo) Then

                        detalleFatura.Cantidad = Me.cantidad
                        detalleFatura.Descripcion = elementosDeArticulos.Item("nombre").InnerText
                        detalleFatura.PrecioUnit = elementosDeArticulos.Item("precio").InnerText
                        Me._precioUni = detalleFatura.PrecioUnit
                        Detalle.Add(detalleFatura)



                        Console.WriteLine(detalleFatura.Descripcion)
                        Console.WriteLine("funciona bien")

                    End If


                Catch ex As Exception

                End Try

            Next

        Next




    End Sub



End Class
