using System;
using System.Collections.Generic;
using System.Text;
using FATImplementation.Classes;

class Program
{
    static void Main(string[] args)
    {
        var disco = new Disco(200, 2);
        var arquivo = new byte[]
        {
            0x4f, 0x6c, 0x61, 0x20, 0x6d, 0x75, 0x6e, 0x64, 0x6f, 0x21
        };
        string nomeArquivo = "Teste.txt";

        disco.AdicionarArquivo(nomeArquivo, arquivo);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo)!));

        var arquivo2 = new byte[]
        {
            0x43, 0x6f, 0x6d, 0x6f, 0x20, 0x65, 0x73, 0x74, 0x61, 0x20, 0x74, 0x75, 0x64, 0x6f, 0x3f
        };
        string nomeArquivo2 = "Teste2.txt";

        disco.AdicionarArquivo(nomeArquivo2, arquivo2);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo2)!));
        disco.RemoverArquivo(nomeArquivo);

        var arquivo3 = new byte[]
        {
            0x4f, 0x6c, 0x61, 0x20, 0x6d, 0x75, 0x6e, 0x64, 0x6f, 0x20, 0x65, 0x6e, 0x20, 0x65, 0x73, 0x70, 0x61, 0x6e,
            0x6f, 0x6c
        };
        string nomeArquivo3 = "Teste3.txt";

        disco.AdicionarArquivo(nomeArquivo3, arquivo3);
        Console.WriteLine(Encoding.UTF8.GetString(disco.RetornarArquivo(nomeArquivo3)!));

    }
}