--------------------------------------------------------
-- Archivo creado  - martes-enero-15-2019   
--------------------------------------------------------
DROP TABLE "DEBTS" cascade constraints;
DROP TABLE "INCOMES_EXPENSES" cascade constraints;
DROP TABLE "PPAYMENTS" cascade constraints;
DROP TABLE "SOURCES_TARGETS" cascade constraints;
DROP TABLE "TYPES_INCOME" cascade constraints;
DROP TABLE "TYPES_PPAYMENT" cascade constraints;
DROP TABLE "VALIDATIONS" cascade constraints;
--------------------------------------------------------
--  DDL for Table DEBTS
--------------------------------------------------------

  CREATE TABLE "DEBTS" 
   (	"ID" NUMBER(38,0), 
	"DDATE" DATE, 
	"REFUSER" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(60), 
	"AMOUNT" NUMBER(11,2), 
	"PAID" NUMBER(1,0)
   ) ;

   COMMENT ON COLUMN "DEBTS"."PAID" IS '0 FALSE, 1 TRUE';
--------------------------------------------------------
--  DDL for Table INCOMES_EXPENSES
--------------------------------------------------------

  CREATE TABLE "INCOMES_EXPENSES" 
   (	"ID" NUMBER(38,0), 
	"IE_DATE" DATE, 
	"REFUSER" NUMBER(38,0), 
	"REFST" NUMBER(38,0), 
	"REFTYPE" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(60), 
	"AMOUNT" NUMBER(11,2), 
	"REFACTION" NUMBER(1,0)
   ) ;

   COMMENT ON COLUMN "INCOMES_EXPENSES"."REFST" IS 'REF TO SOURCE OR TARGET';
   COMMENT ON COLUMN "INCOMES_EXPENSES"."REFACTION" IS '0 FOR INCOME 1 FOR EXPENSE';
--------------------------------------------------------
--  DDL for Table PPAYMENTS
--------------------------------------------------------

  CREATE TABLE "PPAYMENTS" 
   (	"ID" NUMBER(38,0), 
	"PPDATE" DATE, 
	"REFUSER" NUMBER(38,0), 
	"REFTYPE" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(60), 
	"AMOUNT" NUMBER(11,0), 
	"PAID" NUMBER(1,0)
   ) ;
--------------------------------------------------------
--  DDL for Table SOURCES_TARGETS
--------------------------------------------------------

  CREATE TABLE "SOURCES_TARGETS" 
   (	"ID" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(25)
   ) ;
--------------------------------------------------------
--  DDL for Table TYPES_INCOME
--------------------------------------------------------

  CREATE TABLE "TYPES_INCOME" 
   (	"ID" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(25)
   ) ;
--------------------------------------------------------
--  DDL for Table TYPES_PPAYMENT
--------------------------------------------------------

  CREATE TABLE "TYPES_PPAYMENT" 
   (	"ID" NUMBER(38,0), 
	"DESCRIPTION" VARCHAR2(25)
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
REM INSERTING into DEBTS
SET DEFINE OFF;
REM INSERTING into INCOMES_EXPENSES
SET DEFINE OFF;
REM INSERTING into PPAYMENTS
SET DEFINE OFF;
REM INSERTING into SOURCES_TARGETS
SET DEFINE OFF;
REM INSERTING into TYPES_INCOME
SET DEFINE OFF;
REM INSERTING into TYPES_PPAYMENT
SET DEFINE OFF;
REM INSERTING into VALIDATIONS
SET DEFINE OFF;
--------------------------------------------------------
--  DDL for Index DEBTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "DEBTS_PK" ON "DEBTS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index INCOMES_EXPENSES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "INCOMES_EXPENSES_PK" ON "INCOMES_EXPENSES" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index PPAYMENTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PPAYMENTS_PK" ON "PPAYMENTS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index SOURCE_TARGET_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SOURCE_TARGET_PK" ON "SOURCES_TARGETS" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index TYPES_INCOME_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "TYPES_INCOME_PK" ON "TYPES_INCOME" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index TYPES_PPAYMENT_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "TYPES_PPAYMENT_PK" ON "TYPES_PPAYMENT" ("ID") 
  ;
--------------------------------------------------------
--  DDL for Index VALIDATIONS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "VALIDATIONS_PK" ON "VALIDATIONS" ("ID") 
  ;
--------------------------------------------------------
--  Constraints for Table DEBTS
--------------------------------------------------------

  ALTER TABLE "DEBTS" ADD CONSTRAINT "CK_DEBTS_PAID" CHECK (PAID BETWEEN 0 AND 1) ENABLE;
  ALTER TABLE "DEBTS" ADD CONSTRAINT "DEBTS_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "DEBTS" MODIFY ("PAID" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("AMOUNT" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("REFUSER" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("DDATE" NOT NULL ENABLE);
  ALTER TABLE "DEBTS" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table INCOMES_EXPENSES
--------------------------------------------------------

  ALTER TABLE "INCOMES_EXPENSES" ADD CONSTRAINT "CK_ACTION" CHECK (REFACTION BETWEEN 0 AND 1) ENABLE;
  ALTER TABLE "INCOMES_EXPENSES" ADD CONSTRAINT "INCOMES_EXPENSES_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("REFACTION" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("AMOUNT" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("REFTYPE" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("REFST" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("REFUSER" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("IE_DATE" NOT NULL ENABLE);
  ALTER TABLE "INCOMES_EXPENSES" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PPAYMENTS
--------------------------------------------------------

  ALTER TABLE "PPAYMENTS" ADD CONSTRAINT "CK_PPAY_PAID" CHECK (PAID BETWEEN 0 AND 1) ENABLE;
  ALTER TABLE "PPAYMENTS" ADD CONSTRAINT "PPAYMENTS_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "PPAYMENTS" MODIFY ("PAID" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("AMOUNT" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("REFTYPE" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("REFUSER" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("PPDATE" NOT NULL ENABLE);
  ALTER TABLE "PPAYMENTS" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table SOURCES_TARGETS
--------------------------------------------------------

  ALTER TABLE "SOURCES_TARGETS" ADD CONSTRAINT "SOURCE_TARGET_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "SOURCES_TARGETS" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "SOURCES_TARGETS" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TYPES_INCOME
--------------------------------------------------------

  ALTER TABLE "TYPES_INCOME" ADD CONSTRAINT "TYPES_INCOME_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "TYPES_INCOME" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "TYPES_INCOME" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TYPES_PPAYMENT
--------------------------------------------------------

  ALTER TABLE "TYPES_PPAYMENT" ADD CONSTRAINT "TYPES_PPAYMENT_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "TYPES_PPAYMENT" MODIFY ("DESCRIPTION" NOT NULL ENABLE);
  ALTER TABLE "TYPES_PPAYMENT" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table VALIDATIONS
--------------------------------------------------------

  ALTER TABLE "VALIDATIONS" MODIFY ("TOTAL" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" ADD CONSTRAINT "VALIDATIONS_PK" PRIMARY KEY ("ID") ENABLE;
  ALTER TABLE "VALIDATIONS" MODIFY ("A_CHECK" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("A_RECEIPT" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("A_INCASH" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("REFUSER" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("VALIDATION_DATE" NOT NULL ENABLE);
  ALTER TABLE "VALIDATIONS" MODIFY ("ID" NOT NULL ENABLE);
