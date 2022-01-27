using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ConfigurationManager.Core.Contract.Models;
using ConfigurationManager.Core.Contract.Projects;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Core.Contract.Configurations;

/// <summary>
/// Configuration for project witn env
/// </summary>
[Index(nameof(Environment), nameof(ProjectId))]
public class Configuration : BaseModel
{
    public string Environment { get; set; }
    public JsonDocument Json { get; set; }
    public int ProjectId { get; set; }
    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }
}