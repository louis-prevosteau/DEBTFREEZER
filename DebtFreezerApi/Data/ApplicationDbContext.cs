using DebtFreezerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DebtFreezerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DBSet des tables
        //Chaque DbSet represente une table dans Mysql

        // Table des dettes
        public DbSet<Debt>  Dettes { get; set; }

        //Table des challenges

        public DbSet<Challenge> Challenges { get; set; }


        //Table des paiement

        public DbSet<Payment> Paiements { get; set; }

        //Table des utilsateurs
        public DbSet<User> Utilisateurs { get; set; }

        



    }
}
