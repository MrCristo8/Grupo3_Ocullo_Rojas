/*==============================================================*/
/* Table: PRODUCTO                                              */
/*==============================================================*/
create table PRODUCTO (
   CODIGOPRODUCTO       int                  not null,
   NOMBREPRODUCTO       varchar(45)          not null,
   FOTOPRODUCTO         image                null,
   PRECIOPRODUCTO       float                not null,
   constraint PK_PRODUCTO primary key (CODIGOPRODUCTO)
)