using Firebase.Auth;

namespace Api_Login.Services
{
    public class FileService : IFilesService
    {
        public Task<string> SubirArchivo(Stream archivo, string nombre)
        {
            string correo? = "";
            string clave? = "";
            string ruta ?= "";
            string api_key? = "";
        }
    }
}
