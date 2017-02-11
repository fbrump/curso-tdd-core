namespace Caelum.Leilao
{
    /// <summary>
    /// This class mapping throw class.
    /// </summary>
    public class Lance
    {
        /// <summary>
        /// User that give throw
        /// </summary>
        /// <returns>User.</returns>
        public Usuario Usuario { get; set; }
        /// <summary>
        /// Value of the throw.
        /// </summary>
        /// <returns>Value</returns>
        public double Valor { get; set; }

        /// <summary>
        /// Method that do throw.
        /// </summary>
        /// <param name="usuario">User give throw.</param>
        /// <param name="valor">Value of the throw.</param>
        public Lance(Usuario usuario, double valor)
        {
            this.Usuario = usuario;
            this.Valor = valor;
        }
    }
}