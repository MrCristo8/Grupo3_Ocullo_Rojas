/*==============================================================*/
/* Table: PEDIDO                                                */
/*==============================================================*/
create table PEDIDO (
   CODIGOPEDIDO         int                  not null,
   CODIGOCLIENTE        int                  not null,
   CODIGOPRODUCTO       int                  not null,
   FECHAPEDIDO          datetime             not null,
   CANTIDADPEDIDO       int                  not null,
   constraint PK_PEDIDO primary key (CODIGOPEDIDO)
)
GO
alter table PEDIDO
   add constraint FK_PEDIDO_PEDIDO_CLIENTE foreign key (CODIGOCLIENTE)
      references CLIENTE (CODIGOCLIENTE)
GO
alter table PEDIDO
   add constraint FK_PEDIDO_PEDIDO2_PRODUCTO foreign key (CODIGOPRODUCTO)
      references PRODUCTO (CODIGOPRODUCTO)
GO
/*==============================================================*/
/* Index: PEDIDO_FK                                             */
/*==============================================================*/




create nonclustered index PEDIDO_FK on PEDIDO (CODIGOCLIENTE ASC)
GO
/*==============================================================*/
/* Index: PEDIDO2_FK                                            */
/*==============================================================*/




create nonclustered index PEDIDO2_FK on PEDIDO (CODIGOPRODUCTO ASC)