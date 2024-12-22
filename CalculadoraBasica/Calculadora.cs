namespace CalculadoraBasica
{
    public class Calculadora
    {
        private readonly IInteracaoUsuario _interacaoUsuario;
        private readonly IDictionary<TipoOperacao, IOperacao> _operacoes;


        public Calculadora(IInteracaoUsuario interacaoUsuario)
        {
            _interacaoUsuario = interacaoUsuario;
            _operacoes = new Dictionary<TipoOperacao, IOperacao>
            {
                { TipoOperacao.Soma, new Soma() },
                { TipoOperacao.Subtracao, new Subtracao() },
                { TipoOperacao.Multiplicacao, new Multiplicacao() },
                { TipoOperacao.Divisao, new Divisao() }
            };

        }

        public void Executar()
        {
            TipoOperacao tipoOperacao;
            do
            {
                tipoOperacao = Menu();
                if (tipoOperacao != TipoOperacao.Inexistente)
                {
                    Calcular(tipoOperacao);
                }
            } while(tipoOperacao != TipoOperacao.Inexistente);
        }

        private void Calcular(TipoOperacao tipoOperacao)
        {
            if (!ObterNumero("Digite o primeiro número: ", out var x) ||
                !ObterNumero("Digite o segundo número: ", out var y))
            {
                _interacaoUsuario.ExibirMensagem("Entrada inválida. Operação Cancelada.");
                return;
            }

            if(_operacoes.TryGetValue(tipoOperacao, out var operacao))
            {
                var resultado = operacao.Calcular(x, y);
                _interacaoUsuario.ExibirMensagem($"Resultado: {resultado}");
            }
            else
            {
                _interacaoUsuario.ExibirMensagem("Operação inexistente.");
            }
        }

        private TipoOperacao Menu()
        {
             TipoOperacao tipoOperacao;
            _interacaoUsuario.ExibirMensagem("\nEscolha uma operação:");
            _interacaoUsuario.ExibirMensagem("1 - Soma\n2 - Subtração\n3 - Multiplicação\n4 - Divisão\n5 - Sair");
            var entrada = _interacaoUsuario.ObterEntrada();


            switch(entrada) 
            {
                case "1":
                    tipoOperacao = TipoOperacao.Soma;
                    break;
                case "2":
                    tipoOperacao = TipoOperacao.Subtracao;
                    break;
                case "3":
                    tipoOperacao = TipoOperacao.Multiplicacao;
                    break;
                case "4":
                    tipoOperacao = TipoOperacao.Divisao;
                    break;
                case "5":
                    tipoOperacao = TipoOperacao.Inexistente;
                    _interacaoUsuario.ExibirMensagem("Você saiu! Até ++!");
                    break;    
                default:
                    tipoOperacao = TipoOperacao.Inexistente;
                    _interacaoUsuario.ExibirMensagem($"Operacao: {entrada} invalida.");
                    break;
            }
            return tipoOperacao;
        }

        private bool ObterNumero(string mensagem, out double numero)
        {
            _interacaoUsuario.ExibirMensagem(mensagem);
            var entrada = _interacaoUsuario.ObterEntrada();
            return double.TryParse(entrada, out numero);
        }

    }
}