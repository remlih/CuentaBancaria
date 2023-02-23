using BlazorAppCuentasBancarias.Data;

namespace BlazorAppCuentasBancarias.Repository
{
    public interface ICuentaRepository
    {
        Task<List<CuentaBancaria>> GetCuentasAsync();
        Task<CuentaBancaria> GetCuentaPorNumeroAsync(int numbero);
        Task CrearAsync(CuentaBancaria cuentaBancaria);
        Task ActualizarAsync(CuentaBancaria cuentaBancaria);
        Task EliminaAccountAsync(CuentaBancaria cuentaBancaria);
    }
}
