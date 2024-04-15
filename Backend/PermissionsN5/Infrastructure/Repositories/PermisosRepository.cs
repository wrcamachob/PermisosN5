using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PermissionsN5;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PermisosRepository : IPermisos
    {
        private readonly PermissionContext _permissionContext;

        /// <summary>
        /// Constructor.
        /// </summary>
        public PermisosRepository(PermissionContext context)
        {
            _permissionContext = context;
        }

        public async Task<IEnumerable<Permiso>> GetPermissions()
        {
            using (var context = new PermissionContext())
            {
                return await _permissionContext.Permisos.ToListAsync();
            }
        }

        public async Task<int> RequestPermission(Permiso entity)
        {
            Permiso perm = new()
            {
                NombreEmpleado = entity.NombreEmpleado,
                ApellidoEmpleado = entity.ApellidoEmpleado,
                TipoPermiso = entity.TipoPermiso,
                FechaPermiso = entity.FechaPermiso                
            };
            _permissionContext.Permisos.Add(perm);
            _permissionContext.SaveChanges();

            return 1;
        }

        public async Task<int> ModifyPermission(Permiso entity)
        {
            Permiso entPerm = _permissionContext.Permisos.FirstOrDefault(x => x.Id == entity.Id);
            if (entPerm != null)
            {
                Permiso perm = new()
                {
                    NombreEmpleado = entity.NombreEmpleado,
                    ApellidoEmpleado = entity.ApellidoEmpleado,
                    TipoPermiso = entity.TipoPermiso,
                    FechaPermiso = entity.FechaPermiso
                };
                _permissionContext.SaveChanges();
                //result = "Actualizado Exitosamente";
            }
            else
            {
                //result = "Registro no existe";
            }
            return 1;
        }       

    }
}
