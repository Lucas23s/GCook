using System.ComponentModel.DataAnnotations;

namespace GCook.ViewModels;

public class LoginVM
{
    [Display(Name = "Email ou Nome de Usuário", Prompt = "Informe seu Email ou Nome de Usuário")]
    [Required(ErrorMessage = "O Email ou Nome de Usuário é obrigatório")]
    public string Email { get; set;}
    
    [DataType(DataType.Password)]
    [Display(Name = "Senha de Acesso", Prompt = "********")]
    [Required(ErrorMessage = "A Senha é obrigatória")]
    public string Senha { get; set;}
    
    [Display(Name = "Manter Conectado?")]
    public bool Lembrar { get; set;} = false;
    public string UrlRetorno { get; set;}
}