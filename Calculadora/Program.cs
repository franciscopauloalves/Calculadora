using System;

namespace Calculadora
{
    class Calculadora
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; //Valor padrão é não número se uma operação de divisão puder resultar num erro.

            //Use uma switch para fazer os cálculos
            switch (op)
            {
                case "a":
                    result = num1 + num2; 
                    break;
                case "s":
                    result = num1 - num2; 
                    break;
                case "m":
                    result = num1 * num2; 
                    break;
                case "d":;
                    //Peça para  usuário entrar com um divisor diferente de zero.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    } 
                    break;

                //Retornará um texto de alerta quando o valor for inválido.
                default:
                    break;
            }
            return result;
        }
    }


    class Programa
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            //Display com o ítulo da aplicação em C#
            Console.WriteLine("Console Calculadora em C#\r");
            Console.WriteLine("-------------------------\n");

            while (!endApp)
            {
                //Declarando as variávies no estado inicial: 
                //Vazias e resultado 0
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                //Peça para o usuário escrever o primeiro número e guarda na variável numInput1
                Console.Write("Digite um némero e pressione Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Este é um valor inválido. Por favor digite um valor válido: ");
                    numInput1 = Console.ReadLine();
                }

                //Peça para o usuário escrever o segundo número e guarde na variável numInput2
                Console.Write("Digite outro número e presione Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.WriteLine("Este é um valor inválido. Por favor digite um valor válido: ");
                    numInput2 = Console.ReadLine();
                }

                //Peça para o usuário escolher a opção de operação
                Console.WriteLine("Escolha um operador da lista seguinte: ");
                Console.WriteLine("\ta - Adicionar");
                Console.WriteLine("\ts - Subtrar");
                Console.WriteLine("\tm - Multiplicar");
                Console.WriteLine("\td - Dividir");
                Console.Write("Sua opção: ");

                //Ler a oção selecionada
                string op = Console.ReadLine();

                //Alerta
                try
                {
                    result = Calculadora.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Este operador irá resultar num erro.\n");
                        Console.WriteLine("--------------------------------------");
                    }
                    else
                        Console.WriteLine("Seu resultado: {00:0.##}\n", result);
                }

                //Mensagem caso ocorra uma exceção
                catch (Exception e)
                {
                    Console.WriteLine("Exceção ocorreu,tente fazer a operação.\n" + e.Message);
                }

                Console.WriteLine("------------------------------------------");

                //Espere pelo usuário para finalizar a aplicação
                Console.WriteLine("Digite s e pressione Enter para continuar, ou n e pressione Enter para fechar a aplicação: ");
                if (Console.ReadLine() == "n") endApp = true;
                Console.WriteLine("\n");//Linha amigável
                Console.WriteLine("Console Calculadora em C#\r"); //Recomeçar
            }
            return;
        }
    }
}

//ADICIONANDO FUNCIONALIDADE DECIMAL
//Para localizar e substituir precione "Ctrl + H"
//Tipos primitivos: int --> float
//A propriedade Convert.ToInt32 --> Convert.ToDouble

//CORRIGIR "DIVISÃO POR ZERO"
//Substituir os códigos do Case "d".

//CORRIGIR ERRO DE FORMATO
//INSERIR CARACTER ALFANUMÉRICO EM VEZ DE NÚMERICO
//Para isso deve refatorar o código inserido anteriormente

//São Paulo 03.06.2022
//IPT - CSTI