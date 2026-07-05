using BeeWeb.Data.UnitOfWork;
using BeeWeb.DTOs.Requests;
using BeeWeb.DTOs.Responses;
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

        public async Task<DetallePerfilResponse?> DetallePerfilAsync(Guid? usuarioId)
        {
            var negocio = await _uow.NegocioRepository.DetalePorUsuarioIdSesionAsync(usuarioId);
            if(negocio is null)
            {
                return null;
            }
            return new 
                DetallePerfilResponse(
                negocio.Nombre,
                negocio.Direccion,
                negocio.Rubro,
                negocio.Descripcion,
                negocio.TipoMoneda,
                negocio.Usuario.Nombre,
                negocio.Usuario.Codigo);
        }

        public async Task<Guid> RegistrarAsync(RegistrarNegocioRequest request)
        {
            var usuario = await _uow.UsuarioRepository.ObtenerUsuarioPorCodigoAsync(request.codigoUsuario);
            if(usuario is null)
            {
                return Guid.Empty;
            }
            var model = new Negocio()
            {
                NegocioId = Guid.NewGuid(),
                Nombre = request.nombre,
                Descripcion = request.descripcion,
                Direccion = request.direccion,
                TipoMoneda = request.tipoMoneda,
                Rubro = request.rubro,
                UsuarioId = usuario.UsurioId
            };
            return await _uow.NegocioRepository.RegistrarAsync(model);
        }
    }
}
