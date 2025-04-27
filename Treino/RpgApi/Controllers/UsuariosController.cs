using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> UsuarioExistente(string Username)
        {
            if (await _context.TB_USUARIOS.AnyAsync(x => x.Username.ToLower() == Username.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Usuario> Lu = await _context.TB_USUARIOS.ToListAsync();
                return Ok(Lu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.Username))
                {
                    throw new System.Exception("Nome de Usuario já existe");
                }
                if (user.Email == "")
                {
                    throw new Exception("O usuario não pode ser cadastrado sem um email");
                }
                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.TB_USUARIOS.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario? usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado");
                }
                else if (!Criptografia.VerificaPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("A senha digitada não está correta");
                    throw new System.Exception("Usuario não encontrado");
                }
                else if (!Criptografia.VerificaPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta");
                }
                else
                {
                    usuario.DataAcesso = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenha(Usuario UsuarioSenhaAlterada)
        {
            try
            {
                Usuario usuDB = await _context.TB_USUARIOS.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(UsuarioSenhaAlterada.Username.ToLower()));
                if (usuDB == null)
                {
                    throw new Exception("O usuario passado nao existe");
                }
                else{
                    Criptografia.CriarPasswordHash(UsuarioSenhaAlterada.PasswordString, out byte[] hash, out byte[] salt);
                    usuDB.PasswordString = string.Empty;
                    usuDB.PasswordHash = hash;
                    usuDB.PasswordSalt = salt;
                    _context.TB_USUARIOS.Update(UsuarioSenhaAlterada);
                    List<Usuario> Lu = await _context.TB_USUARIOS.ToListAsync();
                    return Ok(Lu);

                }
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }



        }
    }
}