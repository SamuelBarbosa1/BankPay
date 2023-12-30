namespace BankPay
{
    public class Banco
    {
        private string nome;
        private List<Conta> contas;
        private static int proximoNumeroConta = 1;

        public string Nome { get { return nome; } }

        public Banco(string nome)
        {
            this.nome = nome;
            this.contas = new List<Conta>();
        }

        public void AdicionarConta(Conta conta)
        {
            conta.NumeroConta = proximoNumeroConta;
            proximoNumeroConta++;
            contas.Add(conta);
        }

        public Conta ObterConta(int numeroConta)
        {
            return contas.Find(c => c.NumeroConta == numeroConta);
        }
    }
}
