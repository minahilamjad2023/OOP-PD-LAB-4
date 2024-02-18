using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.BL
{
    public class SignIn
    {
        private string name;
        private string password;
        private string role;

        public SignIn(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }

        public string getUserName()
        {
            return name;
        }

        public string getPassword()
        {
            return password;
        }

        public string getRole()
        {
            return role;
        }

        public void setRole(string role)
        {
             this.role = role;
        }
        public void setPassworde(string password)
        {
             this.password = password;
        }
        public void setUserName(string name)
        {
             this.name = name;
        }

    }
}
