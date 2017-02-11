namespace Caelum.Leilao
{
    using System.Collections.Generic;

    /// <summary>
    /// This class mapping auction.
    /// </summary>
    public class Leilao
    {
        /// <summary>
        /// Description of the auction.
        /// </summary>
        /// <returns></returns>
        public string Descricao { get; set; }
        /// <summary>
        /// Throws have in auction.
        /// </summary>
        /// <returns>List of the thorws</returns>
        public IList<Lance> Lances { get; set; }

        /// <summary>
        /// Constructior of the auction.
        /// </summary>
        /// <param name="descricao">Name of the auction</param>
        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        /// <summary>
        /// Propose the throw in action.
        /// </summary>
        /// <param name="lance">Throw</param>
        public void Propoe(Lance lance)
        {
            this.Lances.Add(lance);
        }
    }
}