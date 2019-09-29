using CalcMVC.Models.Context;
using CalcMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalcMVC.Models
{
    public class LoginState
    {
        ProjectContext db;
        public LoginState()
        {
            db = new ProjectContext();
        }

        public bool IsLoginSuccess(string name, string password)
        {
            User user = db.Users.Where(x => x.UserName.Equals(name) && x.Password.Equals(password)).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}