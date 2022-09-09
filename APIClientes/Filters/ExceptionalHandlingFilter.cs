using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace APIClientes.Filters
{
    public class ExceptionalHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails
            {
                Status = 0, 
                Title = "Erro inesperado",
                Detail ="Erro inesperado ao se comunicar com o banco de dados",
                Type = context.Exception.GetType().Name
            };

            Console.WriteLine($"Tipo da exceção {context.Exception.GetType().Name}, mensagem {context.Exception.Message}, stack trace {context.Exception.StackTrace}");

            switch (context.Exception)
            {
                case SqlException:
                    problem.Status = 503;
                    problem.Detail ="Erro inesperado ao se comunicar com o banco de dados";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    context.Result = new ObjectResult(problem);
                    break;
                case NullReferenceException:
                    problem.Status = 417;
                    problem.Detail ="Erro inesperado no sistema";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status417ExpectationFailed;
                    context.Result = new ObjectResult(problem);
                    break;
                default:
                    problem.Status = 500;
                    problem.Detail ="Erro inesperado. Tente novamente";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(problem);
                    break;
            }
        }

    }
}
