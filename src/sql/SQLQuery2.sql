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
/*Procedimiento almacenado para obtener la pr�xima clave de venta a insertar*/
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
-----------------------------------------------------------------------------------------------------------------------------------------------
/*Procedimiento almacenado que se encarga de hacer registros en la tabla compras*/
SELECT * FROM PROVEEDOR
EXEC INTERTACOMPRA 403,0
CREATE PROC INTERTACOMPRA
@PROV INT,
@BAN INT OUTPUT

AS

DECLARE @CLVCOM INT

IF (SELECT COUNT(*) FROM COMPRAS)=0
	SET @CLVCOM=300
ELSE
	SET @CLVCOM=(SELECT MAX(CLVCOM) FROM COMPRAS)+1

IF (SELECT COUNT(*) FROM PROVEEDOR WHERE CLVPROV=@PROV)=0
	--PRINT 'EL PROVEEDOR NO EXISTE'
	SET @BAN=1
ELSE
	BEGIN
		BEGIN TRAN
			INSERT INTO COMPRAS(CLVCOM)VALUES(@CLVCOM)
			INSERT INTO PROVCOM(CLVCOM, CLVPROV)VALUES(@CLVCOM, @PROV)
		COMMIT TRAN
			--PRINT 'INSERCI�N EXITOSA'
			SET @BAN=2
	END
-----------------------------------------------------------------------------------------------------------------------------------------------
/*Procedimiento almacenado para verificar que un producto sea vendido por un determiando proveedor*/

SELECT PRODUCTOS.CLVPROD, PROVEEDOR.CLVPROV
FROM PRODUCTOS INNER JOIN (PRODCOM INNER JOIN (COMPRAS INNER JOIN(PROVCOM INNER JOIN PROVEEDOR ON PROVEEDOR.CLVPROV = PROVCOM.CLVPROV)
ON PROVCOM.CLVCOM = COMPRAS.CLVCOM) ON COMPRAS.CLVCOM = PRODCOM.CLVCOM) ON PRODCOM.CLVPROD = PRODUCTOS.CLVPROD

CREATE PROC PRODPROV
@CLVPROD INT,
@CLVPROV INT,
@BAN INT OUT

AS

SET @BAN = (SELECT COUNT(*)
			FROM PRODUCTOS INNER JOIN (PRODCOM INNER JOIN (COMPRAS INNER JOIN(PROVCOM INNER JOIN PROVEEDOR ON PROVEEDOR.CLVPROV = PROVCOM.CLVPROV)
			ON PROVCOM.CLVCOM = COMPRAS.CLVCOM) ON COMPRAS.CLVCOM = PRODCOM.CLVCOM) ON PRODCOM.CLVPROD = PRODUCTOS.CLVPROD
			WHERE PRODUCTOS.CLVPROD = @CLVPROD AND PROVEEDOR.CLVPROV = @CLVPROV)

-----------------------------------------------------------------------------------------------------------------------------------------------
/*Procedimiento almacenado que se encarga de insertar registros en la tabla detalle producto-compra*/
CREATE PROC INTERTAPRODCOM
@CLVCOM INT,
@CLVPROD INT,
@CANTCOM INT,
@PRECIOCOM MONEY, 
@GANAN INT,
@BAN INT OUTPUT

AS

IF (SELECT COUNT(*) FROM COMPRAS WHERE CLVCOM=@CLVCOM)=0
	--PRINT 'ESA CLAVE DE COMPRA NO SE ENCUENTRA INSERTADA'
	SET @BAN=1
ELSE
	IF (SELECT COUNT(*) FROM PRODUCTOS WHERE CLVPROD=@CLVPROD)=0
		--PRINT 'ESA CLAVE DE PRODUCTO NO SE ENCUENTRA INSERTADA'
		SET @BAN=2
	ELSE
		IF @CANTCOM<=0
			--PRINT 'LA CANTIDAD COMPRADA NO PUEDE SER IGUAL O MENOR A CERO'
			SET @BAN=3

	ELSE
		IF (@GANAN <= 1)
			--PRINT 'LA CANTIDAD DE GANANCIA DEBE SER IGUAL O MAYOR QUE 1' 
			SET @BAN=4
		ELSE
			IF (SELECT COUNT (*) FROM PRODCOM WHERE CLVPROD=@CLVPROD AND CLVCOM=@CLVCOM)=0
			BEGIN
				BEGIN TRAN
					INSERT INTO PRODCOM VALUES(@CLVPROD, @CLVCOM, @CANTCOM)

					UPDATE PRODUCTOS SET EXIST=EXIST+(SELECT CANTCOM FROM PRODCOM
					WHERE CLVPROD=@CLVPROD AND CLVCOM=@CLVCOM), PRECIOCOM=@PRECIOCOM, GANAN=@GANAN
					WHERE CLVPROD=@CLVPROD

					UPDATE PRODUCTOS SET PRECIOVEN=(SELECT PRECIOCOM FROM PRODUCTOS 
					WHERE CLVPROD=@CLVPROD)+(SELECT GANAN FROM PRODUCTOS WHERE CLVPROD=@CLVPROD)*(1.16)
					WHERE CLVPROD=@CLVPROD

					UPDATE COMPRAS SET TOTALCOM=TOTALCOM+((SELECT CANTCOM FROM PRODCOM WHERE CLVPROD=@CLVPROD AND CLVCOM=@CLVCOM)
					*(SELECT PRECIOCOM FROM PRODUCTOS WHERE CLVPROD=@CLVPROD))
					WHERE CLVCOM=@CLVCOM
				COMMIT TRAN
			END
			ELSE
				--PRINT'ESE DETALLE YA SE INSERTO'
				SET @BAN=5

delete PROVCOM where CLVCOM > 315
delete COMPRAS where CLVCOM > 315
delete PRODCOM where CLVCOM > 315
select * from COMPRAS
select * from PRODCOM
select * from PROVCOM