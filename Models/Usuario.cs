using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nombre de Usuario")]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Contraseña { get; set; }

    [Required]
    [EmailAddress]
    public string Mail { get; set; }

    [Phone]
    public string Telefono { get; set; }
} 