

using Alura.LeilaoOnline.Core;

using System;

using Xunit;

namespace Alura.LeilaoOnline.Tests
{   
    public class LeilaoTestes
    {

        [Fact]
        public void LeilaoComTresClientes()
        {
            //Arrange - Cenário
            //Dado leilao com 3 clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            var beltrano = new Interessada("Beltrano", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(beltrano, 1400);

            //Act - metodo sob teste
            //Quando o pregrão/leilão termina
            leilao.TerminaPregao();

            //Assert
            //Então o valor esperado é o maior valor dado
            //E o cliente ganhador é o que deu o maior lance
            var valorEsperado = 1400;
            

            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(beltrano, leilao.Ganhador.Cliente);
        }

        [Fact]
        public void LeiLaoComLancesOrdenadosPorValor()
        {
            //Arrange - Cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(fulano, 1000);

            //Act - metodo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComApenasUmLance()
        {
            //Arrange - Cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            //Act - metodo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

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
