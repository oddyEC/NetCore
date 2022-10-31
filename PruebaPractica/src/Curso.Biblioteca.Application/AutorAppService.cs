using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application
{
    public class AutorAppService: IAutorAppService
    {
        private readonly IAutorRepository repository;

        public AutorAppService(IAutorRepository repository)
        {
            this.repository = repository;
        }
    }
}