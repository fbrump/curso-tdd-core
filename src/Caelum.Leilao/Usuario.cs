namespace Caelum.Leilao
{
    /// <summary>
    /// This class mapping user.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identified of the User.
        /// </summary>
        /// <returns>ID</returns>
        public int Id { get; set; }
        /// <summary>
        /// Name of the User
        /// </summary>
        /// <returns>Name</returns>
        public string Nome { get; set; }

        /// <summary>
        /// Construction fo the user.
        /// </summary>
        /// <param name="nome">Name of the User.</param>
        public Usuario(string nome)
            : this(0, nome)
        {
            
        }

        /// <summary>
        /// Construction of the user.
        /// </summary>
        /// <param name="id">ID of the user.</param>
        /// <param name="nome">Name of the user.</param>
        public Usuario(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != obj.GetType())
                return false;
            Usuario outro = (Usuario)obj;

            return outro.Id == this.Id && outro.Nome.Equals(this.Nome);
        }
    }
}