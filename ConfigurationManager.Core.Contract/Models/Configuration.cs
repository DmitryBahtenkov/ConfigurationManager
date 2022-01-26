using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConfigurationManager.Core.Contract.Models;

/// <summary>
/// Configuration for project witn env
/// </summary>
public class Configuration : BaseModel
{
    public string Environment { get; set; }
    public JsonDocument Json { get; set; }
    public int ProjectId { get; set; }
    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }
}