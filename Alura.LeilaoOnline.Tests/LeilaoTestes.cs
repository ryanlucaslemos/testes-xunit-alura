﻿

using Alura.LeilaoOnline.Core;

using System;

using Xunit;

namespace Alura.LeilaoOnline.Tests
{   
    public class LeilaoTestes
    {

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void LeilaoComVariosLances(double valorEsperado, double[] ofertas)
        {
            //Arrange - Cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }
            
            //Act - metodo sob teste
            leilao.TerminaPregao();

            //Assert

            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeiLaoSemLances()
        {
            //Arrange - Cenário
            var leilao = new Leilao("Van Gogh");
            //Act - metodo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);

        }
    }
}
