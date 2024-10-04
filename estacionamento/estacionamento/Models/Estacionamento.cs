﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace estacionamento.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            int numeroDeLetras = placa.Count(char.IsLetter);

            if (placa.Length == 7 && numeroDeLetras >= 3)
            {
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine($"Veículo com placa {placa} ja estra no estacionamento.");
                }
                else
                {
                    // Adicionar a placa à lista de veículos
                    veiculos.Add(placa.ToUpper()); // Armazena a placa em letras maiúsculas
                    Console.WriteLine($"Veículo com placa {placa} adicionado.");

                }
            }
            else
            {
                Console.WriteLine("essa placa é invalida");
            }

            
    
        }

        public void RemoverVeiculo()
        {
            ListarVeiculos();
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                decimal horas = 0;
                decimal valorTotal = 0;

                
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                horas = Convert.ToDecimal(Console.ReadLine());

                if (horas < 12)
                {
                    valorTotal = precoInicial + (precoPorHora * horas);
                }
                else
                {
                    valorTotal = 20;
                }

                

                // Remover a placa digitada da lista de veículos
                veiculos.Remove(placa.ToUpper()); // Remove em maiúsculas

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                // Exibe todos os veículos estacionados
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}