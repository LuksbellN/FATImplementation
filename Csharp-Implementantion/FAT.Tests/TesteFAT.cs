using System.Text;
using FATImplementation.Classes;

namespace YourTestProjectNamespace
{
    [TestFixture]
    public class DiscoTests
    {
        [Test]
        public void AdicionarArquivo_RetornarArquivo()
        {
            // Arrange
            var disco = new Disco(75, 2);

            var arquivo = new byte[]
            {
                0x4f, 0x6c, 0x61, 0x20, 0x6d, 0x75, 0x6e, 0x64, 0x6f, 0x21
            };
            string nomeArquivo = "Teste.txt";

            disco.AdicionarArquivo(nomeArquivo, arquivo);
            var resultado = disco.RetornarArquivo(nomeArquivo) ?? [];

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(Encoding.UTF8.GetString(arquivo), Encoding.UTF8.GetString(resultado));
            Console.WriteLine(Encoding.UTF8.GetString(resultado));

            var arquivo2 = new byte[]
            {
                0x43, 0x6f, 0x6d, 0x6f, 0x20, 0x65, 0x73, 0x74, 0x61, 0x20, 0x74, 0x75, 0x64, 0x6f, 0x3f
            };
            string nomeArquivo2 = "Teste2.txt";

            disco.AdicionarArquivo(nomeArquivo2, arquivo2);
            var resultado2 = disco.RetornarArquivo(nomeArquivo2) ?? [];

            // Assert
            Assert.IsNotNull(resultado2);
            Assert.AreEqual(Encoding.UTF8.GetString(arquivo2), Encoding.UTF8.GetString(resultado2));
            Console.WriteLine(Encoding.UTF8.GetString(resultado2));

            var arquivo3 = new byte[]
            {
                0x4f, 0x6c, 0x61, 0x20, 0x6d, 0x75, 0x6e, 0x64, 0x6f, 0x20, 0x65, 0x6e, 0x20, 0x65, 0x73, 0x70, 0x61,
                0x6e,
                0x6f, 0x6c
            };
            string nomeArquivo3 = "Teste3.txt";

            disco.AdicionarArquivo(nomeArquivo3, arquivo3);
            var resultado3 = disco.RetornarArquivo(nomeArquivo3) ?? [];

            // Assert
            Assert.IsNotNull(resultado3);
            Assert.AreEqual(Encoding.UTF8.GetString(arquivo3), Encoding.UTF8.GetString(resultado3));
            Console.WriteLine(Encoding.UTF8.GetString(resultado3));

            var arquivo4 = new byte[]
            {
                0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64, 0x21
            };
            string nomeArquivo4 = "Teste4.txt";

            disco.AdicionarArquivo(nomeArquivo4, arquivo4);
            var resultado4 = disco.RetornarArquivo(nomeArquivo4) ?? [];

            // Assert
            Assert.IsNotNull(resultado4);
            Assert.AreEqual(Encoding.UTF8.GetString(arquivo4), Encoding.UTF8.GetString(resultado4));
            Console.WriteLine(Encoding.UTF8.GetString(resultado4));

            var arquivo5 = new byte[]
            {
                0x49, 0x74, 0x20, 0x69, 0x73, 0x20, 0x61, 0x20, 0x62, 0x65, 0x61, 0x75, 0x74, 0x69, 0x66, 0x75, 0x6c,
                0x20,
                0x64, 0x61, 0x79
            };
            string nomeArquivo5 = "Teste5.txt";

            disco.AdicionarArquivo(nomeArquivo5, arquivo5);
            var resultado5 = disco.RetornarArquivo(nomeArquivo5) ?? [];

            // Assert
            Assert.IsNotNull(resultado5);
            Assert.AreEqual(Encoding.UTF8.GetString(arquivo5), Encoding.UTF8.GetString(resultado5));
            Console.WriteLine(Encoding.UTF8.GetString(resultado5));

            disco.RemoverArquivo(nomeArquivo2);

            var arquivo6 = new byte[]
            {
                0x4c, 0x6f, 0x72, 0x65, 0x6d, 0x20, 0x69, 0x70, 0x73, 0x75, 0x6d, 0x20, 0x64, 0x6f, 0x6c, 0x6f, 0x72,
                0x20,
                0x73, 0x69, 0x74, 0x20, 0x61, 0x6d, 0x65, 0x74
            };
            string nomeArquivo6 = "Teste6.txt";

            disco.AdicionarArquivo(nomeArquivo6, arquivo6);
            var resultado6 = disco.RetornarArquivo(nomeArquivo6) ?? [];

            // Assert
            Assert.IsNotNull(resultado6);
            Assert.AreEqual(Encoding.UTF8.GetString(arquivo6), Encoding.UTF8.GetString(resultado6));
            Console.WriteLine(Encoding.UTF8.GetString(resultado6));

            disco.RemoverArquivo(nomeArquivo4);

            var arquivo7 = new byte[]
            {
                0x54, 0x68, 0x69, 0x73, 0x20, 0x69, 0x73, 0x20, 0x61, 0x20, 0x74, 0x65, 0x73, 0x74, 0x20, 0x6d,
                0x65, 0x73, 0x73, 0x61, 0x67, 0x65, 0x20, 0x69, 0x6e, 0x20, 0x68, 0x65, 0x78, 0x61, 0x64, 0x65,
                0x63, 0x69, 0x6d, 0x61, 0x6c
            };
            string nomeArquivo7 = "Teste7.txt";

            disco.AdicionarArquivo(nomeArquivo7, arquivo7);
            var resultado7 = disco.RetornarArquivo(nomeArquivo7) ?? [];

            // Assert
            Assert.IsNotNull(resultado7);
            Assert.AreEqual(Encoding.UTF8.GetString(arquivo7), Encoding.UTF8.GetString(resultado7));
            Console.WriteLine(Encoding.UTF8.GetString(resultado7));

            disco.RemoverArquivo(nomeArquivo5);

            var arquivo8 = new byte[]
            {
                0x48, 0x65, 0x78, 0x61, 0x64, 0x65, 0x63, 0x69, 0x6d, 0x61, 0x6c, 0x20, 0x69, 0x73, 0x20, 0x66, 0x75,
                0x6e
            };
            string nomeArquivo8 = "Teste8.txt";

            disco.AdicionarArquivo(nomeArquivo8, arquivo8);
            var resultado8 = disco.RetornarArquivo(nomeArquivo8) ?? [];

            // Assert
            Assert.IsNotNull(resultado8);
            Assert.AreEqual(Encoding.UTF8.GetString(arquivo8), Encoding.UTF8.GetString(resultado8));
            Console.WriteLine(Encoding.UTF8.GetString(resultado8));

            disco.RemoverArquivo(nomeArquivo);

            var arquivo9 = new byte[]
            {
                0x49, 0x6e, 0x20, 0x76, 0x69, 0x74, 0x61, 0x65, 0x20, 0x64, 0x75, 0x69, 0x73, 0x20, 0x65, 0x72, 0x68,
                0x61,
                0x63, 0x6f, 0x20, 0x6d, 0x61, 0x69, 0x6f, 0x72
            };
            string nomeArquivo9 = "Teste9.txt";

            disco.AdicionarArquivo(nomeArquivo9, arquivo9);
            var resultado9 = disco.RetornarArquivo(nomeArquivo9) ?? [];

            // Assert
            Assert.IsNotNull(resultado9);
            Assert.AreEqual(Encoding.UTF8.GetString(arquivo9), Encoding.UTF8.GetString(resultado9));
            Console.WriteLine(Encoding.UTF8.GetString(resultado9));
            
            Console.WriteLine(disco);

        }
    }
}