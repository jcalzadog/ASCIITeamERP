--------------------------------------------------------
-- Archivo creado  - jueves-enero-17-2019   
--------------------------------------------------------
DROP TABLE "DEBTS" cascade constraints;
DROP TABLE "USERS_ROLES" cascade constraints;
DROP TABLE "PLATFORMS" cascade constraints;
DROP TABLE "PRODUCTS" cascade constraints;
DROP TABLE "LOGS" cascade constraints;
DROP TABLE "ROL_PERM" cascade constraints;
DROP TABLE "SOURCES_TARGETS" cascade constraints;
DROP TABLE "VALIDATIONS" cascade constraints;
DROP TABLE "CUSTOMERS" cascade constraints;
DROP TABLE "INCOMES_EXPENSES" cascade constraints;
DROP TABLE "USERS" cascade constraints;
DROP TABLE "TYPES_INCOME" cascade constraints;
DROP TABLE "PERMITS" cascade constraints;
DROP TABLE "TYPES_PPAYMENT" cascade constraints;
DROP TABLE "PAYMENTMETHODS" cascade constraints;
DROP TABLE "PPAYMENTS" cascade constraints;
DROP TABLE "ORDERSPRODUCTS" cascade constraints;
DROP TABLE "ORDERS" cascade constraints;
DROP TABLE "ROLES" cascade constraints;
DROP TABLE "CATEGORIES" cascade constraints;
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
--  DDL for Table USERS_ROLES
--------------------------------------------------------

  CREATE TABLE "USERS_ROLES" 
   (	"IDUSERROL" NUMBER(38,0), 
	"IDUSER" NUMBER(38,0), 
	"IDROLE" NUMBER(38,0)
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
--  DDL for Table PRODUCTS
--------------------------------------------------------

  CREATE TABLE "PRODUCTS" 
   (	"IDPRODUCT" NUMBER(*,0), 
	"NAME" VARCHAR2(40 BYTE), 
	"IDCATEGORY" NUMBER(38,0), 
	"IDPLATFORM" NUMBER(38,0), 
	"MINIMUMAGE" NUMBER(2,0), 
	"PRICE" FLOAT(126), 
	"DELETED" NUMBER(*,0)
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
--  DDL for Table ROL_PERM
--------------------------------------------------------

  CREATE TABLE "ROL_PERM" 
   (	"IDROLPERM" NUMBER(38,0), 
	"IDPERMIT" NUMBER(38,0), 
	"IDROLE" NUMBER(38,0)
   ) ;
--------------------------------------------------------
--  DDL for Table SOURCES_TARGETS
--------------------------------------------------------

  CREATE TABLE "SOURCES_TARGETS" 
   (	"ID" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(40 BYTE)
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
	"REFACTION" NUMBER(1,0)
   ) ;

   COMMENT ON COLUMN "INCOMES_EXPENSES"."REFST" IS 'REF TO SOURCE OR TARGET';
   COMMENT ON COLUMN "INCOMES_EXPENSES"."REFACTION" IS '0 FOR INCOME 1 FOR EXPENSE';
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
--  DDL for Table TYPES_INCOME
--------------------------------------------------------

  CREATE TABLE "TYPES_INCOME" 
   (	"ID" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(25 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table PERMITS
--------------------------------------------------------

  CREATE TABLE "PERMITS" 
   (	"IDPERMIT" NUMBER(38,0), 
	"NAME" VARCHAR2(30 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table TYPES_PPAYMENT
--------------------------------------------------------

  CREATE TABLE "TYPES_PPAYMENT" 
   (	"ID" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(25 BYTE)
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
--  DDL for Table PPAYMENTS
--------------------------------------------------------

  CREATE TABLE "PPAYMENTS" 
   (	"ID" NUMBER(38,0), 
	"PPDATE" DATE, 
	"REFUSER" NUMBER(38,0), 
	"REFTYPE" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(60 BYTE), 
	"AMOUNT" NUMBER(11,0), 
	"PAID" NUMBER(1,0)
   ) ;
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
--  DDL for Table ROLES
--------------------------------------------------------

  CREATE TABLE "ROLES" 
   (	"IDROLE" NUMBER(38,0), 
	"NAME" VARCHAR2(30 BYTE)
   ) ;
--------------------------------------------------------
--  DDL for Table CATEGORIES
--------------------------------------------------------

  CREATE TABLE "CATEGORIES" 
   (	"IDCATEGORY" NUMBER(38,0), 
	"NAME" VARCHAR2(30 BYTE), 
	"DELETED" NUMBER(38,0)
   ) ;
REM INSERTING into DEBTS
SET DEFINE OFF;
REM INSERTING into USERS_ROLES
SET DEFINE OFF;
Insert into USERS_ROLES (IDUSERROL,IDUSER,IDROLE) values ('1','1','1');
Insert into USERS_ROLES (IDUSERROL,IDUSER,IDROLE) values ('2','2','2');
Insert into USERS_ROLES (IDUSERROL,IDUSER,IDROLE) values ('3','3','1');
REM INSERTING into PLATFORMS
SET DEFINE OFF;
Insert into PLATFORMS (IDPLATFORM,NAME,DELETED) values ('1','PLAY STATION','0');
Insert into PLATFORMS (IDPLATFORM,NAME,DELETED) values ('2','NINTENDO','0');
Insert into PLATFORMS (IDPLATFORM,NAME,DELETED) values ('3','XBOX','0');
REM INSERTING into PRODUCTS
SET DEFINE OFF;
Insert into PRODUCTS (IDPRODUCT,NAME,IDCATEGORY,IDPLATFORM,MINIMUMAGE,PRICE,DELETED) values ('2','fifa 18','1','1','13','12','0');
Insert into PRODUCTS (IDPRODUCT,NAME,IDCATEGORY,IDPLATFORM,MINIMUMAGE,PRICE,DELETED) values ('1','AA','1','1','16','50','0');
REM INSERTING into LOGS
SET DEFINE OFF;
REM INSERTING into ROL_PERM
SET DEFINE OFF;
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('1','1','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('2','2','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('3','3','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('4','4','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('5','5','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('6','6','1');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('7','4','2');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('8','5','2');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('11','3','3');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('12','4','3');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('9','1','3');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('10','2','3');
Insert into ROL_PERM (IDROLPERM,IDPERMIT,IDROLE) values ('13','7','1');
REM INSERTING into SOURCES_TARGETS
SET DEFINE OFF;
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('0','Product Sale');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1','Income performed by Administration');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('2','Varied due to another circunmstance');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1000','Payroll');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1001','Buying Raw Material');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1002','Takeout');
Insert into SOURCES_TARGETS (ID,DESCRIPTION) values ('1003','Varied due to another circumnstance');
REM INSERTING into VALIDATIONS
SET DEFINE OFF;
REM INSERTING into CUSTOMERS
SET DEFINE OFF;
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('5','05739350E','Jesus','Calzado','calle 65496','666','abc@abc.com','11630','0');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('4','05739349K','Jesus','Calzado','Calle calle calle 123','680444882','jcg598@gmail.com','13260','0');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('1','00000000L','john','doe','fake street 123','666','john@doe.com','3','0');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('2','12121212F','Diego','Alba','c/ cruces','0','skdjbfuyjhs','30300','0');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('3','12121232F','bb','CC','SSSS','121212','DFDFDF','13472','1');
Insert into CUSTOMERS (IDCUSTOMER,DNI,NAME,SURNAME,ADDRESS,PHONE,EMAIL,REFZIPCODESCITIES,DELETED) values ('6','121212','aa','nn','asdfa','68044654','adfa','13250','0');
REM INSERTING into INCOMES_EXPENSES
SET DEFINE OFF;
Insert into INCOMES_EXPENSES (ID,IE_DATE,REFUSER,REFST,REFTYPE,DESCRIPTION,AMOUNT,REFACTION) values ('1',to_date('01/01/19','DD/MM/RR'),'1','1','1','test move','1500,25','0');
REM INSERTING into USERS
SET DEFINE OFF;
Insert into USERS (IDUSER,NAME,PASSWORD,DELETED) values ('1','root','c93ccd78b2076528346216b3b2f701e6','0');
Insert into USERS (IDUSER,NAME,PASSWORD,DELETED) values ('2','user1','c93ccd78b2076528346216b3b2f701e6','0');
Insert into USERS (IDUSER,NAME,PASSWORD,DELETED) values ('3','Enrique','c93ccd78b2076528346216b3b2f701e6','1');
REM INSERTING into TYPES_INCOME
SET DEFINE OFF;
Insert into TYPES_INCOME (ID,DESCRIPTION) values ('0','Cash');
Insert into TYPES_INCOME (ID,DESCRIPTION) values ('1','Check');
Insert into TYPES_INCOME (ID,DESCRIPTION) values ('2','Receipt');
REM INSERTING into PERMITS
SET DEFINE OFF;
Insert into PERMITS (IDPERMIT,NAME) values ('1','USERS MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('2','CUSTOMERS MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('6','PLATFORMS MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('3','ORDERS  MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('4','PRODUCTS MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('5','CATEGORIES MANAGEMENT');
Insert into PERMITS (IDPERMIT,NAME) values ('7','CASHBOOK MANAGEMENT');
REM INSERTING into TYPES_PPAYMENT
SET DEFINE OFF;
Insert into TYPES_PPAYMENT (ID,DESCRIPTION) values ('0','Agency');
Insert into TYPES_PPAYMENT (ID,DESCRIPTION) values ('1','Other');
REM INSERTING into PAYMENTMETHODS
SET DEFINE OFF;
Insert into PAYMENTMETHODS (IDPAYMENTMETHOD,PAYMENTMETHOD,DELETED) values ('1','PAYPAL','0');
Insert into PAYMENTMETHODS (IDPAYMENTMETHOD,PAYMENTMETHOD,DELETED) values ('2','Credit Card','0');
REM INSERTING into PPAYMENTS
SET DEFINE OFF;
REM INSERTING into ORDERSPRODUCTS
SET DEFINE OFF;
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('1','1','1','2','100');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('4','3','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('5','4','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('2','2','2','1','12');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('3','2','1','1','50');
Insert into ORDERSPRODUCTS (IDORDERPRODUCT,REFORDER,REFPRODUCT,AMOUNT,PRICESALE) values ('6','6','2','1','12');
REM INSERTING into ORDERS
SET DEFINE OFF;
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('1','1','1',to_date('03/12/18','DD/MM/RR'),'1','100','10','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('4','6','1',to_date('09/12/18','DD/MM/RR'),'1','50','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('5','2','1',to_date('09/12/18','DD/MM/RR'),'1','0','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('6','2','1',to_date('09/12/18','DD/MM/RR'),'2','12','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('2','5','1',to_date('09/12/18','DD/MM/RR'),'2','62','0','0');
Insert into ORDERS (IDORDER,REFCUSTOMER,REFUSER,DATETIME,REFPAYMENTMETHOD,TOTAL,PREPAID,DELETED) values ('3','2','1',to_date('09/12/18','DD/MM/RR'),'1','12','0','0');
REM INSERTING into ROLES
SET DEFINE OFF;
Insert into ROLES (IDROLE,NAME) values ('1','ADMIN');
Insert into ROLES (IDROLE,NAME) values ('2','USER');
Insert into ROLES (IDROLE,NAME) values ('3','PRUEBA');
REM INSERTING into CATEGORIES
SET DEFINE OFF;
Insert into CATEGORIES (IDCATEGORY,NAME,DELETED) values ('1','ACTION','0');
Insert into CATEGORIES (IDCATEGORY,NAME,DELETED) values ('2','SHOOTER','0');
Insert into CATEGORIES (IDCATEGORY,NAME,DELETED) values ('3','SPORTS','0');
--------------------------------------------------------
--  DDL for Index DEBTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "DEBTS_PK" ON "DEBTS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007139
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007139" ON "USERS_ROLES" ("IDUSERROL") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007125
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007125" ON "PLATFORMS" ("IDPLATFORM") 
  ;
--------------------------------------------------------
--  DDL for Index PRODUCTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRODUCTS_PK" ON "PRODUCTS" ("IDPRODUCT") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007222
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007222" ON "LOGS" ("FECHACAMBIO") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007135
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007135" ON "ROL_PERM" ("IDROLPERM") 
  ;
--------------------------------------------------------
--  DDL for Index SOURCE_TARGET_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SOURCE_TARGET_PK" ON "SOURCES_TARGETS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index VALIDATIONS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "VALIDATIONS_PK" ON "VALIDATIONS" ("ID") 
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
--  DDL for Index USERS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "USERS_PK" ON "USERS" ("IDUSER") 
  ;
--------------------------------------------------------
--  DDL for Index TYPES_INCOME_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "TYPES_INCOME_PK" ON "TYPES_INCOME" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007131
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007131" ON "PERMITS" ("IDPERMIT") 
  ;
--------------------------------------------------------
--  DDL for Index TYPES_PPAYMENT_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "TYPES_PPAYMENT_PK" ON "TYPES_PPAYMENT" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PAYMENTMETHODS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PAYMENTMETHODS_PK" ON "PAYMENTMETHODS" ("IDPAYMENTMETHOD") 
  ;
--------------------------------------------------------
--  DDL for Index PPAYMENTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PPAYMENTS_PK" ON "PPAYMENTS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index ORDERSPRODUCTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ORDERSPRODUCTS_PK" ON "ORDERSPRODUCTS" ("IDORDERPRODUCT") 
  ;
--------------------------------------------------------
--  DDL for Index ORDERS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "ORDERS_PK" ON "ORDERS" ("IDORDER") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007128
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007128" ON "ROLES" ("IDROLE") 
  ;
--------------------------------------------------------
--  DDL for Index SYS_C007121
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYS_C007121" ON "CATEGORIES" ("IDCATEGORY") 
  ;
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
--  Constraints for Table USERS_ROLES
--------------------------------------------------------

  ALTER TABLE "USERS_ROLES" MODIFY ("IDUSERROL" NOT NULL ENABLE);
  ALTER TABLE "USERS_ROLES" MODIFY ("IDUSER" NOT NULL ENABLE);
  ALTER TABLE "USERS_ROLES" MODIFY ("IDROLE" NOT NULL ENABLE);
  ALTER TABLE "USERS_ROLES" ADD PRIMARY KEY ("IDUSERROL") ENABLE;
--------------------------------------------------------
--  Constraints for Table PLATFORMS
--------------------------------------------------------

  ALTER TABLE "PLATFORMS" MODIFY ("IDPLATFORM" NOT NULL ENABLE);
  ALTER TABLE "PLATFORMS" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "PLATFORMS" MODIFY ("DELETED" NOT NULL ENABLE);
  ALTER TABLE "PLATFORMS" ADD PRIMARY KEY ("IDPLATFORM") ENABLE;
--------------------------------------------------------
--  Constraints for Table PRODUCTS
--------------------------------------------------------

  ALTER TABLE "PRODUCTS" MODIFY ("IDPRODUCT" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS" MODIFY ("PRICE" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS" ADD CONSTRAINT "PRODUCTS_PK" PRIMARY KEY ("IDPRODUCT") ENABLE;
--------------------------------------------------------
--  Constraints for Table LOGS
--------------------------------------------------------

  ALTER TABLE "LOGS" ADD PRIMARY KEY ("FECHACAMBIO") ENABLE;
  ALTER TABLE "LOGS" MODIFY ("DESCRIPCION" NOT NULL ENABLE);
  ALTER TABLE "LOGS" MODIFY ("IDUSER" NOT NULL ENABLE);
  ALTER TABLE "LOGS" MODIFY ("FECHACAMBIO" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table ROL_PERM
--------------------------------------------------------

  ALTER TABLE "ROL_PERM" MODIFY ("IDROLPERM" NOT NULL ENABLE);
  ALTER TABLE "ROL_PERM" MODIFY ("IDPERMIT" NOT NULL ENABLE);
  ALTER TABLE "ROL_PERM" MODIFY ("IDROLE" NOT NULL ENABLE);
  ALTER TABLE "ROL_PERM" ADD PRIMARY KEY ("IDROLPERM") ENABLE;
--------------------------------------------------------
--  Constraints for Table SOURCES_TARGETS
--------------------------------------------------------

  ALTER TABLE "SOURCES_TARGETS" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "SOURCES_TARGETS" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "SOURCES_TARGETS" ADD CONSTRAINT "SOURCE_TARGET_PK" PRIMARY KEY ("ID") ENABLE;
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
--------------------------------------------------------
--  Constraints for Table USERS
--------------------------------------------------------

  ALTER TABLE "USERS" ADD CONSTRAINT "USERS_PK" PRIMARY KEY ("IDUSER") ENABLE;
--------------------------------------------------------
--  Constraints for Table TYPES_INCOME
--------------------------------------------------------

  ALTER TABLE "TYPES_INCOME" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "TYPES_INCOME" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "TYPES_INCOME" ADD CONSTRAINT "TYPES_INCOME_PK" PRIMARY KEY ("ID") ENABLE;
--------------------------------------------------------
--  Constraints for Table PERMITS
--------------------------------------------------------

  ALTER TABLE "PERMITS" MODIFY ("IDPERMIT" NOT NULL ENABLE);
  ALTER TABLE "PERMITS" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "PERMITS" ADD PRIMARY KEY ("IDPERMIT") ENABLE;
--------------------------------------------------------
--  Constraints for Table TYPES_PPAYMENT
--------------------------------------------------------

  ALTER TABLE "TYPES_PPAYMENT" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "TYPES_PPAYMENT" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "TYPES_PPAYMENT" ADD CONSTRAINT "TYPES_PPAYMENT_PK" PRIMARY KEY ("ID") ENABLE;
--------------------------------------------------------
--  Constraints for Table PAYMENTMETHODS
--------------------------------------------------------

  ALTER TABLE "PAYMENTMETHODS" ADD CONSTRAINT "PAYMENTMETHODS_PK" PRIMARY KEY ("IDPAYMENTMETHOD") ENABLE;
  ALTER TABLE "PAYMENTMETHODS" MODIFY ("IDPAYMENTMETHOD" NOT NULL ENABLE);
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
--  Constraints for Table ORDERSPRODUCTS
--------------------------------------------------------

  ALTER TABLE "ORDERSPRODUCTS" ADD CONSTRAINT "ORDERSPRODUCTS_PK" PRIMARY KEY ("IDORDERPRODUCT") ENABLE;
--------------------------------------------------------
--  Constraints for Table ORDERS
--------------------------------------------------------

  ALTER TABLE "ORDERS" ADD CONSTRAINT "ORDERS_PK" PRIMARY KEY ("IDORDER") ENABLE;
--------------------------------------------------------
--  Constraints for Table ROLES
--------------------------------------------------------

  ALTER TABLE "ROLES" MODIFY ("IDROLE" NOT NULL ENABLE);
  ALTER TABLE "ROLES" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "ROLES" ADD PRIMARY KEY ("IDROLE") ENABLE;
--------------------------------------------------------
--  Constraints for Table CATEGORIES
--------------------------------------------------------

  ALTER TABLE "CATEGORIES" MODIFY ("IDCATEGORY" NOT NULL ENABLE);
  ALTER TABLE "CATEGORIES" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "CATEGORIES" MODIFY ("DELETED" NOT NULL ENABLE);
  ALTER TABLE "CATEGORIES" ADD PRIMARY KEY ("IDCATEGORY") ENABLE;
