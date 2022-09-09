using APIClientes.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIClientes.Filters
{
    public class VerificaSeRegistroExisteActionFilter : ActionFilterAttribute
    {
        ICustomerService _customerService;
        public VerificaSeRegistroExisteActionFilter(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            string cpf = (string)context.ActionArguments["cpf"];

            if (_customerService.GetCustomer(cpf) != null)
            {
                Console.WriteLine("Filtro de verificação de existencia do cliente: Cliente encontrado na base de dados");

            }
            else
            {
                Console.WriteLine("Filtro de verificação de existencia do registro: Cliente não encontrado na base de dados");
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }


    }
}
