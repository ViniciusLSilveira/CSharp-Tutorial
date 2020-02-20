﻿namespace Secao10.Abstratos.ExercicioFixacao.Entities
{
    class Company : TaxPayer
    {

        public int NumberOfEmployees { get; set; }

        public Company(string name, double annualIncome, int numberOfEmployees) : base(name, annualIncome)
        {
            NumberOfEmployees = numberOfEmployees;
        }

        public override double Tax()
        {
            double tax;

            if (NumberOfEmployees <= 10)
            {
                tax = (AnnualIncome * 0.16);
            }
            else
            {
                tax = (AnnualIncome * 0.14);
            }

            return tax;
        }
    }
}
