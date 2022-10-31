Use Pruebasv1


CREATE TABLE [dbo].[CatalogoEmpresas](
   [Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
   [Codigo] [varchar](30) NOT NULL,
   [Nombre] [varchar](30) NOT NULL,
   [Telefono] [int] NOT NULL,
   [Direccion] [varchar](30),
   [Correo] [varchar](25),
)


CREATE PROCEDURE SelectAllEmpresas
AS
SELECT * FROM CatalogoEmpresas
GO


CREATE PROCEDURE SelectEmpresaID  
	@Id int
AS
	SELECT * FROM CatalogoEmpresas WHERE Id = @Id
GO


CREATE PROCEDURE CreateEmpresa  
	@Codigo varchar(30),
	@Nombre varchar(30),
	@Telefono int,
	@Direccion varchar(30),
	@Correo varchar(25)
AS
	INSERT INTO CatalogoEmpresas (Codigo, Nombre, Telefono, Direccion, Correo) VALUES (@Codigo, @Nombre, @Telefono, @Direccion, @Correo);
GO


CREATE PROCEDURE UpdateEmpresa  
	@Id int,
	@Codigo varchar(30),
	@Nombre varchar(30),
	@Telefono int,
	@Direccion varchar(30),
	@Correo varchar(25)
AS

	IF @Id > 0 
	BEGIN 
		UPDATE CatalogoEmpresas SET Codigo=@Codigo, Nombre=@Nombre, Telefono=@Telefono, Direccion=@Direccion, Correo=@Correo WHERE Id=@Id;
	END
GO


CREATE PROCEDURE DeleteEmpresa  
	@Id int
AS
	
	IF @Id > 0
	BEGIN 
		DELETE FROM CatalogoEmpresas WHERE Id = @Id;
	END
GO
