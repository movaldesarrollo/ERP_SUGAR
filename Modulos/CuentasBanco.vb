Module CuentasBanco

    Public Function GetDCCuentaBancaria(ByVal numeroCuenta As String) As String

        '*******************************************************************
        ' Nombre: GetDCCuentaBancaria
        ' por Enrique Martínez Montejo - 29/07/2006
        '
        ' Versión: 1.0
        '
        ' Finalidad: Obtiene el dígito de control de un número de
        '            cuenta bancaria.
        ' Entradas:
        '  numeroCuenta: String. El número de cuenta cuyo dígito de 
        '                control se desea obtener
        ' Resultados:
        ' String:    El dígito de control de la cuenta bancaria.
        '*******************************************************************

        ' Primero compruebo que la longitud del parámetro
        ' sea de 18 caracteres, y que éstos sean números.
        '
        If (numeroCuenta.Length <> 18) Then
            Return Nothing
        Else
            Dim ch As Char
            For Each ch In numeroCuenta
                If (Not Char.IsNumber(ch)) Then Return Nothing
            Next
        End If

        Dim cociente1, cociente2, resto1, resto2 As Integer
        Dim sucursal, cuenta, dc1, dc2 As String
        Dim suma1, suma2, n As Integer

        ' Matriz que contiene los pesos utilizados en el
        ' algoritmo de cálculo de los dos dígitos de control.
        '
        Dim pesos() As Integer = {6, 3, 7, 9, 10, 5, 8, 4, 2, 1}

        sucursal = numeroCuenta.Substring(0, 8)
        cuenta = numeroCuenta.Substring(8, 10)

        ' Obtengo el primer dígito de control que verificará
        ' los códigos de Entidad y Oficina.
        '
        For n = 7 To 0 Step -1
            suma1 = suma1 + Convert.ToInt32(sucursal.Substring(n, 1)) * pesos(7 - n)
        Next

        ' Calculamos el cociente de dividir el resultado
        ' de la suma entre 11.
        '
        cociente1 = suma1 \ 11 ' Nos da un resultado entero.

        ' Calculo el resto de la división. Para ello,
        ' en lugar de utilizar el operador Mod, utilizo
        ' la fórmula para obtener el resto de la división.
        '
        resto1 = suma1 - (11 * cociente1)

        dc1 = (11 - resto1).ToString

        Select Case dc1
            Case "11"
                dc1 = "0"
            Case "10"
                dc1 = "1"
        End Select

        ' Ahora obtengo el segundo dígíto, que verificará
        ' el número de cuenta de cliente.
        '
        For n = 9 To 0 Step -1
            suma2 = suma2 + Convert.ToInt32(cuenta.Substring(n, 1)) * pesos(9 - n)
        Next

        ' Calculamos el cociente de dividir el resultado
        ' de la suma entre 11.
        '
        cociente2 = suma2 \ 11 ' Nos da un resultado entero

        ' Calculo el resto de la división. Para ello,
        ' en lugar de utilizar el operador Mod, utilizo
        ' la fórmula para obtener el resto de la división.
        '
        resto2 = suma2 - (11 * cociente2)

        dc2 = (11 - resto2).ToString

        Select Case dc2
            Case "11"
                dc2 = "0"
            Case "10"
                dc2 = "1"
        End Select

        ' Devuelvo el dígito de control.
        '
        Return dc1 & dc2

    End Function


    Public Function ValidateCuentaBancaria(ByVal numeroCuenta As String) As Boolean

        '*******************************************************************
        ' Nombre: ValidateCuentaBancaria
        ' por Enrique Martínez Montejo - 29/07/2006
        '
        ' Versión: 1.0
        '
        ' Finalidad: Validar el dígito de control de un número de
        '            cuenta bancaria.
        ' Entradas:
        '     numeroCuenta: String. El número de cuenta cuyo dígito de 
        '                   control se desea obtener
        ' Resultados:
        '     Boolean:    True/False.
        '*******************************************************************

        ' Primero compruebo que la longitud del parámetro
        ' sea de 20 caracteres.
        '
        If (numeroCuenta.Length <> 20) Then Return False

        ' Extraigo el dígito de control.
        '
        Dim dc As String = numeroCuenta.Substring(8, 2)

        ' Del número de cuenta, elimino el dígito de control.
        '
        numeroCuenta = numeroCuenta.Remove(8, 2)

        ' Obtengo el dígito de control verdadero.
        '
        Dim dcTemp As String = GetDCCuentaBancaria(numeroCuenta)

        ' Devuelvo el resultado.
        '
        If dc = dcTemp Then Return True

    End Function

    Public Function IBANCalculo(ByVal Pais As String, ByVal Cuenta As String) As String
        ' Recibe el pais con 2 letras (ES para España)
        ' Recibe el número de cuenta

        Dim Letras As String '* 26
        Dim IBAN As String
        Dim Dividendo As Integer
        Dim Resto As Integer

        ' Quita los posibles espacios
        Cuenta = Replace(Cuenta, " ", "")

        ' Calcula el valor de las letras, las quita y añade el valor al final
        Letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        IBAN = Cuenta & CStr(InStr(1, Letras, Left(Pais, 1)) + 9) & CStr(InStr(1, Letras, Right(Pais, 1)) + 9) & "00"

        For Contador = 1 To Len(IBAN)
            Dividendo = Resto & Mid(IBAN, Contador, 1)
            Resto = Dividendo Mod 97
        Next Contador

        IBANCalculo = "IBAN" & Pais & Format((98 - Resto), "00") & Cuenta

    End Function

    Public Function IBANValidacion(ByVal IBAN) As Boolean
        ' Recibe el IBAN
        Try


            If Len(IBAN) < 10 Then Return False
            Dim Letras As String '* 26
            Dim Dividendo As Integer
            Dim Resto As Integer

            Letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

            ' Quita la palabra IBAN
            IBAN = Replace(IBAN, "IBAN", "")

            ' Quita los posibles espacios
            IBAN = Replace(IBAN, " ", "")

            ' Calcula el valor de las letras, las quita y añade el valor al final
            IBAN = Mid(IBAN, 3, Len(IBAN) - 2) & CStr(InStr(1, Letras, Left(IBAN, 1)) + 9) & CStr(InStr(1, Letras, Mid(IBAN, 2, 1)) + 9)

            ' Quita los digitos de control y los pone al final
            IBAN = Mid(IBAN, 3, Len(IBAN) - 2) & Left(IBAN, 2)

            For Contador = 1 To Len(IBAN)
                Dividendo = Resto & Mid(IBAN, Contador, 1)
                Resto = Dividendo Mod 97
            Next Contador

            If Resto = 1 Then
                IBANValidacion = True
            Else
                IBANValidacion = False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
