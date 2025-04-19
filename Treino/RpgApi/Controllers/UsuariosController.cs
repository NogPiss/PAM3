using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context){
            _context = context;
        }

        private async Task<bool> UsuarioExistente(string Username){
            if( await _context.TB_USUARIOS.AnyAsync(x => x.Username.ToLower() == Username.ToLower())){
                return true;
            }
            return false;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user){
            try{
                if(await UsuarioExistente(user.Username)){
                    throw new System.Exception("Nome de Usuario já existe");
                }
                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.TB_USUARIOS.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
                }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }
}