/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2017                    */
/* Created on:     09/06/2024 19:42:28                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURAS') and o.name = 'FK_FACTURAS_RELATIONS_CLIENTES')
alter table FACTURAS
   drop constraint FK_FACTURAS_RELATIONS_CLIENTES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURAS_DETALLES') and o.name = 'FK_FACTURAS_REFERENCE_FACTURAS')
alter table FACTURAS_DETALLES
   drop constraint FK_FACTURAS_REFERENCE_FACTURAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURAS_DETALLES') and o.name = 'FK_FACTURAS_REFERENCE_PRODUCTO')
alter table FACTURAS_DETALLES
   drop constraint FK_FACTURAS_REFERENCE_PRODUCTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTES')
            and   type = 'U')
   drop table CLIENTES
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FACTURAS')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index FACTURAS.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FACTURAS')
            and   type = 'U')
   drop table FACTURAS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FACTURAS_DETALLES')
            and   type = 'U')
   drop table FACTURAS_DETALLES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTOS')
            and   type = 'U')
   drop table PRODUCTOS
go

/*==============================================================*/
/* Table: CLIENTES                                              */
/*==============================================================*/
create table CLIENTES (
   IDENTIFICACION       char(10)             not null,
   NOMBRES              char(50)             null,
   CORREO               char(100)            null,
   TELEFONO             char(10)             null,
   constraint PK_CLIENTES primary key (IDENTIFICACION)
)
go

/*==============================================================*/
/* Table: FACTURAS                                              */
/*==============================================================*/
create table FACTURAS (
   COD_FACTURA          int                  not null,
   IDENTIFICACION       char(10)             null,
   COD_CLIENTE          char(10)             null,
   ESTABLECIMIENTO      char(3)              null,
   SUCURSAL             char(3)              null,
   FECHA_EMISION        datetime             null,
   NUMERO_AUTORIZACION  bigint               null,
   NOMBRE_CLIENTE       char(50)             null,
   CORREO_CLIENTE       char(100)            null,
   DESCUENTO            decimal(19,4)        null,
   IVA                  int                  null,
   constraint PK_FACTURAS primary key (COD_FACTURA)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/




create nonclustered index RELATIONSHIP_2_FK on FACTURAS (IDENTIFICACION ASC)
go

/*==============================================================*/
/* Table: FACTURAS_DETALLES                                     */
/*==============================================================*/
create table FACTURAS_DETALLES (
   COD_FACTURA          int                  not null,
   CODIGO_PRODUCTO      int                  not null,
   PRECIO_UNITARIO      decimal(19,4)        null,
   CANTIDAD             int                  null,
   constraint PK_FACTURAS_DETALLES primary key (COD_FACTURA, CODIGO_PRODUCTO)
)
go

/*==============================================================*/
/* Table: PRODUCTOS                                             */
/*==============================================================*/
create table PRODUCTOS (
   CODIGO               int                  not null,
   PRODUCTO             char(30)             null,
   PRECIO_UNITARIO      decimal(14,4)        null,
   constraint PK_PRODUCTOS primary key (CODIGO)
)
go

alter table FACTURAS
   add constraint FK_FACTURAS_RELATIONS_CLIENTES foreign key (IDENTIFICACION)
      references CLIENTES (IDENTIFICACION)
go

alter table FACTURAS_DETALLES
   add constraint FK_FACTURAS_REFERENCE_FACTURAS foreign key (COD_FACTURA)
      references FACTURAS (COD_FACTURA)
go

alter table FACTURAS_DETALLES
   add constraint FK_FACTURAS_REFERENCE_PRODUCTO foreign key (CODIGO_PRODUCTO)
      references PRODUCTOS (CODIGO)
go

