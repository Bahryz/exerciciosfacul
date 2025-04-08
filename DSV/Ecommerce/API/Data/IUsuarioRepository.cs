using API.Models;
using System.Collections.Generic;

namespace API.Data
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
    }
}
