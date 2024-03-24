namespace FATImplementation.Classes;

public class AreaDeDados
{
    private Dictionary<int, byte[]?> Clusters; 
    private int ClustersLivres { get; set; }
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
        Clusters[numeroCluster] = null;
    }
        
    public int RetornarProximoClusterLivre()
    {
        return Clusters.FirstOrDefault(entry => entry.Value == null).Key;
    }
}