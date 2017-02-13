namespace Caelum.Leilao
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class AnoBissexto
    {
        public bool EhBissexto(int ano)
        {
            if (ano % 4 == 0 && !(ano % 100 == 0) || ano % 400 == 0)
                return true;

            return false;
        }
    }
}