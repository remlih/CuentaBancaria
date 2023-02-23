using BlazorAppCuentasBancarias.Data;
using BlazorAppCuentasBancarias.Interfaces;
using BlazorAppCuentasBancarias.Repository;

namespace BlazorAppCuentasBancarias.Services
{
    public class CuentaBancariaService : ICuentaBancariaService
    {
        private ICuentaRepository _repository;
        public CuentaBancariaService(ICuentaRepository repository)
        {
            _repository = repository;
        }
       
        public async Task<CuentaBancaria> ConsultarCuenta(int numeroCuenta)
        {
            return await _repository.GetCuentaPorNumeroAsync(numeroCuenta);
        }

        public async Task<bool> Consignar(int numeroCuenta, decimal valor)
        {
            var cuenta = await ConsultarCuenta(numeroCuenta);
            if (cuenta != null)
            {
                cuenta.Saldo += valor;
                await _repository.ActualizarAsync(cuenta);
                return true;
            }
            return false;
        }

        public async Task<bool> Retirar(int numeroCuenta, decimal valor)
        {
            var cuenta = await ConsultarCuenta(numeroCuenta);
            if (cuenta != null && cuenta.Saldo >= valor)
            {
                cuenta.Saldo -= valor;
                await _repository.ActualizarAsync(cuenta);
                return true;
            }

            return false;
        }

        public async Task<bool> Crear(CuentaBancaria cuenta)
        {
            if (cuenta != null)
            {
                var existe = await ConsultarCuenta(cuenta.NumeroCuenta);
                if (existe == null)
                {
                    await _repository.CrearAsync(cuenta);
                    return true;
                }
            }

            return false;
        }

        public async Task<List<CuentaBancaria>> CuentasBancarias()
        {
            return await _repository.GetCuentasAsync();
        }
    }
}
