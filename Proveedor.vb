Public Class Proveedor
    Private Sub Proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        menuprin.Enabled = False
        menuprin.Visible = False

        consulta = New ADODB.Recordset
        consulta = conexion.Execute("select clvprov from proveedor order by clvprov")

        While Not consulta.EOF
            CLVPROV.Items.Add(consulta.Fields(0).Value())
            consulta.MoveNext()
        End While

    End Sub

    Private Sub salir_Click(sender As Object, e As EventArgs) Handles salir.Click
        menuprin.Enabled = True
        menuprin.Visible = True
        Close()
    End Sub

    Private Sub consultar_Click(sender As Object, e As EventArgs) Handles consultar.Click
        consulta2 = New ADODB.Recordset
        consulta2 = conexion.Execute("select NOMDIST,NOMPROV,TEL,DIREC,EMAIL,CP,CIUDAD from PROVEEDOR where CLVPROV=" & CLVPROV.Text)

        If Not consulta2.EOF Then
            NOMDIST.Text = consulta2.Fields(0).Value
            NOMPROV.Text = consulta2.Fields(1).Value
            TEL.Text = consulta2.Fields(2).Value
            DIREC.Text = consulta2.Fields(3).Value
            EMAIL.Text = consulta2.Fields(4).Value
            CP.Text = consulta2.Fields(5).Value
            CIUDAD.Text = consulta2.Fields(6).Value

        Else
            MsgBox("LA CLAVE DEL PROVEEDOR NO EXISTE O ESTÁ DADA DE BAJA")
        End If
    End Sub

    Private Sub insertar_Click(sender As Object, e As EventArgs) Handles insertar.Click
        ban = New ADODB.Parameter
        Dim clave As Integer
        clave = 0
        comando = New ADODB.Command
        With comando
            .CommandText = "INSERTAPROV"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Append(.CreateParameter("0", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 50, NOMDIST.Text))
            .Parameters.Append(.CreateParameter("1", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 50, NOMPROV.Text))
            .Parameters.Append(.CreateParameter("3", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 12, TEL.Text))
            .Parameters.Append(.CreateParameter("2", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 50, DIREC.Text))
            .Parameters.Append(.CreateParameter("4", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 35, EMAIL.Text))
            .Parameters.Append(.CreateParameter("5", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamInput, , Val(CP.Text)))
            .Parameters.Append(.CreateParameter("6", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 40, CIUDAD.Text))
            .Parameters.Append(.CreateParameter("7", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamInput, , Val(CLVPROV.Text)))
            .Parameters.Append(.CreateParameter("8", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamOutput, , 0))
            .ActiveConnection = conexion
            .Execute()
            ban.Value = .Parameters(5).Value
        End With
        If ban.Value = 1 Then
            MsgBox("POR FAVOR INSERTA EL NOMBRE DEL PROVEEDOR")
        Else
            If ban.Value = 2 Then
                MsgBox("POR FAVOR INSERTA EL NOMBRE DEL DISTRIBUIDOR")
            Else
                If ban.Value = 3 Then
                    MsgBox("POR FAVOR INSERTA LA DIRECCION")
                Else
                    If ban.Value = 4 Then
                        MsgBox("POR FAVOR INSERTA EL CORREO ELECTRONICO")
                    Else
                        If ban.Value = 5 Then
                            MsgBox("POR FAVOR INSERTA LA CIUDAD DE UBICACION")
                        Else
                            consql = ("select max(clvprov)from proveedor")
                            consulta1 = New ADODB.Recordset
                            consulta1 = conexion.Execute(consql)

                            ' If Not consulta1.EOF Then
                            'clave = consulta1.Fields(0).Value
                        End If

                        MsgBox("INSERCIÓN CORRECTA")
                        NOMDIST.Text = ""
                                    NOMPROV.Text = ""
                                    TEL.Text = ""
                                    DIREC.Text = ""
                                    EMAIL.Text = ""
                                    CP.Text = ""
                                    CIUDAD.Text = ""
                        CLVPROV.Text = ""
                        'clave = 415 + 1

                        'End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub eliminar_Click(sender As Object, e As EventArgs) Handles eliminar.Click
        ban = New ADODB.Parameter
        comando = New ADODB.Command
        With comando
            .CommandText = "ELIMPROV"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Append(.CreateParameter("0", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamInput, , Val(CLVPROV.Text)))
            .Parameters.Append(.CreateParameter("1", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamOutput, , 0))
            .ActiveConnection = conexion
            .Execute()
            ban.Value = .Parameters(1).Value
        End With

        If ban.Value = 1 Then
            MsgBox("LA CLAVE DEL PROVEEDOR NO EXISTE")
        Else
            MsgBox("PROVEEDOR ELIMINADO CORRECTAMENTE")
            CLVPROV.Text = ""
            NOMDIST.Text = ""
            NOMPROV.Text = ""
            DIREC.Text = ""
            EMAIL.Text = ""
            TEL.Text = ""
            CP.Text = ""
            CIUDAD.Text = ""

        End If
    End Sub

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        ban = New ADODB.Parameter
        comando = New ADODB.Command
        With comando
            .CommandText = "MODIFICAPROV"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Append(.CreateParameter("0", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 50, NOMDIST.Text))
            .Parameters.Append(.CreateParameter("1", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 50, NOMPROV.Text))
            .Parameters.Append(.CreateParameter("3", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 12, TEL.Text))
            .Parameters.Append(.CreateParameter("2", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 50, DIREC.Text))
            .Parameters.Append(.CreateParameter("4", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 35, EMAIL.Text))
            .Parameters.Append(.CreateParameter("5", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamInput, , Val(CP.Text)))
            .Parameters.Append(.CreateParameter("6", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 40, CIUDAD.Text))
            .Parameters.Append(.CreateParameter("7", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamInput, , Val(CLVPROV.Text)))
            .Parameters.Append(.CreateParameter("8", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamOutput, , 0))
            .ActiveConnection = conexion
            .Execute()
            ban.Value = .Parameters(7).Value
        End With
        If ban.Value = 1 Then
            MsgBox("POR FAVOR INSERTA EL NOMBRE DEL PROVEEDOR")
        Else
            If ban.Value = 2 Then
                MsgBox("POR FAVOR INSERTA EL NOMBRE DEL DISTRIBUIDOR")
            Else
                If ban.Value = 3 Then
                    MsgBox("POR FAVOR INSERTA LA DIRECCION")
                Else
                    If ban.Value = 4 Then
                        MsgBox("POR FAVOR INSERTA EL CORREO ELECTRONICO")
                    Else
                        If ban.Value = 5 Then
                            MsgBox("POR FAVOR INSERTA LA CIUDAD DE UBICACION")
                        Else
                            If ban.Value = 6 Then
                                MsgBox("LA CLAVE DEL EMPLEADO NO TIENE QUE ESTAR VACIA")
                            Else
                                If ban.Value = 7 Then
                                    MsgBox("LA CLAVE DEL PROVEEDOR NO EXISTE")
                                Else
                                    MsgBox("MODIFICACION REALIZADA CORRECTAMENTE")
                                    NOMDIST.Text = ""
                                    NOMPROV.Text = ""
                                    TEL.Text = ""
                                    DIREC.Text = ""
                                    EMAIL.Text = ""
                                    CP.Text = ""
                                    CIUDAD.Text = ""
                                    CLVPROV.Text = ""

                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
End Class