
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiNet.Models;

public class Property // reference to properties or real states
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }
    public string Picture { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
}