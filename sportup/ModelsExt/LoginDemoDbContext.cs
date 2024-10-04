using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sportup.Models
{

    public partial class LoginDemoDbContext : DbContext
    {
        public Models.User GetUSerFromDB(int UserId)
        {
            Models.User user = this.Users.Where(u => u.UserId == UserId).FirstOrDefault();
            return user;
        }
    }

}