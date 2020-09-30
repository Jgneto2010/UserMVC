using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class ClientViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório"), MaxLength(40)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório"), MaxLength(40)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório"), MaxLength(11), MinLength(11)]
        public string Cpf { get; set; }
    }
}
