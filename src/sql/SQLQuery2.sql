--PROCESOS ALMACENADOS PARA LA TABLA DE VENTAS
-------------------------------------------------------------------------------------------------------------------------------------------------
/*Proceso almacenado que se encarga de insertar datos en la tabla detalles productos-ventas
	-Actualiza la total de la venta
	-Actualiza las existencias de los productos
*/
SELECT * FROM VENTAS
SELECT * FROM VENPRODPRODPROV

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

--PROCESOS ALMACENADOS PARA LA TABLA DE COMPRAS
-----------------------------------------------------------------------------------------------------------------------------------------------
/*Procedimiento almacenado para obtener la pr�xima clave de compra a insertar*/
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

IF (SELECT COUNT(*) FROM PRODCOM WHERE CLVPROD = @CLVPROD) = 0
	SET @BAN = 1
ELSE
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

					UPDATE PRODUCTOS SET PRECIOVEN=((SELECT PRECIOCOM FROM PRODUCTOS 
					WHERE CLVPROD=@CLVPROD)+(SELECT GANAN FROM PRODUCTOS WHERE CLVPROD=@CLVPROD))*(1.16)
					WHERE CLVPROD=@CLVPROD

					UPDATE COMPRAS SET TOTALCOM=TOTALCOM+((SELECT CANTCOM FROM PRODCOM WHERE CLVPROD=@CLVPROD AND CLVCOM=@CLVCOM)
					*(SELECT PRECIOCOM FROM PRODUCTOS WHERE CLVPROD=@CLVPROD))
					WHERE CLVCOM=@CLVCOM
				COMMIT TRAN
			END
			ELSE
				--PRINT'ESE DETALLE YA SE INSERTO'
				SET @BAN=5
-------------------------------------------------------------------------------------------------------------------------------------------------
--PROCESOS DE LA TABLA PROVEEDOR
/*Proceso almacenado que devuelve la pr�xima clave del proveedor que se insetar�*/
CREATE PROC ULTIMACLVPROVEEDOR
@CLVPROV INT OUT

AS

IF (SELECT COUNT(*) FROM PROVEEDOR)=0
	SET @CLVPROV=400
ELSE
	SET @CLVPROV=(SELECT MAX(CLVPROV) FROM PROVEEDOR)+1

/*Proceso almacenado para realizar la inserci�n de un nuevo proveedor*/
SELECT * FROM PROVEEDOR
CREATE PROC INSERTAPROV
@NOMPROV VARCHAR (50),
@NOMDIST VARCHAR (50),
@TEL VARCHAR (12),
@DIREC VARCHAR (50),
@EMAIL VARCHAR (35),
@CP INT,
@CIUDAD VARCHAR (40),
@CLVPROV INT,
@BAN INT OUTPUT

AS

SET @BAN=0

IF @NOMPROV=''
	--PRINT 'POR FAVOR INSERTA EL NOMBRE DEL PROVEEDOR'
	SET @BAN=1
ELSE
		IF @NOMDIST=''
			--PRINT 'POR FAVOR INSERTA EL NOMBRE DEL DISTRIBUIDOR'
			SET @BAN=2
		ELSE
				IF @DIREC=''
					--PRINT 'POR FAVOR INSERTA LA DIRECCION'
					SET @BAN=3
				ELSE
						IF @EMAIL=''
							--PRINT 'POR FAVOR INSERTA EL CORREO ELECTRONICO'
							SET @BAN=4
						ELSE
							IF @CIUDAD=''
								--PRINT 'POR FAVOR INSERTA LA CIUDAD DE UBICACION'
								SET @BAN=5
							ELSE
								BEGIN
									BEGIN TRAN
										INSERT INTO PROVEEDOR VALUES (@NOMPROV, @NOMDIST, @TEL, @DIREC, @EMAIL, @CP, @CIUDAD, @CLVPROV)
									COMMIT TRAN
								END

/*Proceso que elimina a un proveedor por su clave*/
CREATE PROC ELIMINARPROV
@CLVPROV INT,
@BAN INT OUT

AS

SET @BAN = 0;

IF (SELECT COUNT(*) FROM PROVEEDOR WHERE CLVPROV = @CLVPROV) = 1
	BEGIN
		BEGIN TRAN
			DELETE FROM PROVEEDOR WHERE CLVPROV = @CLVPROV
		COMMIT TRAN
	END
ELSE
	SET @BAN = 1

-------------------------------------------------------------------------------------------------------------------------------------------------
--PROCESOS ALMACENADOS PARA LA TABLA PRODUCTOS
/*Proceso almacenado que regresa la pr�xima clave de producto a insertar*/
CREATE PROC ULTIMACLVPROD
@CLVPROD INT OUT

AS

IF (SELECT COUNT(*) FROM PRODUCTOS)=0
	SET @CLVPROD=200
ELSE
	SET @CLVPROD=(SELECT MAX(CLVPROD) FROM PRODUCTOS)+1

-------------------------------------------------------------------------------------------------------------------------------------------------
/*Proceso almacenado para insetar productos*/
SELECT * FROM PRODUCTOS
CREATE PROC INSERTAPRODUCTOS
@NOMPRODUCT VARCHAR(40),
@CLVPROD INT,
@BAN INT OUTPUT

AS

SET @BAN = 0

IF (@NOMPRODUCT='')
	--PRINT 'FAVOR DE PONER EL NOMBRE DEL PRODUCTO'
	SET @BAN=1
