using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PermisoModels
    {
        private int id;
        private string nombreEmpleado;
        private string apellidoEmpleado;
        private int tipoPermiso;        
        private DateTime fechaPermiso;        

        public int ID { get => id; set => id = value; }
                
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "The field name must be alphanumeric")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "The field last name must be alphanumeric")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string ApellidoEmpleado { get => apellidoEmpleado; set => apellidoEmpleado = value; }        
        public int TipoPermiso { get => tipoPermiso; set => tipoPermiso = value; }
        public DateTime FechaPermiso { get => fechaPermiso; set => fechaPermiso = value; }
        
        public PermisoModels()
        {
        }
    }
}
