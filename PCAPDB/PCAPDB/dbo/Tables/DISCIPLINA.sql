/*==============================================================*/
/* Table: DISCIPLINA                                            */
/*==============================================================*/
create table DISCIPLINA (
   CODIGODISCIPLINA     int                  not null,
   NOMBREDISCIPLINA     varchar(45)          not null,
   constraint PK_DISCIPLINA primary key (CODIGODISCIPLINA)
)