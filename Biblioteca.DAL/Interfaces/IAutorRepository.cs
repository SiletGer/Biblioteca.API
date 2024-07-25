﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entities.Models;

namespace Biblioteca.DAL.Interfaces
{
    public interface IAutorRepository
    {
        public Task<List<Autor>> GetAutoresAsync();
        public Task<Autor> GetAutorByIdAsync(int id);
        public Task<int> InsertAutorAsync(Autor autor);
        public Task<Autor> updateAutorAsync(Autor autor);
        public Task<bool> DeleteAutorAsync(int id);
    }
}