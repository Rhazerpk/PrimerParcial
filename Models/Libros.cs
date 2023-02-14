using System.ComponentModel.DataAnnotations;

public class Libros{

    [Key]

    [Required(ErrorMessage ="El libroId es requerido")]
    public int LibroId { get; set; }
    [Required(ErrorMessage ="El título es requerido")]
    public string? Titulo { get; set; }
    [Required(ErrorMessage ="El precio es requerido")]
    public double Precio { get; set; }
    
}