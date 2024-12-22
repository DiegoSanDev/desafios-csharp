namespace CalculadoraBasica
{
    public class ConsoleInteracaoUsuario : IInteracaoUsuario
    {
        public void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public string ObterEntrada()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}