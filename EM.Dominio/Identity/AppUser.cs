namespace EM.Dominio.Identity
{
    using Microsoft.AspNetCore.Identity;

    public class AppUser : IdentityUser
    {
        public string NombreMostrar { get; set; }
    }
}
