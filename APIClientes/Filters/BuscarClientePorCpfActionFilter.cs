using APIClientes.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace APIClientes.Filters
{
    public class BuscarClientePorCpfActionFilter: ActionFilterAttribute
    {
 
        
            ICustomerService _customerService;
            public BuscarClientePorCpfActionFilter(ICustomerService customerService)
            {
                _customerService = customerService;
            }
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                string cpf = (string)context.ActionArguments["cpf"];


                if (_customerService.GetCustomer(cpf) != null)
                {
                    Console.WriteLine($"Filtro de verificação de cliente com cpf {cpf}: Encontramos um cliente com o {cpf}. Os dados serão exibidos.");

                }
                else
                {
                    Console.WriteLine($"Filtro de verificação de cliente com cpf {cpf}: Nenhum cliente foi localizado com o CPF {cpf}");
                    context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
                }
            }


        
    }

}

