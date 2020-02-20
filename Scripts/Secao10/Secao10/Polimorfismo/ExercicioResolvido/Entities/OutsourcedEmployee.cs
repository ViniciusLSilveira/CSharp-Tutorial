namespace Secao10.Polimorfismo.ExercicioResolvido.Entities
{
    class OutsourcedEmployee : Employee
    {

        public double AdditionalCharge { get; set; }

        public OutsourcedEmployee()
        {
        }

        public OutsourcedEmployee(string name, int hours, double valuePerHour, double additionalCharge) : base(name, hours, valuePerHour)
        {
            AdditionalCharge = additionalCharge;
        }

        public override double Payment()
        {
            double total = base.Payment();
            return total + AdditionalCharge * 1.1;
        }
    }
}
