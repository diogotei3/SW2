using System.Threading.Tasks;

public class LivroRepositorioCSV
{
    //private static readonly string nomeArquivoCSV = "Repositorio\\livros.csv";
    private static readonly string nomeArquivoCSV = "D:\\Downloads\\Visual Studio\\ConsoleAppAula1\\ConsoleAppAula1\\Repositorio\\livros.csv";

    private ListaDeLeitura _paraler;
    private ListaDeLeitura _lendo;
    private ListaDeLeitura _lidos;

    public LivroRepositorioCSV()
    {
        var arrayParaler = new List<Livro>();
        var arrayLendo = new List<Livro>();
        var arrayLidos = new List<Livro>();

        using (var file = File.OpenText(LivroRepositorioCSV.nomeArquivoCSV))
        {
            while (!file.EndOfStream)
            {
                var textoLivro = file.ReadLine();
                if (string.IsNullOrEmpty(textoLivro))
                {
                    continue;
                }
                var infoLivro = textoLivro.Split(';');
                var livro = new Livro
                {
                    Id = Convert.ToInt32(infoLivro[1]),
                    Titulo = infoLivro[2],
                    Autor = infoLivro[3]
                };
                switch (infoLivro[0])
                {
                    case "para-ler":
                        arrayParaler.Add(livro);
                        break;
                    case "lendo":
                        arrayLendo.Add(livro);
                        break;
                    case "lidos":
                        arrayLidos.Add(livro);
                        break;
                    default:
                        break;
                }
            }
        }

        _paraler = new ListaDeLeitura("Para ler", arrayParaler.ToArray());
        _lendo = new ListaDeLeitura("Lendo", arrayLendo.ToArray());
        _lidos = new ListaDeLeitura("Lido", arrayLidos.ToArray());

    }
    public ListaDeLeitura Paraler => _paraler;
    public ListaDeLeitura Lendo => _lendo;
    public ListaDeLeitura Lidos => _lidos;

    public IEnumerable<Livro> Todos => _paraler.Livros.Union(_lendo.Livros).Union(_lidos.Livros);

    public void Incluir(Livro livro)
    {
        var id = Todos.Select(l => l.Id).Max();
        using (var file = File.AppendText(LivroRepositorioCSV.nomeArquivoCSV))
        {
            string value = $"para-ler; {id + 1}; {livro.Titulo}; {livro.Autor}";
            file.WriteLine(value);
        }
    }
}