namespace Caelum.Leilao
{
    using System;
    using System.Linq;
    using System.Collections;

    public class Palindromo
    {
        public bool EhPalindromo(String frase)
        {
            String fraseFiltrada = frase.ToUpper().Replace(" ", "").Replace("-", "");

            for(int i = 0; i < fraseFiltrada.Length; i++) 
            {
                if(fraseFiltrada[i] != fraseFiltrada[fraseFiltrada.Length -i]) 
                {
                    return false;
                }
            }

            return true;
        }
    }
}