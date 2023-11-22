using DesafioDavson.Data;
using DesafioDavson.Models;
using DesafioDavson.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDavson.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasDeTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemasDeTarefasDBContext sistemasDeTarefasDBContext)
        {
            _dbContext = sistemasDeTarefasDBContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new NotImplementedException($"Usuario para o Id:{id} nao foi encontrado no banco de dados!");

            }   

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new NotImplementedException($"Usuario para o Id:{id} nao foi encontrado no banco de dados!");

            }

            usuarioPorId.Name = usuario.Name;
            usuario.Email = usuario.Email;
            usuario.DataNascimento = usuario.DataNascimento;
            usuario.CPF = usuario.CPF;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }
    }
}
