/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     5/27/2018 19:20:45                           */
/*==============================================================*/


drop table if exists STANJE;

drop table if exists USTANOVA;

/*==============================================================*/
/* Table: STANJE                                                */
/*==============================================================*/
create table STANJE
(
   ID_STANJA            int not null,
   ID_USTANOVE          int,
   TRENUTNO_STANJE      int,
   POSLEDNJI_UZETI      int,
   DATUM                date,
   primary key (ID_STANJA)
);

/*==============================================================*/
/* Table: USTANOVA                                              */
/*==============================================================*/
create table USTANOVA
(
   ID_USTANOVE          int not null,
   NAZIV                varchar(100),
   LON                  float,
   LAT                  float,
   BROJ_SALTERA         smallint,
   LOKACIJA_NA_MAPI     varchar(100),
   LOGO                 longblob,
   primary key (ID_USTANOVE)
);

alter table STANJE add constraint FK_STANJE_USTANOVE foreign key (ID_USTANOVE)
      references USTANOVA (ID_USTANOVE) on delete restrict on update restrict;

