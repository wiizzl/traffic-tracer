using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrafficTracer.Models;

public enum PlateType
{
    SIV,
    FNI
}

public partial class Immatriculation
{
    public int Id { get; set; }
    
    [MaxLength(12)]
    public string Plate { get; set; }
    
    public PlateType Type { get; set; }
    public DateTime ReadDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? UpdatedAt { get; set; }
}