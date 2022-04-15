-------------------------------------------------------------------------------------------------------------------------------------------------
/*Proceso almacenado que se encarga de insertar datos en la tabla detalles productos-ventas
	-Actualiza la total de la venta
	-Actualiza las existencias de los productos
*/
SELECT * FROM VENTAS
SELECT * FROM VENPROD

CREATE PROC INSERTAVENPROD
@CVEVEN INT,
@CLVPROD INT,
@CANTVEN INT,
@BAN INT OUTPUT

AS

IF (SELECT COUNT (*) FROM VENTAS WHERE CVEVEN=@CVEVEN)=1
	IF(SELECT COUNT(*) FROM PRODUCTOS WHERE CLVPROD=@CLVPROD)=1
		IF @CANTVEN>0
			IF (SELECT EXIST FROM PRODUCTOS WHERE CLVPROD=@CLVPROD)>@CANTVEN
				IF (SELECT COUNT(*) FROM VENPROD WHERE CLVPROD=@CLVPROD AND CVEVEN=@CVEVEN)=1
					--PRINT 'ESE DETALLE YA SE HABIA INSERTADO'
					SET @BAN=1
				ELSE
				BEGIN
					BEGIN TRAN
						INSERT INTO VENPROD VALUES(@CANTVEN,@CVEVEN,@CLVPROD)
						UPDATE PRODUCTOS SET EXIST=EXIST-(SELECT CANTIDADVEN FROM VENPROD WHERE CLVPROD=@CLVPROD AND CVEVEN=@CVEVEN)
						WHERE CLVPROD=@CLVPROD

						UPDATE VENTAS SET SUBTOTAL=SUBTOTAL+(((SELECT PRECIOVEN FROM PRODUCTOS WHERE CLVPROD=@CLVPROD)
						*(SELECT CANTIDADVEN FROM VENPROD WHERE CVEVEN=@CVEVEN AND CLVPROD=@CLVPROD))*(.84)),
						IVA=IVA+(((SELECT PRECIOVEN FROM PRODUCTOS WHERE CLVPROD=@CLVPROD)
						*(SELECT CANTIDADVEN FROM VENPROD WHERE CVEVEN=@CVEVEN AND CLVPROD=@CLVPROD))*(.16))
						WHERE CVEVEN=@CVEVEN
					COMMIT TRAN
				END
			ELSE
				--PRINT 'NO EXISTEN TANTOS PRODUCTOS EN EXISTENCIA'
				SET @BAN=2
		ELSE
			--PRINT 'NO SE PUEDE VENDER LA CANTIDAD DE 0'
			SET @BAN=3
	ELSE
		--PRINT 'ESA CLAVE DE PRODUCTO NO ESTA REGISTRADO'
		SET @BAN=4
ELSE
	--PRINT 'ESA CLAVE DE VENTA NO ESTA REGISTRADA'
	SET @BAN=5
-------------------------------------------------------------------------------------------------------------------------------------------------
/*Porceso almacenado que se encarga de hacer inserciones en la tabla ventas*/
CREATE PROC INSERTAVENTAS

@CVEVEN INT OUT

AS

IF(SELECT COUNT(*) FROM VENTAS)=0
	SET @CVEVEN=101
ELSE
	SET @CVEVEN=(SELECT MAX(CVEVEN) AS CLAVE FROM VENTAS)+1
				BEGIN
					BEGIN TRAN
						INSERT INTO VENTAS (CVEVEN) VALUES (@CVEVEN)
						PRINT 'VENTA INSERTADA'
					COMMIT TRAN
				END
-----------------------------------------------------------------------------------------------------------------------------------------------
/*Procedimiento almacenado para obtener la próxima clave de venta a insertar*/
SELECT * FROM PROVEEDOR
CREATE PROC ULTIMACLVCOMPRA
@CLVCOM INT OUT

AS

IF (SELECT COUNT(*) FROM COMPRAS)=0
	SET @CLVCOM=300
ELSE
	SET @CLVCOM=(SELECT MAX(CLVCOM) FROM COMPRAS)+1
-----------------------------------------------------------------------------------------------------------------------------------------------
/*Procedimiento almacenado que retorna el nombre del provedor*/
CREATE PROC NOMBREPROV
@CLVPROV INT,
@NOMDIST VARCHAR(50) OUT

AS

IF (SELECT COUNT(*) FROM PROVEEDOR WHERE CLVPROV = @CLVPROV)= 1
	SET @NOMDIST = (SELECT NOMDIST FROM PROVEEDOR WHERE CLVPROV = @CLVPROV)
ELSE
	SET @NOMDIST = NULL