using System.ComponentModel.DataAnnotations;

namespace APIClientes.Model.Customer
{
    public class Customer
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 números (apenas números)")]
        public string? Cpf { get; set; }


        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        public DateTime? DataNascimento { get; set; }

        //[Range(18, int.MaxValue, ErrorMessage = "Você deve ter no minimo 18 anos.")]
        public int? Idade => GetIdade();

        [Required(ErrorMessage = "Permissão é obrigatório")]

        public string Permissao { get; set; }

        public int GetIdade()
        {
            int idade = DateTime.Now.Year - ((DateTime)DataNascimento).Year;
            if (DateTime.Now.DayOfYear < ((DateTime)DataNascimento).DayOfYear)
            {
                idade--;
            }
            return idade;
        }

    }

}
