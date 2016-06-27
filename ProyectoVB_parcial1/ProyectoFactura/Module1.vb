Module Module1

    Sub Main()

        Dim tipoRol As Byte = 1
        While True
            If (login(tipoRol)) Then
                If (tipoRol = 1) Then
                    mostrarMenuAdministrador()
                Else
                    mostrarMenuVendedor()
                End If
            End If
        End While

    End Sub

    Public Sub agregarCategoria()
        Dim continuar As String = "s"

        Do While continuar = "s"
            Console.Clear()

            Dim objCategoria As New categoria()

            Console.WriteLine("Id: ")
            objCategoria.Id = Console.ReadLine()

            Console.WriteLine("Nombre: ")
            objCategoria.Nombre = Console.ReadLine()

            objCategoria.GuardarCategoria()

            Console.WriteLine("categoria guardada")

            Console.Write(vbTab & vbTab & vbTab & "Guardar otra categoria? [s/n]: ")
            continuar = Console.ReadLine()
        Loop
    End Sub

    Public Sub agregarProducto()
        Console.WriteLine("FUNCION POR DEFINIR")
    End Sub

    Public Sub agregarVendedor()
        Console.WriteLine("FUNCION POR DEFINIR")
    End Sub

    Public Sub salir()
        Console.WriteLine("FUNCION POR DEFINIR")
    End Sub

    Public Sub mostrarMenuAdministrador()
        Dim opcion As String = String.Empty

        While True
            Console.Clear()
            Console.WriteLine(vbTab & "--------------------------------------------------------------" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "==============================")
            Console.WriteLine(vbTab & vbTab & vbTab & "|      MENÚ ADMIN            |")
            Console.WriteLine(vbTab & vbTab & vbTab & "==============================" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "1.- Agregar categoria" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "2.- Agregar producto" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "3.- Agregar Vendedor" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "4.- Salir" & vbNewLine)
            Console.Write(vbTab & vbTab & vbTab & "Escriba su opción: ")
            opcion = Console.ReadLine()
            Console.WriteLine(vbTab & "--------------------------------------------------------------" & vbNewLine)

            Select Case opcion
                Case 1
                    agregarCategoria()
                Case 2
                    agregarProducto()
                Case 3
                    agregarVendedor()
                Case 4
                    Exit While
                Case Else
                    Console.WriteLine("Opcion no existe. Escriba bien.")
            End Select
        End While

    End Sub

    Public Sub Facturar()
        Console.WriteLine("FUNCION POR DEFINIR")
    End Sub


    Public Sub mostrarMenuVendedor()
        Dim opcion As String = String.Empty

        While True
            Console.Clear()
            Console.WriteLine(vbTab & "--------------------------------------------------------------" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "==============================")
            Console.WriteLine(vbTab & vbTab & vbTab & "|         MENÚ VENDEDOR      |")
            Console.WriteLine(vbTab & vbTab & vbTab & "==============================" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "1.- Facturar" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "2.- Salir" & vbNewLine)
            Console.Write(vbTab & vbTab & vbTab & "Escriba su opción: ")
            opcion = Console.ReadLine()
            Console.WriteLine(vbTab & "--------------------------------------------------------------" & vbNewLine)

            Select Case opcion
                Case 1
                    Facturar()
                Case 2
                    Exit While
                Case Else
                    Console.WriteLine("Opcion no existe. Escriba bien.")
            End Select
        End While

    End Sub

    Public Function login(ByRef rol As Byte) As Boolean

        Dim usuarioInput As String = String.Empty
        Dim claveInput As String = String.Empty
        Dim continua As String = "s"

        While True
            Console.Clear()
            Console.WriteLine(vbTab & "--------------------------------------------------------------" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "==============================")
            Console.WriteLine(vbTab & vbTab & vbTab & "|            LOGIN            |")
            Console.WriteLine(vbTab & vbTab & vbTab & "==============================" & vbNewLine)
            Console.Write(vbTab & vbTab & vbTab & "Usuario: ")
            usuarioInput = Console.ReadLine()
            Console.Write(vbTab & vbTab & vbTab & "Clave: ")
            claveInput = Console.ReadLine()
            Console.WriteLine(vbTab & "--------------------------------------------------------------" & vbNewLine)

            Dim objUsuario As New empleado()
            objUsuario.Usuario = usuarioInput
            objUsuario.Clave = claveInput

            If (objUsuario.Login) Then
                rol = objUsuario.TipoEmpleado
                Return True
            Else
                Console.WriteLine(vbTab & "Usuario no existe, intente nuevamente." & vbNewLine)
            End If
        End While

        Return False
    End Function

End Module
