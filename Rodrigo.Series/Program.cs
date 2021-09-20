using System;

namespace Rodrigo.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario();

          while (opcaoUsuario.ToUpper() != "X")
          {    
            switch(opcaoUsuario)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                    AtualizarSerie();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSerie();
                    break;
                case "C":
                    Console.Clear();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }

            opcaoUsuario = ObterOpcaoUsuario();
        }

        Console.WriteLine("OBRIGADO POR ESCOLHER NOSSOS SERVIÇOS!");
        Console.ReadLine();
    }   

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

         private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
         private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
        {
            Console.WriteLine("INSERIR UMA NOVA SÉRIE");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i ,Enum.GetName(typeof(Genero), i));
            }
            Console.Write("DIGITE O GENÊRO ENTRE AS OPÇÕES ACIMA: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("DIGITE O TÍTULO DA SÉRIE: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("DIGITE O ANO DE INÍCIO DA SÉRIE: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("DIGITE A DESCRIÇÃO DA SÉRIE: ");
            string entradaDescricao = Console.ReadLine();    

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Rodrigo Séries - Satisfação Garantida!");
            Console.WriteLine("Escolha a opção desejada:");

            Console.WriteLine("1 - LISTAR SÉRIES");
            Console.WriteLine("2 - INSERIR NOVA SÉRIE");
            Console.WriteLine("3 - ATUALIZAR UMA SÉRIE");
            Console.WriteLine("4 - EXCLUIR UMA SÉRIE");
            Console.WriteLine("5 - VISUALIZAR UMA SÉRIE");
            Console.WriteLine("C - LIMPAR TELA");
            Console.WriteLine("X - SAIR");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
