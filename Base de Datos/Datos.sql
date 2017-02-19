/**LICENCIA Y FERIADOS CAMBIE DATE --> DATETIME**/


/*Se crea la Entidad*/
/*Categoria=A,B,C = Cantidad de empleados para la promocion */
INSERT INTO [Prempty].[dbo].[Entidades]
           ([RazonSocial],[Cuit],[Domicilio],[Telefono],[Categoria],[FechaAlta],[FechaBaja])
     VALUES
           ('R-r Forjados','30-70967474-5','Arieta','4460-9000','A','01/01/2015',null)


/*** ROLES ***/
INSERT INTO [Prempty].[dbo].[Roles]([Rol])VALUES ('Empleado')
INSERT INTO [Prempty].[dbo].[Roles]([Rol])VALUES ('Administrador')
INSERT INTO [Prempty].[dbo].[Roles]([Rol])VALUES ('Gerente')

/***AREAS***/
INSERT INTO [Prempty].[dbo].[Areas]([Descripcion],[IdEntidad])VALUES('Ventas',1)
INSERT INTO [Prempty].[dbo].[Areas]([Descripcion],[IdEntidad])VALUES('Produccion',1)
INSERT INTO [Prempty].[dbo].[Areas]([Descripcion],[IdEntidad])VALUES('Administracion',1)


/****ADMINISTRADOR*****/

SELECT * FROM USUARIOS;


/**EMPLEADOS VENTAS PARA ENTIDAD 1 de METALURGICA***/
INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100001,'Ariel','Cazon','14/01/1989','01/01/2015',1,'12345','Av. Mayo','ARIELCA',1,'ariel.cazon@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100002,'Juan','Perez','14/02/1989','01/01/2015',1,'12345','Donovan','JUANPE',1,'juan.perez@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100003,'Susana','Molina','14/01/1990','01/01/2015',1,'12345','Av. Mayo','SUSANAMO',1,'susana.molina@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100004,'Marcelo','Camero','01/02/1990','01/01/2015',1,'12345','Av. Mayo','MARCELOC',1,'marcelo.camero@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100005,'Jose','Herrera','01/03/1990','01/01/2015',1,'12345','Arieta','JOSEHE',1,'jose.herrera@gmail.com')

/**EMPLEADOS PRODUCCION PARA ENTIDAD 1 de METALURGICA***/

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100006,'Agustin','Ponce','10/04/1990','01/01/2015',2,'12345','Av. Mayo','AGUSPO',1,'agustin.ponce@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100007,'Alejo','Ledesma','10/04/1987','01/01/2015',2,'12345','Arieta','ALEJOLE',1,'alejo.ledesma@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100008,'Bruno','Vega','10/04/1991','01/01/2015',2,'12345','Leandro Alem','BRUNOVE',1,'bruno.vega@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100009,'Daniel','Soria','01/05/1989','01/01/2015',2,'12345','Donovan','DANIELSO',1,'daniel.soria@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100010,'Mateo','Gonzales','12/05/1990','01/01/2015',2,'12345','Donovan','MATEOGO',1,'mateo.gonzales@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100011,'Juan','Tapia','12/04/1990','01/01/2015',2,'12345','Arieta','JUANTA',1,'juan.tapia@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100012,'Lucas','Garcia','12/03/1992','01/01/2015',2,'12345','Arieta','LUCASGA',1,'lucas.garcia@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100013,'Mario','Bonar','12/05/1992','01/01/2015',2,'12345','Arieta','MARIOBO',1,'mario.bonar@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100014,'Jose','Paz','12/04/1990','01/01/2015',2,'12345','Arieta','JOSEPAZ',1,'jose.paz@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100015,'Setastian','Villar','19/05/1992','01/01/2015',2,'12345','Arieta','SEBASVI',1,'sebastian.villar@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100016,'Rodrigo','Fernandez','19/06/1989','01/01/2015',2,'12345','Arieta','RODRIFE',1,'rodrigo.fernandez@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100017,'Diego','Diaz','16/05/1989','01/01/2015',2,'12345','Arieta','DIEGODI',1,'diego.diaz@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100018,'Matias','Acosta','23/05/1993','01/01/2015',2,'12345','Arieta','MATIASAC',1,'matias.acosta@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100019,'Andres','Alvarez','30/05/1993','01/01/2015',2,'12345','Arieta','ANDRESAL',1,'andres.alvarez@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100020,'Belen','Lopez','02/05/1987','01/01/2015',2,'12345','Arieta','BELENLO',1,'belen.lopez@gmail.com')




