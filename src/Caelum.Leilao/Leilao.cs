namespace Caelum.Leilao
{
    using System.Linq;
    using System.Collections;
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
            if (this.Lances.Count == 0 || 
                this.podeDarLance(lance.Usuario))
                this.Lances.Add(lance);
        }

        private bool podeDarLance(Usuario usuario)
        {
            return (!this.ultimoLanceDado().Usuario.Equals(usuario) &&
                this.qtdDeLancesDo(usuario) < 5);
        }

        private Lance ultimoLanceDado()
        {
            return this.Lances[this.Lances.Count - 1];
        }

        private int qtdDeLancesDo(Usuario usuario)
        {
            int total = 0;
            foreach (var l in this.Lances)
            {
                if (l.Usuario.Equals(usuario)) total ++;
            }

            return total;
        }

        public void DobraLance (Usuario usuario)
        {
            Lance ultimoLance = this.ultimoLanceDo(usuario);
            
            if (ultimoLance != null)
                this.Propoe(new Lance(usuario, ultimoLance.Valor * 2));
        }

        public Lance ultimoLanceDo(Usuario usuario)
        {
            return this.Lances
                .Where(t => t.Usuario.Nome.Equals(usuario.Nome))
                .LastOrDefault();
        }
    }
}