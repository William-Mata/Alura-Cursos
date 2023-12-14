using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AutenticacaoUsuarioAPI.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var dataNascimento = context.User.FindFirst(x => x.Type == ClaimTypes.DateOfBirth);

            if(dataNascimento == null)
            {
                return Task.CompletedTask;
            }

            var dataConvertida = DateTime.Parse(dataNascimento.Value);
            var dias = DateTime.UtcNow.Subtract(dataConvertida);
            var idade = (dias.Days / 365.3);
           
            if (idade >= requirement.Idade)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
