using Microsoft.EntityFrameworkCore;
using Employees.Models;

namespace Employees.Data
{
    //inherit it from entity framework core,it will manage DB for us
    public class ApplicationDBContext : DbContext
    {
        //configure database
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        //create db set ,model
        public DbSet<Employee>employees{ get; set; }
    }     
}



 
