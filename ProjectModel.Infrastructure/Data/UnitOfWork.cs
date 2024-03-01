using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace ProjectModel.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectModelDbContext _context;

        public UnitOfWork(ProjectModelDbContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Trate a exceção de concorrência aqui
                throw new Exception("Ocorreu um erro de concorrência ao salvar as alterações no banco de dados.", ex);
            }
            catch (DbUpdateException ex)
            {
                // Trate a exceção de atualização do banco de dados aqui
                throw new Exception("Ocorreu um erro ao salvar as alterações no banco de dados.", ex);
            }
            catch (Exception ex)
            {
                // Trate outras exceções aqui
                throw new Exception("Ocorreu um erro ao salvar as alterações no banco de dados.", ex);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
