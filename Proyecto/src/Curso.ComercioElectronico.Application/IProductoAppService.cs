using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application
{
    public interface IProductoAppService
    {
        Task<ProductoDto> GetByIdAsync(int id);

        ListaPaginada<ProductoDto> GetAll(int limit = 10, int offset = 0);

        Task<ProductoDto> CreateAsync(ProductoCrearActualizarDto productoDto);

        Task UpdateAsync(int id, ProductoCrearActualizarDto productoDto);

        Task<bool> DeleteAsync(int productoId);
    }





    public class ProductoCrearActualizarDto
    {

        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string? Observaciones { get; set; }

        public DateTime? Caducidad { get; set; }


        [Required]
        public int MarcaId { get; set; }


        [Required]
        public int TipoProductoId { get; set; }


    }

}