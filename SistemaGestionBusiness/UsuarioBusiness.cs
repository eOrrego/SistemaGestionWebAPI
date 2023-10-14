using SistemaGestionEntities;
using SistemaGestionData;

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
            UsuarioData.CrearUsuario(usuario);
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
    }
}