/**EMPLEADOS ADMONISTRACION PARA ENTIDAD 1 de METALURGICA***/

SELECT * FROM USUARIOS;

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100021,'Florencia','Sosa','07/07/1987','01/01/2015',3,'12345','9 de Julio','FLORESO',1,'florencia.sosa@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100022,'Maria','Torres','21/07/1989','01/01/2015',3,'12345','Arieta','MARIATO',1,'florencia.sosa@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100023,'Barbara','Velez','22/07/1987','01/01/2015',3,'12345','Arieta','BARBARAVE',1,'barbara.velez@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100024,'Juan','Romero','11/07/1991','01/01/2015',3,'12345','Ramos','JUANRO',1,'barbara.velez@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100025,'Luz','Garcia','13/07/1991','01/01/2015',3,'12345','9 de Julio','LUZGA',1,'luz.garcia@gmail.com')

INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (1,100026,'Luciano','Diaz','20/07/1991','01/01/2015',3,'12345','Moreno','LUCIANODI',1,'luciano.diaz@gmail.com')


INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (2,100027,'Rodrigo','Yucra','16/01/1989','01/01/2015',3,'12345','Av. Mayo','RODRIYU',1,'rodrigo.yucra@gmail.com')

/****GERENTE*****/
INSERT INTO [Prempty].[dbo].[Usuarios]
           ([IdRol],[Legajo],[Nombre],[Apellido],[FechaNac],[FechaIngreso],[IdArea],[Password],[Domicilio],[NombreUsuario],[IdEntidad],[Email])
     VALUES
           (3,100028,'Celeste','Coopa','06/04/1986','01/01/2015',3,'12345','Donovan','CELESCO',1,'celeste.coopa@gmail.com')




/***********************************  INGRESOS 2015 ***************************************/
/**ARIEL CAZON***/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'05/01/2015','09:00:00','18:00:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'06/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'07/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'08/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'09/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'12/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'13/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'14/01/2015','09:00:00','18:01:00')
/*DIA 15 FALTO POR CUMPLE**/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'16/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'19/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'20/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'21/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'22/01/2015','09:00:00','18:01:00')
/***  dia 23 falta de estudio  ***/

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'26/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'27/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'28/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'29/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'30/01/2015','09:00:00','18:01:00')

/****JUAN****/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'05/01/2015','09:00:00','18:00:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'06/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'07/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'08/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'09/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'12/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'13/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'14/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'15/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'16/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'19/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'20/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'21/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'22/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'23/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'26/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'27/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'28/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'29/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'30/01/2015','09:00:00','18:01:00')


/****SUSANA****/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'05/01/2015','09:00:00','18:00:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'06/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'07/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'08/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'09/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'12/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'13/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'14/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'16/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'19/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'20/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'21/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'22/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'23/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'26/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'27/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'28/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'29/01/2015','09:00:00','18:01:00')

/**Marcelo 100004*/

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'05/01/2015','09:00:00','18:00:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'06/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'07/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'08/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'09/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'12/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'13/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'14/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'15/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'16/01/2015','09:00:00','18:01:00')

/*Jose 100005 */
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'05/01/2015','09:00:00','18:00:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'06/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'07/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'08/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'09/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'12/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'13/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'14/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'16/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'19/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'20/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'21/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'22/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'23/01/2015','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'26/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'27/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'28/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'29/01/2015','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'30/01/2015','09:00:00','18:01:00')



/*****************************  INGESOS 2016 **********************************/
SELECT * FROM INGRESOS;

/**ARIEL CAZON***/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'04/01/2016','09:00:00','18:00:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'05/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'06/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'07/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'08/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'11/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'12/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'13/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'14/01/2016','09:00:00','18:01:00')
/*DIA DE FALTA POR CUMPLE Y DP 2 SEMANAS DE VACAS*/


