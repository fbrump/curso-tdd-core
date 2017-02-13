namespace Caelum.Leilao.Test
{
    using System;
    using Xunit;
    using Caelum.Leilao;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class AnoBissextoTest
    {
        [Fact]
        public void Should_do_leap_year()
        {
            //Given
            AnoBissexto anoBissexto = new AnoBissexto();

            //When
            var result = anoBissexto.EhBissexto(1996);
            
            //Then
            Assert.True(result);
        }

        [Fact]
        public void Should_do_not_leap_year()
        {
            //Given
            AnoBissexto anoBissexto = new AnoBissexto();

            //When
            var result = anoBissexto.EhBissexto(1999);
            
            //Then
            Assert.False(result);
        }
        
    }
}