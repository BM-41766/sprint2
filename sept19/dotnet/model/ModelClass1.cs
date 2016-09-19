using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication8.Models
{
    public class ModelClass1
    {
        public string name="";
        public string pwd="";
        public string X_Username
        {
        get
        {
            return name;
        }
            set
            {
                name=value;
            }
        }
        public string X_paswrd
        {
            get
            {
                return pwd;
            }
            set
            {
                pwd=value;
            }
        }
        string msg;
        public string login()
        {
            try
            {
                ServiceReference2.Service1Client sc1 = new ServiceReference2.Service1Client();
                msg = sc1.login(X_Username, X_paswrd);
               // return msg;
            }
            catch (Exception ex)
            {
                errorloginfile.SendError(ex);
            }
            return msg;
        }
    }
}
