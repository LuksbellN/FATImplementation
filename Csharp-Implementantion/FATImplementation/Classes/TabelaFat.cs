namespace FATImplementation.Classes;

public class TabelaFat
{
    private Dictionary<int, EntradaFat> Table; 
    private int QuantidadeClustersLivres { get; set; }
    public TabelaFat(int quantClustersLivres)
    {
        QuantidadeClustersLivres = quantClustersLivres;
        Table = new Dictionary<int, EntradaFat>();
        Table.EnsureCapacity(quantClustersLivres);
        for (int i = 2; i < quantClustersLivres; i++)
        {
            Table[i] = new EntradaFat(0, false);
        }
    }

    public bool PodeArmazenarsNClusters(int clusters)
    {
        return QuantidadeClustersLivres >= clusters;
    }

    public EntradaFat RetornarEntrada(int entradaCluster)
    {
        return Table[entradaCluster];
    }
    public void AdicionarEntrada(int indiceCluster, int? proximoCluster, bool flagFimArquivo)
    {
        Table[indiceCluster] = new EntradaFat(proximoCluster, flagFimArquivo);
    }

    public void LimparEntrada(int indiceCluster)
    {
        Table[indiceCluster] = new EntradaFat(0, false);
    }

    public int RetornarProximaEntradaLivre()
    {
        return Table.FirstOrDefault(entry => entry.Value.ProximoCluster == 0).Key;
    }
}