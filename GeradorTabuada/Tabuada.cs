using Microsoft.VisualBasic;

namespace GeradorTabuada
{
    public class Tabuada
    {
        private IInteracaoUsuario _interacaoUsuario;

        public Tabuada(IInteracaoUsuario interacaoUsuario)
        {
            _interacaoUsuario = interacaoUsuario;
        }

        public void ExibirTabuada()
        {
            string sair = "s";
            
            while("s".Equals(sair))
            {
                if(!ObterNumero("Digite um número para gerar a tabuada:", out double numero)) 
                {
                    _interacaoUsuario.ExibirMensagem("Entrada inválida. Operação Cancelada.");
                    return;
                }
                _interacaoUsuario.ExibirMensagem($"\nTabuada de {numero}: ");
                for(int i = 1; i <= 10; i++) 
                {
                    var resultado = numero * i;
                    _interacaoUsuario.ExibirMensagem($"{numero} x {i} = {resultado}");
                }
                _interacaoUsuario.ExibirMensagem("Deseja gerar outra tabuada? (s/n): ");
                sair = _interacaoUsuario.ObterEntrada();
            }
        }

        private bool ObterNumero(string mensagem, out double numero)
        {
            _interacaoUsuario.ExibirMensagem(mensagem);
            var entrada = _interacaoUsuario.ObterEntrada();
            return Double.TryParse(entrada, out numero);
        }
    }
}