using System.ComponentModel.DataAnnotations;

public class RecuperarSenhaVM
{
    [Required(ErrorMessage = "A nova senha é obrigatória.")]
    [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
    public string NovaSenha { get; set; }

    [Required(ErrorMessage = "Confirme a nova senha.")]
    [Compare("NovaSenha", ErrorMessage = "As senhas não coincidem.")]
    public string ConfirmarSenha { get; set; }
}
