using System.IO.Compression;
using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application
{
    public class ProductoAppService : IProductoAppService
    {
        private readonly IProductoRepository repository;

        public ProductoAppService(IProductoRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ProductoDto> CreateAsync(ProductoCrearActualizarDto marca)
        {

        }

        public Task<bool> DeleteAsync(int marcaId)
        {

        }

        public ListaPaginada<ProductoDto> GetAll(int limit = 10, int offset = 0)
        {
            var consulta = repository.GetAllIncluding(x => x.Marca,
            x => x.TipoProducto);

            //Lista 
            var consultaListaProductosDto = repository.GetAllIncluding(x => x.Marca,
            x => x.TipoProducto);
            // 1. Ejecvutar linq Total registros
            var total = consulta.Count();
            var listaProductosDto = consulta.Skip(offset)
                                            .Take(limit)
                                            .Select(
                                             x => new ProductoDto()
                                             {
                                                 Id = x.Id,
                                                 Caducidad = x.Caducidad,
                                                 //Utilizar propiedad navegacion,
                                                 //para obtener información de una clase relacionada
                                                 Marca = x.Marca.Nombre,
                                                 MarcaId = x.MarcaId,
                                                 Nombre = x.Nombre,
                                                 Observaciones = x.Observaciones,
                                                 Precio = x.Precio,
                                                 //Utilizar propiedad navegacion,
                                                 // para obtener informacion de una clase relacionada
                                                 TipoProducto = x.TipoProducto.Nombre,
                                                 TipoProductoId = x.TipoProductoId

                                             }
                                            );
                
        }

        public Task UpdateAsync(int id, ProductoCrearActualizarDto marca)
        {

        }
    }
}