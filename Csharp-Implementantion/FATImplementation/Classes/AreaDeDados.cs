namespace FATImplementation.Classes;

public class AreaDeDados
{
    public Dictionary<int, byte[]?> Clusters; 
    public int ClustersLivres { get; set; }
    // Construtor
    public AreaDeDados(int quantClusters, int bytesPorCluster)
    {
        ClustersLivres = quantClusters;
        Clusters = new Dictionary<int, byte[]?>();
        Clusters.EnsureCapacity(quantClusters);
        for (int i = 2; i < quantClusters; i++)
        {
            Clusters[i] = null;
        }
    }
    
    public byte[] RetornarDadosCluster(int clusterNumber)
    {
        return (Clusters.ContainsKey(clusterNumber) ? Clusters[clusterNumber] : null)!; 
    }

    public bool PodeArmazenarNClusters(int clusters)
    {
        return ClustersLivres >= clusters;
    }
    
    // Método para escrever dados em um cluster
    public int GravarDados(byte[] data)
    {
        int numeroCluster = RetornarProximoClusterLivre();
        
        Clusters[numeroCluster] = data;
        ClustersLivres--;
        return numeroCluster;
    }

    public void LimparDados(int numeroCluster)
    {
        ClustersLivres++;
        Clusters[numeroCluster] = null;
    }
        
    public int RetornarProximoClusterLivre()
    {
        return Clusters.FirstOrDefault(entry => entry.Value == null).Key;
    }
    
    public override string ToString()
    {
        string clustersString = "Clusters: {\n";
        foreach (var entry in Clusters)
        {
            clustersString += $"\t{entry.Key}: {entry.Value},\n";
        }
        clustersString += string.Format("}}, ClustersLivres: {0}", ClustersLivres);
        return clustersString;
    }
}