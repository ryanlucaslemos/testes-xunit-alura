﻿using Alura.LeilaoOnline.Core;

using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
            Console.ReadKey();
        }

        private static void LeilaoComApenasUmLance()
        {
            //Arrange - Cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            //Act - metodo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);

        }

        private static void Verifica(double valorEsperado, double valorObtido)
        {
            var cor = Console.ForegroundColor;
            if (valorEsperado == valorObtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste Falhou esperado: {valorEsperado}, obtido: {valorObtido}");
            }
            Console.ForegroundColor = cor;
        }

        private static void LeilaoComVariosLances()
        {
            //Arrange - Cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            //Act - metodo sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }
    }
}
