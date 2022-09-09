using APIClientes.Core.Interfaces;
using APIClientes.Filters;
using APIClientes.Model.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes ("application/json")] //define que a entrada é em json
    [Produces("application/json")] //define que a saida é em json
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
         

        [HttpPost("/cadastrar")] //https://localhost:7156/api/Customer CREATE
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ServiceFilter(typeof(VerificaCpfExistenteActionFilter))]
        public IActionResult CreateCustomer(Customer customer)
        {
            Console.WriteLine("Criando cadastro de cliente");

            if (!_customerService.InsertCustomer(customer))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(CreateCustomer), customer);
        }

        [HttpGet("/todosOsClientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [TypeFilter(typeof(LogAuthorizationFilter))]
        public ActionResult<List<Customer>> GetCustomers()
        {
            Console.WriteLine("Buscando todos os clientes");
            return Ok(_customerService.GetCustomers());
        }

        [HttpGet("/pesquisarPorCpf")] //https://localhost:7156/api/Customer GET
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(BuscarClientePorCpfActionFilter))]
        public ActionResult<List<Customer>> ReadCustomer(string cpf)
        {
            Console.WriteLine("Buscando cliente através do cpf");
            var customer = _customerService.GetCustomer(cpf);
            if (customer == null)
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            return Ok(customer);
        }


        [HttpPut("/atualizar")] //https://localhost:7156/api/Customer PUT
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(VerificaSeRegistroExisteActionFilter))]
        public ActionResult<Customer> Update(string cpf, Customer who)
        {
            Console.WriteLine("Alterando cliente");
            if (!_customerService.UpdateCustomer(cpf, who))
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            return Ok(who);


        }

        //https://localhost:7156/api/Customer DELETE
        [HttpDelete("/{cpf}/deletar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delet(string cpf)
        {
            Console.WriteLine("Apagando cliente");

            if (!_customerService.DeleteCustomer(cpf))
            {
                return NotFound();
            }
            return Ok();
        }

 
    }

   
}
