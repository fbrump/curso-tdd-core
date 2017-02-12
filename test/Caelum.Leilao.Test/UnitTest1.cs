namespace Caelum.Leilao.Test
{
    using System;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void ShouldProcessCode()
        {
            // 1st part: scenario (ARRANGE)
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));
            leilao.Propoe(new Lance(maria, 250.0));

            // 2nd part: ACT
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // 3rd part: validation (ASSERT)
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.Equal(maiorEsperado, leiloeiro.MaiorLance);
            Assert.Equal(menorEsperado, leiloeiro.MenorLance);
        }
    }
}
