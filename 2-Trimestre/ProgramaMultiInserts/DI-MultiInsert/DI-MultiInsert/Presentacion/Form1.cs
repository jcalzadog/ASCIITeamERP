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
            for (; idIncome < 100; idIncome++)
            {

                int randomSource = random.Next(0, 3);
                int randomType = random.Next(0, 3);
                int randomUser = random.Next(1, 3);
                newIncome(0, DateTime.Today, (decimal)randomUser, randomSource, randomType, "multiple insert income " + idIncome, decimal.Parse("100"));
            }
        }

        public void newIncome(decimal id, DateTime income_date, decimal refUser, decimal refSt, decimal refType, string description, decimal amount)
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
            MessageBox.Show("INSERT INTO incomes_expenses VALUES ('" + idIncome + "', '" + income_date.ToString().Substring(0, 10)
                + "','" + refUser + "','" + refSt + "', '" + refType + "', '"
                + description.Replace('\'', ' ').PadRight(60, ' ').Substring(0, 60).Trim() + "', '"
                + amount + "', '0','0')");
            conector.setData("INSERT INTO incomes_expenses VALUES ('" + idIncome + "', '" + income_date.ToString().Substring(0, 10)
                + "','" + refUser + "','" + refSt + "', '" + refType + "', '"
                + description.Replace('\'', ' ').PadRight(60, ' ').Substring(0, 60).Trim() + "', '"
                + amount + "', '0','0')");
        }

        private void button3_Click(object sender, EventArgs e)
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
            for (; idIncome < 100; idIncome++)
            {

                int randomTarget = random.Next(1000, 1004);
                int randomType = random.Next(0, 3);
                int randomUser = random.Next(1, 3);
                newExpense(0, DateTime.Today, (decimal)randomUser, randomTarget, randomType, "multiple insert expense " + idIncome, decimal.Parse("100"));
            }
        }
            public void newExpense(decimal id, DateTime expense_date, decimal refUser, decimal refSt, decimal refType, string description, decimal amount)
            {
            ConnectOracle conector = new ConnectOracle();
            decimal cantExpense = (decimal)conector.DLookUp("COUNT(id)", "incomes_expenses", "");
                decimal idExpense;
                if (cantExpense == 0)
                {
                    idExpense = 1;

                }
                else
                {
                    idExpense = (decimal)conector.DLookUp("MAX(id)", "incomes_expenses", "");
                    idExpense++;
                }
                conector.setData("INSERT INTO incomes_expenses VALUES (" + idExpense + ", '" + expense_date.ToString().Substring(0, 10)
                    + "','" + refUser + "','" + refSt + "', '" + refType + "', '"
                    + description.Replace('\'', ' ').PadRight(60, ' ').Substring(0, 60).Trim() + "', '"
                    + amount + "', 1,0)");
            }
    }
    
}
