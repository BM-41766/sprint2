using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace MvcApplication8.Views.my
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        
        public void DoWork()
        {

        }
        public string login()
        {
            SqlConnection CON = new SqlConnection("Data Source=admin-pc;Initial Catalog=facebooklogin;Integrated Security=True");
           
            CON.Open();
            SqlCommand CMD =CON.CreateCommand();
            CMD.CommandText = "select * from userlogin";
            SqlDataReader sdr = CMD.ExecuteReader();
            userlogin login=new userlogin(); 
            while(sdr.Read())
            {
             if((login.username.Equals(sdr["username"].ToString()))&&(login.password.Equals(sdr["password"].ToString())))

             {
                 login.username=sdr["username"].ToString();
                 login.password=sdr["password"].ToString();
                 

             }
             String str = JsonConvert.SerializeObject(login);
             return str;
            }

           // CON.Close();
           // CMD.Dispose();
           return null;
        }


    }
}