ELSE
	IF (SELECT COUNT(*) FROM PRODUCTOS WHERE NOMPRODUCT=@NOMPRODUCT)=0
	BEGIN 
			BEGIN TRAN
				INSERT INTO PRODUCTOS (CLVPROD, NOMPRODUCT) VALUES (@CLVPROD, @NOMPRODUCT)
			COMMIT TRAN
		END
	ELSE
		--PRINT 'YA ESXISTE UN PRODUCTO CON EL MISMO NOMBRE'
		SET @BAN=2

/*Proceso almacenado para eliminar un producto*/
CREATE PROC ELIMINARPROD
@CLVPROD INT,
@BAN INT OUT

AS

SET @BAN = 0

IF (SELECT COUNT(*) FROM PRODUCTOS WHERE CLVPROD = @CLVPROD) = 1
	BEGIN
		BEGIN TRAN
			DELETE PRODUCTOS WHERE CLVPROD = @CLVPROD
		COMMIT TRAN
	END
ELSE
	SET @BAN = 1

/*Procedimiento almacenado para actualizar informaci�n de los productos*/
SELECT * FROM PRODUCTOS
CREATE PROC ACTUALIZARPORD
@CLVPROD INT,
@NOMPRODUCT VARCHAR(40),
@PRECIOCOMP MONEY,
@GANAN MONEY,
@BAN INT OUT

AS

SET @BAN = 0

IF (SELECT COUNT(*) FROM PRODUCTOS WHERE CLVPROD = @CLVPROD) = 1
	IF @NOMPRODUCT <> ''
		IF @PRECIOCOMP > 0
			IF @GANAN > 0
				BEGIN
					BEGIN TRAN
						UPDATE PRODUCTOS
							SET NOMPRODUCT = @NOMPRODUCT,
							PRECIOCOM = @PRECIOCOMP,
							GANAN = @GANAN,
							PRECIOVEN = (@PRECIOCOMP + @GANAN) * 1.16
							WHERE CLVPROD = @CLVPROD
					COMMIT TRAN
				END
			ELSE
				--LA GANANCIA DEBE SER MAYOR A 0
				SET @BAN = 4
		ELSE
			--EL PRECIO DE COMPRA NO P�EDE SER 0 O MENOS
			SET @BAN = 3 
	ELSE
		--EL NOMBRE NO PUEDE QUEDAR VACIO
		SET @BAN = 2
ELSE
	--NO EXISTE UN PRODUCTO CON ESA CLAVE
	SET @BAN = 1

--Procedimiento almacenado que determina si existe una venta por su clave.
CREATE PROC EXISTEVENTA
@CVEVEN INT,
@BAN INT OUTPUT

AS

SET @BAN = (SELECT COUNT(*) FROM VENTAS WHERE CVEVEN = @CVEVEN)

--Proceso almacenado que permite consultar clave, nombre, cantidad venida y total de los productos de una determinada venta
CREATE PROCEDURE PRODUCTOSVEND
@CVEVEN INT
AS
SELECT PRODUCTOS.CLVPROD, PRODUCTOS.NOMPRODUCT, VENPROD.CANTIDADVEN, (PRODUCTOS.PRECIOVEN * VENPROD.CANTIDADVEN) AS TOTAL
FROM PRODUCTOS INNER JOIN VENPROD ON VENPROD.CLVPROD = PRODUCTOS.CLVPROD
WHERE VENPROD.CVEVEN = @CVEVEN

--Procseso almacenado que recupera el subtotal, el iva y la fecha en la que se reali� la venta.
CREATE PROCEDURE INFOVENTA
@SUBTOTAL MONEY OUTPUT,
@IVA MONEY OUTPUT,
@FECHAVEN DATE OUTPUT,
@CVEVEN INT

AS

SET @SUBTOTAL = (SELECT SUBTOTAL FROM VENTAS WHERE CVEVEN = @CVEVEN)
SET @IVA = (SELECT IVA FROM VENTAS WHERE CVEVEN = @CVEVEN)
SET @FECHAVEN = (SELECT FECHAVEN FROM VENTAS WHERE CVEVEN = @CVEVEN)

--Proceso almacenado para 
CREATE PROCEDURE PRODUCTOSCOMP
@CLVCOM INT
AS
SELECT PRODUCTOS.CLVPROD, PRODUCTOS.NOMPRODUCT, PRODCOM.CANTCOM, (PRODUCTOS.PRECIOVEN * PRODCOM.CANTCOM) AS TOTAL
FROM PRODUCTOS INNER JOIN PRODCOM ON PRODCOM.CLVPROD = PRODUCTOS.CLVPROD
WHERE PRODCOM.CLVCOM = @CLVCOM

CREATE ALTER PROC INFOCOMPRA
@CLAVE INT,
@FECHACOM DATE OUT,
@TOTALCOM MONEY OUT

AS

SET @FECHACOM = (SELECT FECHACOM FROM COMPRAS WHERE CLVCOM = @CLAVE)
SET @TOTALCOM = (SELECT TOTALCOM FROM COMPRAS WHERE CLVCOM = @CLAVE)

CREATE PROC EXISTECOMPRA
@CLVCOM INT,
@BAN INT OUT

AS

SET @BAN = (SELECT COUNT(*) FROM COMPRAS WHERE CLVCOM = @CLVCOM)