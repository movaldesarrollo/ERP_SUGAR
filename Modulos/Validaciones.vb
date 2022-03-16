Module Validaciones
    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function





    Function SoloNumerosConDecimales(ByVal Keyascii As Short) As Short
        If InStr("1234567890,.", Chr(Keyascii)) = 0 Then
            SoloNumerosConDecimales = 0
        Else
            SoloNumerosConDecimales = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosConDecimales = Keyascii
            Case 13
                SoloNumerosConDecimales = Keyascii
        End Select
    End Function

    Function SoloNumerosConDecimales(ByVal Keyascii As Short, ByVal cadena As String) As Short

        If InStr("1234567890,.", Chr(Keyascii)) = 0 Then
            SoloNumerosConDecimales = 0
        Else
            If InStr(cadena, ",") > 0 And Keyascii = CShort(Asc(",")) Then
                SoloNumerosConDecimales = 0
            Else
                SoloNumerosConDecimales = Keyascii
            End If
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosConDecimales = Keyascii
            Case 13
                SoloNumerosConDecimales = Keyascii
        End Select
    End Function

   


    Function SoloNumerosConGuiones(ByVal Keyascii As Short) As Short
        If InStr("1234567890-", Chr(Keyascii)) = 0 Then
            SoloNumerosConGuiones = 0
        Else
            SoloNumerosConGuiones = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosConGuiones = Keyascii
            Case 13
                SoloNumerosConGuiones = Keyascii
        End Select
    End Function

    Function SoloNumerosConMayMen(ByVal Keyascii As Short) As Short
        If InStr("1234567890<>", Chr(Keyascii)) = 0 Then
            SoloNumerosConMayMen = 0
        Else
            SoloNumerosConMayMen = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosConMayMen = Keyascii
            Case 13
                SoloNumerosConMayMen = Keyascii
        End Select
    End Function

    Function SoloNumerosConEspacios(ByVal Keyascii As Short) As Short
        If InStr("1234567890 ", Chr(Keyascii)) = 0 Then
            SoloNumerosConEspacios = 0
        Else
            SoloNumerosConEspacios = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosConEspacios = Keyascii
            Case 13
                SoloNumerosConEspacios = Keyascii
        End Select
    End Function



    Function SoloNumerosTelefono(ByVal Keyascii As Short) As Short
        If InStr("1234567890+ ", Chr(Keyascii)) = 0 Then
            SoloNumerosTelefono = 0
        Else
            SoloNumerosTelefono = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosTelefono = Keyascii
            Case 13
                SoloNumerosTelefono = Keyascii
        End Select
    End Function



End Module
