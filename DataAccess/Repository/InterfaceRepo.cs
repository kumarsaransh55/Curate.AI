using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface InterfaceRepo
    {
        public string ValidateUser(string uEmail, string uPass);
        public bool RegisterUser(UserDetails userDetails);
        public UserDetails GetUser(string eMailID);
        public bool UpdateUser(UserDetails userDetails);
    }
}