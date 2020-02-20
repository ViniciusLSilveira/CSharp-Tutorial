namespace Secao10.Abstratos.ExercicioFixacao.Entities
{
    class Individual : TaxPayer
    {

        public double HealthExpenditures { get; set; }

        public Individual(string name, double annualIncome, double healthExpenditures) : base(name, annualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax()
        {

            double tax;

            if (AnnualIncome < 20000.00)
            {
                tax = (AnnualIncome * 0.15) - (HealthExpenditures * 0.5);
            }
            else
            {
                tax = (AnnualIncome * 0.25) - (HealthExpenditures * 0.5);
            }

            return tax;
        }
    }
}