/*juan */
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'04/01/2016','09:00:00','18:00:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'05/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'06/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'07/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'08/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'11/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'12/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'13/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'14/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'15/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'18/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'19/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'20/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'21/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'22/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'25/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'26/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'27/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'28/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'29/01/2016','09:00:00','18:01:00')

/*susana*/

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'18/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'19/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'20/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'21/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'22/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'25/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'26/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'27/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'28/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'29/01/2016','09:00:00','18:01:00')

/*MARCELO*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'04/01/2016','09:00:00','18:00:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'05/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'06/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'07/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'08/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'11/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'12/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'13/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'14/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'15/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'18/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'19/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'20/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'21/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'22/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'25/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'26/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'27/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'28/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'29/01/2016','09:00:00','18:01:00')

/*jose*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'04/01/2016','09:00:00','18:00:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'05/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'06/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'07/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'08/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'11/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'12/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'13/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'14/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'15/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'18/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'19/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'20/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'21/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'22/01/2016','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'25/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'26/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'27/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'28/01/2016','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'29/01/2016','09:00:00','18:01:00')


/***********************  INGRESOS 2017 ***************************/
/*ARIEL 2017**/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'03/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'04/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'05/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'06/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'09/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'10/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'11/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'12/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'13/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'16/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'17/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'18/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'19/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'20/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'23/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'24/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'25/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'26/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'27/01/2017','09:00:00','18:01:00')


INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'30/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'31/01/2017','09:00:00','18:01:00')


/*FEBRERO ARIEL 2017*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'01/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'02/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'03/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'06/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'07/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'08/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'09/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'10/02/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'13/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'14/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'15/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'16/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'17/02/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'20/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'21/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'22/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'23/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (1,'24/02/2017','09:00:00','18:01:00')


/**JUAN ENERO 2O17*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'16/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'17/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'18/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'19/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'20/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'23/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'24/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'25/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'26/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'27/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'30/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'31/01/2017','09:00:00','18:01:00')

SELECT * FROM USUARIOS;

/*FEBRERO JUAN 2017*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'01/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'02/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'03/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'06/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'07/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'08/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'09/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'10/02/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'13/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'14/02/2017','09:00:00','18:01:00')
/**FALTO POR CUMPLE*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'16/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'17/02/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'20/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'21/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'22/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'23/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (2,'24/02/2017','09:00:00','18:01:00')



/**SUSANA ENERO 2O17*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'02/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'03/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'04/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'05/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'06/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'23/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'24/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'25/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'26/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'27/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'30/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'31/01/2017','09:00:00','18:01:00')

/**Susana FEBRERO 2017*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'01/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'02/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'03/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'06/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'07/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'08/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'09/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'10/02/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'13/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'14/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'15/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'16/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'17/02/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'20/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'21/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'22/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'23/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (3,'24/02/2017','09:00:00','18:01:00')


/**MARCELO*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'02/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'03/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'04/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'05/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'06/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'09/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'10/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'11/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'12/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'13/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'16/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'17/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'18/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'19/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'20/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'23/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'24/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'25/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'26/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'27/01/2017','09:00:00','18:01:00')


INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'30/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'31/01/2017','09:00:00','18:01:00')

/*FEBRERO 2017*/
SELECT * FROM INGRESOS WHERE IdUsuario = 4;
SELECT * FROM USUARIOS WHERE IdUsuario = 4;

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'01/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'02/02/2017','09:00:00','18:01:00')
/*FALTO EL 3 POR CUMPLE */

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'20/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'21/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'22/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'23/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (4,'24/02/2017','09:00:00','18:01:00')


/*JOSE*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'02/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'03/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'04/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'05/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'06/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'09/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'10/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'11/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'12/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'13/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'16/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'17/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'18/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'19/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'20/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'23/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'24/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'25/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'26/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'27/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'30/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'31/01/2017','09:00:00','18:01:00')

/**JOSE FEBRERO 2017*/
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'01/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'02/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'03/01/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'06/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'07/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'08/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'09/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'10/02/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'13/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'14/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'15/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'16/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'17/02/2017','09:00:00','18:01:00')

INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'20/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'21/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'22/01/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'23/02/2017','09:00:00','18:01:00')
INSERT INTO [Prempty].[dbo].[Ingresos]([IdUsuario],[FechaActual],[HoraIngreso],[HoraEgreso])
     VALUES (5,'24/02/2017','09:00:00','18:01:00')


/***************************************************/
/******MOTIVO LICENCIA******/
select * from MotivoLicencia;
INSERT INTO MotivoLicencia([Descripcion],[IdEntidad])
     VALUES ('Enfermedad',1)
INSERT INTO MotivoLicencia([Descripcion],[IdEntidad])
     VALUES ('Estudio',1)
INSERT INTO MotivoLicencia([Descripcion],[IdEntidad])
     VALUES ('Vacaciones',1)
INSERT INTO MotivoLicencia([Descripcion],[IdEntidad])
     VALUES ('Mudanza',1)


/******LICENCIA DE LOS DIAS QUE FALTOS********/
/*0=pendiente, 1=aprobado, 2=rechazado */
select * from Licencias;

/************************** 2015 *******************************/
/*Jose dia de enfermedad*/

INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'23/01/2015',1,'Dia por Enfermedad',1)
/*Susana Mudanza*/
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'30/01/2015',4,'Dia por Mudanza',1)

/*usuario 4*/
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'19/01/2015',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'20/01/2015',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'21/01/2015',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'22/01/2015',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'23/01/2015',3,'Vacaciones por ley',1)

INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'26/01/2015',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'27/01/2015',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'28/01/2015',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'29/01/2015',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'30/01/2015',3,'Vacaciones por ley',1)


/*VACACIONES DE JUAN 2016*/
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'18/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'19/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'20/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'21/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'22/01/2016',3,'Vacaciones por ley',1)

INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'25/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'26/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'27/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'28/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (1,'29/01/2016',3,'Vacaciones por ley',1)


/*susana vacaciones 2016*/
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'04/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'05/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'06/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'07/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'08/01/2016',3,'Vacaciones por ley',1)

INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'11/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'12/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'13/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'14/01/2016',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'15/01/2016',3,'Vacaciones por ley',1)


/**JUAN ENERO 2017 VACAS**/

INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'02/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'03/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'04/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'05/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'06/01/2017',3,'Vacaciones por ley',1)

INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'09/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'10/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'11/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'12/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (2,'13/01/2017',3,'Vacaciones por ley',1)

/*SUSANA VACACIONES 2017*/
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'09/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'10/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'11/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'12/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'13/01/2017',3,'Vacaciones por ley',1)

INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'16/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'17/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'18/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'19/01/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (3,'20/01/2017',3,'Vacaciones por ley',1)


/*MARCELO VACACIONES FEBRERO 2017*/

INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'06/02/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'07/02/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'08/02/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'09/02/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'10/02/2017',3,'Vacaciones por ley',1)

INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'13/02/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'14/02/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'15/02/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'16/02/2017',3,'Vacaciones por ley',1)
INSERT INTO [Prempty].[dbo].[Licencias]
           ([IdUsuario],[Fecha],[Motivo],[Descripcion],[Estado])
     VALUES (4,'17/02/2017',3,'Vacaciones por ley',1)






/*** FERIADOS 2017***/
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170101','Año Nuevo');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170227','Carnaval 1');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170228','Carnaval 2');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170324','Día Nacional de la Memoria por la Verdad y la Justicia.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170402','Día del Veterano y de los Caídos en la Guerra de Malvinas.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170413','Jueves Santo.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170414','Viernes Santo.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170501','Dia del trabajador');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170525','Revolucion de Mayo');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170617','Inmortalidad del General Martín Miguel de Güemes.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170620','Inmortalidad del General Manuel Belgrano.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170709','Dia de la independencia.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20170821','Inmortalidad del General José de San Martín');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20171016','Día del Respeto a la Diversidad Cultural.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20171120','Día de la Soberanía Nacional.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20171208','Inmaculada Concepción de María.');
INSERT INTO [Prempty].[dbo].[Feriados]([Fecha] ,[Descripcion])
     VALUES ('20171225','Navidad.');

