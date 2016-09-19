using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;


namespace MvcApplication8.Views.my
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        
        public void DoWork()
        {

        }
        public string login(string X_username,string X_password)
        {
            SqlConnection CON = new SqlConnection("Data Source=admin-pc;Initial Catalog=facebooklogin;Integrated Security=True");
           
            CON.Open();
            SqlCommand CMD =CON.CreateCommand();
            CMD.CommandText = "select * from userlogin";
            SqlDataReader sdr = CMD.ExecuteReader();
            userlogin login=new userlogin();
           login.username = X_username;
            login.password = X_password;
            try
            {
                while (sdr.Read())
                {
                    if ((login.username.Equals(sdr["username"].ToString())) && (login.password.Equals(sdr["password"].ToString())))
                    {
                        login.firstname = sdr["firstname"].ToString();
                        login.lastname = sdr["lastname"].ToString();

                        login.username = sdr["username"].ToString();
                        login.X_loginid = sdr["loginid"].ToString();
                        login.profilepic = sdr["profilepic"].ToString();
                        String str = "\"loginid:\" " + login.X_loginid + "   \"username:\" " + login.username + "       \"firstname:\" " + login.firstname + "        \"lastname:\" " + login.lastname + "        \"profilepic:\" " + login.profilepic + "    \"Responce code:200      Msg:Sucess\" ";
                        return str;

                    }
                    else if ((login.username.Equals(sdr["username"].ToString())) || (login.password.Equals(sdr["password"].ToString())))
                    {
                        login.firstname = sdr["firstname"].ToString();
                        login.lastname = sdr["lastname"].ToString();
                        login.username = sdr["username"].ToString();
                        login.X_loginid = sdr["loginid"].ToString();
                        login.profilepic = sdr["profilepic"].ToString();
                        String str = "\"username:\" " + login.username + "   \"profilepic:\" " + login.profilepic + "    \"Responce code:500   Msg:password incorrect\" ";
                        return str;

                    }
                    else if (!(login.username.Equals(sdr["username"].ToString())) && (!(login.password.Equals(sdr["password"].ToString()))))
                    {
                        login.firstname = sdr["firstname"].ToString();
                        login.lastname = sdr["lastname"].ToString();
                        login.username = sdr["username"].ToString();
                        login.X_loginid = sdr["loginid"].ToString();
                        login.profilepic = sdr["profilepic"].ToString();
                        String str = "    \"Responce code:404    Msg:Email id doesnot exit\" ";
                        return str;

                    }


                }
            }
            catch (Exception ex)
            {
                errorloginfile.SendError(ex);

            }
                

           // CON.Close();
           // CMD.Dispose();
           return null;
        }


    }
}
