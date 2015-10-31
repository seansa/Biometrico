using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.Usuario
{
    public static class ConstantesSeguridad
    {
        private static string ClaveSecreta = "1MonitorFeo@Tiene@BrilloPerfecto";

        public static string UsuarioAdministrador = "ADMIN";
        public static string PasswordAdministrador = "123";

        public static string PasswordPorDefecto()
        {
            var clave = EncriptarCadena("P$assword");
            return clave;
        }
                
        public static string EncriptarCadena(string cadena)
        {
            byte[] cadenaBytes = Encoding.UTF8.GetBytes(cadena);
            byte[] claveBytes = Encoding.UTF8.GetBytes(ClaveSecreta);

            //creamos un objeto de la clase Rijndael
            RijndaelManaged rij = new RijndaelManaged();
            //configuramos para que utilize el medo ECB
            rij.Mode = CipherMode.ECB;
            //configuramos para encriptar en 256bit
            rij.BlockSize = 256;
            //declaramos que si necesitas mas bytes agregue ceros
            rij.Padding = PaddingMode.Zeros;
            //declaramos un encriptador que use mi clave secreta y un vector de inicializacion aleatorio
            ICryptoTransform encriptador;
            encriptador = rij.CreateEncryptor(claveBytes, rij.IV);

            //declaramos un stream de memoria para que guarde los datos encriptados a medida que se van calculando
            MemoryStream memStream = new MemoryStream();

            //declaramos un stream de cibrado para que pueda escribir aqui la cadena a encriptar.
            //Esta clase utiliza el encriptador y el stream de memoria para realizar la encriptacion y para almacenarla
            CryptoStream cifradoStream;
            cifradoStream = new CryptoStream(memStream, encriptador, CryptoStreamMode.Write);

            //escribo los byte a encriptar. a medida que se va escribiendo se va encripdando la candena
            cifradoStream.Write(cadenaBytes, 0, cadenaBytes.Length);

            //aviso que la encriptacion termino
            cifradoStream.FlushFinalBlock();

            //convertimos los datos encripdatos de la memoria sobre el array
            byte[] cipherTextBytes = memStream.ToArray();

            //cierro los datos creados
            memStream.Close();
            cifradoStream.Close();

            //convierto el resultado en base 64 para que sea legible y devuelvo el resultado
            return Convert.ToBase64String(cipherTextBytes);
        }
    }
}
