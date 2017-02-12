namespace Caelum.Leilao.Test
{
    using System;
    using Xunit;
    using Caelum.Leilao;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class LeilaoTest
    {
        [Fact]
        public void Should_received_one_throw()
        {
        
            Leilao leilao = new Leilao("Macbook Pro 15");
            Assert.Equal(0, leilao.Lances.Count);

            var usuario = new Usuario("Steve Jobs");
            leilao.Propoe(new Lance(usuario, 2000));

            Assert.Equal(1, leilao.Lances.Count);
            Assert.Equal(2000, leilao.Lances[0].Valor, 4);
        
        }

        [Fact]
        public void Should_received_many_throws()
        {
            //Given
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");
            Usuario steveWoznik = new Usuario("Steve Woznik");

            //When
            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(steveWoznik, 3000));

            //Then
            Assert.Equal(2, leilao.Lances.Count);
            Assert.Equal(2000, leilao.Lances[0].Valor, 4);
            Assert.Equal(3000, leilao.Lances[1].Valor, 4);
        }
    }
}