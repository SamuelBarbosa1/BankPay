using BankPay;

public class Transferencia
{
    public static bool RealizarTransferencia(Conta contaOrigem, Conta contaDestino, double valor)
    {
        if (contaOrigem.Sacar(valor))
        {
            contaDestino.Depositar(valor);
            return true;
        }
        else
        {
            return false;
        }
    }
}
