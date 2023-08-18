public interface ILivroRepositorio { 
    ListaDeLeitura paraLer { get; }
    ListaDeLeitura Lendo { get; }
    ListaDeLeitura Lidos { get; }
    IEnumerable<Livro> Todos { get; }
    public void Incluir(Livro livro);
}