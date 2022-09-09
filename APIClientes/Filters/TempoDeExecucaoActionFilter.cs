using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace APIClientes.Filters
{
    public class TempoDeExecucaoActionFilter : IActionFilter
    {
        Stopwatch stopwatch = new();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Start();
  
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"A execução durou: {stopwatch.Elapsed.TotalSeconds} segundos");

            stopwatch.Stop();
        }
    }
}
