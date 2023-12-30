namespace BankPay
{
    public class BankPay
    {
        private Banco banco;

        public BankPay(string nomeBanco)
        {
            banco = new Banco(nomeBanco);
        }
        private void RealizarDeposito(Conta conta)
        {
            Console.Write("Digite o valor do depósito: ");
            double valorDeposito = Convert.ToDouble(Console.ReadLine());
            conta.Depositar(valorDeposito);
            Console.WriteLine("Depósito realizado com sucesso!");
        }
        private void RealizarSaque(Conta conta)
        {
            Console.Write("Digite o valor do saque: ");
            double valorSaque = Convert.ToDouble(Console.ReadLine());

            if (conta.Sacar(valorSaque))
            {
                Console.WriteLine("Saque realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para o saque.");
            }
        }
        public void Executar()
        {
            Console.WriteLine($"Bem-vindo ao {banco.Nome}!");

            while (true)
            {
                
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Criar conta");
                Console.WriteLine("2. Acessar conta");
                Console.WriteLine("3. Sair");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        CriarConta();
                        break;
                    case "2":
                        AcessarConta();
                        break;
                    case "3":
                        Console.WriteLine("Obrigado por usar o BankPay. Adeus!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void CriarConta()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o valor inicial da conta: ");
            double saldoInicial = Convert.ToDouble(Console.ReadLine());

            Conta conta = new Conta(nome, saldoInicial);
            banco.AdicionarConta(conta);

            Console.WriteLine($"Conta criada com sucesso para {nome}!");
            Console.WriteLine($"Número da conta: {conta.NumeroConta}");
        }

        private void AcessarConta()
        {
            Console.Write("Digite o número da conta: ");
            int numeroConta = Convert.ToInt32(Console.ReadLine());

            Conta conta = banco.ObterConta(numeroConta);

            if (conta != null)
            {
                Console.WriteLine($"Bem-vindo, {conta.Titular}!");
                MostrarMenuConta(conta);
            }
            else
            {
                Console.WriteLine("Conta não encontrada. Verifique o número da conta e tente novamente.");
            }
        }
        private void RealizarTransferencia(Conta contaOrigem, Conta contaDestino)
        {
            Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = Convert.ToDouble(Console.ReadLine());

            if (Transferencia.RealizarTransferencia(contaOrigem, contaDestino, valorTransferencia))
            {
                Console.WriteLine("Transferência realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para a transferência.");
            }
        }
        private void MostrarMenuConta(Conta conta)
        {
            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Ver saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Sacar");
                Console.WriteLine("4. Transferência");
                Console.WriteLine("5. Voltar ao menu principal");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine($"Saldo atual: {conta.Saldo}");
                        break;
                    case "2":
                        RealizarDeposito(conta);
                        break;
                    case "3":
                        RealizarSaque(conta);
                        break;
                    case "4":
                        Console.Write("Digite o número da conta de destino: ");
                        int numeroContaDestino = Convert.ToInt32(Console.ReadLine());
                        Conta contaDestino = banco.ObterConta(numeroContaDestino);

                        if (contaDestino != null)
                        {
                            RealizarTransferencia(conta, contaDestino);
                        }
                        else
                        {
                            Console.WriteLine("Conta de destino não encontrada. Verifique o número da conta e tente novamente.");
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
