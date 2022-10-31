namespace BP.NetCore
{
    public class Ejecucion
    {
        public static void CombinacionCuenta()
        {
            var bancos = CuentaMock.ObtenerBancos();
            var cuentas = CuentaMock.ObtenerCuentas();
            var clientes = CuentaMock.ObtenerClientes();
            var transacciones = CuentaMock.ObtenerTransacciones();
            var listaCuentasBancos = from c in cuentas
                                     join b in bancos on c.BancoCodigo equals b.Codigo
                                     select new
                                     {
                                         c.Nombre,
                                         c.BancoCodigo,
                                         Banco = b.Nombre
                                     };
            // foreach (var item in listaCuentasBancos)
            // {
            //     System.Console.WriteLine(item);
            // }
            var saldoActual = from c in cuentas
                              join t in transacciones on c.CodigoCuenta equals t.CodigoCajero
                              select new
                              {
                                  c.Valor,

                              };
            var numeroTarjetaYBanco = from c in cuentas
                                      join cl in clientes on c.Nombre equals cl.Nombre
                                      join b in bancos on c.BancoCodigo equals b.Codigo
                                      select new
                                      {
                                          cl.NroTarjeta,
                                          b.Nombre
                                      };
            foreach (var item in saldoActual)
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine("2NDA CONSULTA");
            foreach (var item in numeroTarjetaYBanco)
            {
                System.Console.WriteLine(item);
            }

        }

    }

    public class Banco
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }


    public class Cuenta
    {
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public string BancoCodigo { get; set; }
        public string CodigoCuenta { get; set; }
    }

    public class TransaccionesATM
    {
        public string CodigoCajero { get; set; }
        public string Fecha { get; set; }
        public decimal Cantidad { get; set; }

    }
    public class Cliente
    {
        public string Nombre { get; set; }
        public string NroTarjeta { get; set; }
        public string Pin { get; set; }
    }

    public static class CuentaMock
    {
        public static IList<TransaccionesATM> ObtenerTransacciones()
        {
            var lista = new List<TransaccionesATM>(){
                new TransaccionesATM(){CodigoCajero = "1234", Fecha = "01/02/2022", Cantidad = 50.00M},
                new TransaccionesATM(){CodigoCajero = "1237", Fecha = "01/02/2022", Cantidad = 55.00M},
                new TransaccionesATM(){CodigoCajero = "1238", Fecha = "01/02/2022", Cantidad = 505.00M},
                new TransaccionesATM(){CodigoCajero = "1239", Fecha = "01/02/2022", Cantidad = 522.00M},
                new TransaccionesATM(){CodigoCajero = "1234", Fecha = "01/02/2022", Cantidad = 530.00M},
                new TransaccionesATM(){CodigoCajero = "1231", Fecha = "01/02/2022", Cantidad = 123.00M},
                new TransaccionesATM(){CodigoCajero = "1232", Fecha = "01/02/2022", Cantidad = 34.00M},
            };
            return lista;
        }
        public static IList<Cliente> ObtenerClientes()
        {
            var lista = new List<Cliente>(){
            new Cliente() { Nombre = "Bob Lesman", NroTarjeta = "23354523", Pin = "1234" },
            new Cliente() { Nombre = "Joe Landy", NroTarjeta = "23354544", Pin = "3244" },
            new Cliente() { Nombre = "Meg Ford",NroTarjeta = "23354545", Pin = "3343" },
            new Cliente() { Nombre = "Peg Vale",NroTarjeta = "23354566", Pin = "1555" },
            new Cliente() { Nombre = "Mike Johnson",NroTarjeta = "233545443", Pin = "1666" },
            new Cliente() { Nombre = "Les Paul",NroTarjeta = "23354526", Pin = "1777" },
            new Cliente() { Nombre = "Sid Crosby",NroTarjeta = "23354577", Pin = "1235" },
            new Cliente() { Nombre = "Sarah Ng",NroTarjeta = "233545244", Pin = "1237" },
            new Cliente() { Nombre = "Tina Fey",NroTarjeta = "233545211", Pin = "1236" },
            new Cliente() { Nombre = "Sid Brown",NroTarjeta = "23354555", Pin = "1239" },
            new Cliente() { Nombre = "230020100",NroTarjeta = "233545288", Pin = "1238" },
            new Cliente() { Nombre = "10103020",NroTarjeta = "23354529", Pin = "1231" },
            new Cliente() { Nombre = "20304050",NroTarjeta = "23354521", Pin = "1232" },
            new Cliente() { Nombre = "Grupo.Internacional",NroTarjeta = "23354525", Pin = "1534" },
        };
            return lista;

        }
        public static IList<Cuenta> ObtenerCuentas()
        {

            var lista = new List<Cuenta>() {
                new Cuenta(){ Nombre="Bob Lesman", Valor=80345.66M, BancoCodigo="FTB", CodigoCuenta = "1234"},
                new Cuenta(){ Nombre="Joe Landy", Valor=9284756.21M, BancoCodigo="WF", CodigoCuenta = "3244"},
                new Cuenta(){ Nombre="Meg Ford", Valor=304.01M, BancoCodigo="BOA", CodigoCuenta = "3343"},
                new Cuenta(){ Nombre="Peg Vale", Valor=1303.92M, BancoCodigo="BOA", CodigoCuenta = "1555"},
                new Cuenta(){ Nombre="Mike Johnson", Valor=12300.12M, BancoCodigo="WF", CodigoCuenta = "1666"},
                new Cuenta(){ Nombre="Les Paul", Valor=8374892.54M, BancoCodigo="WF", CodigoCuenta = "1777"},
                new Cuenta(){ Nombre="Sid Crosby", Valor=957436.39M, BancoCodigo="FTB", CodigoCuenta = "1235"},
                new Cuenta(){ Nombre="Sarah Ng", Valor=3403.85M, BancoCodigo="FTB", CodigoCuenta = "1237"},
                new Cuenta(){ Nombre="Tina Fey", Valor=1000000.00M, BancoCodigo="CITI", CodigoCuenta = "1236"},
                new Cuenta(){ Nombre="Sid Brown", Valor=80.68M, BancoCodigo="CITI", CodigoCuenta = "1239"},
                new Cuenta(){ Nombre="230020100", Valor=320.30M, BancoCodigo="GUAY", CodigoCuenta = "1238"},
                new Cuenta(){ Nombre="10103020", Valor=1230.30M, BancoCodigo="GUAY", CodigoCuenta = "1231"},
                new Cuenta(){ Nombre="20304050", Valor=3203.30M, BancoCodigo="PICH", CodigoCuenta = "1232"},
                new Cuenta(){ Nombre="Grupo.Internacional", Valor=1230303.30M, BancoCodigo="MACH", CodigoCuenta = "1534"}
            };

            return lista;
        }

        public static IList<Banco> ObtenerBancos()
        {

            var lista = new List<Banco>() {
                new Banco(){ Nombre="First Tennessee", Codigo="FTB"},
                new Banco(){ Nombre="Wells Fargo", Codigo="WF"},
                new Banco(){ Nombre="Bank of America", Codigo="BOA"},
                new Banco(){ Nombre="Citibank", Codigo="CITI"},
                new Banco(){ Nombre="B. Guayaquil", Codigo="GUAY"},
                new Banco(){ Nombre="BANCO PICHINCHA", Codigo="PICH"},
                new Banco(){ Nombre="BANCO DE MACHALA.", Codigo="MACH"},

            };

            return lista;
        }
    }
}
