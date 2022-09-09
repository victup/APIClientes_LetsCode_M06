using APIClientes.Core.Interfaces;
using APIClientes.Model.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIClientes.Filters
{
    public class VerificaCpfExistenteActionFilter : ActionFilterAttribute
    {
        ICustomerService _customerService;
        public VerificaCpfExistenteActionFilter( ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string cpf = _customerService.GetCpfByCustomer((Customer)context.ActionArguments["customer"]);


            if (String.IsNullOrEmpty(cpf))
            {
                Console.WriteLine($"Verificando se já existe o CPF informado: Não encontramos nenhum cliente que utilize o cpf Informado. Vamos prosseguir com o seu cadastro.");

            }
            else
            {
                Console.WriteLine($"Verificando se já existe o CPF informado: Encontramos um cliente com o cpf {cpf}, por isso não é possível prosseguir com o cadastro.");
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
 

    }
}
