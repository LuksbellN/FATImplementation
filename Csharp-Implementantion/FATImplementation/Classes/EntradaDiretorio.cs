namespace FATImplementation.Classes;

public class EntradaDiretorio
{
    private Dictionary<string, int> Arquivos;

    public EntradaDiretorio()
    {
        Arquivos = new Dictionary<string, int>();
    }

    public int ResgatarInicioArquivo(string nomeArquivo)
    {
        Arquivos.TryGetValue(nomeArquivo, out int result);
        return result;
    }

    public void AdicionarArquivo(string nomeArquivo, int startCluster)
    {
        Arquivos.Add(nomeArquivo, startCluster);
    }

    public void RemoverArquivo(string nomeArquivo)
    {
        Arquivos.Remove(nomeArquivo);
    }
}