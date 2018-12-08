CREATE TABLE CATEGORIES (
	IDCATEGORY NUMBER(38,0) PRIMARY KEY NOT NULL,
	NAME	VARCHAR2(30) NOT NULL,
	DELETED NUMBER(38,0) NOT NULL
);

CREATE TABLE PLATFORMS (
	IDPLATFORM NUMBER(38,0) PRIMARY KEY NOT NULL,
	NAME VARCHAR2(30) NOT NULL,
	DELETED NUMBER(38,0) NOT NULL
);

CREATE TABLE ROLES (
	IDROLE NUMBER(38,0) PRIMARY KEY NOT NULL,
	NAME VARCHAR2(30) NOT NULL
);

CREATE TABLE PERMITS (
	IDPERMIT NUMBER(38,0) PRIMARY KEY NOT NULL,
	NAME VARCHAR2(30)	NOT NULL
);

CREATE TABLE ROL_PERM (
	IDROLPERM NUMBER(38,0) PRIMARY KEY NOT NULL,
	IDPERMIT NUMBER(38,0) NOT NULL,
	IDROLE NUMBER(38,0) NOT NULL
);

CREATE TABLE USERS_ROLES (
	IDUSERROL NUMBER(38,0) PRIMARY KEY NOT NULL,
	IDUSER NUMBER (38,0) NOT NULL,
	IDROLE NUMBER(38,0) NOT NULL
);

INSERT INTO CATEGORIES VALUES(1,'ACTION',0);	
INSERT INTO CATEGORIES VALUES(2,'SHOOTER',0);
INSERT INTO CATEGORIES VALUES(3,'SPORTS',0);

INSERT INTO PLATFORMS VALUES(1,'PLAY STATION',0);
INSERT INTO PLATFORMS VALUES(2,'NINTENDO',0);
INSERT INTO PLATFORMS VALUES(3,'XBOX',0);

INSERT INTO ROLES VALUES(1,'ADMIN');
INSERT INTO ROLES VALUES(2,'USER');

INSERT INTO PERMITS VALUES(1,'USERS MANAGEMENT');
INSERT INTO PERMITS VALUES(2,'CUSTOMERS MANAGEMENT');
INSERT INTO PERMITS VALUES(3,'ORDERS MANAGEMENT');
INSERT INTO PERMITS VALUES(4,'PRODUCTS MANAGEMENT');
INSERT INTO PERMITS VALUES(5,'CATEGORIES MANAGEMENT');
INSERT INTO PERMITS VALUES(6,'PLATFORMS MANAGEMENT');

ALTER TABLE ROL_PERM ADD CONSTRAINT FK_ROL_PERM_IDROL FOREIGN KEY (IDROLE) REFERENCES ROLES(IDROLE);
ALTER TABLE ROL_PERM ADD CONSTRAINT FK_ROL_PERM_IDPERM FOREIGN KEY (IDPERMIT) REFERENCES PERMITS(IDPERMIT);

ALTER TABLE USERS_ROLES ADD CONSTRAINT FK_USER_ROLES_IDUSER FOREIGN KEY (IDUSER) REFERENCES USERS(IDUSER);
ALTER TABLE USERS_ROLES ADD CONSTRAINT FK_USER_ROLES_IDROLES FOREIGN KEY (IDROLE) REFERENCES ROLES(IDROLE);

