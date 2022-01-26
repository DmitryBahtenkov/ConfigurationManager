using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigurationManager.Core.Contract.Models;

/// <summary>
/// Represents a default model fields
/// </summary>
public abstract class BaseModel
{
    /// <summary>
    /// Auto-incremental ID
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
