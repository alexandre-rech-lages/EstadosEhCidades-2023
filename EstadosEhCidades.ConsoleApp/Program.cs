/**
 * Desenvolva um programa em C# que leia o arquivo cidades.csv 
 * e dê a possibilidade de apresentar as cidades:
    1) agrupadas pela primeira letra 
    2) ou pelo estado que pertence.
 * 
 */
namespace EstadosEhCidades.ConsoleApp
{
    //https://pt.stackoverflow.com/questions/146048/qual-%C3%A9-a-diferen%C3%A7a-entre-n-e-r-n-caracteres-especiais-para-quebra-de-linh
    internal class Program
    {
        static string[] ObterCidadesEhEstados(string caminhoDoArquivo)
        {
            const int POSICAO_CIDADE = 2;
            const int POSICAO_ESTADO = 3;

            string arquivo = File.ReadAllText(caminhoDoArquivo);

            string[] linhas = arquivo.Split("\r\n");

            string[] cidadesEhEstados = new string[linhas.Length];

            int j = 0;
            for (int i = 1; i < linhas.Length; i++)
            {
                string[] colunas = linhas[i].Split(";");

                cidadesEhEstados[j] = colunas[POSICAO_CIDADE] + ";" + colunas[POSICAO_ESTADO];

                j++;
            }

            return cidadesEhEstados;
        }

        static void MostrarCidadesAgrupadasPelaPrimeiraLetra(string[] cidadesEhEstados)
        {
            Console.Clear();

            char[] alfabeto = new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                   'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

            for (int i = 0; i < alfabeto.Length; i++)
            {
                //mostrar o cabeçalho
                Console.WriteLine($"\nCidades com a letra {alfabeto[i]}\n");

                for (int x = 0; x < cidadesEhEstados.Length; x++)
                {
                    char primeiraLetra = alfabeto[i];

                    //verificar se o nome do municipio inicia com a letra selecionada
                    if (cidadesEhEstados[x] != null && cidadesEhEstados[x].StartsWith(primeiraLetra))
                    {
                        int posicaoInicioEstado = cidadesEhEstados[x].IndexOf(";");
                        string cidadeSemEstado = cidadesEhEstados[x].Remove(posicaoInicioEstado);
                        Console.WriteLine("\t" + cidadeSemEstado);
                    }
                }
            }
        }

        static void MostrarCidadesAgrupadasPorEstado(string[] cidadesEhEstados)
        {
            Console.Clear();
            string[] estados = new string[]
               {
                "Acre", "Alagoas", "Amapá", "Amazonas", "Bahia", "Ceará", "Distrito Federal",
                "Espírito Santo", "Goiás", "Maranhão", "Mato Grosso", "Mato Grosso do Sul",
                "Minas Gerais", "Pará", "Paraíba", "Paraná", "Pernambuco", "Piauí", "Rio de Janeiro",
                "Rio Grande do Norte", "Rio Grande do Sul", "Rondônia", "Roraima", "Santa Catarina",
                "São Paulo", "Sergipe", "Tocantins"
               };

            for (int i = 0; i < estados.Length; i++)
            {
                //mostrar o cabeçalho
                string estado = estados[i];

                Console.WriteLine($"\nCidades do estado: {estado}\n");

                for (int x = 0; x < cidadesEhEstados.Length; x++)
                {
                    if (cidadesEhEstados[x] != null && cidadesEhEstados[x].Contains(estado))
                    {
                        int posicaoInicioEstado = cidadesEhEstados[x].IndexOf(";");
                        string cidadeSemEstado = cidadesEhEstados[x].Remove(posicaoInicioEstado);
                        Console.WriteLine("\t" + cidadeSemEstado);
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            string caminhoArquivo = @"Dados\Cidades.csv";

            string[] cidadesEhEstados = ObterCidadesEhEstados(caminhoArquivo);

            Console.WriteLine("Menu de Escolha:");

            Console.WriteLine("Digite 1 para apresentar as cidades agrupadas pela primeira letra:");

            Console.WriteLine("Digite 2 para apresentar as cidades agrupadas por estado:");

            string opcao = Console.ReadLine();

            if (opcao == "1")
                MostrarCidadesAgrupadasPelaPrimeiraLetra(cidadesEhEstados);

            else if (opcao == "2")
                MostrarCidadesAgrupadasPorEstado(cidadesEhEstados);

            Console.ReadLine();
        }
    }
}