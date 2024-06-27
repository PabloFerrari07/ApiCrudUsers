using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDCsharp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string age { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        public string phone { get; set; }
    }
}
