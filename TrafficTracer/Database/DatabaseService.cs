using Microsoft.EntityFrameworkCore;
using TrafficTracer.Models;

namespace TrafficTracer.Database;

public partial class DatabaseService
{
    private readonly DatabaseContext _context = new DatabaseContext();

    public DatabaseService()
    {
        _context.Database.EnsureCreated();
        _context.Immatriculations.Load();
    }
    
    public List<Immatriculation> GetImmatriculations()
    {
        return _context.Immatriculations.Where(i => i.DeletedAt == null).ToList();
    }

    public void AddImmatricuation(string plate, PlateType type, DateTime readDate)
    {
        var data = new Immatriculation { Plate = plate, Type = type, ReadDate = readDate };
        _context.Immatriculations.Add(data);
        _context.SaveChanges();
    }
    
    public Immatriculation? GetImmatriculationById(int id)
    {
        return _context.Immatriculations.Find(id);
    }

    public bool UpdateImmatriculation(int id, string plate, PlateType type, DateTime readDate)
    {
        var entity= GetImmatriculationById(id);
        if (entity == null) return false;

        entity.Plate = plate;
        entity.Type = type;
        entity.ReadDate = readDate;

        _context.SaveChanges();
        return true;
    }

    public bool DeleteImmatriculation(int id)
    {
        var entity= GetImmatriculationById(id);
        if (entity == null) return false;
        
        entity.DeletedAt = DateTime.Now;

        /*_context.Remove(entity);*/

        _context.SaveChanges();
        return true;
    }

    public bool ImmatriculationExists(int id)
    {
        return _context.Immatriculations.Any(i => i.Id == id);
    }
}