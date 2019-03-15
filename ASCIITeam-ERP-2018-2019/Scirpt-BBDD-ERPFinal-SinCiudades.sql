--------------------------------------------------------
-- Archivo creado  - martes-marzo-12-2019   
--------------------------------------------------------
DROP TABLE "ORDERSPRODUCTS" cascade constraints;
DROP TABLE "PERMITS" cascade constraints;
DROP TABLE "PLATFORMS" cascade constraints;
DROP TABLE "ORDERS_STATUS" cascade constraints;
DROP TABLE "ROL_PERM" cascade constraints;
DROP TABLE "PPAYMENTS" cascade constraints;
DROP TABLE "LOGS" cascade constraints;
DROP TABLE "LINES_INVOICE" cascade constraints;
DROP TABLE "CATEGORIES" cascade constraints;
DROP TABLE "INVOICES" cascade constraints;
DROP TABLE "DEBTS" cascade constraints;
DROP TABLE "CUSTOMERS" cascade constraints;
DROP TABLE "INCOMES_EXPENSES" cascade constraints;
DROP TABLE "ROLES" cascade constraints;
DROP TABLE "ORDERS_INVOICES" cascade constraints;
DROP TABLE "TYPES_INCOME" cascade constraints;
DROP TABLE "PRODUCTS" cascade constraints;
DROP TABLE "PAYMENTMETHODS" cascade constraints;
DROP TABLE "SOURCES_TARGETS" cascade constraints;
DROP TABLE "TYPES_PPAYMENT" cascade constraints;
DROP TABLE "PRODUCTS_INVOICES" cascade constraints;
DROP TABLE "ORDERS" cascade constraints;
DROP TABLE "USERS" cascade constraints;
DROP TABLE "USERS_ROLES" cascade constraints;
DROP TABLE "VALIDATIONS" cascade constraints;
--------------------------------------------------------
--  DDL for Table ORDERSPRODUCTS
--------------------------------------------------------

  CREATE TABLE "ORDERSPRODUCTS" 
   (	"IDORDERPRODUCT" NUMBER(*,0), 
	"REFORDER" NUMBER(*,0), 
	"REFPRODUCT" NUMBER(*,0), 
	"AMOUNT" NUMBER(*,0), 
	"PRICESALE" FLOAT(126)
   ) ;
