using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIClientes.Filters
{
    public class LogAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("User", out var value);

            if (!String.IsNullOrEmpty(value))
                Console.WriteLine("Usuário autorizado pelo filtro de Autorização");
            else
            {
                Console.WriteLine("Usuário negado pelo filtro de autorização");
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
 
        }
    }
}
