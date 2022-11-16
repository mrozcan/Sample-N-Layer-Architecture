using App.Core.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace App.Domain.Entities;

public class SampleEntity : IEntity
{
    public Guid Id { get; init; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    [AllowNull]
    public string SampleStringData { get; set; }
    [Required]
    public int SampleIntData { get; set; }

    public SampleEntity()
    {
        CreateDate = DateTime.UtcNow;
    }

}
