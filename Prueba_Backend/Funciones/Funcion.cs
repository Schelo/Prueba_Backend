namespace Prueba_Backend.Funciones
{
    public class Funcion
    {
        public bool VerificaToken(string TokenUser, string TokenPass) {

            bool respuesta = false;
            // 1 Obtener valores de json token
            string tokenPass = string.Empty;
            string tokenUser = string.Empty;

            if (tokenPass == TokenPass && TokenUser == TokenUser)
            {
                respuesta = true;
                return respuesta;
            }else
            {
                return respuesta;
            }
        }
    }
}
