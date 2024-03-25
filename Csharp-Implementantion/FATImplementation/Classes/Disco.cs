namespace FATImplementation.Classes;

public class Disco
{
    public int QuantidadeClusters { get; set; }
    public int BytesPorCluster { get; set; }
    public TabelaFat TabelaFat { get; set; }
    public EntradaDiretorio EntradaDiretorio { get; set; }
    public AreaDeDados AreaDeDados { get; set; }

    public Disco(int quantClusters, int bytesPorCluster)
    {
        QuantidadeClusters = quantClusters;
        BytesPorCluster = bytesPorCluster;
        TabelaFat = new TabelaFat(quantClusters);
        AreaDeDados = new AreaDeDados(quantClusters, bytesPorCluster);
        EntradaDiretorio = new EntradaDiretorio();
    }

    public void AdicionarArquivo(string nomeArquivo, byte[] dados)
    {
        int clustersNecessarios = (int)Math.Ceiling((double)dados.Length / BytesPorCluster);
        byte[][] dadosDividos = DividirDadosPorClusters(clustersNecessarios, dados);
        if (!TabelaFat.PodeArmazenarsNClusters(clustersNecessarios) ||
            !AreaDeDados.PodeArmazenarNClusters(clustersNecessarios))
        {
            Console.WriteLine($"Não é possível gravar o arquivo: \n {nomeArquivo}");
            return;
        }

        // Adicionando primeiro cluster
        int clusterAlterado = AreaDeDados.GravarDados(dadosDividos[0]);
        bool flagUltimoCluster = 1 >= clustersNecessarios;
        int? proximoCluster = AreaDeDados.RetornarProximoClusterLivre();

        TabelaFat.AdicionarEntrada(clusterAlterado, proximoCluster, flagUltimoCluster);

        EntradaDiretorio.AdicionarArquivo(nomeArquivo, clusterAlterado);

        // Gravando restante do arquivo  
        for (int i = 1; i < clustersNecessarios; i++)
        {
            clusterAlterado = AreaDeDados.GravarDados(dadosDividos[i]);
            flagUltimoCluster = i + 1 >= clustersNecessarios;
            proximoCluster = flagUltimoCluster ? null : AreaDeDados.RetornarProximoClusterLivre();
            TabelaFat.AdicionarEntrada(clusterAlterado, proximoCluster, flagUltimoCluster);
        }
    }


    public byte[]? RetornarArquivo(string nomeArquivo)
    {
        int clusterInicial = EntradaDiretorio.ResgatarInicioArquivo(nomeArquivo);
        if (clusterInicial == 0)
        {
            Console.WriteLine($"Não foi possível encontrar o arquivo: {nomeArquivo}");
            return null;
        }

        List<byte> dadosArquivo = new();

        var dadosCluster = AreaDeDados.RetornarDadosCluster(clusterInicial).ToList();
        EntradaFat entradaFat = TabelaFat.RetornarEntrada(clusterInicial);
        dadosArquivo.AddRange(dadosCluster);

        while (entradaFat is { FlagFimArquivo: false, ProximoCluster: not null })
        {
            int proximoCluster = (int)entradaFat.ProximoCluster;
            dadosCluster = AreaDeDados.RetornarDadosCluster(proximoCluster).ToList();

            entradaFat = TabelaFat.RetornarEntrada(proximoCluster);

            dadosArquivo.AddRange(dadosCluster);
        }

        return dadosArquivo.ToArray();
    }

    public void RemoverArquivo(string nomeArquivo)
    {
        int clusterInicial = EntradaDiretorio.ResgatarInicioArquivo(nomeArquivo);
        if (clusterInicial == 0)
        {
            Console.WriteLine($"Não foi possível encontrar o arquivo: {nomeArquivo}");
            return;
        }

        AreaDeDados.LimparDados(clusterInicial);
        EntradaFat entradaCluster = TabelaFat.RetornarEntrada(clusterInicial);
        TabelaFat.LimparEntrada(clusterInicial);

        while (entradaCluster is { FlagFimArquivo: false, ProximoCluster: not null })
        {
            int proximoCluster = (int)entradaCluster.ProximoCluster;
            entradaCluster = TabelaFat.RetornarEntrada(proximoCluster);

            AreaDeDados.LimparDados(proximoCluster);
            TabelaFat.LimparEntrada(proximoCluster);
        }

        EntradaDiretorio.RemoverArquivo(nomeArquivo);
    }


    private byte[][] DividirDadosPorClusters(int clustersNecessarios, byte[] dados)
    {
        var result = new byte[clustersNecessarios][];
        
        for (int i = 0; i < clustersNecessarios; i++)
        {
            int offset =  Math.Min(BytesPorCluster, dados.Length - i * BytesPorCluster);
            var divisao = new byte[offset];
        
            for (int j = 0; j < offset; j++)
            {
                int indice = i * BytesPorCluster + j;
                divisao[j] = dados[indice];
            }

            result[i] = divisao;
        }

        return result;
    }

    public override string ToString()
    {   
        return
            $"QuantidadeClusters: {QuantidadeClusters}, BytesPorCluster: {BytesPorCluster}, TabelaFat: {TabelaFat}, EntradaDiretorio: {EntradaDiretorio}, AreaDeDados: {AreaDeDados}";
    }
}