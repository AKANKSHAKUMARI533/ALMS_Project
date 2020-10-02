using ALMSEntity;
using ALMSExceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMSDAL
{
    public class EmployeeDAL
    {
        SqlConnection connection = new SqlConnection(DALStatic.connectionString);

        public bool AddEmployeeDAL(EmployeeEntity employeeEntity)
        {
            try
            {
                connection.Open();


                string command = "spAddEmployee";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Employee_Name", employeeEntity.EmployeeName);
                sqlCommand.Parameters.AddWithValue("@Employee_Email", employeeEntity.EmployeeEmail);
                sqlCommand.Parameters.AddWithValue("@Employee_Phone_Number", employeeEntity.EmployeePhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Employee_Role", employeeEntity.EmployeeRole);
                sqlCommand.Parameters.AddWithValue("@Employee_Status", employeeEntity.EmployeeStatus);
                sqlCommand.Parameters.AddWithValue("@Employee_Password", employeeEntity.EmployeePassword);
                sqlCommand.Parameters.AddWithValue("@mId", employeeEntity.ManagerID);
                sqlCommand.Parameters.AddWithValue("@pId", employeeEntity.ProjectID);

                int RowsAffected = sqlCommand.ExecuteNonQuery();
                if (RowsAffected == 1)
                {

                    return true;
                }
                else
                {
                    return false;
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
            return false;
        }

        public bool UpdateEmployeeDAL(EmployeeEntity employeeEntity)
        {
            try
            {
                connection.Open();


                string command = "spModifyEmployeeDetails";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@eId", employeeEntity.EmployeeID);
                sqlCommand.Parameters.AddWithValue("@Employee_Name", employeeEntity.EmployeeName);
                sqlCommand.Parameters.AddWithValue("@Employee_Email", employeeEntity.EmployeeEmail);
                sqlCommand.Parameters.AddWithValue("@Employee_Phone_Number", employeeEntity.EmployeePhoneNumber);
                sqlCommand.Parameters.AddWithValue("Employee_Role", employeeEntity.EmployeeRole);
                sqlCommand.Parameters.AddWithValue("@Employee_Status", employeeEntity.EmployeeStatus);
                sqlCommand.Parameters.AddWithValue("@Employee_Password", employeeEntity.EmployeePassword);
                sqlCommand.Parameters.AddWithValue("@Manager_ID", employeeEntity.ManagerID);
                sqlCommand.Parameters.AddWithValue("@Project_ID", employeeEntity.ProjectID);

                int RowsAffected = sqlCommand.ExecuteNonQuery();
                if (RowsAffected == 1)
                {

                    return true;
                }
                else
                {
                    return false;
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
            return false;
        }

        public bool DeleteEmployeeDAL(EmployeeEntity employeeEntity)
        {
            try
            {
                connection.Open();


                string command = "spDeleteEmployee";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@eId", employeeEntity.EmployeeID);
                int RowsAffected = sqlCommand.ExecuteNonQuery();
                if (RowsAffected == 1)
                {

                    return true;
                }
                else
                {
                    return false;
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
            return false;
        }

        public EmployeeEntity SearchEmployeeDAL(int EmployeeID)
        {
            EmployeeEntity searchedEmployee = new EmployeeEntity();

            try
            {
                connection.Open();
                //Step3. Create the command
                string command = "spSearchEmployee";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@eId", EmployeeID);
                //Step4. Run the command
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {


                    string ename = reader["Employee_Name"].ToString();
                    searchedEmployee.EmployeeName = ename;

                    string email = reader["Employee_Email"].ToString();
                    searchedEmployee.EmployeeEmail = email;

                    string ephone = reader["Employee_Phone_Number"].ToString();
                    searchedEmployee.EmployeePhoneNumber = ephone;

                    string erole = reader["Employee_Role"].ToString();
                    searchedEmployee.EmployeeRole = erole;

                    string estatus = reader["Employee_Status"].ToString();
                    searchedEmployee.EmployeeStatus = estatus;

                    string epass = reader["Employee_Password"].ToString();
                    searchedEmployee.EmployeePassword = epass;

                    int mid = int.Parse(reader["Manager_Id"].ToString());
                    searchedEmployee.ManagerID = mid;

                    int pid = int.Parse(reader["Project_Id"].ToString());
                    searchedEmployee.ProjectID = pid;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Step5. Close the connection
            finally
            {
                if (connection.State == ConnectionState.Open)
                {

                    connection.Close();
                }
            }
            return searchedEmployee;
        }

        public DataTable LoadGridDAL()
        {

            DataTable dataTable = new DataTable();

            try
            {

                connection.Open();

                string command = "spGetAllEmployee";
                SqlCommand sqlCommand = new SqlCommand(command, connection);


             
                SqlDataReader reader = sqlCommand.ExecuteReader();
                
                dataTable.Load(reader);

                
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
            return dataTable;
        }
    }
}
