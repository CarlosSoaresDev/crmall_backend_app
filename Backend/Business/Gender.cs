using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business
{
    // Modelo de negocio Genero
    [Table("gender", Schema = "10384_db_crmall_test")]
    public class Gender
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; } // Indetificação - chave primaria
        [Column("Description")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [MaxLength(255,ErrorMessage = "Não é permitido mais que {1} caracteres.")]      
        public string Description { get; set; } // descrição - Length 255
        [Column("IsActive")]
        public int IsActive { get; set; } = 1; // Ativo - Tinyint 1
        [Column("CreatAt")]
        public DateTime CreatAt { get; set; } = DateTime.UtcNow; // Data de cadastro - Datetime
    }
}