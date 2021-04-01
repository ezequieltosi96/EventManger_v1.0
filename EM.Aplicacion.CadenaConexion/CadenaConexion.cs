namespace EM.Aplicacion.CadenaConexion
{
    public static class CadenaConexion
    {
        // Cadena de conexion Nicolas
        //private const string Servidor = "";
        //private const string BaseDeDatos = "";
        //private const string Usuario = "";
        //private const string Contrasena = "";

        // Cadena de conexion Ezequiel
        private const string Servidor = "DESKTOP-TTT7KKD";
        private const string BaseDeDatos = "EventManager_v1.0";
        private const string Usuario = "sa";
        private const string Contrasena = "pa$$word";

        public static string ObtenercadenaSql => $"Data Source={Servidor};Initial Catalog={BaseDeDatos};User Id={Usuario};Password={Contrasena};";
    }
}
