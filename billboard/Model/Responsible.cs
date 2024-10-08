using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Responsible
    {
        [Key]
        public int IdResponsible { get; set; }

        public int Id_People { get; set; } // Clave foránea para Person

        public  int CompanyId { get; set; } // Cambié a CompanyId

        public bool StateDelete { get; set; }

        // Navegation
        public Person Person { get; set; }
        public Company Company { get; set; }
    }
}
