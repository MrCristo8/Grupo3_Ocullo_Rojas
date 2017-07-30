/*==============================================================*/
/* Table: ARTESANO                                              */
/*==============================================================*/
create table ARTESANO (
   CODIGOARTESANO       int                  not null,
   CODIGODIRECCION      int                  null,
   CODIGODISCIPLINA     int                  null,
   CI_RUC_RISE          varchar(13)          not null,
   NOMBREARTESANO       varchar(45)          not null,
   APELLIDOARTESANO     varchar(45)          not null,
   FECHANACIMIENTO      datetime             not null,
   NUMEROAFILIACION     int                  not null,
   BARRIOARTESANO       varchar(30)          not null,
   TELEFONOTALLERARTESANO varchar(10)          null,
   TELEFONODOMICILIOARTESANO varchar(10)          null,
   TELEFONOPERSONALARTESANO varchar(10)          null,
   CORREOARTESANO       varchar(50)          null,
   RAZONSOCIAL          text                 null,
   ACTIVIDADNEGOCIO     varchar(45)          null,
   RESENAHISTORICAMARCA text                 null,
   LOGOMARCA            image                null,
   ACUERTOINTERMINISTERIAL char(2)              null 
      constraint CKC_ACUERTOINTERMINIS_ARTESANO check (ACUERTOINTERMINISTERIAL is null or (ACUERTOINTERMINISTERIAL in ('Si','No'))),
   PATENTEMUNICIPAL     char(2)              null 
      constraint CKC_PATENTEMUNICIPAL_ARTESANO check (PATENTEMUNICIPAL is null or (PATENTEMUNICIPAL in ('Si','No'))),
   constraint PK_ARTESANO primary key (CODIGOARTESANO)
)
GO
alter table ARTESANO
   add constraint FK_ARTESANO_DISCIPLIN_DISCIPLI foreign key (CODIGODISCIPLINA)
      references DISCIPLINA (CODIGODISCIPLINA)
GO
alter table ARTESANO
   add constraint FK_ARTESANO_RELATIONS_DIRECCIO foreign key (CODIGODIRECCION)
      references DIRECCION (CODIGODIRECCION)
GO
/*==============================================================*/
/* Index: DISCIPLINA_FK                                         */
/*==============================================================*/




create nonclustered index DISCIPLINA_FK on ARTESANO (CODIGODISCIPLINA ASC)
GO
/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/




create nonclustered index RELATIONSHIP_3_FK on ARTESANO (CODIGODIRECCION ASC)