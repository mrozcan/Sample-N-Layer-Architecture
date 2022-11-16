using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace App.Infrastructure.DataTransferObjects;

public class SampleUpdateDto
{
    [Key, Required]
    public Guid Id { get; set; }
    [Required, AllowNull]
    public string SampleStringData { get; set; }
    [Required]
    public int SampleIntData { get; set; }

}
