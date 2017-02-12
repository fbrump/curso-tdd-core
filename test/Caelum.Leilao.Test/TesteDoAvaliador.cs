namespace Caelum.Leilao.Test
{
    using System;
    using Xunit;
    using Caelum.Leilao;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

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
        public void Should_find_three_max_values()
        {
            //Given
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            //When
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            //Then
            Assert.Equal(3, maiores.Count);
            Assert.Equal(400, maiores[0].Valor, 2);
            Assert.Equal(300, maiores[1].Valor, 2);
            Assert.Equal(200, maiores[2].Valor, 2);
            
        }

        [Fact]
        public void Shouldprocess_code_with_one_throw()
        {
            //Given
            Usuario joao = new Usuario("Joao");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 200));
            //When
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);
            
            //Then
            Assert.Equal(200, leiloeiro.MaiorLance, 2);
            Assert.Equal(200, leiloeiro.MenorLance, 2);
            Assert.Equal(200, leiloeiro.MediaLance, 2);
        }

        [Fact]
        public void Should_process_code_with_random_values()
        {
            //Given
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 200.0));
            leilao.Propoe(new Lance(maria, 450.0));
            leilao.Propoe(new Lance(joao, 120.0));
            leilao.Propoe(new Lance(maria, 700.0));
            leilao.Propoe(new Lance(joao, 630.0));
            leilao.Propoe(new Lance(maria, 230.0));

            //When
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            //Then
            Assert.Equal(120, leiloeiro.MenorLance);
            Assert.Equal(700, leiloeiro.MaiorLance);
        }

        [Fact]
        public void Should_process_code_with_throws_descending_order()
        {
            //Given
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 400.0));
            leilao.Propoe(new Lance(maria, 300.0));
            leilao.Propoe(new Lance(joao, 200.0));
            leilao.Propoe(new Lance(maria, 100.0));

            //When
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;
            //Then
            Assert.Equal(100, leiloeiro.MenorLance);
            Assert.Equal(400, leiloeiro.MaiorLance);
            Assert.Equal(400, maiores[0].Valor);
            Assert.Equal(300, maiores[1].Valor);
            Assert.Equal(200, maiores[2].Valor);
        }

        [Fact]
        public void Should_find_three_max_values_in_five_throws()
        {
            //Given
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 340.0));
            leilao.Propoe(new Lance(joao, 400.0));

            //When
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            //Then
            Assert.Equal(3, maiores.Count);
            Assert.Equal(400, maiores[0].Valor, 2);
            Assert.Equal(340, maiores[1].Valor, 2);
            Assert.Equal(300, maiores[2].Valor, 2);
        }

        [Fact]
        public void Should_find_max_values_in_two_throws()
        {
            //Given
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));

            //When
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            //Then
            Assert.Equal(2, maiores.Count);
            Assert.Equal(200, maiores[0].Valor, 2);
            Assert.Equal(100, maiores[1].Valor, 2);
        }

        [Fact]
        public void Should_find_max_values_in_zero_throws()
        {
            //Given
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            //When
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            //Then
            Assert.Equal(0, maiores.Count);
        }

        [Fact]
        public void Should_crazy_math_more_then_thirty()
        {
            //Given
            var valor = 32;
            
            //When
            MatematicaMaluca matematicaMaluca = new MatematicaMaluca();
            var result = matematicaMaluca.ContaMaluca(valor);

            //Then
            Assert.Equal(128, result);
        }

        [Fact]
        public void Should_crazy_math_more_then_ten()
        {
            //Given
            var valor = 15;
            
            //When
            MatematicaMaluca matematicaMaluca = new MatematicaMaluca();
            var result = matematicaMaluca.ContaMaluca(valor);

            //Then
            Assert.Equal(45, result);
        }

        [Fact]
        public void Should_crazy_math_return_multiple_for_two()
        {
            //Given
            var valor = 9;
            
            //When
            MatematicaMaluca matematicaMaluca = new MatematicaMaluca();
            var result = matematicaMaluca.ContaMaluca(valor);

            //Then
            Assert.Equal(18, result);
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

        [Fact]
        public void DeveSelecionarLancesEntre1000E3000()
        {
            //Given
            Usuario joao = new Usuario("Joao");
            
            //When
            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() { 
                new Lance(joao,2000), 
                new Lance(joao,1000), 
                new Lance(joao,3000), 
                new Lance(joao, 800)});

            //Then
            Assert.Equal(1, resultado.Count);
            Assert.Equal(2000, resultado[0].Valor, 2);
        }

        [Fact]
        public void DeveSelecionarLancesEntre500E700()
        {
            //Given
            Usuario joao = new Usuario("Joao");

            //When
            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao,600), 
                new Lance(joao,500), 
                new Lance(joao,700), 
                new Lance(joao, 800)});
            
            //Then
            Assert.Equal(1, resultado.Count);
            Assert.Equal(600, resultado[0].Valor, 2);
        }

        [Fact]
        public void DeveSelecionarLancesMaior5000()
        {
            //Given
            Usuario joao = new Usuario("Joao");

            //When
            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao,6000), 
                new Lance(joao,5000), 
                new Lance(joao,3500), 
                new Lance(joao, 5800)});
            
            //Then
            Assert.Equal(2, resultado.Count);
            Assert.Equal(6000, resultado[0].Valor, 2);
            Assert.Equal(5800, resultado[1].Valor, 2);
        }

        [Fact]
        public void DeveSelecionarLancesMenor500()
        {
            //Given
            Usuario joao = new Usuario("Joao");

            //When
            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao,60), 
                new Lance(joao,50), 
                new Lance(joao,35), 
                new Lance(joao, 58)});
            
            //Then
            Assert.Equal(0, resultado.Count);
        }

    }
}
