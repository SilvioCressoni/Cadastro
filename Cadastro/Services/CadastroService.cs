using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cadastro.Models;
using Cadastro.Services.ViewServices;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Services
{
    public class CadastroService
    {
        private readonly CadastoContext _context;

        public CadastroService(CadastoContext context)
        {
            _context = context;
        }


        public async Task<List<Cadastrado>> FindAllAsync()
        {
            return await _context.Cadastrado.ToListAsync();
        }

        public async Task<Cadastrado> FindById(int id)
        {
            return await _context.Cadastrado.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task AdicionaAsync(Cadastrado cadastrado)
        {
            _context.Cadastrado.Add(cadastrado);

            await _context.SaveChangesAsync();
        }

        public async Task AtualizaAsync(Cadastrado cadastrado)
        {

            var hasAny = await _context.Cadastrado.AnyAsync(x => x.Id == cadastrado.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Userio não encontrado!!!");
            }

            try
            {
                _context.Cadastrado.Update(cadastrado);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

        public async Task Remove(int id)
        {
            var user = _context.Cadastrado.Find(id);

             _context.Cadastrado.Remove(user);
            await _context.SaveChangesAsync();

        }
    }
}
