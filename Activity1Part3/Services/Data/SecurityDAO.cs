using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Activity1Part3.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Activity1Part3.Services.Data
{
    public class SecurityDAO
    {
        string connectionStr = ConfigurationManager.ConnectionStrings["DonaldLocal"].ConnectionString;
        string ValidateLoginQuery = @"if exists(select * from Test.dbo.Users where username = @name and password = @password collate SQL_Latin1_General_CP1_CS_AS)
                                        Begin
                                            select 'True'
                                        End
                                        Else
                                        Begin
                                            select 'False'
                                        End";
        public bool FindByUser(UserModel user)
        {
            bool isLoginValid = false;
            using(SqlConnection conn = new SqlConnection(connectionStr))
            {
                using(SqlCommand cmd = new SqlCommand(ValidateLoginQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@name", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        if(reader[0].ToString() == "True")
                        {
                            isLoginValid = true;
                        } 
                    } catch(SqlException ex)
                    {
                        Debug.WriteLine(ex.Message);
                    } catch(Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return isLoginValid;
                }
            }
        }
    }
}