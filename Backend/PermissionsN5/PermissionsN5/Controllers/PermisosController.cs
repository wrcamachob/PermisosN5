using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PermissionsN5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly IPermisosBL<PermisoModels> _permisos;

        public PermisosController(IPermisosBL<PermisoModels> permisoModel)
        {
            this._permisos = permisoModel;
        }

        [HttpGet]
        public async Task<IEnumerable<PermisoModels>> Get()
        {
            return await _permisos.GetPermissions();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(PermisoModels permiso)
        {
            string message = await _permisos.RequestPermission(permiso);
            return new JsonResult(message);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(PermisoModels permiso)
        {
            string message = await _permisos.ModifyPermission(permiso);
            return new JsonResult(message);
        }        
    }
}
