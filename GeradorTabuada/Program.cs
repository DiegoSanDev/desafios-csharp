using GeradorTabuada;

IInteracaoUsuario interacaoUsuario = new ConsoleInteracaoUsuario();
Tabuada tabuada = new Tabuada(interacaoUsuario);
tabuada.ExibirTabuada();

