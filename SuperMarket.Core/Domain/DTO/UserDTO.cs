using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Core.Domain.DTO
{
    public class UserDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EM_USER")]
        public long UserID { get; set; }
        [Required]
        [Column("EM_EMAIL", TypeName = "varchar(255)")]
        public string Email { get; set; }
        [Required]
        [Column("EM_USERNAME", TypeName = "varchar(255)")]
        public string Username { get; set; }
        [Required]
        [Column("EM_PASSWORD", TypeName = "varchar(255)")]
        public string Password { get; set; }
        [Required]
        [Column("EM_ROLE", TypeName = "varchar(30)")]
        public string Role { get; set; }
        [Required]
        [Column("EM_FULLNAME", TypeName = "varchar(255)")]
        public string NomeCompleto { get; set; }
        [Column("DT_CRIACAO", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }
        [Column("DT_CRIACAO", TypeName = "timestamp")]
        public DateTime UpdatedAt { get; set; }
    }
}
