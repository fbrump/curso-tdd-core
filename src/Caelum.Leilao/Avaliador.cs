namespace Caelum.Leilao
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class container all business fo the evaluator.
    /// </summary>
    public class Avaliador
    {
        /// <summary>
        /// Max value of all
        /// </summary>
        private double maiorDeTodos = Double.MinValue;
        /// <summary>
        /// Min value of all
        /// </summary>
        private double menorDeTodos = Double.MaxValue;
        private IList<Lance> maiores;

        private double mediaDeTodos = new double();

        public void Avalia(Leilao leilao)
        {
            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                    maiorDeTodos = lance.Valor;
                if (lance.Valor < menorDeTodos)
                    menorDeTodos = lance.Valor;
            }

            this.pegaOsMaioresNo(leilao);

            this.mediaDeTodos = leilao.Lances.Sum(t => t.Valor) / leilao.Lances.Count;
        }

        private void pegaOsMaioresNo(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.Lances.OrderByDescending(t => t.Valor));
            maiores = maiores.Take(3).ToList(); //.Skip(3).Take(3).ToList(); //.GetRange(0, 3);
        }

        public double MaiorLance { get { return this.maiorDeTodos; } }
        public double MenorLance { get{ return this.menorDeTodos; } }
        public IList<Lance> TresMaiores { get { return this.maiores; }}
        public double MediaLance {get { return this.mediaDeTodos; }}

    }
}