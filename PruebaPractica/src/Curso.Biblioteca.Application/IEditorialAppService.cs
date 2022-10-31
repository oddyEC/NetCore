using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Application
{
    public interface IEditorialAppService
    {
        ICollection<EditorialDto> GetAll();

        Task<EditorialDto> CreateAsync(EditorialCrearActualizar editorial);

        Task UpdateAsync(int id, EditorialCrearActualizar editorial);

        Task<bool> DeleteAsync(int editorialId);
    }
}