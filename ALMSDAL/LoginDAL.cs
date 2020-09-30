using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSDAL
{
    public class LoginDAL
    {
        SqlConnection connection = new SqlConnection(DALStatic.connectionString);


        public bool ValidateLoginDAL(int userId,string password,string userType)
        {
            try
            {
                if (userType == "Employee")
                {
                    connection.Open();
                    Console.WriteLine("User type is employee verified");
                    string command = "Select Employee_ID,Employee_Password from Employee where Employee_ID = @eId";
                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.Parameters.AddWithValue("@eId", userId);

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        Console.WriteLine("In Reader");
                        if (reader["Employee_ID"].ToString().Equals(userId.ToString()))
                        {
                            if (reader["Employee_Password"].ToString().Equals(password.ToString()))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        { return false; }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (userType == "Admin")
                {
                    Console.WriteLine("User type is Admin verified");
                    connection.Open();
                    Console.WriteLine("admin connection is open");
                    string command = "Select Admin_ID, Admin_Password from Admin where Admin_ID = @aId";
                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.Parameters.AddWithValue("@aId", userId);
                    Console.WriteLine("sql command success");
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        Console.WriteLine("In Reader");
                        if (reader["Admin_ID"].ToString().Equals(userId.ToString()))
                        {
                            if (reader["Admin_Password"].ToString().Equals(password.ToString()))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        { return false; }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return false;
        }

        public bool IsManagerDAL(int userId)
        {
            Console.WriteLine("in manager DAL");
            try
            {
                connection.Open();
                Console.WriteLine("User type managerId checking");
                string command = "Select Manager_ID from Employee where Manager_ID = @mId";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@mId", userId);
                Console.WriteLine("sql command success");
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine("In Reader");
                    if (reader["Manager_ID"].ToString().Equals(userId.ToString()))
                    {
                        return true;
                    }
                    else
                    { return false; }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return false;
        }
    }
}
