using BlazorAppCuentasBancarias.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppCuentasBancarias.Repository
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly BancoContext _context;

        public CuentaRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<List<CuentaBancaria>> GetCuentasAsync()
        {
            return await _context.CuentasBancarias.ToListAsync();
        }

        public async Task<CuentaBancaria> GetCuentaPorNumeroAsync(int cuenta)
        {
            return await _context.CuentasBancarias.FirstOrDefaultAsync(c => c.NumeroCuenta == cuenta);
        }

        public async Task CrearAsync(CuentaBancaria account)
        {
            await _context.CuentasBancarias.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(CuentaBancaria account)
        {
            _context.CuentasBancarias.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task EliminaAccountAsync(CuentaBancaria account)
        {
            _context.CuentasBancarias.Remove(account);
            await _context.SaveChangesAsync();
        }
        
    }
}
