Imports System.Xml
Imports System.Configuration

Public Class administrador
    Inherits persona

    Private rutaDatos As String = ConfigurationManager.AppSettings("archivoUsuarios")

    Public Enum tipo As Byte
        administrador = 1
        vendedor = 2
    End Enum

    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Private _clave As String
    Public Property Clave() As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property

    Public _tipo As Integer
    Public Property TipoEmpleado() As Integer
        Get
            Return _tipo
        End Get
        Set(ByVal value As Integer)
            _tipo = value
        End Set
    End Property

    Public Function Login() As Boolean
        Dim doc As New XmlDocument
        doc.Load(rutaDatos)

        Dim usuarios As XmlNodeList = doc.SelectNodes("//usuarios/usuario")

        For Each Usuario As XmlNode In usuarios
            If Usuario.Item("nickname").InnerText = Me.Usuario And Usuario.Item("password").InnerText = Me.Clave Then

                Me.Nombre = Usuario.Item("nombre").InnerText
                Me.Apellido = Usuario.Item("apellido").InnerText
                Me.Cedula = Usuario.Item("cedula").InnerText
                Me.TipoEmpleado = IIf(Usuario.Item("tipo").InnerText = "1", tipo.administrador, tipo.vendedor)

                Return True
            End If
        Next

        Return False
    End Function

    Public Function GuardarEmpleado() As Boolean
        Try
            Dim doc As XmlDocument = New XmlDocument
            doc.Load(rutaDatos)

            Dim elementoEmpleado As XmlElement = doc.CreateElement("usuario")
            Dim nodoId As XmlNode = doc.CreateElement("id")
            Dim nodoNombre As XmlNode = doc.CreateElement("nombre")
            Dim nodoApellido As XmlNode = doc.CreateElement("apellido")
            Dim nodoCedula As XmlNode = doc.CreateElement("cedula")
            Dim nodoEmail As XmlNode = doc.CreateElement("email")
            Dim nodoNick As XmlNode = doc.CreateElement("nickname")
            Dim nodoPass As XmlNode = doc.CreateElement("password")
            Dim nodoTipo As XmlNode = doc.CreateElement("tipo")

            nodoId.InnerText = Me.Id
            nodoNombre.InnerText = Me.Nombre
            nodoApellido.InnerText = Me.Apellido
            nodoCedula.InnerText = Me.Cedula
            nodoEmail.InnerText = Me.Email
            nodoNick.InnerText = Me.Usuario
            nodoPass.InnerText = Me.Clave
            nodoTipo.InnerText = tipo.administrador

            elementoEmpleado.AppendChild(nodoId)
            elementoEmpleado.AppendChild(nodoNombre)
            elementoEmpleado.AppendChild(nodoApellido)
            elementoEmpleado.AppendChild(nodoCedula)
            elementoEmpleado.AppendChild(nodoEmail)
            elementoEmpleado.AppendChild(nodoNick)
            elementoEmpleado.AppendChild(nodoPass)
            elementoEmpleado.AppendChild(nodoTipo)

            doc.DocumentElement.AppendChild(elementoEmpleado)
            doc.Save(rutaDatos)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function


End Class
