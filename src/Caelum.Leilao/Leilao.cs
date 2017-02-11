namespace Caelum.Leilao
{
    using System.Collections.Generic;
    public class Leilao
    {
        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();

        }

        public void Propoe(Lance lance)
        {
            this.Lances.Add(lance);
        }
    }
}