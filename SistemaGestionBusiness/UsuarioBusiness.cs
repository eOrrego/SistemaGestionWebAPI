using SistemaGestionEntities;
using SistemaGestionData;
using System.Text;
using System.Security.Cryptography;

namespace SistemaGestionBusiness
{
    public static class UsuarioBusiness
    {
        //listar usuarios
        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }

        //obtener usuario por id
        public static Usuario ObtenerUsuarioPorId(int id)
        {
            return UsuarioData.ObtenerUsuarioPorId(id);
        }

        //crear usuario
        public static void CrearUsuario(Usuario usuario)
        {
            //salt estatica para encriptar contraseña
            byte[] salt = Encoding.ASCII.GetBytes("SistemaGestion");

            //encriptar contraseña
            string hashedPassword = HashedPassword(usuario.Contraseña, salt);

            //asignar contraseña encriptada
            usuario.Contraseña = hashedPassword;

            UsuarioData.CrearUsuario(usuario);
        }

        //Metodo para encriptar contraseña
        public static string HashedPassword(string password, byte[] salt)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hash);
        }

        //modificar usuario
        public static void ModificarUsuario(Usuario usuario)
        {
            UsuarioData.ModificarUsuario(usuario);
        }

        //eliminar usuario
        public static void EliminarUsuario(int id)
        {
            UsuarioData.EliminarUsuario(id);
        }

        //obtener usuario por nombre de usuario
        public static Usuario ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return UsuarioData.ObtenerUsuarioPorNombreUsuario(nombreUsuario);
        }
    }
}
