using System;
using System.Linq;

namespace ProyectoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Loans Call = new Loans("Randy");
            Call.First_InfoInput();
            Call.Second_InfoInput2();
            Call.MonthlyInterestCalculation();
            Call.MonthlyFeeCalculation();
            Console.Write(Call.LoanTable());
        }
    }

    class Loans
    {
        //Constructor
        public Loans(string name)
        {
            this.Name = name;
            this.Fee = 0;
            this.Interes_paid = 0;
            this.Paid_capital = 0;
            this.Loan_amount = 0;
            this.Air = 0;
            this.Mir = 0;
            this.Row = 0;
            this.Term = 0;
        }

        //Atributos
        public string Name { get; set; }
        public double Fee { get; set; } // Pago / Cuota.
        public double Interes_paid { get; set; }
        public double Paid_capital { get; set; }
        public double Loan_amount { get; set; }
        public double Air { get; set; } // Annual interest rate.
        public double Mir { get; set; } // Monthly interest rate.
        public int Row { get; set; }
        public int Term { get; set; } // Plazo.

        //Methods

        // Information Input for Double Values.
        public double First_InfoInput()
        {
            Console.Write("Enter the loan amount: ");
            Loan_amount = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            Console.Write("Enter the annual interest rate: ");
            Air = Convert.ToDouble(Console.ReadLine());

            Console.Clear();
            return 0;
        }

        // Information Input for Int Values.
        public int Second_InfoInput2()
        {
            Console.WriteLine("Enter the term in months: ");
            Term = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            return 0;
        }

        public double MonthlyInterestCalculation()
        {
            Mir = (Air / 100) / 12;

            Console.Clear();
            return Mir;
        }

        public bool MonthlyFeeCalculation()
        {
            Fee = Mir + 1;
            Fee = (float)Math.Pow(Fee, Term);
            Fee--; // Fee = Fee -1;
            Fee = Mir / Fee;
            Fee = Mir + Fee;
            Fee = Loan_amount * Fee;

            Console.Clear();
            return true;
        }

        public string LoanTable()
        {
            Console.WriteLine($"Welcome {Name}, here are the results.");

            Console.Write("\n");
            Console.Write("\n");

            Console.Write("\n");
            Row = 1;

            Console.Write("\n");
            Console.Write("\n");

            Console.Write(" Payment Number \t\t");
            Console.Write("Fee \t\t\t");
            Console.Write("Interest Paid \t\t\t");
            Console.Write("Paid_Capital \t\t");
            Console.Write("Loan Amount \t");

            Console.Write("\n");
            Console.Write("\n");
            Console.Write("\t0");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t{0}", Loan_amount);

            for (int i = 1; i <= Term; i++)
            {
                // Number of Rows.
                Console.Write($"\t{Row}\t\t");

                // Fee
                Console.Write($"{Fee}\t");

                // Paid Capital
                Interes_paid = Mir * Loan_amount;
                Console.Write($"{Interes_paid}\t\t");

                // Paid Capital
                Paid_capital = Fee - Interes_paid;
                Console.Write($"\t{Paid_capital}\t");


                // Loan Amount
                Loan_amount = Loan_amount - Paid_capital;

                if (Loan_amount <= 0)
                {
                    Loan_amount = 0;
                }

                Console.Write($"\t{Loan_amount}\t");

                // Increment of Rows
                Row++;
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.Clear();
            return "END";
        }
    }
}
