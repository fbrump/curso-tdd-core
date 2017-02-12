namespace Caelum.Leilao.Test
{
    using System;
    using Xunit;
    using Caelum.Leilao;

    public class TesteDoAvaliador
    {
        [Fact]
        public void Should_process_code()
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
            double mediaEsperada = 317;

            Assert.Equal(maiorEsperado, leiloeiro.MaiorLance);
            Assert.Equal(menorEsperado, leiloeiro.MenorLance);
            Assert.Equal(mediaEsperada, Math.Ceiling(leiloeiro.MediaLance));

        }
        
        [Fact]
        public void Should_understand_auction_with_just_one_throw()
        {
            //Given
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 1000));

            //When
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);
            
            //Then
            Assert.Equal(1000, leiloeiro.MaiorLance);
            Assert.Equal(1000, leiloeiro.MenorLance);
        }

        [Fact]
        public void Should_return_palindrome_is_true()
        {
            //Given
            var frase_civic = "civic";

            //When
            Palindromo palindrome = new Palindromo();
            var result_true = palindrome.EhPalindromo(frase_civic);

            //Then
            Assert.Equal(true, result_true);
        }

        [Fact]
        public void Should_return_palindrome_is_false()
        {
            //Given
            var frase_resultado = "resultado";

            //When
            Palindromo palindrome = new Palindromo();
            var result_false = palindrome.EhPalindromo(frase_resultado);

            //Then
            Assert.False(result_false);
        }

    }
}
