using DatabaseConsole.Data;
using DatabaseConsole.Models;
using DatabaseConsole.Models.Entity;
using Microsoft.EntityFrameworkCore;
using static DatabaseConsole.Models.Entity.CustomerEntity;

namespace DatabaseConsole.Services;

public class ErrandService
{
    private static readonly DataContexts _context = new();
    

    public static List<ErrandEntity> GetAll()
    {
        var errands = _context.Errands
            .Include(x => x.StatusAndComment)
            .ToList();
        
        return errands;
    }
    public static ErrandEntity GetErrandByEmail(string email)
    {
        var customer = _context.Customers
      .Include(x => x.Errand.StatusAndComment)
      .FirstOrDefault(x => x.Email == email);

        if (customer != null)
            return customer.Errand;
        else
            return null!;
        }

        public static void UpdateErrand(ErrandEntity errand)
        {
            _context.Entry(errand).State = EntityState.Modified;
            _context.SaveChanges();
        }
}
