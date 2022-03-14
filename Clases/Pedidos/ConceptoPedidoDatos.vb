﻿Public Class DatosConceptoPedido


    Private idConcepto As Long
    Private numPedido As Integer
    Private numProduccion As Integer
    Private numAlbaran As Integer
    Private codArticuloCli As String = ""
    Private ArticuloCli As String = ""
    Private RefCliente As String = ""
    Private idArticulo As Integer
    Private Cantidad As Double
    Private PVPUnitario As Double
    Private idTipoIVA As Integer
    Private Descuento As Double
    Private PrecioNetoUnitario As Double
    Private Orden As Integer
    Private idEstado As Integer
    Private idArtCli As Long = 0
    Private idConceptoOferta As Long
    Private idConceptoProforma As Long
    Private CantidadServida As Double
    Private CantidadPreparada As Double
    Private Version As Integer

    'Campo calculado
    Private subTotal As Double

    'Datos de otras tablas
    Private codArticulo As String = ""
    Private Articulo As String = ""
    Private idTipoArticulo As Integer = 0
    Private TipoArticulo As String = ""
    Private idSubTipoArticulo As Integer = 0
    Private subTipoArticulo As String = ""
    Private idUnidad As Integer = 0
    Private TipoUnidad As String = "u."
    Private TipoIVA As Double = 0
    Private TipoRecargoEq As Double = 0
    Private Estado As String = ""
    Private EstadoProduccion As String = ""
    Private numOferta As Integer = 0
    Private numProforma As Integer = 0
    Private CantidadStock As Double = 0
    'Private idEscandallo As Integer = 0
    'Private idArticuloBase As Integer = 0
    Private domesticos2 As Integer = 0


    Public Property gidConcepto() As Integer
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Integer)
            idConcepto = value
        End Set
    End Property



    Public Property gnumPedido() As Integer
        Get
            Return numPedido
        End Get
        Set(ByVal value As Integer)
            numPedido = value
        End Set
    End Property

    Public Property gnumProduccion() As Integer
        Get
            Return numProduccion
        End Get
        Set(ByVal value As Integer)
            numProduccion = value
        End Set
    End Property

    Public Property gnumAlbaran() As Integer
        Get
            Return numAlbaran
        End Get
        Set(ByVal value As Integer)
            numAlbaran = value
        End Set
    End Property

    Public Property gcodArticuloCli() As String
        Get
            Return codArticuloCli
        End Get
        Set(ByVal value As String)
            codArticuloCli = value
        End Set
    End Property

    Public Property gArticuloCli() As String
        Get
            Return ArticuloCli
        End Get
        Set(ByVal value As String)
            ArticuloCli = value
        End Set
    End Property

    Public Property gRefCliente() As String
        Get
            Return RefCliente
        End Get
        Set(ByVal value As String)
            RefCliente = value
        End Set
    End Property

    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property

    Public Property gCantidad() As Double
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Double)
            Cantidad = value
        End Set
    End Property

    Public Property gPVPUnitario() As Double
        Get
            Return PVPUnitario
        End Get
        Set(ByVal value As Double)
            PVPUnitario = value
        End Set
    End Property

    Public Property gidTipoIVA() As Integer
        Get
            Return idTipoIVA
        End Get
        Set(ByVal value As Integer)
            idTipoIVA = value
        End Set
    End Property

    Public Property gDescuento() As Double
        Get
            Return Descuento
        End Get
        Set(ByVal value As Double)
            Descuento = value
        End Set
    End Property

    Public Property gPrecioNetoUnitario() As Double
        Get
            Return PrecioNetoUnitario
        End Get
        Set(ByVal value As Double)
            PrecioNetoUnitario = value
        End Set
    End Property

    Public Property gOrden() As Integer
        Get
            Return Orden
        End Get
        Set(ByVal value As Integer)
            Orden = value
        End Set
    End Property

    Public Property gidEstado() As Integer
        Get
            Return idEstado
        End Get
        Set(ByVal value As Integer)
            idEstado = value
        End Set
    End Property

    Public Property gidArtCli() As Long
        Get
            Return idArtCli
        End Get
        Set(ByVal value As Long)
            idArtCli = value
        End Set
    End Property


    Public Property gidConceptoOferta() As Long
        Get
            Return idConceptoOferta
        End Get
        Set(ByVal value As Long)
            idConceptoOferta = value
        End Set
    End Property

    Public Property gidConceptoProforma() As Long
        Get
            Return idConceptoProforma
        End Get
        Set(ByVal value As Long)
            idConceptoProforma = value
        End Set
    End Property

    Public Property gCantidadServida() As Double
        Get
            Return CantidadServida
        End Get
        Set(ByVal value As Double)
            CantidadServida = value
        End Set
    End Property

    Public Property gCantidadPreparada() As Double
        Get
            Return CantidadPreparada
        End Get
        Set(ByVal value As Double)
            CantidadPreparada = value
        End Set
    End Property

    Public Property gVersion() As Integer
        Get
            Return Version
        End Get
        Set(ByVal value As Integer)
            Version = value
        End Set
    End Property

    'Calculado
    Public Property gSubTotal() As Double
        Get
            If PrecioNetoUnitario = 0 Then
                Return Cantidad * (PVPUnitario * (1 - Descuento / 100))
            Else
                Return Cantidad * PrecioNetoUnitario
            End If
        End Get
        Set(ByVal value As Double)

        End Set
    End Property

    'Otras tablas

    Public Property gcodArticulo() As String
        Get
            Return codArticulo
        End Get
        Set(ByVal value As String)
            codArticulo = value
        End Set
    End Property

    Public Property gArticulo() As String
        Get
            Return Articulo
        End Get
        Set(ByVal value As String)
            Articulo = value
        End Set
    End Property

    Public Property gidTipoArticulo() As Integer
        Get
            Return idTipoArticulo
        End Get
        Set(ByVal value As Integer)
            idTipoArticulo = value
        End Set
    End Property

    Public Property gTipoArticulo() As String
        Get
            Return TipoArticulo
        End Get
        Set(ByVal value As String)
            TipoArticulo = value
        End Set
    End Property

    Public Property gidSubTipoArticulo() As Integer
        Get
            Return idSubTipoArticulo
        End Get
        Set(ByVal value As Integer)
            idSubTipoArticulo = value
        End Set
    End Property

    Public Property gSubTipoArticulo() As String
        Get
            Return subTipoArticulo
        End Get
        Set(ByVal value As String)
            subTipoArticulo = value
        End Set
    End Property

    Public Property gidUnidad() As Integer
        Get
            Return idUnidad
        End Get
        Set(ByVal value As Integer)
            idUnidad = value
        End Set
    End Property

    Public Property gTipoUnidad() As String
        Get
            Return TipoUnidad
        End Get
        Set(ByVal value As String)
            TipoUnidad = value
        End Set
    End Property

    Public Property gTipoIVA() As Double
        Get
            Return TipoIVA
        End Get
        Set(ByVal value As Double)
            TipoIVA = value
        End Set
    End Property

    Public Property gTipoRecargoEq() As Double
        Get
            Return TipoRecargoEq
        End Get
        Set(ByVal value As Double)
            TipoRecargoEq = value
        End Set
    End Property

    Public Property gEstado() As String
        Get
            Return UCase(Estado)
        End Get
        Set(ByVal value As String)
            Estado = UCase(value)
        End Set
    End Property

    Public Property gEstadoProduccion() As String
        Get
            Return UCase(EstadoProduccion)
        End Get
        Set(ByVal value As String)
            EstadoProduccion = UCase(value)
        End Set
    End Property

    Public Property gnumOferta() As Integer
        Get
            Return numOferta
        End Get
        Set(ByVal value As Integer)
            numOferta = value
        End Set
    End Property

    Public Property gnumProforma() As Integer
        Get
            Return numProforma
        End Get
        Set(ByVal value As Integer)
            numProforma = value
        End Set
    End Property

    Public Property gCantidadStock() As Double
        Get
            Return CantidadStock
        End Get
        Set(ByVal value As Double)
            CantidadStock = value
        End Set
    End Property

    Public Property gDomesticos2 As Integer
        Get
            Return domesticos2
        End Get
        Set(value As Integer)
            domesticos2 = value
        End Set
    End Property

    'Public Property gidEscandallo() As Integer
    '    Get
    '        Return idEscandallo
    '    End Get
    '    Set(ByVal value As Integer)
    '        idEscandallo = value
    '    End Set
    'End Property

    'Public Property gidArticuloBase() As Integer
    '    Get
    '        Return idArticuloBase
    '    End Get
    '    Set(ByVal value As Integer)
    '        idArticuloBase = value
    '    End Set
    'End Property

End Class
