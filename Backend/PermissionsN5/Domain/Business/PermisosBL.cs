using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using PermissionsN5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
    public class PermisosBL : IPermisosBL<PermisoModels>
    {
        //private readonly PermissionContext _permissionContext;

        private IPermisos permisos;
        public PermisosBL(PermissionContext context) 
        {
            permisos = new PermisosRepository(context);
        }

        public async Task<IEnumerable<PermisoModels>> GetPermissions()
        {
            var permisosDataModel = await permisos.GetPermissions();
            var listPermModel = new List<PermisoModels>();
            foreach (Permiso permiso in permisosDataModel)
            {
                listPermModel.Add(new PermisoModels
                {
                    ID = permiso.Id,
                    NombreEmpleado = permiso.NombreEmpleado,
                    ApellidoEmpleado = permiso.ApellidoEmpleado,
                    TipoPermiso = permiso.TipoPermiso,
                    FechaPermiso = permiso.FechaPermiso
                });
            }
            return listPermModel;
        }

        public async Task<string> ModifyPermission(PermisoModels permiso)
        {
            string message;
            try
            {
                var PermMod = new Permiso
                {
                    NombreEmpleado = permiso.NombreEmpleado,
                    ApellidoEmpleado = permiso.ApellidoEmpleado,
                    TipoPermiso = permiso.TipoPermiso,
                    FechaPermiso = permiso.FechaPermiso
                };
                _ = await permisos.ModifyPermission(PermMod);
                message = "Successfully edited";
            }
            catch (Exception ex)
            { 
                message = ex.ToString();              
            }
            return message;
        }

        public async Task<string> RequestPermission(PermisoModels permiso)
        {
            string message;
            try
            {
                var permMod = new Permiso
                {
                    NombreEmpleado = permiso.NombreEmpleado,
                    ApellidoEmpleado = permiso.ApellidoEmpleado,
                    TipoPermiso = permiso.TipoPermiso,
                    FechaPermiso = permiso.FechaPermiso
                };
                _ = await permisos.RequestPermission(permMod);
                message = "Successfully record";
            }
            catch (Exception ex)
            {
                message = ex.ToString();               
            }
            return message;
        }
    }
}
