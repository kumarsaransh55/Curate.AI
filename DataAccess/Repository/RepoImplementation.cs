using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RepoImplementation : InterfaceRepo
    {
        private CETDbContext _dbContext;
        public RepoImplementation()
        {
            _dbContext = new CETDbContext();
        }

        public string ValidateUser(string uEmail, string uPass)
        {
            UserDetails adminUser = null;
            try
            {
                adminUser = _dbContext.User_Details.Where(u => u.User_EmailId== uEmail &&
                 u.User_Password== uPass).FirstOrDefault();

            }
            catch
            {
                adminUser = null;
            }
            if(adminUser != null)
            {
                return uEmail;
            }
            return null;
        }
        public bool RegisterUser(UserDetails userDetails)
        {
            if(userDetails == null)
            {
                return false;
            }
            else
            {
                _dbContext.User_Details.Add(userDetails);
                _dbContext.SaveChanges();
            }
            return true;
        }

        public UserDetails GetUser(string eMailID)
        {
            return _dbContext.User_Details.FirstOrDefault(x=>x.User_EmailId==eMailID);
        }

        public bool UpdateUser(UserDetails userDetails)
        {
            if(userDetails == null) { return false;}
            UserDetails userDetails1 = _dbContext.User_Details.Find(userDetails.UserId);
            try
            {
                if (userDetails1 != null)
                {
                    userDetails1.User_EmailId = userDetails.User_EmailId;
                    userDetails1.User_Password = userDetails.User_Password;
                    userDetails1.User_Last_Name = userDetails.User_Last_Name;
                    userDetails1.User_Last_Name = userDetails.User_Last_Name;
                    _dbContext.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateProfile(UserDetails userDetails)
        {
            UserDetails userDetails1= GetUser(userDetails.User_EmailId);
            userDetails1.UserId=userDetails.UserId;
            userDetails1.User_EmailId=userDetails.User_EmailId;
            userDetails1.User_Last_Name=userDetails.User_Last_Name;
            userDetails1.User_First_Name=userDetails.User_First_Name;
            userDetails1.User_Password=userDetails.User_Password;
            _dbContext.SaveChanges();
            return true;
        }

    }
}
