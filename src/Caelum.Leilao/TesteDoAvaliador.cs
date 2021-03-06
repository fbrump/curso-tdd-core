namespace Caelum.Leilao
{
    using System;

    public class TesteDoAvaliador
    {
        static void Main(string[] args)
        {
            // 1st part: scenario (ARRANGE)
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // 2nd part: ACT
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // 3rd part: validation (ASSERT)
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Console.WriteLine(maiorEsperado == leiloeiro.MaiorLance);
            Console.WriteLine(menorEsperado == leiloeiro.MenorLance);

            Console.ReadKey();

        }
    }
}