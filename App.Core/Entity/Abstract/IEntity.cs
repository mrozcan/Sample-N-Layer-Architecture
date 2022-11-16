using System.ComponentModel.DataAnnotations;

namespace App.Core.Entity.Abstract;

public interface IEntity
{
    [Key]
    Guid Id { get; init; }
    DateTime CreateDate { get; set; }
    DateTime? UpdateDate { get; set; }
}
