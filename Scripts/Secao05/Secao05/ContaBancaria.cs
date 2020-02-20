using System.Globalization;

namespace Secao05
{
    class ContaBancaria
    {

        public int NumeroConta { get; }
        public string NomeTitular { get; private set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numeroConta, string nome)
        {
            NumeroConta = numeroConta;
            NomeTitular = nome;
            Saldo = 0.0;
        }

        public ContaBancaria(int numeroConta, string nome, double deposito) : this(numeroConta, nome)
        {
            Saldo = deposito;
        }

        public void Deposito(double deposito)
        {
            Saldo += deposito;
        }

        public void Saque(double saque)
        {
            Saldo -= (saque + 5);
        }

        public override string ToString()
        {
            return "Conta: " + NumeroConta +
                ", Titular: " + NomeTitular +
                ", Saldo: $" + Saldo.ToString("F2", CultureInfo.InvariantCulture) + "\n";
        }

    }
}
