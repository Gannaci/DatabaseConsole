using DatabaseConsole.Data;
using DatabaseConsole.Models;
using DatabaseConsole.Models.Entity;
using Microsoft.EntityFrameworkCore;
using static DatabaseConsole.Models.Entity.CustomerEntity;

namespace DatabaseConsole.Services;

public class CustomerService
{
    private static readonly DataContexts _context = new();

   
    public static async Task SaveUserAndErrandAsync(Customer customer, Errand errand, StatusAndComment statusAndComment)
    {
        var customerEntity = new CustomerEntity
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Id = customer.Id
        };
        var errandEntity = new ErrandEntity
        {
            ErrandDescription = errand.ErrandDescription,
            ErrandId = errand.ErrandId,
            TimeStamp = DateTime.Now,
            Customer = customerEntity
        };

        var statusEntity = new StatusEntity
        {
            StatusId = statusAndComment.StatusId,
            Errand = errandEntity,
            Status = statusAndComment.Status,
            Comment = statusAndComment.Comment,
            UpdateTime = DateTime.Now
        };

        customerEntity.Errand = errandEntity;
        errandEntity.StatusAndComment = statusEntity;

        _context.Add(customerEntity);
        _context.Add(errandEntity);
        _context.Add(statusEntity);

        await _context.SaveChangesAsync();
    }
}
