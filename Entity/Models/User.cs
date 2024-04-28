using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Entity
{
  [Table("Users")]
  public class User
  {
    [Column("Id")]
    public int Id { get; set; }

    [Column("Login")]
    public string Login { get; set; }

    [Column("FirstName")]
    public string FirstName { get; set; }

    [Column("LastName")]
    public string LastName { get; set; }

    [Column("Password")]
    public string Password { get; set; }
  }
}