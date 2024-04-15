using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PermissionsN5;

public partial class TipoPermiso
{
    /// <summary>
    /// Unique ID
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Permission description
    /// </summary>
    [Column(TypeName = "text")]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("TipoPermisoNavigation")]
    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
