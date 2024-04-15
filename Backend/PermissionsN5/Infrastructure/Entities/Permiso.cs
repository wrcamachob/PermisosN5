using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PermissionsN5;

public partial class Permiso
{
    /// <summary>
    /// Unique ID
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Employee forename
    /// </summary>
    [Column(TypeName = "text")]
    public string NombreEmpleado { get; set; } = null!;

    /// <summary>
    /// Employee Surname
    /// </summary>
    [Column(TypeName = "text")]
    public string ApellidoEmpleado { get; set; } = null!;

    /// <summary>
    /// Permission Type
    /// </summary>
    public int TipoPermiso { get; set; }

    /// <summary>
    /// Permission Granted on Date
    /// </summary>
    public DateTime FechaPermiso { get; set; }

    [ForeignKey("TipoPermiso")]
    [InverseProperty("Permisos")]
    public virtual TipoPermiso TipoPermisoNavigation { get; set; } = null!;
}
