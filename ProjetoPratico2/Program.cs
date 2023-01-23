using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

namespace ConsoleAppAtividade3Theus
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            string[,] arrayCD = new string[100, 4];
            string[,] arrayVD = new string[100, 3];
            do
            {
                impressaoEstoque(arrayCD);
                int opcao = menu();
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        cadastro(arrayCD);
                        break;
                    case 2:
                        Vender(arrayVD, arrayCD);
                        break;
                    case 3:
                        relatorioVenda(arrayVD, arrayCD);
                        break;
                    case 4:
                        relatorioVP(arrayVD, arrayCD);
                        break;
                    case 0:
                        sair = true;
                        break;
                }
                Console.Clear();
            } while (!sair);
        }
        static int menu()
        {
            Console.WriteLine("Menu:\r\n ========================================\r\n1 - Cadastrar produtos\r\n2 - Realizar uma venda\r\n3 - Relatório de vendas\r\n4 - Relatório de vendas porfuncionários\r\n0 - Sair\r\nSelecione uma opção: ");
            int x = int.Parse(Console.ReadLine());
            return x;
        }
        static void impressaoEstoque(string[,] arrayCD)
        {
            for (int l = 0; l < 100; l++)
{
                if (!string.IsNullOrEmpty(arrayCD[l, 0]))
                {
                    Console.WriteLine($"{arrayCD[l, 0]} ||{arrayCD[l, 1]} || { arrayCD[l, 2]} || { arrayCD[l, 3]} || ");

                }
            }
        }
        static void cadastro(string[,] arrayCD)
        {
            Console.WriteLine("Realizar um cadastramento _\r\n");
            for (int l = 0; l  < 100; l++){
                if (string.IsNullOrEmpty(arrayCD[l, 0]))
                {
                    Console.WriteLine($" Id Gerado: { l}");
                    arrayCD[l, 0] = $"{ l}";
                    Console.Write(" Descrição: ");
                    arrayCD[l, 1] = Console.ReadLine();
                    Console.Write(" Valor: ");
                    arrayCD[l, 2] = Console.ReadLine();
                    Console.Write(" Quantidade: ");
                    arrayCD[l, 3] = Console.ReadLine();
                    break;
                }
            }
        }
        static void Vender(string[,] arrayVD, string[,] arrayCD)
        {
            Console.WriteLine(" Ralizar uma venda __\r\n ");
            int j = 0;
            for (int l = 0; l  < 100; l++)
{
                if (string.IsNullOrEmpty(arrayVD[l, 0]))
                {
                    Console.Write(" Codigo Produto: ");
                    string codproduto = Console.ReadLine();
                    Console.Write(" Codigo Funicionario: ");
                    string funcionario = Console.ReadLine();
                    Console.Write(" Quantidade: ");
                    string quantidade = Console.ReadLine();
                    string[] meuProduto = new string[4];
                    for (j = 0; j  < 100; j++)
{
                        if (!string.IsNullOrEmpty(arrayCD[j, 0]))
                        {
                            if (arrayCD[j, 0] == codproduto)
                            {
                                meuProduto[0] = arrayCD[j, 0];
                                meuProduto[1] = arrayCD[j, 1];
                                meuProduto[2] = arrayCD[j, 2];
                                meuProduto[3] = arrayCD[j, 3];
                                break;
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(meuProduto[0]))
                    {

                        Console.WriteLine(" Prodouto nãoencontardo! ");
                    }
                    else{
                        if (int.Parse(meuProduto[3]) -int.Parse(quantidade)  >= 0){ 
                            arrayVD[l, 2] = quantidade;
                            arrayVD[l, 1] = funcionario;
                            arrayVD[l, 0] = codproduto;
                            arrayCD[j, 3] = (int.Parse(meuProduto[3]) - int.Parse(quantidade)).ToString();
                        }else{ Console.WriteLine(" Produto nãodisponível");
                        }
                    }
                    break;
                }
            }
            Console.ReadKey();
        }
        static void relatorioVenda(string[,] arrayVD, string[,]
        arrayCD)
        {
            Console.WriteLine(" Relatório de vendas _ ");
            double totalVenda = 0;
            Console.WriteLine(" COD || FUCN ||VALOR\r\n====================\r\n ");
            for (int l = 0; l  < 100; l++)
{
                string valorProduto = " " ;
                for (int j = 0; j  < 100; j++)
{
                    if (!string.IsNullOrEmpty(arrayCD[j, 0]))
                    {
                        if (arrayCD[j, 0] == arrayVD[l, 0])
                        {
                            valorProduto =
                            (double.Parse(arrayCD[j, 2]) * double.Parse(arrayVD[l,
                            2])).ToString();
                            totalVenda =
                            double.Parse(valorProduto) + totalVenda;
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(arrayVD[l, 0]))
                {
                    Console.WriteLine($"{ arrayVD[l, 0]} ||{ arrayVD[l, 1]} || { valorProduto}");
                }
            }
            Console.WriteLine($"\r\nO valor total das vendas foi{ totalVenda}");
            Console.ReadKey();
        }
        static void relatorioVP(string[,] arrayVD, string[,]
        arrayCD)
        {
            Console.WriteLine(" Relatório de vendas por funcionário_ \r\n ");
            Console.WriteLine(" Digite o código do funcionário a ser procurado_ \r\n ");
            string codChoice = (Console.ReadLine());
            double porcent = 0;
            double totalVenda = 0;
            string valorVenda = " " ;
            for (int l = 0; l  < 100; l++)
{
                string valorProduto = " " ;
                for (int j = 0; j  < 100; j++)
{
                    if (!string.IsNullOrEmpty(arrayCD[j, 0])  && codChoice == arrayVD[l, 1])
{
                        if (arrayCD[j, 0] == arrayVD[l, 0])
                        {
                            valorProduto =
                            (double.Parse(arrayCD[j, 2]) * double.Parse(arrayVD[l,
                            2])).ToString();
                            totalVenda =
                            double.Parse(valorProduto) + totalVenda;
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(arrayVD[l, 0])  &&
                codChoice == arrayVD[l, 1])
{
                    Console.WriteLine($"{ arrayVD[l, 0]} ||{ arrayVD[l, 1]} || { valorProduto}");
                }
            }
            Console.WriteLine($" Total: { totalVenda}");
            Console.WriteLine($" 10 %:{ totalVenda * 0.10}");
            Console.ReadKey();
        }
    }
}