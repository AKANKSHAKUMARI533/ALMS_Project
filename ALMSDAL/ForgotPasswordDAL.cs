using ALMSEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSDAL
{
    public class ForgotPasswordDAL
    {
        SqlConnection connection = new SqlConnection(DALStatic.connectionString);

        public string ForgotDAL(ForgotPasswordEntity forgotPasswordEntity)
        {
            ForgotPasswordEntity searchedEmployee = new ForgotPasswordEntity();
            
            try
            {
                connection.Open();
                string command = "spForgot";
                SqlCommand sqlCommand= new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
               
                sqlCommand.Parameters.AddWithValue("@Email", searchedEmployee.EmployeeEmail);
                sqlCommand.Parameters.AddWithValue("@Id", searchedEmployee.EmployeeID);
                
                SqlDataReader reader = sqlCommand.ExecuteReader();
                
                if (reader.Read())
                {
                    string epass = reader["Employee_Password"].ToString();
                    searchedEmployee.EmployeePassword = epass;
                }
                else
                {

                    Console.WriteLine("Record is not present in the DataBase");
                }

            }
            catch (SqlException exception)
            {
                Console.WriteLine("Something Went Wrong." + exception.Message);
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
            return searchedEmployee.EmployeePassword;
        }
    }
}
