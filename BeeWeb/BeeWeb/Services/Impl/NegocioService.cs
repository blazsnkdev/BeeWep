using BeeWeb.Data.UnitOfWork;
using BeeWeb.DTOs.Requests;
using BeeWeb.Models;
using BeeWeb.Services.Interfaces;

namespace BeeWeb.Services.Impl
{
    public class NegocioService : INegocioService
    {
        private readonly IUnitOfWork _uow;

        public NegocioService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Guid> RegistrarAsync(RegistrarNegocioRequest request)
        {
            var usuarioId = await _uow.UsuarioRepository.ObtenerIdPorCodigoAsync(request.codigoUsuario);
            var model = new Negocio()
            {
                NegocioId = Guid.NewGuid(),
                Nombre = request.nombre,
                Descripcion = request.descripcion,
                Direccion = request.direccion,
                TipoMoneda = request.tipoMoneda,
                Rubro = request.rubro,
                UsuarioId = usuarioId
            };
            return await _uow.NegocioRepository.RegistrarAsync(model);
        }
    }
}