--------------------------------------------------------
-- Archivo creado  - lunes-noviembre-26-2018   
--------------------------------------------------------
DROP TABLE "VIDEOGAMESERP"."PRODUCTS" cascade constraints;
--------------------------------------------------------
--  DDL for Table PRODUCTS
--------------------------------------------------------

  CREATE TABLE "VIDEOGAMESERP"."PRODUCTS" 
   (	"IDPRODUCT" NUMBER(*,0), 
	"NAME" VARCHAR2(40 BYTE), 
	"IDCATEGORY" NUMBER(38), 
	"IDPLATFORM" NUMBER(38),
    "MINIMUMAGE" NUMBER(2),
    "PRICE" FLOAT,
	"DELETED" NUMBER(*,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into VIDEOGAMESERP.PRODUCTS
SET DEFINE OFF;
--------------------------------------------------------
--  DDL for Index PRODUCTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "VIDEOGAMESERP"."PRODUCTS_PK" ON "VIDEOGAMESERP"."PRODUCTS" ("IDPRODUCT") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table PRODUCTS
--------------------------------------------------------

  ALTER TABLE "VIDEOGAMESERP"."PRODUCTS" MODIFY ("IDPRODUCT" NOT NULL ENABLE);
  ALTER TABLE "VIDEOGAMESERP"."PRODUCTS" MODIFY ("PRICE" NOT NULL ENABLE);
  ALTER TABLE "VIDEOGAMESERP"."PRODUCTS" ADD CONSTRAINT "PRODUCTS_PK" PRIMARY KEY ("IDPRODUCT")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE PRODUCTS ADD CONSTRAINT "FK_PROD_CATEG" FOREIGN KEY (IDCATEGORY) REFERENCES CATEGORIES (IDCATEGORY);
    ALTER TABLE PRODUCTS ADD CONSTRAINT "FK_PROD_PLAF" FOREIGN KEY (IDPLATFORM) REFERENCES PLATFORMS (IDPLATFORM);





--------------------------------------------------------
-- Archivo creado  - lunes-diciembre-03-2018   
--------------------------------------------------------
DROP TABLE "VIDEOGAMESERP"."CUSTOMERS" cascade constraints;
--------------------------------------------------------
--  DDL for Table CUSTOMERS
--------------------------------------------------------

  CREATE TABLE "VIDEOGAMESERP"."CUSTOMERS" 
   (	"IDCUSTOMER" NUMBER(*,0), 
    "DNI" VARCHAR2(9),
	"NAME" VARCHAR2(30 BYTE), 
	"SURNAME" VARCHAR2(20 BYTE), 
	"ADDRESS" VARCHAR2(30 BYTE), 
	"PHONE" NUMBER(*,0), 
	"EMAIL" VARCHAR2(20 BYTE), 
    "REFZIPCODESCITIES" NUMBER,
	"DELETED" NUMBER(*,0) 
	
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into VIDEOGAMESERP.CUSTOMERS
SET DEFINE OFF;
Insert into VIDEOGAMESERP.CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,DELETED,REFZIPCODESCITIES) values ('1','00000000L','john','doe','fake street 123','666','john@doe.com','2365','0');
--------------------------------------------------------
--  DDL for Index CUSTOMERS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "VIDEOGAMESERP"."CUSTOMERS_PK" ON "VIDEOGAMESERP"."CUSTOMERS" ("IDCUSTOMER") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table CUSTOMERS
--------------------------------------------------------

  ALTER TABLE "VIDEOGAMESERP"."CUSTOMERS" ADD CONSTRAINT "CUSTOMERS_PK" PRIMARY KEY ("IDCUSTOMER")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "VIDEOGAMESERP"."CUSTOMERS" ADD CONSTRAINT "CUSTOMERS_UK_DNI" UNIQUE ("DNI");
  
  
  --------------------------------------------------------
-- Archivo creado  - martes-diciembre-04-2018   
--------------------------------------------------------
DROP TABLE "VIDEOGAMESERP"."USERS" cascade constraints;
--------------------------------------------------------
--  DDL for Table USERS
--------------------------------------------------------

  CREATE TABLE "VIDEOGAMESERP"."USERS" 
   (	"IDUSER" NUMBER(*,0), 
	"NAME" VARCHAR2(30 BYTE), 
	"PASSWORD" VARCHAR2(50 BYTE), 
	"DELETED" NUMBER(*,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into VIDEOGAMESERP.USERS
SET DEFINE OFF;
Insert into VIDEOGAMESERP.USERS (IDUSER,NAME,PASSWORD,DELETED) values ('3','pablo','1234','0');
Insert into VIDEOGAMESERP.USERS (IDUSER,NAME,PASSWORD,DELETED) values ('1','root','admin1234','0');
Insert into VIDEOGAMESERP.USERS (IDUSER,NAME,PASSWORD,DELETED) values ('2','user1','1234','0');
Insert into VIDEOGAMESERP.USERS (IDUSER,NAME,PASSWORD,DELETED) values ('4','aaa','aaa','1');
--------------------------------------------------------
--  DDL for Index USERS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "VIDEOGAMESERP"."USERS_PK" ON "VIDEOGAMESERP"."USERS" ("IDUSER") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table USERS
--------------------------------------------------------

  ALTER TABLE "VIDEOGAMESERP"."USERS" ADD CONSTRAINT "USERS_PK" PRIMARY KEY ("IDUSER")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  
  --PARA LOGS
  
  CREATE TABLE LOGS(
    FECHACAMBIO DATE NOT NULL ENABLE PRIMARY KEY, 
	IDUSER NUMBER(38,0) NOT NULL ENABLE, 
	DESCRIPCION VARCHAR2(200 BYTE) NOT NULL ENABLE,
    CONSTRAINT fk_logs
    FOREIGN KEY (IDUSER)
    REFERENCES USERS (IDUSER));