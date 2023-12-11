namespace StarWars.ViewModels;

public class ResultViewModel<T> where T : class
{
    public T Data { get; set; }
    public List<string> Erros { get; set; } = new();

    public ResultViewModel(T data, List<string> erros)
    {
        Data = data;
        Erros = erros;
    }

    public ResultViewModel(T data)
        => Data = data;

    public ResultViewModel(string error)
        => Erros.Add(error);

    public ResultViewModel(IEnumerable<string> erros)
        => Erros.AddRange(erros);
}