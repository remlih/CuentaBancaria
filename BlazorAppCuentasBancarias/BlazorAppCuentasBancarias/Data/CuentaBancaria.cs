namespace BlazorAppCuentasBancarias.Data
{
    public class CuentaBancaria
    {
        public int Id { get; set; }
        public int NumeroCuenta { get; set; }
        public decimal Saldo { get; set; } = 0;
    }
}
