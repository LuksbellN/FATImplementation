using System.Text;
using FATImplementation.Classes;

class Program
{
    static void Main(string[] args)
    {
        // Inicializando disco
        int quantClusters = 100;
        int bytesPorClusters = 4;
        
        var disco = new Disco(quantClusters, bytesPorClusters);
        
        // Operações em arquivos
        var arquivo = new byte[]
        {
            0x4f, 0x6c, 0x61, 0x20, 0x6d, 0x75, 0x6e, 0x64, 0x6f, 0x21
        };
        string nomeArquivo = "Teste.txt";

        disco.AdicionarArquivo(nomeArquivo, arquivo);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo) ?? []));

        var arquivo2 = new byte[]
        {
            0x43, 0x6f, 0x6d, 0x6f, 0x20, 0x65, 0x73, 0x74, 0x61, 0x20, 0x74, 0x75, 0x64, 0x6f, 0x3f
        };
        string nomeArquivo2 = "Teste2.txt";

        disco.AdicionarArquivo(nomeArquivo2, arquivo2);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo2) ?? []));

        var arquivo3 = new byte[]
        {
            0x4f, 0x6c, 0x61, 0x20, 0x6d, 0x75, 0x6e, 0x64, 0x6f, 0x20, 0x65, 0x6e, 0x20, 0x65, 0x73, 0x70, 0x61, 0x6e,
            0x6f, 0x6c
        };
        string nomeArquivo3 = "Teste3.txt";

        disco.AdicionarArquivo(nomeArquivo3, arquivo3);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo3) ?? []));

        var arquivo4 = new byte[]
        {
            0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64, 0x21
        };
        string nomeArquivo4 = "Teste4.txt";

        disco.AdicionarArquivo(nomeArquivo4, arquivo4);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo4) ?? []));

        var arquivo5 = new byte[]
        {
            0x49, 0x74, 0x20, 0x69, 0x73, 0x20, 0x61, 0x20, 0x62, 0x65, 0x61, 0x75, 0x74, 0x69, 0x66, 0x75, 0x6c, 0x20,
            0x64, 0x61, 0x79
        };
        string nomeArquivo5 = "Teste5.txt";

        disco.AdicionarArquivo(nomeArquivo5, arquivo5);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo5) ?? []));

        disco.RemoverArquivo(nomeArquivo2);

        var arquivo6 = new byte[]
        {
            0x4c, 0x6f, 0x72, 0x65, 0x6d, 0x20, 0x69, 0x70, 0x73, 0x75, 0x6d, 0x20, 0x64, 0x6f, 0x6c, 0x6f, 0x72, 0x20,
            0x73, 0x69, 0x74, 0x20, 0x61, 0x6d, 0x65, 0x74
        };
        string nomeArquivo6 = "Teste6.txt";

        disco.AdicionarArquivo(nomeArquivo6, arquivo6);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo6) ?? []));

        disco.RemoverArquivo(nomeArquivo4);

        var arquivo7 = new byte[]
        {
            0x54, 0x68, 0x69, 0x73, 0x20, 0x69, 0x73, 0x20, 0x61, 0x20, 0x74, 0x65, 0x73, 0x74, 0x20, 0x6d, 0x65, 0x73,
            0x73, 0x61, 0x67, 0x65, 0x20, 0x69, 0x6e, 0x20, 0x68, 0x65, 0x78, 0x61, 0x64, 0x65, 0x63, 0x69, 0x6d, 0x61,
            0x6c
        };
        string nomeArquivo7 = "Teste7.txt";

        disco.AdicionarArquivo(nomeArquivo7, arquivo7);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo7) ?? []));

        disco.RemoverArquivo(nomeArquivo5);

        var arquivo8 = new byte[]
        {
            0x48, 0x65, 0x78, 0x61, 0x64, 0x65, 0x63, 0x69, 0x6d, 0x61, 0x6c, 0x20, 0x69, 0x73, 0x20, 0x66, 0x75, 0x6e
        };
        string nomeArquivo8 = "Teste8.txt";

        disco.AdicionarArquivo(nomeArquivo8, arquivo8);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo8) ?? []));
        
        disco.RemoverArquivo(nomeArquivo5);

        var arquivo9 = new byte[]
        {
            0x49, 0x6e, 0x20, 0x76, 0x69, 0x74, 0x61, 0x65, 0x20, 0x64, 0x75, 0x69, 0x73, 0x20, 0x65, 0x72, 0x68, 0x61,
            0x63, 0x6f, 0x20, 0x6d, 0x61, 0x69, 0x6f, 0x72
        };
        string nomeArquivo9 = "Teste9.txt";

        disco.AdicionarArquivo(nomeArquivo9, arquivo9);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo9) ?? []));
        

        Console.WriteLine(disco);
    }
}