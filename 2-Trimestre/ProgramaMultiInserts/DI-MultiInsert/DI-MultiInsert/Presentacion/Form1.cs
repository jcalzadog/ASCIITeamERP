using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_MultiInsert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectOracle conector = new ConnectOracle();
            decimal cantIncomes = (decimal)conector.DLookUp("COUNT(id)", "incomes_expenses", "");
            decimal idIncome;
            if (cantIncomes == 0)
            {
                idIncome = 1;

            }
            else
            {
                idIncome = (decimal)conector.DLookUp("MAX(id)", "incomes_expenses", "");
                idIncome++;
            }

            Random random = new Random();
            for (; idIncome < 2000; idIncome++)
            {
                decimal refActionAle = random.Next(0, 2);
                if(refActionAle == 1)
                {
                    int randomSource = random.Next(0, 3);
                    int randomType = random.Next(0, 3);
                    int randomUser = random.Next(1, 3);
                    decimal amountAle = random.Next(1, 1001);

                    decimal checkT = getTotalChecksIncome() - getTotalChecksExpense();
                    decimal cashT = getTotalCashIncome() - getTotalCashExpense();
                    decimal receiptT = getTotalReceiptsIncome() - getTotalReceiptsExpense();

                    if (randomType == 0)
                    {
                        if((cashT- amountAle) < 0)
                        {

                        } else
                        {
                            string desc = "";
                            if (refActionAle == 0)
                            {
                                desc = "multiple insert income " + idIncome;
                            }
                            else
                            {
                                desc = "multiple insert expense " + idIncome;
                            }
                            newIncome(0, DateTime.Today, (decimal)randomUser, randomSource, randomType, desc, amountAle, refActionAle);
                        }
                    }
                    if (randomType == 1)
                    {
                        if ((checkT - amountAle) < 0)
                        {

                        }
                        else
                        {
                            string desc = "";
                            if (refActionAle == 0)
                            {
                                desc = "multiple insert income " + idIncome;
                            }
                            else
                            {
                                desc = "multiple insert expense " + idIncome;
                            }
                            newIncome(0, DateTime.Today, (decimal)randomUser, randomSource, randomType, desc, amountAle, refActionAle);
                        }
                    }
                    if (randomType == 2)
                    {
                        if ((receiptT - amountAle) < 0)
                        {

                        }
                        else
                        {
                            string desc = "";
                            if (refActionAle == 0)
                            {
                                desc = "multiple insert income " + idIncome;
                            }
                            else
                            {
                                desc = "multiple insert expense " + idIncome;
                            }
                            newIncome(0, DateTime.Today, (decimal)randomUser, randomSource, randomType, desc, amountAle, refActionAle);
                        }
                    }

                } else
                {
                    int randomSource = random.Next(0, 3);
                    int randomType = random.Next(0, 3);
                    int randomUser = random.Next(1, 3);
                    decimal amountAle = random.Next(1, 1001);

                    string desc = "";
                    if (refActionAle == 0)
                    {
                        desc = "multiple insert income " + idIncome;
                    }
                    else
                    {
                        desc = "multiple insert expense " + idIncome;
                    }
                    newIncome(0, DateTime.Today, (decimal)randomUser, randomSource, randomType, desc, amountAle, refActionAle);
                }
                
            }
            MessageBox.Show("Terminado Insert Incomes y Expenses");
        }

        public void newIncome(decimal id, DateTime income_date, decimal refUser, decimal refSt, decimal refType, string description, decimal amount, decimal refaction)
        {
            ConnectOracle conector = new ConnectOracle();
            decimal cantIncomes = (decimal)conector.DLookUp("COUNT(id)", "incomes_expenses", "");
            decimal idIncome;
            if (cantIncomes == 0)
            {
                idIncome = 1;

            }
            else
            {
                idIncome = (decimal)conector.DLookUp("MAX(id)", "incomes_expenses", "");
                idIncome++;
            }
            //MessageBox.Show("INSERT INTO incomes_expenses VALUES ('" + idIncome + "', '" + income_date.ToString().Substring(0, 10)
            //    + "','" + refUser + "','" + refSt + "', '" + refType + "', '"
            //    + description.Replace('\'', ' ').PadRight(60, ' ').Substring(0, 60).Trim() + "', '"
            //    + amount + "', '0','0')");
            decimal st = 0;
            if (refaction == 0)
            {
                st = refSt;
            } else
            {
                st = (refSt+1000);
            }
            conector.setData("INSERT INTO incomes_expenses VALUES ('" + idIncome + "', '" + income_date.ToString().Substring(0, 10)
                + "','" + refUser + "','" + st + "', '" + refType + "', '"
                + description.Replace('\'', ' ').PadRight(60, ' ').Substring(0, 60).Trim() + "', '"
                + amount + "'," +refaction+",'0')");
        }

        public decimal getTotalChecksIncome()
        {
            ConnectOracle conector = new ConnectOracle();
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Check'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='0' and reftype='" + idType + "'");
        }
        public decimal getTotalCashIncome()
        {
            ConnectOracle conector = new ConnectOracle();
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Cash'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='0' and reftype='" + idType + "'");
        }
        public decimal getTotalReceiptsIncome()
        {
            ConnectOracle conector = new ConnectOracle();
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Receipt'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='0' and reftype='" + idType + "'");
        }

        public decimal getTotalChecksExpense()
        {
            ConnectOracle conector = new ConnectOracle();
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Check'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='1' and reftype='" + idType + "'");


        }
        public decimal getTotalCashExpense()
        {
            ConnectOracle conector = new ConnectOracle();
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Cash'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='1' and reftype='" + idType + "'");

        }
        public decimal getTotalReceiptsExpense()
        {
            ConnectOracle conector = new ConnectOracle();
            decimal idType = (decimal)conector.DLookUp("id", "types_income", "description='Receipt'");
            return (decimal)conector.DLookUp("NVL(SUM(AMOUNT),0)", "INCOMES_EXPENSES", "REFACTION='1' and reftype='" + idType + "'");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //ConnectOracle conector = new ConnectOracle();
            //decimal cantIncomes = (decimal)conector.DLookUp("COUNT(id)", "incomes_expenses", "");
            //decimal idIncome;
            //if (cantIncomes == 0)
            //{
            //    idIncome = 1;

            //}
            //else
            //{
            //    idIncome = (decimal)conector.DLookUp("MAX(id)", "incomes_expenses", "");
            //    idIncome++;
            //}

            //Random random = new Random();
            //for (; idIncome < 2000; idIncome++)
            //{

            //    int randomTarget = random.Next(1000, 1004);
            //    int randomType = random.Next(0, 3);
            //    int randomUser = random.Next(1, 3);
            //    decimal amountAle = random.Next(1, 1001);
            //    newExpense(0, DateTime.Today, (decimal)randomUser, randomTarget, randomType, "multiple insert expense " + idIncome, amountAle);
            //}
            //MessageBox.Show("Terminado Expenses");
        }
            public void newExpense(decimal id, DateTime expense_date, decimal refUser, decimal refSt, decimal refType, string description, decimal amount)
            {
            //ConnectOracle conector = new ConnectOracle();
            //decimal cantExpense = (decimal)conector.DLookUp("COUNT(id)", "incomes_expenses", "");
            //    decimal idExpense;
            //    if (cantExpense == 0)
            //    {
            //        idExpense = 1;

            //    }
            //    else
            //    {
            //        idExpense = (decimal)conector.DLookUp("MAX(id)", "incomes_expenses", "");
            //        idExpense++;
            //    }
            //    conector.setData("INSERT INTO incomes_expenses VALUES (" + idExpense + ", '" + expense_date.ToString().Substring(0, 10)
            //        + "','" + refUser + "','" + (Decimal)(refSt+1000) + "', '" + refType + "', '"
            //        + description.Replace('\'', ' ').PadRight(60, ' ').Substring(0, 60).Trim() + "', '"
            //        + amount + "', 1,0)");
            }
    }
    
}
