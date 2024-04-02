namespace FATImplementation.Classes;

public class TabelaFat
{
    public Dictionary<int, EntradaFat> Table; 
    public int QuantidadeClustersLivres { get; set; }
    public TabelaFat(int quantClustersLivres)
    {
        QuantidadeClustersLivres = quantClustersLivres;
        Table = new Dictionary<int, EntradaFat>();
        Table.EnsureCapacity(quantClustersLivres);
        // 2 primeiros clusters reservados  
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
        QuantidadeClustersLivres--;
        Table[indiceCluster] = new EntradaFat(proximoCluster, flagFimArquivo);
    }

    public void LimparEntrada(int indiceCluster)
    {
        QuantidadeClustersLivres++;
        Table[indiceCluster] = new EntradaFat(0, false);
    }

    public int RetornarProximaEntradaLivre()
    {
        return Table.FirstOrDefault(entry => entry.Value.ProximoCluster == 0).Key;
    }
    
    public override string ToString()
    {
        string tableString = "Table: {\n";
        foreach (var entry in Table)
        {
            tableString += $"\t{entry.Key}: {entry.Value},\n";
        }
        tableString += string.Format("}}, QuantidadeClustersLivres: {0}", QuantidadeClustersLivres);
        return tableString;
    }
}