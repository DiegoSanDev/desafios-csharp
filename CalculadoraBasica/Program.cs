using CalculadoraBasica;
IInteracaoUsuario consoleInteracaoUsuario = new ConsoleInteracaoUsuario();
Calculadora calculadora= new Calculadora(consoleInteracaoUsuario);
calculadora.Executar();