--------------------------------------------------------
--  DDL for Table PERMITS
--------------------------------------------------------

  CREATE TABLE "PERMITS" 
   (	"IDPERMIT" NUMBER(38,0), 
	"NAME" VARCHAR2(30 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table PLATFORMS
--------------------------------------------------------

  CREATE TABLE "PLATFORMS" 
   (	"IDPLATFORM" NUMBER(38,0), 
	"NAME" VARCHAR2(30 BYTE), 
	"DELETED" NUMBER(38,0)
   ) ;
--------------------------------------------------------
--  DDL for Table ORDERS_STATUS
--------------------------------------------------------

  CREATE TABLE "ORDERS_STATUS" 
   (	"ID" NUMBER(38,0), 
	"REFORDER" NUMBER(38,0), 
	"STATUS" NUMBER(1,0) DEFAULT 0
   ) ;

   COMMENT ON COLUMN "ORDERS_STATUS"."STATUS" IS '0:NADA,1:CONF,2:ETI,3:ENVI,4:FACTU';
--------------------------------------------------------
--  DDL for Table ROL_PERM
--------------------------------------------------------

  CREATE TABLE "ROL_PERM" 
   (	"IDROLPERM" NUMBER(38,0), 
	"IDPERMIT" NUMBER(38,0), 
	"IDROLE" NUMBER(38,0)
   ) ;
--------------------------------------------------------
--  DDL for Table PPAYMENTS
--------------------------------------------------------

  CREATE TABLE "PPAYMENTS" 
   (	"ID" NUMBER(38,0), 
	"PPDATE" DATE, 
	"REFUSER" NUMBER(38,0), 
	"REFTYPE" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(60 BYTE), 
	"AMOUNT" NUMBER(11,2), 
	"PAID" NUMBER(1,0)
   ) ;
--------------------------------------------------------
--  DDL for Table LOGS
--------------------------------------------------------

  CREATE TABLE "LOGS" 
   (	"FECHACAMBIO" DATE, 
	"IDUSER" NUMBER(38,0), 
	"DESCRIPCION" VARCHAR2(200 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table LINES_INVOICE
--------------------------------------------------------

  CREATE TABLE "LINES_INVOICE" 
   (	"ID" NUMBER, 
	"DESCRIPTION" VARCHAR2(60 BYTE), 
	"AMOUNT" NUMBER(11,2) DEFAULT 0, 
	"PRICE" FLOAT(126) DEFAULT 0, 
	"REFINVOICE" NUMBER(38,0), 
	"DELETED" NUMBER(1,0) DEFAULT 0
   ) ;
--------------------------------------------------------
--  DDL for Table CATEGORIES
--------------------------------------------------------

  CREATE TABLE "CATEGORIES" 
   (	"IDCATEGORY" NUMBER(38,0), 
	"NAME" VARCHAR2(30 BYTE), 
	"DELETED" NUMBER(38,0)
   ) ;
--------------------------------------------------------
--  DDL for Table INVOICES
--------------------------------------------------------

  CREATE TABLE "INVOICES" 
   (	"NUM_INVOICE" NUMBER(38,0), 
	"DATETIME" DATE, 
	"REFCUSTOMER" NUMBER(38,0), 
	"AMOUNT" NUMBER(11,2) DEFAULT 0, 
	"DELETED" NUMBER(1,0) DEFAULT 0, 
	"POSTED" NUMBER(1,0) DEFAULT 0, 
	"ID" NUMBER(38,0)
   ) ;

   COMMENT ON COLUMN "INVOICES"."DELETED" IS '0 no deleted, 1 si deleted';
--------------------------------------------------------
--  DDL for Table DEBTS
--------------------------------------------------------

  CREATE TABLE "DEBTS" 
   (	"ID" NUMBER(38,0), 
	"DDATE" DATE, 
	"REFUSER" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(60 BYTE), 
	"AMOUNT" NUMBER(11,2), 
	"PAID" NUMBER(1,0)
   ) ;

   COMMENT ON COLUMN "DEBTS"."PAID" IS '0 FALSE, 1 TRUE';
--------------------------------------------------------
--  DDL for Table CUSTOMERS
--------------------------------------------------------

  CREATE TABLE "CUSTOMERS" 
   (	"IDCUSTOMER" NUMBER(*,0), 
	"DNI" VARCHAR2(9 BYTE), 
	"NAME" VARCHAR2(30 BYTE), 
	"SURNAME" VARCHAR2(20 BYTE), 
	"ADDRESS" VARCHAR2(30 BYTE), 
	"PHONE" NUMBER(*,0), 
	"EMAIL" VARCHAR2(20 BYTE), 
	"REFZIPCODESCITIES" NUMBER, 
	"DELETED" NUMBER(*,0)
   ) ;
--------------------------------------------------------
--  DDL for Table INCOMES_EXPENSES
--------------------------------------------------------

  CREATE TABLE "INCOMES_EXPENSES" 
   (	"ID" NUMBER(38,0), 
	"IE_DATE" DATE, 
	"REFUSER" NUMBER(38,0), 
	"REFST" NUMBER(38,0), 
	"REFTYPE" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(60 BYTE), 
	"AMOUNT" NUMBER(11,2), 
	"REFACTION" NUMBER(1,0), 
	"REVOKED" NUMBER(1,0) DEFAULT 0
   ) ;

   COMMENT ON COLUMN "INCOMES_EXPENSES"."REFST" IS 'REF TO SOURCE OR TARGET';
   COMMENT ON COLUMN "INCOMES_EXPENSES"."REFACTION" IS '0 FOR INCOME 1 FOR EXPENSE';
--------------------------------------------------------
--  DDL for Table ROLES
--------------------------------------------------------

  CREATE TABLE "ROLES" 
   (	"IDROLE" NUMBER(38,0), 
	"NAME" VARCHAR2(30 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table ORDERS_INVOICES
--------------------------------------------------------

  CREATE TABLE "ORDERS_INVOICES" 
   (	"IDORDERINV" NUMBER(38,0), 
	"IDORDER" NUMBER(38,0), 
	"IDINVOICE" NUMBER(38,0)
   ) ;
--------------------------------------------------------
--  DDL for Table TYPES_INCOME
--------------------------------------------------------

  CREATE TABLE "TYPES_INCOME" 
   (	"ID" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(25 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table PRODUCTS
--------------------------------------------------------

  CREATE TABLE "PRODUCTS" 
   (	"IDPRODUCT" NUMBER(*,0), 
	"NAME" VARCHAR2(40 BYTE), 
	"IDCATEGORY" NUMBER(38,0), 
	"IDPLATFORM" NUMBER(38,0), 
	"MINIMUMAGE" NUMBER(2,0), 
	"PRICE" FLOAT(126), 
	"DELETED" NUMBER(*,0), 
	"STOCK" NUMBER(5,0) DEFAULT 0
   ) ;
--------------------------------------------------------
--  DDL for Table PAYMENTMETHODS
--------------------------------------------------------

  CREATE TABLE "PAYMENTMETHODS" 
   (	"IDPAYMENTMETHOD" NUMBER, 
	"PAYMENTMETHOD" VARCHAR2(100 BYTE), 
	"DELETED" NUMBER
   ) ;
--------------------------------------------------------
--  DDL for Table SOURCES_TARGETS
--------------------------------------------------------

  CREATE TABLE "SOURCES_TARGETS" 
   (	"ID" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(40 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table TYPES_PPAYMENT
--------------------------------------------------------

  CREATE TABLE "TYPES_PPAYMENT" 
   (	"ID" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(25 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table PRODUCTS_INVOICES
--------------------------------------------------------

  CREATE TABLE "PRODUCTS_INVOICES" 
   (	"IDPROINV" NUMBER(38,0), 
	"IDPRODUCT" NUMBER(38,0), 
	"IDINVOICE" NUMBER(38,0), 
	"AMOUNT" NUMBER(38,0) DEFAULT 0, 
	"PRICESALE" NUMBER(38,2)
   ) ;
--------------------------------------------------------
--  DDL for Table ORDERS
--------------------------------------------------------

  CREATE TABLE "ORDERS" 
   (	"IDORDER" NUMBER(*,0), 
	"REFCUSTOMER" NUMBER(*,0), 
	"REFUSER" NUMBER(*,0), 
	"DATETIME" DATE, 
	"REFPAYMENTMETHOD" NUMBER, 
	"TOTAL" NUMBER(20,2), 
	"PREPAID" NUMBER(20,2), 
	"DELETED" NUMBER(*,0)
   ) ;
--------------------------------------------------------
--  DDL for Table USERS
--------------------------------------------------------

  CREATE TABLE "USERS" 
   (	"IDUSER" NUMBER(*,0), 
	"NAME" VARCHAR2(30 BYTE), 
	"PASSWORD" VARCHAR2(50 BYTE), 
	"DELETED" NUMBER(*,0)
   ) ;
--------------------------------------------------------
--  DDL for Table USERS_ROLES
--------------------------------------------------------

  CREATE TABLE "USERS_ROLES" 
   (	"IDUSERROL" NUMBER(38,0), 
	"IDUSER" NUMBER(38,0), 
	"IDROLE" NUMBER(38,0)
   ) ;
--------------------------------------------------------
--  DDL for Table VALIDATIONS
--------------------------------------------------------

  CREATE TABLE "VALIDATIONS" 
   (	"ID" NUMBER(38,0), 
	"VALIDATION_DATE" DATE, 
	"REFUSER" NUMBER(38,0), 
	"A_INCASH" NUMBER(11,2), 
	"A_RECEIPT" NUMBER(11,2), 
	"A_CHECK" NUMBER(11,2), 
	"TOTAL" NUMBER(11,2)
   ) ;
REM INSERTING into ORDERSPRODUCTS
SET DEFINE OFF;
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('21','15','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('24','18','3','5','70');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('25','4','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('26','6','2','1','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('27','8','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('1','1','1','2','100');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('4','3','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('28','19','3','1','70');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('2','2','2','1','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('3','2','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('7','7','2','1','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('9','9','2','1','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('10','9','2','1','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('11','9','2','2','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('12','10','2','5','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('13','11','2','5','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('14','11','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('15','12','1','3','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('16','13','2','1','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('17','13','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('18','14','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('19','14','2','1','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('20','14','2','1','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('22','16','2','4','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('23','17','3','26','70');
REM INSERTING into PERMITS
SET DEFINE OFF;
Insert into PERMITS (IDPERMIT,NAME) values ('1','USERS MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('2','CUSTOMERS MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('6','PLATFORMS MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('3','ORDERS  MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('4','PRODUCTS MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('5','CATEGORIES MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('7','CASHBOOK MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('8','INVOICES MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('9','CONFIRM ORDER');
Insert into PERMITS (IDPERMIT,NAME) values ('10','LABEL ORDER');
Insert into PERMITS (IDPERMIT,NAME) values ('11','SENT ORDER');
Insert into PERMITS (IDPERMIT,NAME) values ('12','INVOICE ORDER');
REM INSERTING into PLATFORMS
SET DEFINE OFF;
Insert into PLATFORMS (IDPLATFORM,NAME,DELETED) values ('1','PLAY STATION','0');
Insert into PLATFORMS (IDPLATFORM,NAME,DELETED) values ('2','NINTENDO','0');
Insert into PLATFORMS (IDPLATFORM,NAME,DELETED) values ('3','XBOX','0');
Insert into PLATFORMS (IDPLATFORM,NAME,DELETED) values ('4','PRUEBA22','0');
REM INSERTING into ORDERS_STATUS
SET DEFINE OFF;
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('15','15','4');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('18','18','3');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('1','1','1');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('2','2','1');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('3','3','2');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('4','4','1');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('5','5','1');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('6','6','4');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('7','7','4');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('8','8','0');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('9','9','0');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('10','10','2');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('11','11','1');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('12','12','2');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('13','13','1');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('14','14','4');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('16','16','1');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('17','17','4');
Insert into ORDERS_STATUS (ID,REFORDER,STATUS) values ('19','19','1');
REM INSERTING into ROL_PERM
SET DEFINE OFF;
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('109','3','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('110','4','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('111','5','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('112','6','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('113','7','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('114','8','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('81','4','2');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('79','2','2');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('80','3','2');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('82','5','2');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('83','6','2');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('115','9','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('86','3','3');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('90','7','3');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('91','8','3');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('92','9','3');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('95','12','3');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('116','10','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('117','11','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('118','12','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('98','3','4');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('105','10','4');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('106','11','4');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('107','1','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('108','2','1');
REM INSERTING into PPAYMENTS
SET DEFINE OFF;
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('11',to_date('02/03/19','DD/MM/RR'),'1','0','Nº Order15','50','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('14',to_date('04/03/19','DD/MM/RR'),'1','1','Nº Order18','340','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('15',to_date('04/03/19','DD/MM/RR'),'1','1','Nº Order4','40','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('3',to_date('24/01/19','DD/MM/RR'),'1','0','test ppayment 3','1500','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('4',to_date('24/01/19','DD/MM/RR'),'1','1','test ppayment 4','300,66','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('5',to_date('24/01/19','DD/MM/RR'),'1','0','test pp 000','100','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('1',to_date('24/01/19','DD/MM/RR'),'1','1','test ppayment 1','20000','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('2',to_date('24/01/19','DD/MM/RR'),'1','0','test ppayment 2','1500,3','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('6',to_date('24/01/19','DD/MM/RR'),'1','0','Luis','0','1');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('7',to_date('01/01/01','DD/MM/RR'),'1','0','Nº Order10','60','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('8',to_date('01/01/01','DD/MM/RR'),'1','0','Nº Order11','110','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('9',to_date('25/02/19','DD/MM/RR'),'1','0','Nº Order12','150','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('10',to_date('25/02/19','DD/MM/RR'),'1','1','Nº Order14','14','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('12',to_date('02/03/19','DD/MM/RR'),'1','0','Nº Order16','48','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('13',to_date('04/03/19','DD/MM/RR'),'1','1','Nº Order17','1320','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('16',to_date('12/03/19','DD/MM/RR'),'1','1','Nº Order1','90','0');
Insert into PPAYMENTS (ID,PPDATE,REFUSER,REFTYPE,DESCRIPTION,AMOUNT,PAID) values ('17',to_date('12/03/19','DD/MM/RR'),'4','0','Nº Order19','70','0');
REM INSERTING into LOGS
SET DEFINE OFF;
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Role ADMIN updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Role ADMIN updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Order 15 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Role ADMIN updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 18 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 1 restored');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 1 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 4 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 4 restored');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 4 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 4 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 4 restored');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 1 restored');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 4 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 6 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 4 restored');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 8 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 6 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 16 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 6 restored');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 9 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 8 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Product fifa 17 updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 18 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('21/01/19','DD/MM/RR'),'1','Role cash created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('21/01/19','DD/MM/RR'),'1','Role CASH updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('21/01/19','DD/MM/RR'),'1','Role CASH updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('21/01/19','DD/MM/RR'),'1','User cash created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('22/01/19','DD/MM/RR'),'1','Role USER updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('19/02/19','DD/MM/RR'),'1','Order 7 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('25/02/19','DD/MM/RR'),'1','Order 8 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('25/02/19','DD/MM/RR'),'1','Order 9 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('25/02/19','DD/MM/RR'),'1','Order 10 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('25/02/19','DD/MM/RR'),'1','Order 11 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('25/02/19','DD/MM/RR'),'1','Order 12 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('25/02/19','DD/MM/RR'),'1','Order 13 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('25/02/19','DD/MM/RR'),'1','Order 14 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','User prueba1 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Customer 33333333O created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Customer 33333333O updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Order 16 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Categorie MOBA created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Platform PRUEBAPLATAFORMA created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Platform PRUEBA22 updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('02/03/19','DD/MM/RR'),'1','Categorie MOOBA updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Product fifa 17 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Product fifa 17 updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 17 created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Role ADMIN updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Product fifa 17 updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('04/03/19','DD/MM/RR'),'1','Order 1 deleted');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('12/03/19','DD/MM/RR'),'1','Role ENCAR created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('12/03/19','DD/MM/RR'),'1','Role ADMINISTRATIVO created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('12/03/19','DD/MM/RR'),'1','Role ALMACEN created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('12/03/19','DD/MM/RR'),'1','Role ADMIN updated');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('12/03/19','DD/MM/RR'),'1','User Encargado created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('12/03/19','DD/MM/RR'),'1','User Administrativo created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('12/03/19','DD/MM/RR'),'1','User Almacen created');
Insert into LOGS (FECHACAMBIO,IDUSER,DESCRIPCION) values (to_date('12/03/19','DD/MM/RR'),'4','Order 19 created');
REM INSERTING into LINES_INVOICE
SET DEFINE OFF;
Insert into LINES_INVOICE (ID,DESCRIPTION,AMOUNT,PRICE,REFINVOICE,DELETED) values ('3','Gastos de Envio','1','3,33','2','0');
Insert into LINES_INVOICE (ID,DESCRIPTION,AMOUNT,PRICE,REFINVOICE,DELETED) values ('1','Gastos de Envio','1','4,5','1','0');
Insert into LINES_INVOICE (ID,DESCRIPTION,AMOUNT,PRICE,REFINVOICE,DELETED) values ('2','Pendrives','17','6','2','0');
REM INSERTING into CATEGORIES
SET DEFINE OFF;
Insert into CATEGORIES (IDCATEGORY,NAME,DELETED) values ('1','ACTION','0');
Insert into CATEGORIES (IDCATEGORY,NAME,DELETED) values ('2','SHOOTER','0');
Insert into CATEGORIES (IDCATEGORY,NAME,DELETED) values ('3','SPORTS','0');
Insert into CATEGORIES (IDCATEGORY,NAME,DELETED) values ('4','MOOBA','0');
REM INSERTING into INVOICES
SET DEFINE OFF;
Insert into INVOICES (NUM_INVOICE,DATETIME,REFCUSTOMER,AMOUNT,DELETED,POSTED,ID) values ('20190002',to_date('12/03/19','DD/MM/RR'),'7','105,33','0','0','2');
Insert into INVOICES (NUM_INVOICE,DATETIME,REFCUSTOMER,AMOUNT,DELETED,POSTED,ID) values ('20190001',to_date('12/03/19','DD/MM/RR'),'4','54,5','0','1','1');
Insert into INVOICES (NUM_INVOICE,DATETIME,REFCUSTOMER,AMOUNT,DELETED,POSTED,ID) values ('20190003',to_date('12/03/19','DD/MM/RR'),'2','12','0','0','3');
Insert into INVOICES (NUM_INVOICE,DATETIME,REFCUSTOMER,AMOUNT,DELETED,POSTED,ID) values ('20190004',to_date('12/03/19','DD/MM/RR'),'1','12','0','0','4');
Insert into INVOICES (NUM_INVOICE,DATETIME,REFCUSTOMER,AMOUNT,DELETED,POSTED,ID) values ('20190005',to_date('12/03/19','DD/MM/RR'),'2','74','0','0','5');
Insert into INVOICES (NUM_INVOICE,DATETIME,REFCUSTOMER,AMOUNT,DELETED,POSTED,ID) values ('20190006',to_date('12/03/19','DD/MM/RR'),'5','1820','0','0','6');
REM INSERTING into DEBTS
SET DEFINE OFF;
Insert into DEBTS (ID,DDATE,REFUSER,DESCRIPTION,AMOUNT,PAID) values ('1',to_date('22/01/19','DD/MM/RR'),'1','test debts','200','0');
REM INSERTING into CUSTOMERS
SET DEFINE OFF;
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('5','05739350E','Jesus','Calzado','calle 65496','666','abc@abc.com','11630','0');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('4','05739349K','Jesus','Calzado','Calle calle calle 123','680444882','jcg598@gmail.com','13260','0');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('1','00000000L','john','doe','fake street 123','666','john@doe.com','3','0');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('2','12121212F','Diego','Alba','c/ cruces','0','skdjbfuyjhs','30300','0');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('3','12121232F','bb','CC','SSSS','121212','DFDFDF','13472','1');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('6','121212','aa','nn','asdfa','68044654','adfa','13250','0');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('7','33333333O','DiegoP','AlbaP','c/ calle123','2323233','diego@gmail.com','33315','0');
REM INSERTING into INCOMES_EXPENSES
SET DEFINE OFF;
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1868',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1912','306','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1869',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1913','955','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1870',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1914','685','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1871',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1915','459','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1872',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1916','737','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1873',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1917','235','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1874',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1918','195','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1875',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1919','153','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1876',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1920','609','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1877',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1921','246','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1878',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1922','788','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1879',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1923','81','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1880',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1924','127','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1881',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1925','336','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1882',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1926','457','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1883',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1927','832','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1884',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1928','121','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1885',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1929','674','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1886',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1930','496','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1887',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1931','423','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1888',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1932','614','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1889',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1933','488','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1890',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1934','577','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1891',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1935','850','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1892',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1936','301','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1893',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1937','259','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1894',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1938','857','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1895',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1939','431','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1896',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1940','849','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1897',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1941','261','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1898',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1942','411','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1899',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1943','801','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1900',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1944','118','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1901',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1945','134','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1902',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1946','817','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1903',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1947','867','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1904',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1948','713','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1905',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1949','796','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1906',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1950','869','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1907',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1951','548','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1908',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1952','530','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1909',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1953','555','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1910',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1954','49','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1911',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1955','645','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1912',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1956','916','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1913',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1957','802','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1914',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1958','962','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1915',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1959','310','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1916',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1960','514','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1917',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1961','332','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1918',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1962','830','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1919',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1963','771','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1920',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1964','656','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1921',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1965','410','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1922',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1966','339','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1923',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1967','424','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1924',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1968','82','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1925',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1969','306','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1926',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1970','889','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1927',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1971','500','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1928',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1972','62','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1929',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1973','546','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1930',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1974','986','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1931',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1975','79','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1932',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1976','337','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1933',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1977','976','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1934',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1978','376','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1935',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1979','301','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1936',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1980','595','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1937',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1981','762','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1938',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1982','147','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1939',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1983','844','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1940',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1984','478','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1941',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1985','170','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1942',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1986','218','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1943',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1987','125','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1944',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1988','793','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1945',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1989','62','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1946',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1990','562','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1947',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1991','697','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1948',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1992','762','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1949',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1993','451','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1950',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1994','498','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1951',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1995','4','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1952',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1996','477','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1953',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1997','728','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1954',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1998','263','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1955',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1999','71','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1956',to_date('24/01/19','DD/MM/RR'),'1','0','0','test income 000','129,35','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1957',to_date('24/01/19','DD/MM/RR'),'1','1000','0','test expense 000','10,23','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1958',to_date('24/01/19','DD/MM/RR'),'1','2','2','test pp 000','50,34','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1959',to_date('24/01/19','DD/MM/RR'),'1','0','1','Luis','11000,26','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1753',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1791','110','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1754',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1792','246','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1755',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1793','617','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1756',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1794','538','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1757',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1795','887','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1758',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1796','931','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1759',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1797','530','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1760',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1798','780','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1761',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1799','60','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1762',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1800','360','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1763',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1801','942','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1764',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1802','298','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1765',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1803','313','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1766',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1804','342','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1767',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1805','913','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1768',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1806','683','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1769',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1807','848','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1770',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1808','861','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1771',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1809','711','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1772',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1810','394','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1773',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1811','466','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1774',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1812','7','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1775',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1813','793','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1776',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1814','522','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1777',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1815','976','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1778',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1816','382','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1779',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1817','11','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1780',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1818','464','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1781',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1819','117','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1782',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1822','758','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1783',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1823','974','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1784',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1824','482','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1785',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1826','139','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1786',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1828','669','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1787',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1829','42','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1788',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1830','188','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1789',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1831','121','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1790',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1832','455','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1791',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1833','819','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1792',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1834','635','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1793',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1835','777','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1794',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1836','823','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1795',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1837','891','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1796',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1838','710','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1797',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1839','535','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1798',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1840','474','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1799',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1841','875','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1800',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1842','896','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1801',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1843','490','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1802',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1844','122','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1803',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1845','656','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1804',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1846','612','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1805',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1847','127','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1806',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1848','212','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1807',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1849','825','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1808',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1850','185','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1809',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1851','265','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1810',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1852','423','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1811',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1853','744','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1812',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1854','391','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1813',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1855','596','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1814',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1856','824','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1815',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1857','468','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1816',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1858','721','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1817',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1859','393','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1818',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1860','434','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1819',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1861','441','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1820',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1862','865','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1821',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1863','480','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1822',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1864','806','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1823',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1865','714','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1824',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1866','169','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1825',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1867','223','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1826',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1868','741','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1827',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1869','263','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1828',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1870','211','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1829',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1872','659','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1830',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1873','136','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1831',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1874','627','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1832',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1875','12','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1833',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1876','819','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1834',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1877','282','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1835',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1878','115','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1836',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1879','81','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1837',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1880','260','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1838',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1881','806','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1839',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1882','776','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1840',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1883','908','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1841',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1884','163','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1842',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1885','108','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1843',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1887','127','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1844',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1888','496','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1845',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1889','344','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1846',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1890','575','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1847',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1891','597','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1848',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1892','958','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1849',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1893','76','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1850',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1894','532','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1851',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1895','819','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1852',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1896','970','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1853',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1897','909','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1854',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1898','315','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1855',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1899','780','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1856',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1900','168','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1857',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1901','519','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1858',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1902','801','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1859',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1903','825','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1860',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1904','400','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1861',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1905','922','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1862',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1906','104','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1863',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1907','927','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1864',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1908','214','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1865',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1909','305','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1866',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1910','691','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1867',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1911','975','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1637',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1674','431','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1638',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1675','903','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1639',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1676','603','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1640',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1677','659','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1641',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1678','867','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1642',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1679','58','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1643',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1680','342','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1644',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1681','187','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1645',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1682','416','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1646',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1683','245','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1647',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1684','718','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1648',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1685','831','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1649',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1686','520','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1650',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1687','325','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1651',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1688','833','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1652',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1689','371','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1653',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1690','751','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1654',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1691','946','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1655',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1692','520','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1656',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1693','159','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1657',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1694','638','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1658',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1695','499','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1659',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1696','193','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1660',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1697','841','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1661',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1698','853','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('239',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 255','597','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('240',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 256','570','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('241',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 257','613','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('242',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 258','309','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('243',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 259','163','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('244',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 260','470','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('245',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 261','381','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('246',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 262','883','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('247',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 263','654','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('248',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 264','159','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('249',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 265','45','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('250',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 266','153','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('251',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 267','134','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('252',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 268','343','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('253',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 269','969','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('254',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 270','828','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('255',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 271','720','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('256',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 272','417','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('257',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 273','715','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('258',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 274','288','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('259',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 275','709','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('260',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 276','894','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('261',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 277','504','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('262',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 278','641','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('263',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 279','590','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('264',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 280','859','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('265',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 281','522','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('266',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 282','318','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('267',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 283','829','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('268',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 284','504','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('269',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 285','296','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('270',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 286','787','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('271',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 287','772','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('272',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 288','325','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('273',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 289','765','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('274',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 290','462','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('275',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 291','650','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('276',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 292','580','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('277',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 293','811','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('278',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 294','436','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('279',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 295','935','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('280',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 296','975','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('281',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 297','825','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('282',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 298','373','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('283',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 299','60','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('284',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 300','58','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('285',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 301','730','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('286',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 302','580','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('287',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 303','661','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('288',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 304','269','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('289',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 305','905','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('290',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 306','909','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('291',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 307','254','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('292',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 308','57','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('293',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 309','535','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('294',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 310','25','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('295',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 311','443','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('296',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 312','186','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('297',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 313','863','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('298',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 314','889','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('299',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 315','760','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('300',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 316','437','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('301',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 317','709','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('302',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 318','194','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('303',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 319','233','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('304',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 320','451','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('305',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 321','638','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('306',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 322','895','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('307',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 323','878','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('308',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 324','227','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('309',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 325','200','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('310',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 326','769','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('311',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 327','950','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('312',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 328','571','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('313',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 329','48','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('314',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 330','633','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('315',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 331','846','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('316',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 332','44','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('317',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 333','378','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('318',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 334','54','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('319',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 335','187','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('320',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 337','542','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('321',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 338','818','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('322',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 339','772','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('323',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 340','357','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('324',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 342','921','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('325',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 343','586','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('326',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 344','819','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('327',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 345','720','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('328',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 346','855','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('329',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 347','129','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('330',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 348','195','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('331',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 349','104','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('332',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 350','202','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('333',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 351','240','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('334',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 352','451','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('335',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 353','118','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('336',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 354','350','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('337',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 355','475','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('338',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 356','744','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('339',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 357','69','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('340',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 358','979','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('341',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 359','512','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('342',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 360','799','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('343',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 361','406','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('344',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 362','822','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('345',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 363','212','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('346',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 364','491','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('347',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 365','318','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('348',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 366','886','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('349',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 367','480','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('350',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 368','332','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('351',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 369','964','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('352',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 370','182','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('353',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 371','274','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('354',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 372','772','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('355',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 373','464','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('121',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 134','99','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('122',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 135','537','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('123',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 136','358','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('124',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 137','555','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('125',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 138','582','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('126',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 139','963','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('127',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 140','69','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('128',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 141','111','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('129',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 142','470','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('130',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 144','405','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('131',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 145','830','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('132',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 146','6','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('133',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 147','700','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('134',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 148','362','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('135',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 149','785','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('136',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 150','528','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('137',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 151','17','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('138',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 152','914','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('139',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 153','390','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('140',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 154','890','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('141',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 155','173','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('142',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 156','547','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('143',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 157','804','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('144',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 158','649','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('145',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 159','110','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('146',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 160','274','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('147',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 161','841','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('148',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 162','748','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('149',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 163','474','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('150',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 164','42','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('151',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 165','661','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('152',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 166','951','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('153',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 167','672','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('154',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 168','220','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('155',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 169','43','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('156',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 170','431','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('157',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 171','471','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('158',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 173','822','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('159',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 174','197','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('160',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 175','663','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('161',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 176','436','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('162',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 177','578','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('163',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 178','702','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('164',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 179','88','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('165',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 180','843','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('166',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 181','484','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('167',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 182','288','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('168',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 183','931','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('169',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 184','50','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('170',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 185','733','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('171',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 186','724','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('172',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 187','957','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('173',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 188','63','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('174',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 189','31','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('175',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 190','244','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('176',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 191','329','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('177',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 192','308','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('178',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 193','12','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('179',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 194','117','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('180',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 195','662','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('181',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 196','226','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('182',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 197','459','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('183',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 198','199','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('184',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 199','924','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('185',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 200','5','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('186',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 201','854','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('187',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 202','878','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('188',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 203','775','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('189',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 204','879','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('190',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 205','122','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('191',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 206','306','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('192',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 207','494','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('193',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 208','665','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('194',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 209','709','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('195',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 210','756','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('196',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 211','341','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('197',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 212','711','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('198',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 213','881','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('199',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 214','751','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('200',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 215','588','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('201',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 216','308','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('202',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 217','113','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('203',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 218','978','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('204',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 219','972','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('205',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 220','877','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('206',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 221','270','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('207',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 222','66','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('208',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 223','208','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('209',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 224','498','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('210',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 225','769','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('211',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 226','994','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('212',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 227','821','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('213',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 228','587','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('214',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 229','83','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('215',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 231','486','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('216',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 232','95','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('217',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 233','593','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('218',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 234','328','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('219',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 235','806','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('220',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 236','148','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('221',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 237','336','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('222',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 238','716','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('223',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 239','477','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('224',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 240','872','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('225',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 241','946','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('226',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 242','41','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('227',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 243','74','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('228',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 244','968','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('229',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 245','308','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('230',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 246','84','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('231',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 247','116','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('232',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 248','481','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('233',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 249','366','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('234',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 250','472','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('235',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 251','951','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('236',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 252','446','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('237',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 253','799','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('238',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 254','383','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('3',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 5','680','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('4',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 8','376','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('5',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 9','117','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('6',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 10','747','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('7',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 11','875','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('8',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 12','416','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('9',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 13','760','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('10',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 14','231','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1','412','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('2',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 4','625','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('11',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 15','426','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('12',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 16','484','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('13',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 17','560','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('14',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 18','368','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('15',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 19','936','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('16',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 20','285','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('17',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 21','543','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('18',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 22','496','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('19',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 23','102','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('20',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 24','789','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('21',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 25','74','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('22',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 26','489','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('23',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 27','564','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('24',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 28','679','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('25',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 29','551','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('26',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 30','559','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('27',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 31','518','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('28',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 32','941','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('29',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 33','414','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('30',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 34','232','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('31',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 35','543','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('32',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 36','741','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('33',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 37','452','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('34',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 38','402','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('35',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 39','384','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('36',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 40','507','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('37',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 41','668','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('38',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 42','806','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('39',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 43','592','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('40',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 44','249','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('41',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 45','392','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('42',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 46','240','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('43',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 47','231','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('44',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 49','453','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('45',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 50','647','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('46',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 51','634','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('47',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 52','756','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('48',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 53','4','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('49',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 55','983','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('50',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 56','496','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('51',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 57','123','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('52',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 58','117','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('53',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 59','871','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('54',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 60','659','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('55',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 61','711','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('56',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 62','781','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('57',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 63','836','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('58',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 64','280','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('59',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 65','405','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('60',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 66','18','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('61',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 67','372','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('62',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 69','6','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('63',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 70','966','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('64',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 71','994','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('65',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 73','863','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('66',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 74','937','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('67',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 76','180','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('68',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 78','516','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('69',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 79','15','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('70',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 80','295','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('71',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 81','267','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('72',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 82','655','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('73',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 83','114','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('74',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 84','215','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('75',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 85','467','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('76',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 86','190','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('77',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 87','625','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('78',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 88','891','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('79',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 89','107','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('80',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 90','829','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('81',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 91','52','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('82',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 92','644','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('83',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 93','189','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('84',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 94','273','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('85',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 95','881','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('86',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 96','433','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('87',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 97','268','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('88',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 98','289','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('89',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 99','650','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('90',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 100','990','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('91',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 102','784','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('92',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 104','526','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('93',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 105','223','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('94',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 106','925','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('95',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 107','581','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('96',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 108','540','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('97',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 110','972','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('98',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 111','85','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('99',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 112','148','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('100',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 113','420','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('101',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 114','314','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('102',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 115','715','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('103',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 116','131','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('104',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 117','315','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('105',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 118','177','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('106',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 119','515','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('107',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 120','723','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('108',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 121','704','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('109',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 122','497','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('110',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 123','406','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('111',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 124','487','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('112',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 125','912','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('113',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 126','281','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('114',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 127','88','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('115',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 128','657','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('116',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 129','132','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('117',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 130','918','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('118',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 131','191','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('119',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 132','149','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('120',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 133','869','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1430',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1467','21','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1431',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1468','787','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1432',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1469','898','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1433',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1470','270','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1434',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1471','370','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1435',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1472','998','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1436',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1473','113','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1437',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1474','798','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1438',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1475','799','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1439',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1476','903','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1440',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1477','767','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1441',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1478','331','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1442',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1479','287','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1443',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1480','734','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1444',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1481','365','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1445',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1482','62','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1446',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1483','861','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1447',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1484','631','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1448',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1485','980','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1449',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1486','33','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1450',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1487','305','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1451',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1488','985','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1452',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1489','970','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1453',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1490','673','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1454',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1491','82','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1455',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1492','110','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1456',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1493','736','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1457',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1494','345','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1458',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1495','497','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1459',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1496','89','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1460',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1497','851','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1461',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1498','182','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1462',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1499','634','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1463',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1500','621','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1464',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1501','517','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1465',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1502','118','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1466',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1503','105','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1467',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1504','740','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1468',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1505','665','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1469',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1506','486','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1470',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1507','404','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1471',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1508','95','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1472',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1509','547','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1473',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1510','468','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1474',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1511','835','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1475',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1512','992','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1476',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1513','364','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1477',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1514','112','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1478',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1515','496','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1479',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1516','35','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1480',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1517','620','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1481',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1518','806','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1482',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1519','931','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1483',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1520','725','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1484',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1521','889','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1485',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1522','48','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1486',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1523','897','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1487',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1524','20','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1488',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1525','978','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1489',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1526','384','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1490',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1527','925','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1491',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1528','829','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1492',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1529','280','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1493',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1530','765','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1494',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1531','498','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1495',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1532','763','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1496',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1533','949','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1497',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1534','43','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1498',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1535','446','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1499',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1536','516','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1500',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1537','646','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1501',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1538','329','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1502',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1539','286','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1503',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1540','427','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1504',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1541','835','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1505',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1542','13','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1506',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1543','878','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1507',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1544','10','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1508',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1545','414','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1509',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1546','168','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1510',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1547','141','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1511',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1548','269','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1512',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1549','265','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1513',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1550','369','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1514',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1551','848','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1515',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1552','412','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1516',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1553','848','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1517',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1554','215','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1518',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1555','598','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1519',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1556','121','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1520',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1557','987','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1291',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1328','831','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1292',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1329','115','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1293',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1330','119','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1294',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1331','430','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1295',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1332','772','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1296',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1333','840','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1297',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1334','264','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1298',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1335','458','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1299',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1336','11','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1300',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1337','491','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1301',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1338','33','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1302',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1339','93','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1303',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1340','596','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1304',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1341','263','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1305',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1342','149','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1306',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1343','388','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1307',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1344','815','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1308',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1345','79','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1309',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1346','188','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1310',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1347','745','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1311',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1348','995','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1312',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1349','463','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1313',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1350','835','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1314',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1351','134','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1315',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1352','240','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('850',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 878','231','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('851',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 879','691','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('852',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 880','139','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('853',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 881','397','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('854',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 882','466','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('855',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 883','346','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('856',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 884','237','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('857',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 885','640','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('858',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 886','711','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('859',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 887','684','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('860',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 888','961','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('861',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 889','946','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('862',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 890','996','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('863',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 891','243','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('864',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 892','483','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('865',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 893','97','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('866',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 894','36','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('867',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 895','567','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('868',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 896','55','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('869',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 897','457','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('870',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 898','173','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('871',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 899','960','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('872',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 900','73','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('873',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 901','236','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('874',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 902','236','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('875',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 903','365','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('876',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 904','330','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('877',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 905','73','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('878',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 906','871','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('879',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 907','196','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('880',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 908','145','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('881',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 909','422','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('882',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 910','577','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('883',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 911','17','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('884',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 912','560','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('885',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 913','419','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('886',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 914','742','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('887',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 915','446','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('888',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 916','939','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('889',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 917','831','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('890',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 918','352','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('891',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 919','445','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('892',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 920','302','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('893',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 921','436','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('894',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 922','131','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('895',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 923','515','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('896',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 924','400','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('897',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 925','872','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('898',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 926','121','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('899',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 927','822','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('900',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 928','661','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('901',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 929','967','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('902',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 930','198','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('903',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 931','494','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('904',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 932','755','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('905',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 933','764','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('906',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 934','974','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('907',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 935','854','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('908',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 936','334','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('909',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 937','63','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('910',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 938','281','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('911',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 939','43','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('912',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 940','769','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('913',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 941','218','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('914',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 942','341','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('915',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 943','937','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('916',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 944','678','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('917',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 945','115','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('918',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 946','965','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('919',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 947','609','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('920',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 948','266','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('921',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 949','802','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('922',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 950','181','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('923',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 951','941','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('924',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 952','939','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('925',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 953','403','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('926',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 954','260','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('927',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 955','620','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('928',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 956','297','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('929',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 957','913','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('930',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 958','685','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('931',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 959','144','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('932',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 960','679','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('933',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 961','983','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('934',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 962','454','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('935',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 963','453','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('936',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 964','262','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('937',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 965','384','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('938',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 966','560','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('939',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 967','291','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('940',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 968','896','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('941',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 969','201','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('942',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 970','193','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('708',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 736','299','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('709',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 737','563','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('710',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 738','956','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('711',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 739','456','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('712',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 740','592','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('713',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 741','522','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('714',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 742','286','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('715',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 743','507','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('716',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 744','71','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('717',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 745','230','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('718',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 746','556','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('719',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 747','955','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('720',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 748','512','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('721',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 749','138','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('722',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 750','219','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('723',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 751','910','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('724',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 752','948','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('725',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 753','22','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('726',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 754','224','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('727',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 755','684','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('728',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 756','956','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('729',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 757','131','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('730',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 758','589','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1316',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1353','932','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1317',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1354','450','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1318',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1355','125','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1319',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1356','718','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1320',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1357','526','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1321',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1358','233','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1322',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1359','899','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1323',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1360','237','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1324',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1361','326','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1325',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1362','68','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1326',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1363','304','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1327',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1364','93','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1328',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1365','949','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1329',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1366','88','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1330',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1367','581','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1331',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1368','421','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1332',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1369','700','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1333',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1370','69','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1334',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1371','468','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1335',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1372','652','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1336',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1373','198','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1337',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1374','127','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1338',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1375','548','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1339',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1376','80','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1340',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1377','421','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1341',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1378','507','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1342',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1379','959','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1343',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1380','724','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1344',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1381','64','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1345',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1382','8','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1346',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1383','245','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1347',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1384','954','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1348',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1385','663','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1349',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1386','569','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1350',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1387','308','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1351',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1388','786','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1352',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1389','651','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1353',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1390','642','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1354',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1391','706','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1355',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1392','901','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1356',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1393','552','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1357',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1394','656','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1358',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1395','65','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1359',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1396','84','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1360',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1397','487','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1361',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1398','283','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1362',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1399','845','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1363',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1400','400','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1364',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1401','810','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1365',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1402','447','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1366',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1403','353','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1367',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1404','567','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1368',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1405','83','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1369',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1406','914','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1370',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1407','581','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1371',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1408','560','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1372',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1409','287','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1373',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1410','179','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1374',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1411','946','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1375',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1412','135','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1376',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1413','196','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1377',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1414','231','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1378',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1415','230','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1379',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1416','363','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1380',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1417','289','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1381',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1418','409','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1382',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1419','314','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1383',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1420','664','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1384',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1421','981','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1385',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1422','507','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1386',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1423','966','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1387',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1424','3','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1388',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1425','673','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1389',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1426','528','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1390',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1427','425','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1391',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1428','727','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1392',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1429','823','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1393',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1430','457','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1394',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1431','337','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1395',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1432','774','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1396',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1433','480','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1397',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1434','937','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1398',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1435','911','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1399',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1436','701','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1400',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1437','905','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1401',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1438','718','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1402',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1439','437','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1403',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1440','167','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1404',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1441','302','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1405',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1442','249','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1175',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1209','3','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1176',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1210','394','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1177',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1211','559','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1178',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1212','22','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1179',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1213','838','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1180',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1214','507','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1181',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1215','225','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1182',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1216','445','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1183',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1217','52','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1184',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1218','310','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1185',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1219','288','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1186',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1220','873','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1187',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1221','192','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1188',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1222','157','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1189',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1223','922','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1190',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1224','148','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1191',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1225','527','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1192',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1226','414','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1193',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1227','988','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1194',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1228','46','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1195',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1229','19','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1196',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1231','181','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1197',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1232','704','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1198',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1233','449','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1199',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1234','768','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1200',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1235','367','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1201',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1236','840','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1202',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1237','663','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1203',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1238','445','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1204',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1239','70','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1205',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1240','760','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1206',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1241','12','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1207',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1242','915','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1208',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1243','188','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1209',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1244','297','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1210',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1245','689','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1211',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1246','358','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1212',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1247','881','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1213',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1248','878','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1214',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1249','311','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1215',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1251','561','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1216',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1252','84','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1217',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1253','362','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1218',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1254','411','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1219',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1255','340','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1220',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1257','100','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1221',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1258','822','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1222',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1259','691','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1223',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1260','979','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1224',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1261','319','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1225',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1262','810','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1226',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1263','646','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1227',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1264','294','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1228',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1265','464','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1229',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1266','290','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1230',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1267','73','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1231',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1268','916','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1232',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1269','201','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1233',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1270','617','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1234',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1271','79','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1235',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1272','658','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1236',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1273','186','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1237',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1274','975','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1238',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1275','959','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1239',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1276','850','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1240',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1277','747','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1241',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1278','405','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1242',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1279','783','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1243',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1280','566','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1244',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1281','177','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1245',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1282','603','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1246',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1283','500','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1247',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1284','959','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1248',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1285','445','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1249',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1286','994','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1250',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1287','122','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1251',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1288','786','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1252',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1289','915','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1253',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1290','476','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1254',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1291','376','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1255',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1292','73','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1256',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1293','209','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1257',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1294','698','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1258',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1295','668','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1259',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1296','722','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1260',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1297','783','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1261',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1298','587','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1262',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1299','495','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1263',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1300','331','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1264',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1301','490','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1265',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1302','86','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1266',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1303','991','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1267',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1304','610','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1268',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1305','92','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1269',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1306','467','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1270',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1307','572','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1271',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1308','479','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1272',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1309','350','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1273',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1310','125','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1274',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1311','313','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1275',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1312','637','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1276',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1313','360','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1277',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1314','31','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1278',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1315','394','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1279',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1316','913','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1280',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1317','626','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1281',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1318','907','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1282',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1319','563','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1283',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1320','322','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1284',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1321','969','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1285',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1322','665','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1286',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1323','133','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1287',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1324','602','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1288',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1325','338','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1289',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1326','952','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1290',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1327','567','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1059',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1087','867','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1060',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1088','865','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1061',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1089','692','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1062',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1090','350','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1063',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1091','567','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1064',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1092','759','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1065',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1093','384','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1066',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1094','186','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1067',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1095','322','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1068',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1097','529','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1069',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1098','903','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1070',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1099','278','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1071',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1100','145','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1072',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1101','329','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1073',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1102','975','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1074',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1103','212','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1075',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1104','533','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1076',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1105','302','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1077',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1106','59','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1078',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1107','550','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1079',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1108','44','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1080',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1109','529','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1081',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1110','287','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1082',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1111','512','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1083',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1112','255','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1084',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1113','601','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1085',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1114','461','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1086',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1115','437','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1087',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1116','280','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1088',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1117','242','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1089',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1118','763','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1090',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1119','508','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1091',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1120','580','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1092',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1122','55','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1093',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1123','122','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1094',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1125','783','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1095',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1127','391','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1096',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1128','530','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1097',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1129','573','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1098',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1130','922','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1099',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1131','477','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1100',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1132','952','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1101',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1133','573','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1102',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1134','301','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1103',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1135','628','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1104',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1136','109','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1105',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1137','317','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1106',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1138','634','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1107',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1139','241','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1108',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1140','494','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1109',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1141','621','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1110',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1142','178','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1111',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1143','989','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1112',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1144','115','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1113',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1145','36','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1114',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1146','756','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1115',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1147','428','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1116',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1148','223','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1117',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1149','305','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1118',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1150','74','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1119',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1151','176','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1120',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1152','511','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1121',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1154','275','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1122',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1155','524','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1123',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1156','384','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1124',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1157','178','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1125',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1158','4','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1126',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1159','497','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1127',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1160','193','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1128',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1161','712','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1129',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1162','883','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1130',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1163','500','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1131',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1164','70','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1132',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1165','524','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1133',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1166','486','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1134',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1167','647','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1135',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1168','999','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1136',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1169','749','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1137',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1170','765','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1138',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1171','269','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1139',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1172','194','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1140',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1173','246','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1141',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1174','1','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1142',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1176','277','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1143',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1177','536','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1144',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1178','255','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1145',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1179','376','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1146',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1180','466','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1147',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1181','866','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1148',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1182','460','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1149',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1183','612','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1150',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1184','196','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1151',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1185','758','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1152',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1186','903','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1153',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1187','231','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1154',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1188','793','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1155',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1189','242','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1156',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1190','140','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1157',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1191','673','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1158',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1192','848','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1159',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1193','155','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1160',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1194','913','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1161',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1195','247','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1162',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1196','963','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1163',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1197','966','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1164',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1198','169','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1165',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1199','428','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1166',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1200','764','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1167',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1201','146','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1168',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1202','605','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1169',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1203','226','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1170',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1204','438','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1171',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1205','634','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1172',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1206','304','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1173',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1207','13','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1174',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1208','677','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('943',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 971','949','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('944',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 972','778','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('945',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 973','34','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('946',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 974','740','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('947',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 975','304','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('948',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 976','15','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('949',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 977','759','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('950',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 978','605','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('951',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 979','22','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('952',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 980','482','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('953',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 981','382','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('954',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 982','130','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('955',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 983','517','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('956',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 984','975','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('957',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 985','725','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('958',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 986','780','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('959',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 987','500','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('960',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 988','508','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('961',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 989','862','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('962',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 990','3','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('963',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 991','627','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('964',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 992','474','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('965',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 993','72','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('966',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 994','93','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('967',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 995','157','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('968',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 996','825','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('969',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 997','353','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('970',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 998','565','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('971',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 999','746','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('972',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1000','242','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('973',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1001','875','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('974',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1002','615','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('975',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1003','818','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('976',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1004','770','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('977',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1005','396','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('978',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1006','273','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('979',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1007','920','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('980',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1008','357','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('981',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1009','13','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('982',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1010','43','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('983',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1011','726','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('984',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1012','384','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('985',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1013','282','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('986',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1014','874','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('987',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1015','979','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('988',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1016','178','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('989',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1017','310','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('990',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1018','372','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('991',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1019','77','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('992',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1020','941','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('993',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1021','102','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('994',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1022','583','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('995',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1023','129','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('996',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1024','318','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('997',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1025','580','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('998',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1026','742','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('999',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1027','986','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1000',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1028','457','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1001',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1029','873','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1002',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1030','920','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1003',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1031','392','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1004',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1032','194','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1005',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1033','627','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1006',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1034','323','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1007',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1035','395','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1008',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1036','746','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1009',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1037','570','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1010',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1038','393','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1011',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1039','709','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1012',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1040','170','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1013',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1041','499','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1014',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1042','995','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1015',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1043','145','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1016',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1044','179','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1017',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1045','59','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1018',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1046','782','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1019',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1047','765','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1020',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1048','572','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1021',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1049','14','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1022',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1050','689','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1023',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1051','758','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1024',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1052','257','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1025',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1053','890','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1026',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1054','397','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1027',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1055','957','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1028',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1056','736','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1029',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1057','216','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1030',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1058','297','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1031',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1059','873','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1032',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1060','773','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1033',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1061','666','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1034',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1062','421','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1035',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1063','597','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1036',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1064','809','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1037',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1065','615','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1038',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1066','890','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1039',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1067','428','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1040',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1068','581','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1041',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1069','878','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1042',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1070','868','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1043',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1071','326','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1044',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1072','159','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1045',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1073','524','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1046',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1074','714','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1047',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1075','575','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1048',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1076','693','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1049',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1077','973','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1050',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1078','709','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1051',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1079','851','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1052',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1080','134','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1053',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1081','459','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1054',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1082','493','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1055',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1083','925','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1056',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1084','329','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1057',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1085','837','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1058',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1086','848','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('826',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 854','31','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('827',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 855','815','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('828',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 856','724','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('829',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 857','240','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('830',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 858','567','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('831',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 859','949','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('832',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 860','669','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('833',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 861','529','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('834',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 862','979','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('835',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 863','664','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('836',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 864','115','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('837',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 865','530','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('838',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 866','879','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('839',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 867','440','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('840',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 868','517','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('841',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 869','919','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('842',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 870','206','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('843',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 871','33','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('844',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 872','317','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('845',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 873','771','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('846',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 874','380','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('847',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 875','459','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('848',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 876','348','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('849',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 877','731','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1662',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1699','383','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1663',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1700','197','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1664',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1701','668','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1665',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1702','996','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1666',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1703','683','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1667',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1704','238','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1668',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1705','397','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1669',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1706','378','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1670',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1707','955','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1671',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1708','953','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1672',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1709','681','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1673',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1710','561','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1674',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1711','217','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1675',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1712','714','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1676',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1713','56','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1677',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1714','67','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1678',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1715','108','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1679',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1716','536','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1680',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1717','114','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1681',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1718','300','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1682',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1719','460','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1683',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1720','426','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1684',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1721','542','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1685',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1722','388','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1686',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1723','812','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1687',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1724','71','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1688',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1725','728','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1689',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1726','615','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1690',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1727','872','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1691',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1728','203','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1692',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1729','661','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1693',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1730','296','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1694',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1731','986','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1695',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1732','572','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1696',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1733','376','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1697',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1734','711','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1698',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1735','708','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1699',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1736','390','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1700',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1737','314','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1701',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1738','792','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1702',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1739','480','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1703',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1740','341','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1704',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1741','769','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1705',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1742','592','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1706',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1743','283','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1707',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1744','986','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1708',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1745','765','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1709',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1746','634','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1710',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1747','394','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1711',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1748','405','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1712',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1749','141','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1713',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1750','585','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1714',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1751','402','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1715',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1752','260','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1716',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1753','343','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1717',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1754','275','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1718',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1755','629','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1719',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1756','551','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1720',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1757','711','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1721',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1758','620','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1722',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1759','1000','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1723',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1760','611','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1724',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1761','91','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1725',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1762','459','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1726',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1764','914','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1727',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1765','126','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1728',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1766','744','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1729',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1767','485','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1730',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1768','283','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1731',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1769','786','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1732',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1770','739','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1733',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1771','426','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1734',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1772','711','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1735',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 1773','203','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1736',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1774','547','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1737',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1775','787','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1738',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1776','799','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1739',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1777','522','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1740',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1778','845','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1741',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1779','412','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1742',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1780','812','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1743',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1781','392','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1744',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1782','935','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1745',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1783','160','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1746',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1784','818','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1747',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1785','752','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1748',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1786','988','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1749',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1787','304','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1750',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1788','623','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1751',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1789','139','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1752',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1790','328','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1521',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1558','850','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1522',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1559','7','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1523',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1560','393','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1524',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1561','742','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1525',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1562','311','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1526',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1563','512','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1527',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1564','253','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1528',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1565','453','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1529',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1566','215','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1530',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1567','456','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1531',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1568','929','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1532',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1569','779','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1533',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1570','869','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1534',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1571','370','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1535',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1572','23','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1536',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1573','471','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1537',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1574','479','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1538',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1575','310','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1539',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1576','955','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1540',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1577','617','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1541',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1578','882','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1542',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1579','838','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1543',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1580','31','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1544',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1581','976','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1545',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1582','580','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1546',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1583','520','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1547',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1584','496','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1548',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1585','132','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1549',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1586','525','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1550',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1587','922','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1551',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1588','601','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1552',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1589','430','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1553',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1590','252','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1554',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1591','695','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1555',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1592','711','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1556',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1593','127','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1557',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1594','842','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1558',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1595','325','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1559',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1596','454','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1560',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1597','316','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1561',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1598','138','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1562',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1599','551','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1563',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1600','495','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1564',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1601','947','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1565',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1602','912','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1566',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1603','940','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1567',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1604','972','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1568',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1605','527','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1569',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1606','651','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1570',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1607','127','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1571',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1608','531','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1572',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1609','666','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1573',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 1610','487','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1574',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1611','207','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1575',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1612','61','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1576',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1613','43','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1577',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1614','983','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1578',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1615','949','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1579',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1616','461','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1580',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1617','398','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1581',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 1618','28','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1582',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1619','323','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1583',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1620','313','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1584',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1621','141','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1585',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 1622','841','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1586',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 1623','654','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1587',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 1624','413','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1588',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1625','920','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1589',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1626','62','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1590',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1627','754','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1591',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 1628','878','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1592',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1629','913','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1593',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1630','692','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1594',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1631','326','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1595',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1632','820','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1596',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1633','259','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1597',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1634','227','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1598',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1635','367','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1599',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1636','676','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1600',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1637','542','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1601',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 1638','768','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1602',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1639','268','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1603',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 1640','761','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1604',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 1641','357','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1605',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1642','852','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1606',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1643','741','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1607',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 1644','426','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1608',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1645','501','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1609',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1646','209','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1610',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1647','982','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1611',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1648','866','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1612',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1649','170','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1613',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1650','148','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1614',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1651','380','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1615',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1652','734','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1616',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1653','622','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1617',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1654','717','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1618',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1655','269','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1619',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1656','590','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1620',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1657','549','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1621',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1658','960','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1622',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1659','836','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1623',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1660','866','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1624',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1661','746','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1625',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 1662','529','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1626',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1663','19','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1627',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1664','254','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1628',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 1665','836','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1629',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 1666','856','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1630',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 1667','732','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1631',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1668','76','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1632',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 1669','758','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1633',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 1670','902','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1634',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1671','467','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1635',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1672','171','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1636',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 1673','650','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1406',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1443','122','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1407',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1444','263','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1408',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 1445','14','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1409',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 1446','822','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1410',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 1447','24','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1411',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1448','30','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1412',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 1449','989','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1413',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 1450','930','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1414',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 1451','582','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1415',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 1452','354','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1416',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1453','43','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1417',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1454','969','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1418',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 1455','274','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1419',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 1456','993','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1420',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 1457','530','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1421',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 1458','34','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1422',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 1459','127','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1423',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 1460','748','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1424',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 1461','598','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1425',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 1462','281','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1426',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1463','491','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1427',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 1464','613','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1428',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 1465','302','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1429',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 1466','179','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('731',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 759','775','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('732',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 760','149','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('733',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 761','794','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('734',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 762','830','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('735',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 763','554','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('736',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 764','235','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('737',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 765','163','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('738',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 766','580','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('739',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 767','921','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('740',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 768','198','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('741',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 769','177','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('742',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 770','428','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('743',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 771','378','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('744',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 772','180','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('745',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 773','80','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('746',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 774','637','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('747',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 775','280','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('748',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 776','836','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('749',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 777','611','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('750',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 778','722','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('751',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 779','244','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('752',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 780','944','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('753',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 781','592','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('754',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 782','377','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('755',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 783','942','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('756',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 784','966','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('757',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 785','646','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('758',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 786','407','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('759',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 787','723','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('760',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 788','351','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('761',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 789','520','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('762',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 790','233','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('763',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 791','233','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('764',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 792','839','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('765',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 793','83','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('766',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 794','66','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('767',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 795','576','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('768',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 796','356','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('769',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 797','200','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('770',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 798','38','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('771',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 799','932','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('772',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 800','455','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('773',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 801','688','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('774',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 802','310','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('775',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 803','19','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('776',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 804','395','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('777',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 805','581','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('778',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 806','603','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('779',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 807','788','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('780',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 808','947','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('781',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 809','449','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('782',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 810','213','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('783',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 811','41','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('784',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 812','967','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('785',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 813','118','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('786',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 814','316','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('787',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 815','578','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('788',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 816','186','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('789',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 817','404','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('790',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 818','242','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('791',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 819','989','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('792',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 820','670','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('793',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 821','50','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('794',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 822','812','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('795',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 823','744','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('796',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 824','46','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('797',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 825','12','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('798',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 826','425','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('799',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 827','162','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('800',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 828','930','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('801',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 829','723','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('802',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 830','367','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('803',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 831','265','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('804',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 832','266','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('805',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 833','392','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('806',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 834','555','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('807',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 835','241','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('808',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 836','183','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('809',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 837','240','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('810',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 838','980','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('811',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 839','149','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('812',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 840','341','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('813',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 841','32','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('814',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 842','696','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('815',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 843','199','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('816',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 844','283','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('817',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 845','759','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('818',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 846','643','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('819',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 847','577','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('820',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 848','521','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('821',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 849','725','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('822',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 850','859','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('823',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 851','901','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('824',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 852','608','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('825',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 853','339','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('591',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 617','425','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('592',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 618','668','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('593',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 619','904','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('594',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 620','446','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('595',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 621','491','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('596',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 622','372','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('597',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 623','232','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('598',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 624','915','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('599',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 625','700','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('600',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 626','191','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('601',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 627','399','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('602',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 628','181','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('603',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 629','216','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('604',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 630','187','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('605',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 631','188','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('606',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 632','869','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('607',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 633','196','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('608',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 634','948','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('609',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 635','423','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('610',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 636','765','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('611',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 637','767','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('612',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 638','917','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('613',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 639','864','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('614',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 640','44','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('615',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 641','423','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('616',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 642','873','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('617',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 643','630','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('618',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 644','412','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('619',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 646','723','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('620',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 647','205','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('621',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 649','312','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('622',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 650','326','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('623',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 651','168','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('624',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 652','746','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('625',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 653','863','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('626',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 654','668','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('627',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 655','350','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('628',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 656','882','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('629',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 657','538','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('630',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 658','675','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('631',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 659','191','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('632',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 660','480','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('633',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 661','342','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('634',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 662','392','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('635',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 663','224','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('636',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 664','689','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('637',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 665','388','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('638',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 666','908','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('639',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 667','416','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('640',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 668','478','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('641',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 669','555','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('642',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 670','351','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('643',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 671','309','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('644',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 672','691','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('645',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 673','441','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('646',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 674','819','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('647',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 675','638','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('648',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 676','838','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('649',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 677','922','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('650',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 678','724','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('651',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 679','602','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('652',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 680','232','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('653',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 681','675','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('654',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 682','111','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('655',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 683','846','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('656',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 684','638','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('657',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 685','220','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('658',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 686','3','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('659',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 687','838','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('660',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 688','500','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('661',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 689','685','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('662',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 690','535','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('663',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 691','562','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('664',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 692','29','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('665',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 693','435','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('666',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 694','495','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('667',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 695','561','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('668',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 696','445','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('669',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 697','858','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('670',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 698','303','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('671',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 699','635','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('672',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 700','467','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('673',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 701','52','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('674',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 702','390','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('675',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 703','961','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('676',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 704','709','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('677',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 705','232','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('678',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 706','353','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('679',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 707','411','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('680',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 708','244','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('681',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 709','595','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('682',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 710','363','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('683',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 711','610','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('684',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 712','356','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('685',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 713','950','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('686',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 714','472','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('687',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 715','573','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('688',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 716','445','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('689',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 717','876','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('690',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 718','289','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('691',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 719','944','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('692',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 720','529','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('693',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 721','931','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('694',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 722','519','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('695',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 723','395','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('696',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 724','329','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('697',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 725','454','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('698',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 726','845','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('699',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 727','886','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('700',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 728','218','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('701',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 729','945','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('702',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 730','46','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('703',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 731','508','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('704',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 732','491','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('705',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 733','835','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('706',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 734','389','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('707',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 735','419','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('473',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 492','544','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('474',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 493','298','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('475',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 494','848','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('476',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 495','171','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('477',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 496','313','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('478',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 497','620','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('479',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 498','914','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('480',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 500','299','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('481',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 501','260','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('482',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 502','795','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('483',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 503','425','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('484',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 504','589','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('485',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 505','85','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('486',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 506','993','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('487',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 507','328','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('488',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 508','218','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('489',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 509','873','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('490',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 510','595','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('491',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 511','729','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('492',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 512','406','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('493',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 513','990','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('494',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 515','508','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('495',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 516','461','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('496',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 518','267','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('497',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 520','326','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('498',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 521','923','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('499',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 522','712','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('500',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 523','423','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('501',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 524','609','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('502',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 526','383','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('503',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 527','662','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('504',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 528','668','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('505',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 529','17','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('506',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 530','733','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('507',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 531','493','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('508',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 532','669','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('509',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 533','757','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('510',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 534','749','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('511',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 535','461','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('512',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 536','231','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('513',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 537','754','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('514',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 538','702','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('515',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 539','324','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('516',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 540','18','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('517',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 543','748','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('518',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 544','278','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('519',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 545','927','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('520',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 546','370','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('521',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 547','444','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('522',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 548','867','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('523',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 549','412','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('524',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 550','986','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('525',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 551','530','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('526',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 552','398','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('527',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 553','716','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('528',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 554','861','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('529',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 555','670','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('530',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 556','887','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('531',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 557','757','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('532',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 558','389','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('533',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 559','163','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('534',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 560','60','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('535',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 561','49','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('536',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 562','970','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('537',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 563','943','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('538',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 564','502','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('539',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 565','1','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('540',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 566','639','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('541',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 567','197','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('542',to_date('24/01/19','DD/MM/RR'),'2','1','0','multiple insert income 568','885','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('543',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 569','264','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('544',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 570','43','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('545',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 571','597','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('546',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 572','315','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('547',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 573','584','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('548',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 574','939','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('549',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 575','284','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('550',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 576','4','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('551',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 577','458','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('552',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 578','778','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('553',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 579','941','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('554',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 580','868','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('555',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 581','425','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('556',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 582','788','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('557',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 583','581','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('558',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 584','465','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('559',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 585','213','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('560',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 586','396','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('561',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 587','832','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('562',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 588','104','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('563',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 589','243','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('564',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 590','143','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('565',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 591','841','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('566',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 592','355','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('567',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 593','55','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('568',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 594','580','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('569',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 595','501','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('570',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 596','600','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('571',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 597','89','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('572',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 598','72','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('573',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 599','258','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('574',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 600','248','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('575',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 601','546','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('576',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 602','783','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('577',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 603','746','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('578',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 604','427','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('579',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 605','385','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('580',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 606','63','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('581',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 607','349','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('582',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 608','593','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('583',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 609','652','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('584',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 610','304','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('585',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 611','45','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('586',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 612','265','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('587',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 613','310','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('588',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 614','506','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('589',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 615','122','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('590',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 616','618','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('356',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 374','480','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('357',to_date('24/01/19','DD/MM/RR'),'2','1001','2','multiple insert expense 375','883','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('358',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 376','453','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('359',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 377','289','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('360',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 378','948','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('361',to_date('24/01/19','DD/MM/RR'),'2','0','1','multiple insert income 379','98','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('362',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 380','834','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('363',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 381','671','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('364',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 382','93','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('365',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 383','427','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('366',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 384','559','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('367',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 385','76','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('368',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 386','474','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('369',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 387','577','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('370',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 388','272','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('371',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 389','360','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('372',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 390','28','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('373',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 391','377','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('374',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 392','239','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('375',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 393','494','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('376',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 394','437','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('377',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 395','133','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('378',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 396','440','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('379',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 397','575','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('380',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 398','882','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('381',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 399','451','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('382',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 400','235','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('383',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 401','508','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('384',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 402','87','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('385',to_date('24/01/19','DD/MM/RR'),'1','1001','1','multiple insert expense 403','983','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('386',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 404','213','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('387',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 405','534','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('388',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 406','63','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('389',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 407','171','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('390',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 408','141','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('391',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 409','49','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('392',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 410','25','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('393',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 411','108','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('394',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 412','700','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('395',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 413','62','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('396',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 414','997','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('397',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 415','812','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('398',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 416','23','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('399',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 417','659','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('400',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 418','470','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('401',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 419','702','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('402',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 420','769','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('403',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 421','194','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('404',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 422','260','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('405',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 423','190','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('406',to_date('24/01/19','DD/MM/RR'),'2','1002','0','multiple insert expense 424','980','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('407',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 425','1','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('408',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 426','438','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('409',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 427','291','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('410',to_date('24/01/19','DD/MM/RR'),'1','0','1','multiple insert income 428','222','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('411',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 429','5','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('412',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 430','920','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('413',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 431','175','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('414',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 432','277','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('415',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 433','267','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('416',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 434','743','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('417',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 435','592','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('418',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 436','251','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('419',to_date('24/01/19','DD/MM/RR'),'2','1002','2','multiple insert expense 437','846','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('420',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 438','592','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('421',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 439','515','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('422',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 440','848','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('423',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 441','421','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('424',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 442','699','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('425',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 443','667','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('426',to_date('24/01/19','DD/MM/RR'),'2','0','0','multiple insert income 445','204','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('427',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 446','21','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('428',to_date('24/01/19','DD/MM/RR'),'2','0','2','multiple insert income 447','479','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('429',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 448','399','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('430',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 449','233','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('431',to_date('24/01/19','DD/MM/RR'),'1','1000','2','multiple insert expense 450','737','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('432',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 451','820','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('433',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 452','321','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('434',to_date('24/01/19','DD/MM/RR'),'2','1','1','multiple insert income 453','368','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('435',to_date('24/01/19','DD/MM/RR'),'2','2','2','multiple insert income 454','61','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('436',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 455','316','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('437',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 456','234','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('438',to_date('24/01/19','DD/MM/RR'),'1','1','0','multiple insert income 457','573','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('439',to_date('24/01/19','DD/MM/RR'),'2','2','0','multiple insert income 458','913','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('440',to_date('24/01/19','DD/MM/RR'),'2','1000','0','multiple insert expense 459','67','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('441',to_date('24/01/19','DD/MM/RR'),'1','2','2','multiple insert income 460','143','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('442',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 461','233','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('443',to_date('24/01/19','DD/MM/RR'),'1','1002','2','multiple insert expense 462','268','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('444',to_date('24/01/19','DD/MM/RR'),'1','0','2','multiple insert income 463','228','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('445',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 464','888','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('446',to_date('24/01/19','DD/MM/RR'),'2','1','2','multiple insert income 465','284','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('447',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 466','7','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('448',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 467','45','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('449',to_date('24/01/19','DD/MM/RR'),'1','1001','0','multiple insert expense 468','993','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('450',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 469','688','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('451',to_date('24/01/19','DD/MM/RR'),'2','1001','0','multiple insert expense 470','181','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('452',to_date('24/01/19','DD/MM/RR'),'1','1','2','multiple insert income 471','23','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('453',to_date('24/01/19','DD/MM/RR'),'2','1000','2','multiple insert expense 472','905','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('454',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 473','549','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('455',to_date('24/01/19','DD/MM/RR'),'2','1001','1','multiple insert expense 474','390','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('456',to_date('24/01/19','DD/MM/RR'),'1','0','0','multiple insert income 475','220','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('457',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 476','591','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('458',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 477','912','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('459',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 478','422','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('460',to_date('24/01/19','DD/MM/RR'),'1','1002','0','multiple insert expense 479','265','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('461',to_date('24/01/19','DD/MM/RR'),'1','1001','2','multiple insert expense 480','820','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('462',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 481','948','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('463',to_date('24/01/19','DD/MM/RR'),'2','1000','1','multiple insert expense 482','947','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('464',to_date('24/01/19','DD/MM/RR'),'1','2','1','multiple insert income 483','975','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('465',to_date('24/01/19','DD/MM/RR'),'1','1000','1','multiple insert expense 484','292','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('466',to_date('24/01/19','DD/MM/RR'),'2','2','1','multiple insert income 485','877','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('467',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 486','262','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('468',to_date('24/01/19','DD/MM/RR'),'1','1002','1','multiple insert expense 487','303','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('469',to_date('24/01/19','DD/MM/RR'),'1','2','0','multiple insert income 488','962','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('470',to_date('24/01/19','DD/MM/RR'),'1','1','1','multiple insert income 489','408','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('471',to_date('24/01/19','DD/MM/RR'),'1','1000','0','multiple insert expense 490','373','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('472',to_date('24/01/19','DD/MM/RR'),'2','1002','1','multiple insert expense 491','639','1','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1962',to_date('04/03/19','DD/MM/RR'),'1','0','0','Nº Order17','500','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1963',to_date('04/03/19','DD/MM/RR'),'1','0','0','Nº Order18','10','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1964',to_date('04/03/19','DD/MM/RR'),'1','0','0','Nº Order4','10','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1965',to_date('04/03/19','DD/MM/RR'),'1','0','0','Nº Order6','12','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1960',to_date('25/02/19','DD/MM/RR'),'1','0','0','Nº Order13','62','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1961',to_date('25/02/19','DD/MM/RR'),'1','0','0','Nº Order14','60','0','0');
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION,REVOKED) values ('1966',to_date('12/03/19','DD/MM/RR'),'1','0','0','Nº Order1','10','0','0');
REM INSERTING into ROLES
SET DEFINE OFF;
Insert into ROLES (IDROLE,NAME) values ('1','ADMIN');
Insert into ROLES (IDROLE,NAME) values ('4','ALMACEN');
Insert into ROLES (IDROLE,NAME) values ('2','ENCAR');
Insert into ROLES (IDROLE,NAME) values ('3','ADMINISTRATIVO');
REM INSERTING into ORDERS_INVOICES
SET DEFINE OFF;
Insert into ORDERS_INVOICES (IDORDERINV,IDORDER,IDINVOICE) values ('1','15','1');
Insert into ORDERS_INVOICES (IDORDERINV,IDORDER,IDINVOICE) values ('2','6','3');
Insert into ORDERS_INVOICES (IDORDERINV,IDORDER,IDINVOICE) values ('3','7','4');
Insert into ORDERS_INVOICES (IDORDERINV,IDORDER,IDINVOICE) values ('4','14','5');
Insert into ORDERS_INVOICES (IDORDERINV,IDORDER,IDINVOICE) values ('5','17','6');
REM INSERTING into TYPES_INCOME
SET DEFINE OFF;
Insert into TYPES_INCOME (ID,DESCRIPTION) values ('0','Cash');
Insert into TYPES_INCOME (ID,DESCRIPTION) values ('1','Check');
Insert into TYPES_INCOME (ID,DESCRIPTION) values ('2','Receipt');
REM INSERTING into PRODUCTS
SET DEFINE OFF;
Insert into PRODUCTS (IDPRODUCT,NAME,IDCATEGORY,IDPLATFORM,MINIMUMAGE,PRICE,DELETED,STOCK) values ('2','fifa 18','1','1','13','12','0','47');
Insert into PRODUCTS (IDPRODUCT,NAME,IDCATEGORY,IDPLATFORM,MINIMUMAGE,PRICE,DELETED,STOCK) values ('1','AA','1','1','16','50','0','49');
Insert into PRODUCTS (IDPRODUCT,NAME,IDCATEGORY,IDPLATFORM,MINIMUMAGE,PRICE,DELETED,STOCK) values ('3','fifa 17','3','1','15','70','0','8');
REM INSERTING into PAYMENTMETHODS
SET DEFINE OFF;
Insert into PAYMENTMETHODS (IDPAYMENTMETHOD,PAYMENTMETHOD,DELETED) values ('1','Cash','0');
Insert into PAYMENTMETHODS (IDPAYMENTMETHOD,PAYMENTMETHOD,DELETED) values ('2','Wire Transfer','0');
Insert into PAYMENTMETHODS (IDPAYMENTMETHOD,PAYMENTMETHOD,DELETED) values ('3','Credit Card','0');
Insert into PAYMENTMETHODS (IDPAYMENTMETHOD,PAYMENTMETHOD,DELETED) values ('4','Paypal','0');
Insert into PAYMENTMETHODS (IDPAYMENTMETHOD,PAYMENTMETHOD,DELETED) values ('5','Cash on Delivery','0');
REM INSERTING into SOURCES_TARGETS
SET DEFINE OFF;
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('0','Product Sale');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1','Income performed by Administration');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('2','Varied due to another circunmstance');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1000','Payroll');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1001','Buying Raw Material');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1002','Takeout');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1003','Varied due to another circumnstance');
REM INSERTING into TYPES_PPAYMENT
SET DEFINE OFF;
Insert into TYPES_PPAYMENT (ID,DESCRIPTION) values ('0','Agency');
Insert into TYPES_PPAYMENT (ID,DESCRIPTION) values ('1','Other');
REM INSERTING into PRODUCTS_INVOICES
SET DEFINE OFF;
REM INSERTING into ORDERS
SET DEFINE OFF;
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('15','4','1',to_date('02/03/19','DD/MM/RR'),'5','50','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('18','4','1',to_date('04/03/19','DD/MM/RR'),'1','350','10','1');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('1','1','1',to_date('03/12/18','DD/MM/RR'),'1','100','10','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('4','6','1',to_date('09/12/18','DD/MM/RR'),'1','50','10','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('5','2','1',to_date('09/12/18','DD/MM/RR'),'1','0','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('6','2','1',to_date('09/12/18','DD/MM/RR'),'2','12','12','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('2','5','1',to_date('09/12/18','DD/MM/RR'),'2','62','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('3','2','1',to_date('09/12/18','DD/MM/RR'),'1','12','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('7','1','1',to_date('19/02/19','DD/MM/RR'),'2','12','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('8','4','1',to_date('25/02/19','DD/MM/RR'),'1','50','12','1');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('9','2','1',to_date('25/02/19','DD/MM/RR'),'1','48','0','1');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('10','6','1',to_date('25/02/19','DD/MM/RR'),'5','60','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('11','2','1',to_date('25/02/19','DD/MM/RR'),'5','110','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('12','4','1',to_date('25/02/19','DD/MM/RR'),'5','150','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('13','2','1',to_date('25/02/19','DD/MM/RR'),'2','62','62','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('14','2','1',to_date('25/02/19','DD/MM/RR'),'3','74','60','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('16','7','1',to_date('02/03/19','DD/MM/RR'),'5','48','0','1');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('17','5','1',to_date('04/03/19','DD/MM/RR'),'2','1820','500','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('19','1','4',to_date('12/03/19','DD/MM/RR'),'5','70','0','0');
REM INSERTING into USERS
SET DEFINE OFF;
Insert into USERS (IDUSER,NAME,PASSWORD,DELETED) values ('1','root','c93ccd78b2076528346216b3b2f701e6','0');
Insert into USERS (IDUSER,NAME,PASSWORD,DELETED) values ('2','user1','c93ccd78b2076528346216b3b2f701e6','1');
Insert into USERS (IDUSER,NAME,PASSWORD,DELETED) values ('4','Administrativo','b9e0927b549f7599b01a97ee524cdc7c','0');
Insert into USERS (IDUSER,NAME,PASSWORD,DELETED) values ('5','Almacen','4e210009a1cfbf891ee1a8f75f441e2f','0');
Insert into USERS (IDUSER,NAME,PASSWORD,DELETED) values ('3','Encargado','cb0d0277094bffbf04eceb3a6091cfaa','0');
REM INSERTING into USERS_ROLES
SET DEFINE OFF;
Insert into USERS_ROLES (IDUSERROL,IDUSER,IDROLE) values ('1','1','1');
Insert into USERS_ROLES (IDUSERROL,IDUSER,IDROLE) values ('3','4','3');
Insert into USERS_ROLES (IDUSERROL,IDUSER,IDROLE) values ('4','5','4');
Insert into USERS_ROLES (IDUSERROL,IDUSER,IDROLE) values ('2','3','2');
REM INSERTING into VALIDATIONS
SET DEFINE OFF;
Insert into VALIDATIONS (ID,VALIDATION_DATE,REFUSER,A_INCASH,A_RECEIPT,A_CHECK,TOTAL) values ('1',to_date('24/01/19','DD/MM/RR'),'1','5811','9929','8022','23762');
--------------------------------------------------------
--  DDL for Index ORDERSPRODUCTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ORDERSPRODUCTS_PK" ON "ORDERSPRODUCTS" ("IDORDERPRODUCT") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007131
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007131" ON "PERMITS" ("IDPERMIT") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007125
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007125" ON "PLATFORMS" ("IDPLATFORM") 
  ;
--------------------------------------------------------
--  DDL for Index ORDERS_STATUS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ORDERS_STATUS_PK" ON "ORDERS_STATUS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007135
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007135" ON "ROL_PERM" ("IDROLPERM") 
  ;
--------------------------------------------------------
--  DDL for Index PPAYMENTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PPAYMENTS_PK" ON "PPAYMENTS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007121
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007121" ON "CATEGORIES" ("IDCATEGORY") 
  ;
--------------------------------------------------------
--  DDL for Index INVOICES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "INVOICES_PK" ON "INVOICES" ("NUM_INVOICE") 
  ;
--------------------------------------------------------
--  DDL for Index INVOICES_PK1
--------------------------------------------------------

  CREATE UNIQUE INDEX "INVOICES_PK1" ON "INVOICES" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index DEBTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "DEBTS_PK" ON "DEBTS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index CUSTOMERS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "CUSTOMERS_PK" ON "CUSTOMERS" ("IDCUSTOMER") 
  ;
--------------------------------------------------------
--  DDL for Index CUSTOMERS_UK_DNI
--------------------------------------------------------

  CREATE UNIQUE INDEX "CUSTOMERS_UK_DNI" ON "CUSTOMERS" ("DNI") 
  ;
--------------------------------------------------------
--  DDL for Index INCOMES_EXPENSES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "INCOMES_EXPENSES_PK" ON "INCOMES_EXPENSES" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007128
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007128" ON "ROLES" ("IDROLE") 
  ;
--------------------------------------------------------
--  DDL for Index ORDERS_INVOICES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ORDERS_INVOICES_PK" ON "ORDERS_INVOICES" ("IDORDERINV") 
  ;
--------------------------------------------------------
--  DDL for Index TYPES_INCOME_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "TYPES_INCOME_PK" ON "TYPES_INCOME" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PRODUCTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRODUCTS_PK" ON "PRODUCTS" ("IDPRODUCT") 
  ;
--------------------------------------------------------
--  DDL for Index PAYMENTMETHODS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PAYMENTMETHODS_PK" ON "PAYMENTMETHODS" ("IDPAYMENTMETHOD") 
  ;
--------------------------------------------------------
--  DDL for Index SOURCE_TARGET_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SOURCE_TARGET_PK" ON "SOURCES_TARGETS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index TYPES_PPAYMENT_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "TYPES_PPAYMENT_PK" ON "TYPES_PPAYMENT" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PRODUCTS_INVOICES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRODUCTS_INVOICES_PK" ON "PRODUCTS_INVOICES" ("IDPROINV") 
  ;
--------------------------------------------------------
--  DDL for Index ORDERS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ORDERS_PK" ON "ORDERS" ("IDORDER") 
  ;
--------------------------------------------------------
--  DDL for Index USERS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "USERS_PK" ON "USERS" ("IDUSER") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007139
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007139" ON "USERS_ROLES" ("IDUSERROL") 
  ;
--------------------------------------------------------
--  DDL for Index VALIDATIONS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "VALIDATIONS_PK" ON "VALIDATIONS" ("ID") 
  ;
--------------------------------------------------------
--  Constraints for Table ORDERSPRODUCTS
--------------------------------------------------------

  ALTER TABLE "ORDERSPRODUCTS" ADD CONSTRAINT "ORDERSPRODUCTS_PK" PRIMARY KEY ("IDORDERPRODUCT") ENABLE;
--------------------------------------------------------
--  Constraints for Table PERMITS
--------------------------------------------------------

  ALTER TABLE "PERMITS" MODIFY ("IDPERMIT" NOT NULL ENABLE);
  ALTER TABLE "PERMITS" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "PERMITS" ADD PRIMARY KEY ("IDPERMIT") ENABLE;
--------------------------------------------------------
--  Constraints for Table PLATFORMS
--------------------------------------------------------

  ALTER TABLE "PLATFORMS" MODIFY ("IDPLATFORM" NOT NULL ENABLE);
  ALTER TABLE "PLATFORMS" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "PLATFORMS" MODIFY ("DELETED" NOT NULL ENABLE);
  ALTER TABLE "PLATFORMS" ADD PRIMARY KEY ("IDPLATFORM") ENABLE;
--------------------------------------------------------
--  Constraints for Table ORDERS_STATUS
--------------------------------------------------------

  ALTER TABLE "ORDERS_STATUS" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "ORDERS_STATUS" MODIFY ("REFORDER" NOT NULL ENABLE);
  ALTER TABLE "ORDERS_STATUS" MODIFY ("STATUS" NOT NULL ENABLE);
  ALTER TABLE "ORDERS_STATUS" ADD CONSTRAINT "ORDERS_STATUS_PK" PRIMARY KEY ("ID") ENABLE;
--------------------------------------------------------
--  Constraints for Table ROL_PERM
--------------------------------------------------------

  ALTER TABLE "ROL_PERM" MODIFY ("IDROLPERM" NOT NULL ENABLE);
  ALTER TABLE "ROL_PERM" MODIFY ("IDPERMIT" NOT NULL ENABLE);
  ALTER TABLE "ROL_PERM" MODIFY ("IDROLE" NOT NULL ENABLE);
  ALTER TABLE "ROL_PERM" ADD PRIMARY KEY ("IDROLPERM") ENABLE;
--------------------------------------------------------
--  Constraints for Table PPAYMENTS
--------------------------------------------------------

  ALTER TABLE "PPAYMENTS" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("PPDATE" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("REFUSER" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("REFTYPE" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("AMOUNT" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("PAID" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" ADD CONSTRAINT "PPAYMENTS_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "PPAYMENTS" ADD CONSTRAINT "CK_PPAY_PAID" CHECK (PAID BETWEEN 0 AND 1) ENABLE;
--------------------------------------------------------
--  Constraints for Table LOGS
--------------------------------------------------------

  ALTER TABLE "LOGS" MODIFY ("DESCRIPCION" NOT NULL ENABLE);
  ALTER TABLE "LOGS" MODIFY ("IDUSER" NOT NULL ENABLE);
  ALTER TABLE "LOGS" MODIFY ("FECHACAMBIO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table LINES_INVOICE
--------------------------------------------------------

  ALTER TABLE "LINES_INVOICE" MODIFY ("REFINVOICE" NOT NULL ENABLE);
  ALTER TABLE "LINES_INVOICE" MODIFY ("PRICE" NOT NULL ENABLE);
  ALTER TABLE "LINES_INVOICE" MODIFY ("AMOUNT" NOT NULL ENABLE);
  ALTER TABLE "LINES_INVOICE" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "LINES_INVOICE" MODIFY ("DELETED" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table CATEGORIES
--------------------------------------------------------

  ALTER TABLE "CATEGORIES" MODIFY ("IDCATEGORY" NOT NULL ENABLE);
  ALTER TABLE "CATEGORIES" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "CATEGORIES" MODIFY ("DELETED" NOT NULL ENABLE);
  ALTER TABLE "CATEGORIES" ADD PRIMARY KEY ("IDCATEGORY") ENABLE;
--------------------------------------------------------
--  Constraints for Table INVOICES
--------------------------------------------------------

  ALTER TABLE "INVOICES" ADD CONSTRAINT "INVOICES_PK2" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "INVOICES" MODIFY ("DELETED" NOT NULL ENABLE);
  ALTER TABLE "INVOICES" MODIFY ("REFCUSTOMER" NOT NULL ENABLE);
  ALTER TABLE "INVOICES" MODIFY ("DATETIME" NOT NULL ENABLE);
  ALTER TABLE "INVOICES" MODIFY ("NUM_INVOICE" NOT NULL ENABLE);
  ALTER TABLE "INVOICES" MODIFY ("POSTED" NOT NULL ENABLE);
  ALTER TABLE "INVOICES" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table DEBTS
--------------------------------------------------------

  ALTER TABLE "DEBTS" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("DDATE" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("REFUSER" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("AMOUNT" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("PAID" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" ADD CONSTRAINT "DEBTS_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "DEBTS" ADD CONSTRAINT "CK_DEBTS_PAID" CHECK (PAID BETWEEN 0 AND 1) ENABLE;
--------------------------------------------------------
--  Constraints for Table CUSTOMERS
--------------------------------------------------------

  ALTER TABLE "CUSTOMERS" ADD CONSTRAINT "CUSTOMERS_PK" PRIMARY KEY ("IDCUSTOMER") ENABLE;
  ALTER TABLE "CUSTOMERS" ADD CONSTRAINT "CUSTOMERS_UK_DNI" UNIQUE ("DNI") ENABLE;
--------------------------------------------------------
--  Constraints for Table INCOMES_EXPENSES
--------------------------------------------------------

  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("IE_DATE" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("REFUSER" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("REFST" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("REFTYPE" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("AMOUNT" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("REFACTION" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" ADD CONSTRAINT "INCOMES_EXPENSES_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "INCOMES_EXPENSES" ADD CONSTRAINT "CK_ACTION" CHECK (REFACTION BETWEEN 0 AND 1) ENABLE;
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("REVOKED" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ROLES
--------------------------------------------------------

  ALTER TABLE "ROLES" MODIFY ("IDROLE" NOT NULL ENABLE);
  ALTER TABLE "ROLES" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "ROLES" ADD PRIMARY KEY ("IDROLE") ENABLE;
--------------------------------------------------------
--  Constraints for Table ORDERS_INVOICES
--------------------------------------------------------

  ALTER TABLE "ORDERS_INVOICES" ADD CONSTRAINT "ORDERS_INVOICES_PK" PRIMARY KEY ("IDORDERINV") ENABLE;
  ALTER TABLE "ORDERS_INVOICES" MODIFY ("IDINVOICE" NOT NULL ENABLE);
  ALTER TABLE "ORDERS_INVOICES" MODIFY ("IDORDER" NOT NULL ENABLE);
  ALTER TABLE "ORDERS_INVOICES" MODIFY ("IDORDERINV" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TYPES_INCOME
--------------------------------------------------------

  ALTER TABLE "TYPES_INCOME" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "TYPES_INCOME" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "TYPES_INCOME" ADD CONSTRAINT "TYPES_INCOME_PK" PRIMARY KEY ("ID") ENABLE;
--------------------------------------------------------
--  Constraints for Table PRODUCTS
--------------------------------------------------------

  ALTER TABLE "PRODUCTS" MODIFY ("IDPRODUCT" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS" MODIFY ("PRICE" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS" ADD CONSTRAINT "PRODUCTS_PK" PRIMARY KEY ("IDPRODUCT") ENABLE;
  ALTER TABLE "PRODUCTS" MODIFY ("STOCK" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PAYMENTMETHODS
--------------------------------------------------------

  ALTER TABLE "PAYMENTMETHODS" MODIFY ("IDPAYMENTMETHOD" NOT NULL ENABLE);
  ALTER TABLE "PAYMENTMETHODS" ADD CONSTRAINT "PAYMENTMETHODS_PK" PRIMARY KEY ("IDPAYMENTMETHOD") ENABLE;
--------------------------------------------------------
--  Constraints for Table SOURCES_TARGETS
--------------------------------------------------------

  ALTER TABLE "SOURCES_TARGETS" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "SOURCES_TARGETS" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "SOURCES_TARGETS" ADD CONSTRAINT "SOURCE_TARGET_PK" PRIMARY KEY ("ID") ENABLE;
--------------------------------------------------------
--  Constraints for Table TYPES_PPAYMENT
--------------------------------------------------------

  ALTER TABLE "TYPES_PPAYMENT" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "TYPES_PPAYMENT" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "TYPES_PPAYMENT" ADD CONSTRAINT "TYPES_PPAYMENT_PK" PRIMARY KEY ("ID") ENABLE;
--------------------------------------------------------
--  Constraints for Table PRODUCTS_INVOICES
--------------------------------------------------------

  ALTER TABLE "PRODUCTS_INVOICES" MODIFY ("PRICESALE" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS_INVOICES" MODIFY ("AMOUNT" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS_INVOICES" ADD CONSTRAINT "PRODUCTS_INVOICES_PK" PRIMARY KEY ("IDPROINV") ENABLE;
  ALTER TABLE "PRODUCTS_INVOICES" MODIFY ("IDINVOICE" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS_INVOICES" MODIFY ("IDPRODUCT" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS_INVOICES" MODIFY ("IDPROINV" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ORDERS
--------------------------------------------------------

  ALTER TABLE "ORDERS" ADD CONSTRAINT "ORDERS_PK" PRIMARY KEY ("IDORDER") ENABLE;
--------------------------------------------------------
--  Constraints for Table USERS
--------------------------------------------------------

  ALTER TABLE "USERS" ADD CONSTRAINT "USERS_PK" PRIMARY KEY ("IDUSER") ENABLE;
--------------------------------------------------------
--  Constraints for Table USERS_ROLES
--------------------------------------------------------

  ALTER TABLE "USERS_ROLES" MODIFY ("IDUSERROL" NOT NULL ENABLE);
  ALTER TABLE "USERS_ROLES" MODIFY ("IDUSER" NOT NULL ENABLE);
  ALTER TABLE "USERS_ROLES" MODIFY ("IDROLE" NOT NULL ENABLE);
  ALTER TABLE "USERS_ROLES" ADD PRIMARY KEY ("IDUSERROL") ENABLE;
--------------------------------------------------------
--  Constraints for Table VALIDATIONS
--------------------------------------------------------

  ALTER TABLE "VALIDATIONS" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("VALIDATION_DATE" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("REFUSER" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("A_INCASH" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("A_RECEIPT" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("A_CHECK" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" ADD CONSTRAINT "VALIDATIONS_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "VALIDATIONS" MODIFY ("TOTAL" NOT NULL ENABLE);
