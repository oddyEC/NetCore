using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Biblioteca.Domain;
namespace Curso.Biblioteca.Application
{
    public class LibroAppService : ILibroAppService
    {
        private readonly ILibroRepository repository;

        public LibroAppService(ILibroRepository repository)
        {
            this.repository = repository;
        }

        
    }
}