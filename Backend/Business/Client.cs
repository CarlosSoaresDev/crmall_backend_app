using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business
{
    // Modelo de negocio Cliente
    [Table("client", Schema = "10384_db_crmall_test")]
    public class Client
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; } // Indetificação - chave primaria
        [Column("Name")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(255, ErrorMessage = "Não é permitido mais que {1} caracteres.")]
        public string Name { get; set; } // Nome do cliente - Length 255
        [Column("DateBirth")]     
        [Required(ErrorMessage = "O campo data de nascimento é obrigatório")] 
        public DateTime DateBirth { get; set; } // Data de nascimento
        [Column("GenderId")]
        [Required(ErrorMessage = "O campo generoId é obrigatório")]
        public int GenderId { get; set; } // Genero id - join com a tabela de genero(gender)
        [Column("Cep")]
        [MaxLength(9, ErrorMessage = "Não é permitido mais que {1} caracteres.")]
        public string Cep { get; set; } // Cep - length 9
        [Column("Address")]
        [MaxLength(255, ErrorMessage = "Não é permitido mais que {1} caracteres.")]
        public string Address { get; set; } // Endereço  - length 255
        [Column("Number")]
        [MaxLength(50, ErrorMessage = "Não é permitido mais que {1} caracteres.")]
        public string Number { get; set; } // Numero da casa - length 50
        [Column("Complement")]
        [MaxLength(255, ErrorMessage = "Não é permitido mais que {1} caracteres.")]
        public string Complement { get; set; } //  Complemento - Length 255
        [Column("Neighborhood")]
        [MaxLength(255, ErrorMessage = "Não é permitido mais que {1} caracteres.")]
        public string Neighborhood { get; set; } // Baiiro - Length 255
        [Column("State")]    
        [MaxLength(255, ErrorMessage = "Não é permitido mais que {1} caracteres.")]
        public string State { get; set; } // Estado(Uf) - Length 255
        [Column("City")]      
        [MaxLength(255, ErrorMessage = "Não é permitido mais que {1} caracteres.")]
        public string City { get; set; } // Cidade - Length 255
        [Column("IsUpdate")]
        public int IsUpdate { get; set; } = 0; // Atualizado - Tinyint 1
        [Column("CreatAt")]
        public DateTime CreatAt { get; set; } = DateTime.Now; // Data de criação - Datetime
    }
}