/*==============================================================*/
/* Table: DIRECCION                                             */
/*==============================================================*/
create table DIRECCION (
   CODIGODIRECCION      int                  not null,
   SECTORDIRECCION      varchar(30)          not null,
   BARRIODIRECCION      varchar(30)          not null,
   CALLEPRINCIPAL       varchar(45)          not null,
   CALLESECUNDARIA      varchar(45)          not null,
   constraint PK_DIRECCION primary key (CODIGODIRECCION)
)