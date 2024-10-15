using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sportup.Models
{

    public partial class LoginDemoDbContext : DbContext
    {
        public Models.Users GetUSerFromDB(int UserId)
        {
            Models.Users user = this.Users.Where(u => u.UserId == UserId).FirstOrDefault();
            return user;
        }
    }

}