/*==============================================================*/
/* Table: STOCK                                                 */
/*==============================================================*/
create table STOCK (
   CODIGOARTESANO       int                  not null,
   CODIGOPRODUCTO       int                  not null,
   CANTIDADPRODUCTO     int                  not null,
   constraint PK_STOCK primary key (CODIGOARTESANO, CODIGOPRODUCTO)
)
GO
alter table STOCK
   add constraint FK_STOCK_STOCK_ARTESANO foreign key (CODIGOARTESANO)
      references ARTESANO (CODIGOARTESANO)
GO
alter table STOCK
   add constraint FK_STOCK_STOCK2_PRODUCTO foreign key (CODIGOPRODUCTO)
      references PRODUCTO (CODIGOPRODUCTO)
GO
/*==============================================================*/
/* Index: STOCK_FK                                              */
/*==============================================================*/




create nonclustered index STOCK_FK on STOCK (CODIGOARTESANO ASC)
GO
/*==============================================================*/
/* Index: STOCK2_FK                                             */
/*==============================================================*/




create nonclustered index STOCK2_FK on STOCK (CODIGOPRODUCTO ASC)