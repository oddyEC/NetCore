using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Application
{
    public interface IAutorAppService
    {
        ICollection<AutorDto> GetAll();

        Task<AutorDto> CreateAsync(AutorCrearActualizar autor);

        Task UpdateAsync(int id, AutorCrearActualizar autor);

        Task<bool> DeleteAsync(int autorId);
    }
}