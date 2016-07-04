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
            Console.WriteLine("" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "==========================================")
            Console.WriteLine(vbTab & vbTab & vbTab & "|      MANTENIMIENTO DE CATEGORIA        |")
            Console.WriteLine(vbTab & vbTab & vbTab & "==========================================" & vbNewLine)

            Dim objCategoria As New categoria()

            Do
                If (objCategoria.existeId()) Then
                    Console.WriteLine(vbTab & vbTab & vbTab & "Una categoría con dicho Id ya ha sido ingresada")
                End If

                Console.Write(vbTab & vbTab & vbTab & "Id: ")
                objCategoria.Id = Console.ReadLine()
            Loop While (objCategoria.existeId())

            

           

            Console.Write(vbTab & vbTab & vbTab & "Nombre : ")
            objCategoria.Nombre = Console.ReadLine()

            objCategoria.GuardarCategoria()

            Console.Write(vbTab & vbTab & vbTab & "Categoría guardada exitosamente" & vbNewLine & vbNewLine)

            Console.Write(vbTab & vbTab & vbTab & "¿Guardar otra categoría? [s/n]: ")
            continuar = Console.ReadLine()
        Loop
    End Sub

    Public Sub agregarProducto()
        Dim continuar As String = "s"

        Do While continuar = "s"
            Console.Clear()
            Console.WriteLine("" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "==========================================")
            Console.WriteLine(vbTab & vbTab & vbTab & "|      MANTENIMIENTO DE CATEGORIA        |")
            Console.WriteLine(vbTab & vbTab & vbTab & "==========================================" & vbNewLine)


            Dim objArticulo As New articulo()

            Console.Write(vbTab & vbTab & vbTab & "Id: ")
            objArticulo.Id = Console.ReadLine()

            Console.Write(vbTab & vbTab & vbTab & "Nombre : ")
            objArticulo.Nombre = Console.ReadLine()

            Console.Write(vbTab & vbTab & vbTab & "Marca : ")
            objArticulo.Marca = Console.ReadLine()

            Console.Write(vbTab & vbTab & vbTab & "Modelo : ")
            objArticulo.Modelo = Console.ReadLine()

            Console.Write(vbTab & vbTab & vbTab & "Precio : ")
            objArticulo.Precio = Console.ReadLine()

            Console.Write(vbTab & vbTab & vbTab & "Stock : ")
            objArticulo.Stock = Console.ReadLine()

            Console.Write(vbTab & vbTab & vbTab & "Aplica IVA [s/n] : ")
            Dim input As String = Console.ReadLine()
            objArticulo.AplicaIva = IIf(input = "s", True, False)

            Console.Write(vbTab & vbTab & vbTab & "Descripción : ")
            objArticulo.Descripcion = Console.ReadLine()

            Console.Write(vbTab & vbTab & vbTab & "Categoría : ")
            objArticulo.Categoria.Id = Console.ReadLine()

            objArticulo.GuardarArticulo()

            Console.Write(vbTab & vbTab & vbTab & "Artículo guardado exitosamente" & vbNewLine & vbNewLine)

            Console.Write(vbTab & vbTab & vbTab & "¿Guardar otro artículo? [s/n]: ")
            continuar = Console.ReadLine()
        Loop
    End Sub

    Public Sub agregarVendedor()
        Dim continuar As String = "s"

        Do While continuar = "s"
            Console.Clear()
            Console.WriteLine("" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "==========================================")
            Console.WriteLine(vbTab & vbTab & vbTab & "|      MANTENIMIENTO DE VENDEDORES       |")
            Console.WriteLine(vbTab & vbTab & vbTab & "==========================================" & vbNewLine)

            Dim empleadoNuevo As empleado = New empleado

            
            Console.Write(vbTab & vbTab & vbTab & "Ingrese Id: ")
            empleadoNuevo.Id = Console.ReadLine

            Console.Write(vbTab & vbTab & vbTab & "Ingrese Nombre: ")
            empleadoNuevo.Nombre = Console.ReadLine

            Console.Write(vbTab & vbTab & vbTab & "Ingrese Apellido: ")
            empleadoNuevo.Apellido = Console.ReadLine

            Console.Write(vbTab & vbTab & vbTab & "Ingrese Cédula: ")
            empleadoNuevo.Cedula = Console.ReadLine

            Console.Write(vbTab & vbTab & vbTab & "Ingrese Email: ")
            empleadoNuevo.Email = Console.ReadLine

            Console.Write(vbTab & vbTab & vbTab & "Ingrese nombre User: ")
            empleadoNuevo.Usuario = Console.ReadLine

            Console.Write(vbTab & vbTab & vbTab & "Ingrese Password: ")
            empleadoNuevo.Clave = Console.ReadLine

            empleadoNuevo.GuardarEmpleado()
            Console.Write("" & vbNewLine)
            Console.Write(vbTab & vbTab & vbTab & "Vendedor registrado exitosamente" & vbNewLine & vbNewLine)

            Console.Write(vbTab & vbTab & vbTab & "¿Registrar otro vendedor? [s/n]: ")
            continuar = Console.ReadLine()
        Loop





    End Sub

    Public Sub salir()
        Console.WriteLine("FUNCION POR DEFINIR")
    End Sub

    Public Sub mostrarMenuAdministrador()
        Dim opcion As String = String.Empty

        While True
            Console.Clear()
            Console.WriteLine("" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "==============================")
            Console.WriteLine(vbTab & vbTab & vbTab & "|          MENÚ ADMIN        |")
            Console.WriteLine(vbTab & vbTab & vbTab & "==============================" & vbNewLine)
            Console.WriteLine(vbTab & vbTab & vbTab & "1.- Agregar categoría" & vbNewLine)
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
                    Console.WriteLine("Opción no existe. Escriba bien.")
            End Select
        End While

    End Sub

    Public Sub Facturar()
        'Console.WriteLine("FUNCION POR DEFINIR")
        Dim provincia As New provincia()
        Dim continuar As String = "s"
        Dim factura As New factura()
        Dim detalleFatura As New detalleFactura()
        Do While continuar = "s"

            factura.ElegirArticuloAFacturar()

            Console.WriteLine(vbTab & vbTab & vbTab & "desea agregar mas productor S o facturar N")
            continuar = Console.ReadLine()

        Loop
        Console.Clear()
        Console.WriteLine(vbTab & vbTab & vbTab & "==========================================")
        Console.WriteLine(vbTab & vbTab & vbTab & "|              Facturar        |")
        Console.WriteLine(vbTab & vbTab & vbTab & "==========================================" & vbNewLine)
        Console.Write(vbTab & vbTab & vbTab & "Ingrese Id de la factura")
        factura.Id = Console.ReadLine()
        Console.Write(vbTab & vbTab & vbTab & "Ingrese numerode factura: ")

        factura.NumeroFactura = Console.ReadLine()
        Console.Write(vbTab & vbTab & vbTab & "INgrese Nombre del cliente: ")
        factura.NombreCliente = Console.ReadLine()
        Console.Write(vbTab & vbTab & vbTab & "INgrese ruc del cliente: ")
        factura.Ruc = Console.ReadLine()
        Console.Write(vbTab & vbTab & vbTab & "INgrese telefono del cliente: ")
        factura.Telefono = Console.ReadLine()
        Console.Write(vbTab & vbTab & vbTab & "INgrese provincia:")
        factura.provincia = Console.ReadLine()
        Console.Write(vbTab & vbTab & vbTab & "INgrese direccion del cliente: ")
        factura.Direccion = Console.ReadLine()
        Console.Write(vbTab & vbTab & vbTab & "Ingrese fecha de emosion: ")
        factura.FechaEmision = Console.ReadLine()

        factura.SubTotal = factura.cantidad * factura.detalleFatura.PrecioUnit

        If (factura.provincia = "Manabi" Or factura.provincia = "manabi" Or factura.provincia = "Esmeraldas" Or factura.provincia = "esmeraldas") Then
            factura.TotalIva = factura.SubTotal * 0.12
        Else
            factura.TotalIva = factura.SubTotal * 0.14
        End If

        factura.TotalPagar = factura.SubTotal + factura.TotalIva
        factura.GuardarFactura()


    End Sub

    Public Sub mostrarMenuVendedor()
        Dim opcion As String = String.Empty

        While True
            Console.Clear()
            Console.WriteLine("" & vbNewLine)
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
                    Console.WriteLine("Opción no existe. Escriba bien.")
            End Select
        End While

    End Sub

    Public Function login(ByRef rol As Byte) As Boolean

        Dim usuarioInput As String = String.Empty
        Dim claveInput As String = String.Empty
        Dim continua As String = "s"

        While True
            Console.Clear()
            Console.WriteLine("" & vbNewLine)
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
