using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem
{
     public class LoginObject
    {
         public LoginObject(string Username, string Password, string competence)
        {
            this.UserName = Username;
            this.PassWord = Password;
            this.Competence = competence;
        }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Competence { get; set; }

    }
}
