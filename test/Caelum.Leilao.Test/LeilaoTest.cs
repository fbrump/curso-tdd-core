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

        [Fact]
        public void Should_do_not_accept_two_throws_consecutive()
        {
            //Given
            Leilao leilao = new Leilao("Macbook Pro 15");
            var steveJobs = new Usuario("Steve Jobs");

            //When
            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(steveJobs, 3000));
            
            //Then
            Assert.Equal(1, leilao.Lances.Count);
            Assert.Equal(2000, leilao.Lances[0].Valor, 4);
        }

        [Fact]
        public void Should_do_not_accept_more_then_five_throws_some_user()
        {
            //Given
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");
            Usuario billGates = new Usuario("Bill Gates");
            
            //When
            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(billGates, 3000));

            leilao.Propoe(new Lance(steveJobs, 4000));
            leilao.Propoe(new Lance(billGates, 5000));

            leilao.Propoe(new Lance(steveJobs, 6000));
            leilao.Propoe(new Lance(billGates, 7000));

            leilao.Propoe(new Lance(steveJobs, 8000));
            leilao.Propoe(new Lance(billGates, 9000));

            leilao.Propoe(new Lance(steveJobs, 10000));
            leilao.Propoe(new Lance(billGates, 11000));

            // Deve ser ignorado
            leilao.Propoe(new Lance(steveJobs, 12000));
            
            //Then
            Assert.Equal(10, leilao.Lances.Count);
            var ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];

            Assert.Equal(11000, ultimoLance.Valor, 4);
        }
    }
}