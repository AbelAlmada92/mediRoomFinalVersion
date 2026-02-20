namespace Api_Login.Services
{
    public interface IFilesService
    {
        Task<string> SubirArchivo(Stream archivo, string nombre );
    }
}
