using Com.Qualcomm.Qswat.Core.Utility;
using Com.Qualcomm.Qswat.Data.Context;
using Com.Qualcomm.Qswat.Model.Common;
using System;
using System.Linq;

namespace Com.Qualcomm.Qswat.Data.Initializer
{
    public class DataSeeds
    {
        private readonly EfContext _context;

        public DataSeeds(EfContext context)
        {
            _context = context;
        }

        public void SeedAll()
        {
            SeedUser();
            SeedTicket();
        }

        public void SeedUser()
        {
            var testUser =
                _context.Set<User>()
                    .FirstOrDefault(
                        m => m.Email.Equals("guangming.lan@gmail.com", StringComparison.CurrentCultureIgnoreCase));
            if (testUser == null)
            {
                _context.Set<User>().Add(new User()
                {
                    Email = "guangming.lan@gmail.com",
                    PasswordHash = EncryptHelper.Md5Hex("123456"),
                    FirstName = "Guangming",
                    LastName = "Lan",
                    Phone = "626-272-7768",
                    Address = new Address()
                    {
                        AddressLine1 = "10 Thunder Run",
                        AddressLine2 = "APT 21H",
                        City = "Irvine",
                        State = "CA",
                        Country = "USA",
                        PostalCode = "92614"
                    }
                });
                _context.SaveChanges();
            }
        }

        public void SeedTicket()
        {
            var testUser =
               _context.Set<User>()
                   .FirstOrDefault(
                       m => m.Email.Equals("guangming.lan@gmail.com", StringComparison.CurrentCultureIgnoreCase));
            if (testUser != null)
            {
                var ticket = testUser.Issues.FirstOrDefault(m => m.Description == "test");
                if (ticket == null)
                {
                    _context.Set<Issue>().Add(new Issue()
                    {
                        Title = "Ticket from test case",
                        Description = "test",
                        Assignee = testUser,
                        CreatedBy = testUser,
                        CreateDateTimeUtc = DateTime.UtcNow
                    });

                    _context.SaveChanges();
                }
            }
        }
    }
}