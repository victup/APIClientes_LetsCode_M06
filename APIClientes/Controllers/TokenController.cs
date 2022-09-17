using APIClientes.Core.Interfaces;
using APIClientes.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIClientes.Controllers
{

    [ApiController]
    [Route ("[controller]")]
    public class TokenController : Controller
    {

        public ICustomerService _customerService;
        public ITokenService _tokenService;
        public TokenController(ICustomerService customerService, ITokenService tokenService)
        {
            _customerService = customerService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult CreateToken(string cpf)
        {
            var customer = _customerService.GetCustomer(cpf);

            if (customer == null)
            return BadRequest();
            return Ok(_tokenService.GenerateTokenProdutos(customer.Nome, customer.Permissao));
        }
    }
}
