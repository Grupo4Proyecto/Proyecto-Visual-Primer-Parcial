﻿Imports System.Configuration
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
            Dim nodoProducto As XmlNode = doc.CreateElement("productos")

            nodoId.InnerText = Me.Id
            nodoNombre.InnerText = Me.Nombre

            elementoCategoria.AppendChild(nodoId)
            elementoCategoria.AppendChild(nodoNombre)
            elementoCategoria.AppendChild(nodoProducto)

            doc.DocumentElement.AppendChild(elementoCategoria)
            doc.Save(rutaDatos)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function existeId() As Boolean
        Dim xml As New XmlDocument
        xml.Load(rutaDatos)
        For Each categoria As XmlNode In xml.DocumentElement.ChildNodes
            If (categoria.Item("id").InnerText = Me.Id) Then
                Return True
            End If
        Next

        Return False
    End Function


    Public Function Buscar() As Boolean
        Try
            Dim doc As New XmlDocument
            doc.Load(rutaDatos)

            Dim elementoRaiz As XmlElement = doc.DocumentElement

            For Each elementoArticulo As XmlNode In elementoRaiz.ChildNodes
                If (elementoArticulo.Item("id").InnerText = Me.Id) Then
                    Me.Nombre = elementoArticulo.Item("nombre").InnerText
                    Return True
                End If
            Next

            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub MostrarCategoria()
        Try
            Dim XmlDoc As New XmlDocument()
            XmlDoc.Load(rutaDatos)
            Dim elementoRaiz As XmlNodeList = XmlDoc.GetElementsByTagName("categorias")

            Console.Clear()
            Console.WriteLine(vbTab & vbTab & vbTab & "==========================================")
            Console.WriteLine(vbTab & vbTab & vbTab & "|      MANTENIMIENTO DE CATEGORIA        |")
            Console.WriteLine(vbTab & vbTab & vbTab & "==========================================" & vbNewLine)

            For Each elementoCategoria As XmlNode In elementoRaiz
                For Each elementosDeCategoria As XmlNode In elementoCategoria.ChildNodes
                    Console.WriteLine(vbTab & vbTab & vbTab & elementosDeCategoria.Item("id").InnerText & elementosDeCategoria.Item("nombre").InnerText)

                Next

            Next


        Catch ex As Exception

        End Try



    End Sub

    Public Sub modificarCategoria()
        Try
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(rutaDatos)
            Dim elementoRaiz As XmlNodeList = xmlDoc.GetElementsByTagName("categorias")
            Dim elemetoCategoria As XmlElement = xmlDoc.CreateElement("categoria")

            For Each elementoCategoriaNodo As XmlNode In elementoRaiz
                For Each nodoHijo As XmlNode In elementoCategoriaNodo.ChildNodes

                    Dim nodoNombre As XmlNode = xmlDoc.CreateElement("nombre")
                    nodoNombre.InnerText = Me.Nombre

                    elemetoCategoria.ReplaceChild(nodoNombre, nodoHijo)
                    xmlDoc.DocumentElement.ReplaceChild(elemetoCategoria, elementoCategoriaNodo)
                    xmlDoc.Save(rutaDatos)
                Next
            Next
        Catch ex As Exception

        End Try


    End Sub

End Class
