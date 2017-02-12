namespace Caelum.Leilao
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    public class FiltroDeLances
    {
        public IList<Lance> Filtra(IList<Lance> lances)
        {
            IList<Lance> resultado = new List<Lance>();

            foreach (Lance lance in lances)
            {
                if (lance.Valor > 1000 && lance.Valor < 3000)
                    resultado.Add(lance);
                else if (lance.Valor > 500 && lance.Valor < 700)
                    resultado.Add(lance);
                else if (lance.Valor > 5000)
                    resultado.Add(lance);
            }

            return resultado;
        }
    }
}