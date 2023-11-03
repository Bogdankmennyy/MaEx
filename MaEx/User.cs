using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Windows;




    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }


        [Required]
        public string UserName { get; set; }


        [Required]
        public string PhoneNamber { get; set; }


    }

//using Microsoft.EntityFrameworkCore;

//public class MarketExchangeContext : DbContext
//    {
//        public DbSet<User> Users { get; set; }


//    }
