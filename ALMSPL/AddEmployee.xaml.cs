using ALMSBLL;
using ALMSEntity;
using ALMSExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ALMSPL
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        EmployeeEntity EmployeeEntity = new EmployeeEntity();
        EmployeeBLL EmployeeBLL = new EmployeeBLL();
        public AddEmployee()
        {
            InitializeComponent();
            dgEmployees.DataContext = EmployeeBLL.LoadGridBLL();
        }

        private void SaveDetails(object sender, RoutedEventArgs e)
        {
            try
            {
                string employeeName = txtName.Text;
                string employeeEmail = txtEmail.Text;
                string employeePhone = txtPhone.Text;
                string employeeRole = empRole.Text;
                string employeeStatus = txtStatus.Text;
                string employeePassword = txtPassword.Text;
                int managerId = Convert.ToInt32(txtMId.Text);
                int projectId = Convert.ToInt32(txtPId.Text);
                // asign value to leave class

                EmployeeEntity.EmployeeName = employeeName;
                EmployeeEntity.EmployeeEmail = employeeEmail;
                EmployeeEntity.EmployeePhoneNumber = employeePhone;
                EmployeeEntity.EmployeeRole = employeeRole;
                EmployeeEntity.EmployeeStatus = employeeStatus;
                EmployeeEntity.EmployeePassword = employeePassword;
                EmployeeEntity.ManagerID = managerId;
                EmployeeEntity.ProjectID = projectId;

                Console.WriteLine(EmployeeEntity);
                bool requestStatus = EmployeeBLL.EmployeeAddBLL(EmployeeEntity);

                if (requestStatus == true)
                {
                   
                    MessageBox.Show("Employee Added Successfully");
                    dgEmployees.DataContext = EmployeeBLL.LoadGridBLL();
                }
                else
                {
                    MessageBox.Show("Something is wrong..check your details again..");
                }
            }
            catch (ALMSException exception)
            {
                MessageBox.Show("Something Went Wrong." + exception.Message);
            }
        }



        private void UpdateEmployee(object sender, RoutedEventArgs e)
        {
            try
            {


                int EmpId;
                EmpId = Convert.ToInt32(txtId.Text);

                string employeeRole = empRole.Text;
                string employeeName = txtName.Text;
                string employeeEmail = txtEmail.Text;
                string employeePhone = txtPhone.Text;
                string employeeStatus = txtStatus.Text;
                string employeePassword = txtPassword.Text;
                int managerId = Convert.ToInt32(txtMId.Text);
                int projectId = Convert.ToInt32(txtPId.Text);

                EmployeeEntity.EmployeeID = EmpId;
                EmployeeEntity.EmployeeName = employeeName;
                EmployeeEntity.EmployeeEmail = employeeEmail;
                EmployeeEntity.EmployeePhoneNumber = employeePhone;
                EmployeeEntity.EmployeeRole = employeeRole;
                EmployeeEntity.EmployeeStatus = employeeStatus;
                EmployeeEntity.EmployeePassword = employeePassword;
                EmployeeEntity.ManagerID = managerId;
                EmployeeEntity.ProjectID = projectId;



                bool updateStatus = EmployeeBLL.UpdateEmployeeBLL(EmployeeEntity);
                if (updateStatus == true)
                {

                    MessageBox.Show("Employee Updated Successfully");
                    dgEmployees.DataContext = EmployeeBLL.LoadGridBLL();
                }
                else
                {
                    MessageBox.Show("Something is wrong..check your details again..");
                }


            }
            catch (ALMSException exception)
            {
                MessageBox.Show("Something Went Wrong." + exception.Message);
            }

        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            int EmpId;
            EmpId = Convert.ToInt32(txtId.Text);

            EmployeeEntity.EmployeeID = EmpId;

            bool deleteEmployee = EmployeeBLL.DeleteEmployeeBLL(EmployeeEntity);

            if (deleteEmployee == true)
            {

                MessageBox.Show("Employee Deleted Successfully");
                dgEmployees.DataContext = EmployeeBLL.LoadGridBLL();
            }
            else
            {
                MessageBox.Show("Something is wrong..check your details again..");
            }
        }



        private void SearchEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeEntity searchedEmployeeEntity = null;

            try
            {
                int EmployeeID = int.Parse(txtId.Text);

                searchedEmployeeEntity = EmployeeBLL.SearchAttendanceBLL(EmployeeID);

                txtName.Text = searchedEmployeeEntity.EmployeeName;
                txtEmail.Text = searchedEmployeeEntity.EmployeeEmail;
                txtPhone.Text = searchedEmployeeEntity.EmployeePhoneNumber;
                empRole.Text = searchedEmployeeEntity.EmployeeRole;
                txtStatus.Text = searchedEmployeeEntity.EmployeeStatus;
                txtPassword.Text = searchedEmployeeEntity.EmployeePassword;
                txtMId.Text = searchedEmployeeEntity.ManagerID.ToString();
                txtPId.Text = searchedEmployeeEntity.ProjectID.ToString();
            }
            catch (ALMSException execption)
            {

                MessageBox.Show("Something Went Wrong." + execption.Message);
            }
        }
    }
}
