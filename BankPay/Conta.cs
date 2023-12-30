namespace BankPay
{
    public class Conta
    {
        private string titular;
        private double saldo;
        private int numeroConta;

        public string Titular { get { return titular; } }
        public double Saldo { get { return saldo; } }
        public int NumeroConta
        {
            get { return numeroConta; }
            set { numeroConta = value; }
        }

        public Conta(string titular, double saldoInicial)
        {
            this.titular = titular;
            this.saldo = saldoInicial;
        }

        public void Depositar(double valor)
        {
            saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
                return true;
            }
            return false;
        }
    }
}
