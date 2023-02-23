using BlazorAppCuentasBancarias.Data;

namespace BlazorAppCuentasBancarias.Interfaces
{
    public interface ICuentaBancariaService
    {
        Task<CuentaBancaria> ConsultarCuenta(int numeroCuenta);
        Task<bool> Consignar(int numeroCuenta, decimal valor);
        Task<bool> Retirar(int numeroCuenta, decimal valor);
        Task<bool> Crear(CuentaBancaria cuenta);
        Task<List<CuentaBancaria>> CuentasBancarias();
    }
}
