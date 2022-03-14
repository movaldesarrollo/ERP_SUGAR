Imports System.Text
Imports System.Text.RegularExpressions

Module NIF_CIF



    Public Function GetDcNif(ByVal nif As String) As Char

        '*******************************************************************
        ' Nombre:     GetDcNif
        '             por Enrique Martínez Montejo
        '
        ' Finalidad:  Devuelve la letra correspondiente al NIF o al NIE
        '             (Número de Identificación de Extranjero)
        '
        ' Entradas:
        '     NIF:    String. La cadena del NIF cuya letra final se desea
        '             obtener.
        '
        ' Resultados:
        '     String: La letra del NIF/NIE.
        '
        '*******************************************************************

        ' Pasamos el NIF a mayúscula a la vez que eliminamos los
        ' espacios en blanco al comienzo y al final de la cadena.
        '
        nif = nif.Trim().ToUpper()

        ' El NIF está formado de uno a nueve números seguido de una letra.
        '
        ' El NIF de otros colectivos de personas físicas, está
        ' formato por una letra (K, L, M), seguido de 7 números
        ' y de una letra final.
        '
        ' El NIE está formado de una letra inicial (X, Y, Z),
        ' seguido de 7 números y de una letra final.
        ' 
        ' En el patrón de la expresión regular, defino cuatro grupos en el
        ' siguiente orden:
        '
        ' 1º) 1 a 8 dígitos.
        ' 2º) 1 a 8 dígitos + 1 letra.
        ' 3º) 1 letra + 1 a 7 dígitos.
        ' 4º) 1 letra + 1 a 7 dígitos + 1 letra.
        '
        Try
            Dim re As New Regex( _
                  "(^\d{1,8}$)|(^\d{1,8}[A-Z]$)|(^[K-MX-Z]\d{1,7}$)|(^[K-MX-Z]\d{1,7}[A-Z]$)", _
                 RegexOptions.IgnoreCase)

            If (Not (re.IsMatch(nif))) Then Return Nothing

            ' Nos quedamos únicamente con los números del NIF, y
            ' los formateamos con ceros a la izquierda si su
            ' longitud es inferior a siete caracteres.
            '
            re = New Regex("(\d{1,8})")

            Dim numeros As String = re.Match(nif).Value.PadLeft(7, "0"c)

            ' Primer carácter del NIF.
            '
            Dim firstChar As Char = nif.Chars(0)

            ' Si procede, reemplazamos la letra del NIE por el peso que le corresponde.
            '
            If (firstChar = "X"c) Then
                numeros = "0" & numeros

            ElseIf (firstChar = "Y"c) Then
                numeros = "1" & numeros

            ElseIf (firstChar = "Z"c) Then
                numeros = "2" & numeros

            End If

            ' Tabla del NIF
            '
            '  0T  1R  2W  3A  4G  5M  6Y  7F  8P  9D
            ' 10X 11B 12N 13J 14Z 15S 16Q 17V 18H 19L
            ' 20C 21K 22E 23T
            '
            ' Procedo a calcular el NIF/NIE
            '
            Dim dni As Integer = CInt(numeros)

            ' La operación consiste en calcular el resto de dividir el DNI
            ' entre 23 (sin decimales). Dicho resto (que estará entre 0 y 22),
            ' se busca en la tabla y nos da la letra del NIF.
            '
            ' Obtenemos el resto de la división.
            '
            Dim r As Integer = dni Mod 23

            ' Obtenemos el dígito de control del NIF
            '
            Dim dc As Char = CChar("TRWAGMYFPDXBNJZSQVHLCKE".Substring(r, 1))

            Return dc

        Catch
            ' Cualquier excepción producida, devolverá el valor Nothing.
            '
            Return Nothing

        End Try

    End Function

    Public Function ValidateNif(ByRef nif As String) As Boolean

        '*******************************************************************
        ' Nombre:     ValidateNif
        '             por Enrique Martínez Montejo
        '
        ' Finalidad:  Validar el NIF/NIE pasado a la función.
        '
        ' Entradas:
        '     NIF:    String. El NIF/NIE que se desea verificar. El número
        '             será devuelto formateado y con el NIF/NIE correcto.
        ' Resultados:
        ' Boolean:    True/False
        '
        '*******************************************************************

        Dim nifTemp As String = nif.Trim().ToUpper()

        If (nifTemp.Length > 9 Or nifTemp.Length < 2) Then Return False

        ' Guardamos el dígito de control.
        Dim dcTemp As Char = nifTemp.Chars(nif.Length - 1)

        ' Compruebo si el dígito de control es un número.
        If (Char.IsDigit(dcTemp)) Then Return Nothing

        ' Nos quedamos con los caracteres, sin el dígito de control.
        nifTemp = nifTemp.Substring(0, nif.Length - 1)

        If (nifTemp.Length < 8) Then
            Dim paddingChar As String = New String("0"c, 8 - nifTemp.Length)
            nifTemp = nifTemp.Insert(nifTemp.Length, paddingChar)
        End If

        ' Obtengo el dígito de control correspondiente, utilizando
        ' para ello una llamada a la función GetDcCif.
        '
        Dim dc As Char = GetDcNif(nif)

        If (Not (dc = Nothing)) Then
            nif = nifTemp & dc
        End If

        Return (dc = dcTemp)

    End Function



    Public Function GetDcCif(ByVal nif As String) As Char

        '*******************************************************************
        ' Nombre:     GetDcCif
        '             por Enrique Martínez Montejo
        '
        ' Finalidad:  Obtener el Dígito de Control de un NIF correspondiente
        '             a personas jurídicas y otras entidades con o sin
        '             personalidad jurídica.
        '
        ' Entradas:
        '     nif:    String. El NIF cuyo dígito de control se desea obtener.
        '
        ' Resultados:
        '     String: La letra o el número correspondiente al NIF.
        '
        '*******************************************************************

        ' Pasamos el NIF a mayúscula a la vez que eliminamos todos los
        ' carácteres que no sean números o letras. Note que no incluyo
        ' la letra I, porque si bien no puede aparecer como carácter
        ' inicial de un NIF, sí puede ser un dígito de control válido,
        ' lo que no sucede con las letras O y T.
        '
        Dim re As New Regex("([^A-W0-9]|[OT]|[^\w])", RegexOptions.IgnoreCase)

        nif = re.Replace(nif, String.Empty).ToUpper()

        ' Para calcular el CIF, se debe de haber pasado un máximo
        ' de nueve caracteres a la función: una letra válida (que
        ' necesariamente deberá de estar comprendida en el intervalo
        ' ABCDEFGHJKLMNPQRSUVW), siete números, y el dígito de control,
        ' que puede ser un número o una letra, dependiendo de la entidad
        ' a la que pertenezca el NIF.
        '
        ' En el patrón de la expresión regular, defino dos grupos en el
        ' siguiente orden:
        ' 1º) 1 letra + 7 u 8 dígitos.
        ' 2º) 1 letra + 7 dígitos + 1 letra.
        '
        ' Note que en el siguiente patrón, no incluyo la letra I como
        ' carácter de inicio válido del NIF.
        '
        re = New Regex("(^[A-HJ-W]\d{7,8}$)|(^[A-HJ-W]\d{7}[A-Z]$)")

        If (Not (re.IsMatch(nif))) Then Return Nothing

        Try
            ' Guardo el último carácter pasado, siempre que
            ' el NIF disponga de nueve caracteres.
            '
            Dim lastChar As Char = Nothing
            If (nif.Length = 9) Then lastChar = nif.Chars(8)

            Dim sumaPar, sumaImpar As Int32

            ' A continuación, la cadena debe tener 7 dígitos.
            '
            Dim digits As String = nif.Substring(1, 7)

            For n As Int32 = 0 To digits.Length - 1 Step 2

                If (n < 6) Then
                    ' Sumo las cifras pares del número que se corresponderá
                    ' con los caracteres 1, 3 y 5 de la variable «digits».
                    '
                    sumaImpar += CInt(CStr(digits.Chars(n + 1)))
                End If

                ' Multiplico por dos cada cifra impar (caracteres 0, 2, 4 y 6).
                '
                Dim dobleImpar As Int32 = 2 * CInt(CStr(digits.Chars(n)))

                ' Acumulo la suma del doble de números impares.
                '
                sumaPar += (dobleImpar Mod 10) + (dobleImpar \ 10)

            Next

            ' Sumo las cifras pares e impares.
            '
            Dim sumaTotal As Int32 = sumaPar + sumaImpar

            ' Me quedo con la cifra de las unidades y se la resto a 10, siempre
            ' y cuando la cifra de las unidades sea distinta de cero.
            '
            sumaTotal = (10 - (sumaTotal Mod 10)) Mod 10

            Dim characters() As Char = _
                        {"J"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c}

            Dim dc As Char = characters(sumaTotal)

            ' Devuelvo el Dígito de Control dependiendo del primer carácter
            ' del NIF pasado a la función.
            '
            Dim firstChar As Char = nif.Chars(0)

            Select Case firstChar
                Case "N"c, "P"c, "Q"c, "R"c, "S"c, "W"c, "K"c, "L"c, "M"c
                    ' NIF de entidades cuyo dígito de control se corresponde
                    ' con una letra. Se incluyen las letras K, L y M porque
                    ' el cálculo del dígito de control es el mismo que para
                    ' el CIF.
                    '
                    ' Al estar los índices de los arrays en base cero, el primer
                    ' elemento del array se corresponderá con la unidad del número
                    ' 10, es decir, el número cero.
                    '
                    Return characters(sumaTotal)

                Case "C"c
                    If ((lastChar = CStr(sumaTotal)) OrElse (lastChar = dc)) Then
                        ' Devuelvo el dígito de control pasado, que
                        ' puede ser un número o una letra.
                        Return lastChar

                    Else
                        ' Devuelvo la letra correspondiente al cálculo
                        ' del dígito de control del NIF.
                        Return dc

                    End If

                Case Else
                    ' NIF de las restantes entidades, cuyo dígito de control es un número.
                    '
                    Return CChar(CStr(sumaTotal))

            End Select

        Catch
            ' Cualquier excepción producida, devolverá Nothing.
            '
            Return Nothing

        End Try

    End Function

    Public Function ValidateCif(ByRef nif As String) As Boolean

        '*******************************************************************
        ' Nombre:     ValidateCif
        '             por Enrique Martínez Montejo
        '
        ' Finalidad:  Validar el NIF pasado a la función.
        '
        ' Entradas:
        '     nif:    String. El NIF que se desea verificar. El número
        '             será devuelto formateado con el NIF correcto.
        ' Resultados:
        '     Boolean: True/False
        '
        '*******************************************************************

        Dim nifTemp As String = nif.Trim().ToUpper()

        If (nifTemp.Length < 9) Then Return False

        ' Guardamos el noveno carácter.
        Dim dcTemp As Char = nifTemp.Chars(8)

        ' Nos quedamos con los primeros ocho caracteres.
        '
        nifTemp = nifTemp.Substring(0, 8)

        ' Obtengo el dígito de control correspondiente, utilizando
        ' para ello una llamada a la función GetDcCif
        '
        Dim dc As Char = GetDcCif(nif)

        If (Not (dc = Nothing)) Then
            nif = nifTemp & dc
        End If

        Return (dc = dcTemp)

    End Function


    'Private Function CalculaNIF(ByVal strA As String) As String
    '    '----------------------------------------------------------------------
    '    ' Calcular la letra del NIF
    '    ' Código original adaptado a Visual Basic                   (13/Sep/95)
    '    ' Adaptado a Visual Basic .NET (VB 9.0/2008)                (09/May/08)
    '    ' y convertido en función que devuelve el NIF correcto
    '    '----------------------------------------------------------------------
    '    Const cCADENA As String = "TRWAGMYFPDXBNJZSQVHLCKE"
    '    Const cNUMEROS As String = "0123456789"
    '    Dim a, b, c, NIF As Integer
    '    Dim sb As New StringBuilder

    '    strA = Trim(strA)
    '    If Len(strA) = 0 Then Return ""

    '    ' Dejar sólo los números
    '    For i As Integer = 0 To strA.Length - 1
    '        If cNUMEROS.IndexOf(strA(i)) > -1 Then
    '            sb.Append(strA(i))
    '        End If
    '    Next

    '    strA = sb.ToString
    '    a = 0
    '    NIF = CInt(Val(strA))
    '    Do
    '        b = CInt(Int(NIF / 24))
    '        c = NIF - (24 * b)
    '        a = a + c
    '        NIF = b
    '    Loop While b <> 0
    '    b = CInt(Int(a / 23))
    '    c = a - (23 * b)

    '    Return strA & Mid(cCADENA, CInt(c + 1), 1)
    'End Function

    '''' Comprueba si es un NIF válido
    '''' No usar espacios ni separadores para la letra
    '''' Devuelve True si es correcto
    '''' </summary>
    '''' <remarks>
    '''' Adaptado de un código de SGF
    '''' http://www.elguille.info/colabora/vb/sgf_Verificar_NIF_CIF.htm
    '''' </remarks>
    'Public Function Verificar_NIF(ByVal valor As String) As Boolean
    '    Dim aux As String

    '    valor = valor.ToUpper ' ponemos la letra en mayúscula
    '    aux = valor.Substring(0, valor.Length - 1) ' quitamos la letra del NIF

    '    If aux.Length >= 7 AndAlso IsNumeric(aux) Then
    '        aux = CalculaNIF(aux) ' calculamos la letra del NIF para comparar con la que tenemos
    '    Else
    '        Return False
    '    End If

    '    If valor <> aux Then ' comparamos las letras
    '        Return False
    '    End If

    '    Return True
    'End Function

    '''' Comprueba si es un CIF
    '''' Devuelve True si es un CIF
    '''' </summary>
    '''' <remarks>
    '''' Adaptado de un código de SGF
    '''' http://www.elguille.info/colabora/vb/sgf_Verificar_NIF_CIF.htm
    '''' </remarks>
    'Public Function Verificar_CIF(ByVal valor As String) As Boolean
    '    Dim strLetra As String, strNumero As String, strDigit As String
    '    Dim strDigitAux As String
    '    Dim auxNum As Integer
    '    Dim i As Integer
    '    Dim suma As Integer
    '    Dim letras As String

    '    letras = "ABCDEFGHKLMPQSX"

    '    valor = UCase(valor)

    '    If Len(valor) < 9 OrElse Not IsNumeric(Mid(valor, 2, 7)) Then
    '        Return False
    '    End If

    '    strLetra = Mid(valor, 1, 1)     ' letra del CIF
    '    strNumero = Mid(valor, 2, 7)    ' Codigo de Control
    '    strDigit = Mid(valor, 9)        ' CIF menos primera y ultima posiciones

    '    If InStr(letras, strLetra) = 0 Then ' comprobamos la letra del CIF (1ª posicion)
    '        Return False
    '    End If

    '    For i = 1 To 7
    '        If i Mod 2 = 0 Then
    '            suma = suma + CInt(Mid(strNumero, i, 1))
    '        Else
    '            auxNum = CInt(Mid(strNumero, i, 1)) * 2
    '            suma = suma + (auxNum \ 10) + (auxNum Mod 10)
    '        End If
    '    Next

    '    suma = (10 - (suma Mod 10)) Mod 10

    '    Select Case strLetra
    '        Case "K", "P", "Q", "S"
    '            suma = suma + 64
    '            strDigitAux = Chr(suma)
    '        Case "X"
    '            strDigitAux = Mid(CalculaNIF(strNumero), 8, 1)
    '        Case Else
    '            strDigitAux = CStr(suma)
    '    End Select

    '    If strDigit = strDigitAux Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function



End Module