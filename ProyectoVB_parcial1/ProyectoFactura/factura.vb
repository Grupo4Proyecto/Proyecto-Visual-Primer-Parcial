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


    Public Function CalcularTotal() As Decimal
        Try
            Dim total As Decimal = 0
            Dim subtotal As Decimal = 0
            Dim totalIva As Decimal = 0
            For Each lineaDetalle As detalleFactura In Me.Detalle
                subtotal = subtotal + lineaDetalle.Costo
                totalIva = totalIva + lineaDetalle.Iva
                total = total + (lineaDetalle.Costo + lineaDetalle.Iva)
            Next
            Me.TotalIva = totalIva
            Me.SubTotal = subtotal
            Return total
        Catch ex As Exception
            Me.TotalIva = 0
            Me.SubTotal = 0
            Return 0
        End Try
    End Function



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


            Dim elementoDetalle As XmlElement = xmlDom.CreateElement("detalle")

            For Each linea As detalleFactura In Me.Detalle
                Dim nodoLinea As XmlElement = xmlDom.CreateElement("linea")

                Dim attrCantidad As XmlAttribute = xmlDom.CreateAttribute("cantidad")
                attrCantidad.Value = linea.Cantidad

                Dim attrCosto As XmlAttribute = xmlDom.CreateAttribute("costo")
                attrCosto.Value = linea.Costo

                Dim attrDescripcion As XmlAttribute = xmlDom.CreateAttribute("descripcion")
                attrDescripcion.Value = linea.Descripcion

                Dim attrPrecio As XmlAttribute = xmlDom.CreateAttribute("precio")
                attrPrecio.Value = linea.PrecioUnit

                Dim attrIVA As XmlAttribute = xmlDom.CreateAttribute("iva")
                attrIVA.Value = linea.Iva

                Dim attrArticulo As XmlAttribute = xmlDom.CreateAttribute("articulo")
                attrArticulo.Value = linea.articulo.Id


                nodoLinea.Attributes.Append(attrCantidad)
                nodoLinea.Attributes.Append(attrCosto)
                nodoLinea.Attributes.Append(attrDescripcion)
                nodoLinea.Attributes.Append(attrPrecio)
                nodoLinea.Attributes.Append(attrArticulo)
                nodoLinea.Attributes.Append(attrIVA)

                elementoDetalle.AppendChild(nodoLinea)
            Next
            elememtoFactura.AppendChild(elementoDetalle)




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


    End Sub


    Public Function BuscarFactura() As Boolean
        Try
            Dim xmlDom As New XmlDocument()
            xmlDom.Load(rutaDatos)

            Dim elementoRaiz As XmlElement = xmlDom.DocumentElement

            For Each elementoFactura As XmlNode In elementoRaiz.ChildNodes
                If (elementoFactura.Item("id").InnerText = Me.Id) Then
                    Me.NumeroFactura = elementoFactura.Item("numeroFactura").InnerText
                    Me.NombreCliente = elementoFactura.Item("nombreCliente").InnerText
                    Me.Ruc = elementoFactura.Item("ruc").InnerText
                    Me.Telefono = elementoFactura.Item("telefono").InnerText
                    Me.provincia = elementoFactura.Item("provincia").InnerText
                    Me.Direccion = elementoFactura.Item("direccion").InnerText
                    Me.FechaEmision = elementoFactura.Item("fechaEmision").InnerText
                    Me.SubTotal = elementoFactura.Item("subtotal").InnerText
                    Me.TotalIva = elementoFactura.Item("totalIva").InnerText
                    Me.TotalPagar = elementoFactura.Item("pagoTotal").InnerText

                End If


            Next
            Return False
        Catch ex As Exception
            Return False
        End Try


    End Function


    Public Sub imprimirFactura()
        Console.Clear()
        Console.WriteLine("" & vbNewLine)
        Console.WriteLine(vbTab & vbTab & vbTab & "==============================")
        Console.WriteLine(vbTab & vbTab & vbTab & "|     Factura Solicitada   |")
        Console.WriteLine(vbTab & vbTab & vbTab & "==============================" & vbNewLine)

        Console.WriteLine(vbTab & vbTab & vbTab & "Numero: " & Me.NumeroFactura)
        Console.WriteLine(vbTab & vbTab & vbTab & "Cliente: " & Me.NombreCliente)
        Console.WriteLine(vbTab & vbTab & vbTab & "Ruc: " & Me.Ruc)
        Console.WriteLine(vbTab & vbTab & vbTab & "Telefono: " & Me.Telefono)
        Console.WriteLine(vbTab & vbTab & vbTab & "Provincia: " & Me.provincia)
        Console.WriteLine(vbTab & vbTab & vbTab & "Direccion: " & Me.Direccion)
        Console.WriteLine(vbTab & vbTab & vbTab & "Fecha De Emision: " & Me.FechaEmision)
        Console.WriteLine(vbTab & vbTab & vbTab & "Subtotal: " & Me.SubTotal)
        Console.WriteLine(vbTab & vbTab & vbTab & "Iva: " & Me.TotalIva)
        Console.WriteLine(vbTab & vbTab & vbTab & "Total a Pagar: " & Me.TotalPagar)
        Console.Read()

    End Sub

End Class
