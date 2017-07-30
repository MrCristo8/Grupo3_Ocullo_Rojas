/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   CODIGOCLIENTE        int                  not null,
   NOMBRECLIENTE        varchar(45)          not null,
   APELLIDOCLIENTE      varchar(45)          not null,
   CORREOCLIENTE        varchar(50)          not null,
   TELEFONOCLIENTE      varchar(10)          not null,
   constraint PK_CLIENTE primary key (CODIGOCLIENTE)
)