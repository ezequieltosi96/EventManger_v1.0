namespace EM.Aplicacion.CadenaConexion
{
    public static class CadenaConexion
    {
        // Cadena de conexion Nicolas
        //private const string Servidor = @"Notebook\SQL";
        //private const string BaseDeDatos = "EventManagerV1";
        //private const string Usuario = "sa";
        //private const string Contrasena = "123";

        // Cadena de conexion Ezequiel
        private const string Servidor = "DESKTOP-TTT7KKD";
        private const string BaseDeDatos = "EventManager_v1.2.1";
        private const string Usuario = "sa";
        private const string Contrasena = "pa$$word";

        public static string ObtenercadenaSql => $"Data Source={Servidor};Initial Catalog={BaseDeDatos};User Id={Usuario};Password={Contrasena};";
    }
}
