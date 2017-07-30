
/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2016                    */
/* Created on:     24/07/2017 18:29:05                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ARTESANO') and o.name = 'FK_ARTESANO_DISCIPLIN_DISCIPLI')
alter table ARTESANO
   drop constraint FK_ARTESANO_DISCIPLIN_DISCIPLI
GO

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ARTESANO') and o.name = 'FK_ARTESANO_RELATIONS_DIRECCIO')
alter table ARTESANO
   drop constraint FK_ARTESANO_RELATIONS_DIRECCIO
GO

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PEDIDO') and o.name = 'FK_PEDIDO_PEDIDO_CLIENTE')
alter table PEDIDO
   drop constraint FK_PEDIDO_PEDIDO_CLIENTE
GO

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PEDIDO') and o.name = 'FK_PEDIDO_PEDIDO2_PRODUCTO')
alter table PEDIDO
   drop constraint FK_PEDIDO_PEDIDO2_PRODUCTO
GO

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STOCK') and o.name = 'FK_STOCK_STOCK_ARTESANO')
alter table STOCK
   drop constraint FK_STOCK_STOCK_ARTESANO
GO

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STOCK') and o.name = 'FK_STOCK_STOCK2_PRODUCTO')
alter table STOCK
   drop constraint FK_STOCK_STOCK2_PRODUCTO
GO

if exists (select 1
            from  sysindexes
           where  id    = object_id('ARTESANO')
            and   name  = 'RELATIONSHIP_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index ARTESANO.RELATIONSHIP_3_FK
GO

if exists (select 1
            from  sysindexes
           where  id    = object_id('ARTESANO')
            and   name  = 'DISCIPLINA_FK'
            and   indid > 0
            and   indid < 255)
   drop index ARTESANO.DISCIPLINA_FK
GO

if exists (select 1
            from  sysobjects
           where  id = object_id('ARTESANO')
            and   type = 'U')
   drop table ARTESANO
GO

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTE')
            and   type = 'U')
   drop table CLIENTE
GO

if exists (select 1
            from  sysobjects
           where  id = object_id('DIRECCION')
            and   type = 'U')
   drop table DIRECCION
GO

if exists (select 1
            from  sysobjects
           where  id = object_id('DISCIPLINA')
            and   type = 'U')
   drop table DISCIPLINA
GO

if exists (select 1
            from  sysindexes
           where  id    = object_id('PEDIDO')
            and   name  = 'PEDIDO2_FK'
            and   indid > 0
            and   indid < 255)
   drop index PEDIDO.PEDIDO2_FK
GO

if exists (select 1
            from  sysindexes
           where  id    = object_id('PEDIDO')
            and   name  = 'PEDIDO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PEDIDO.PEDIDO_FK
GO

if exists (select 1
            from  sysobjects
           where  id = object_id('PEDIDO')
            and   type = 'U')
   drop table PEDIDO
GO

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTO')
            and   type = 'U')
   drop table PRODUCTO
GO

if exists (select 1
            from  sysindexes
           where  id    = object_id('STOCK')
            and   name  = 'STOCK2_FK'
            and   indid > 0
            and   indid < 255)
   drop index STOCK.STOCK2_FK
GO

if exists (select 1
            from  sysindexes
           where  id    = object_id('STOCK')
            and   name  = 'STOCK_FK'
            and   indid > 0
            and   indid < 255)
   drop index STOCK.STOCK_FK
GO

if exists (select 1
            from  sysobjects
           where  id = object_id('STOCK')
            and   type = 'U')
   drop table STOCK
GO
