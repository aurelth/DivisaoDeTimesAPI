using DivisaoDeTimesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DivisaoDeTimesAPI.Services
{
    public class SorteadorDeTimesService
    {
        public (Time, Time) DividirTimes(List<Jogador> jogadores)
        {            
            if (jogadores == null || jogadores.Count < 16)
                throw new ArgumentException("A lista deve conter pelo menos 16 jogadores.");

            // Validar cada jogador individualmente
            foreach (var jogador in jogadores)
            {
                if (string.IsNullOrWhiteSpace(jogador.Nome))
                    throw new ValidationException("O nome do jogador é obrigatório.");

                if (!jogador.Posicao.HasValue)
                    throw new ValidationException("A posição do jogador é obrigatória.");
            }

            // Embaralhar os jogadores para garantir aleatoriedade
            jogadores = jogadores.OrderBy(_ => Guid.NewGuid()).ToList();

            // Distribuir os primeiros 16 jogadores igualmente
            var time1 = new Time(jogadores.Take(8).ToList());
            var time2 = new Time(jogadores.Skip(8).Take(8).ToList());

            // Jogadores excedentes (qualquer número acima de 16)
            var excedente = jogadores.Skip(16).ToList();
            int numExcedente = excedente.Count;

            // Verificar se o número de jogadores excedentes é par ou ímpar
            if (numExcedente > 0)
            {
                var random = new Random();

                if (numExcedente % 2 == 0)
                {
                    // Número par de excedentes: Dividir igualmente entre os times
                    for (int i = 0; i < numExcedente; i++)
                    {
                        if (i % 2 == 0)
                            time1.Jogadores.Add(excedente[i]);
                        else
                            time2.Jogadores.Add(excedente[i]);
                    }
                }
                else
                {
                    // Número ímpar de excedentes: Um time terá um jogador a mais, escolhido aleatoriamente
                    var timeComJogadorExtra = random.Next(2) == 0 ? time1 : time2;
                    var outroTime = timeComJogadorExtra == time1 ? time2 : time1;

                    for (int i = 0; i < numExcedente; i++)
                    {
                        if (i < numExcedente / 2 + 1)
                            timeComJogadorExtra.Jogadores.Add(excedente[i]);
                        else
                            outroTime.Jogadores.Add(excedente[i]);
                    }
                }
            }

            return (time1, time2);
        }
    }
}
