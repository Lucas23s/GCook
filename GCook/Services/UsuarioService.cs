using GCook.Data;
using GCook.Models;
using GCook.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace GCook.Services;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext_context;
    private readonly SignInManager<UsuarioService> _signInManager;
    private readonly UserManager<UsuarioService> _userManager;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(
        AppDbContext context,
        SignInManager<Usuario> signManager,
        UserManager<Usuario> userManager,
        ILogger<UsuarioService> logger
    )
    {
        _context = context;
        _signInManager = signManager;
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<SignInResult> LoginUsuario(LoginVM login)
    {
        string userName = login.Email;
        if (Helper.IsValidEmail(login.Email))
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
                userName = user.userName;
        }

        var result = await _signInManager.PasswordSignInAsync(
            userName, login.Senha, login.Lembrar, lockoutOnFailure: true
        );
    }

    public Task LogoutUsuario()
    {
        throw new NotImplementedException();
    }
}