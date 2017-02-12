namespace Caelum.Leilao
{
    using System;
    using System.Linq;
    using System.Collections;
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

        public void Avalia(Leilao leilao)
        {
            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                    maiorDeTodos = lance.Valor;
                else if (lance.Valor < menorDeTodos)
                    menorDeTodos = lance.Valor;
            }
        }

        public double MaiorLance { get { return this.maiorDeTodos; } }
        public double MenorLance { get{ return this.menorDeTodos; } }

    }
}