Imports System.Xml
Imports System.Configuration

Public Class empleado
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

End Class
