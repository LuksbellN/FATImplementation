namespace FATImplementation.Classes;

public class EntradaFat
{
    public int? ProximoCluster { get; set; } 
    public bool FlagFimArquivo { get; set; }

    public EntradaFat(int? proximoCluster, bool flagFimArquivo)
    {
        ProximoCluster = proximoCluster;
        FlagFimArquivo = flagFimArquivo;
    }
    
    public override string ToString()
    {
        return $"ProximoCluster: {ProximoCluster}, FlagFimArquivo: {FlagFimArquivo}";
    }
}