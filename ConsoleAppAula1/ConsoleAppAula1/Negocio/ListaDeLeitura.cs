using System.Text;

public class ListaDeLeitura
{
    private List<Livro> _livros;
    public string Titulo { get; set; }
    public ListaDeLeitura(string titulo, params Livro[] livros)
    {
        this.Titulo = titulo;
        _livros = livros.ToList();
        _livros.ForEach(l => l.Lista = this);
    }

    public IEnumerable<Livro> Livros
    {
        get { return _livros; } 
    }

    public override string ToString() {
         var Linhas = new StringBuilder();
         Linhas.AppendLine(Titulo);
         Linhas.AppendLine("=======");
         foreach (var livro in Livros)
         {
            Linhas.AppendLine(livro.ToString());
         }
         return Linhas.ToString();
    }


}
