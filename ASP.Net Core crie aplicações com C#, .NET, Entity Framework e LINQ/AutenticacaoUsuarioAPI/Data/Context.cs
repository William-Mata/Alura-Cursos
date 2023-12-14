using AutenticacaoUsuarioAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutenticacaoUsuarioAPI.Data
{
    public class Context : IdentityDbContext<Usuario>
    {   
        public Context(DbContextOptions<Context> context) : base(context) { }
    }
}
