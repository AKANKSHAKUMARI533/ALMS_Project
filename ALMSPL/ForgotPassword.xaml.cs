using ALMSBLL;
using ALMSEntity;
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
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
       
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void Forgot(object sender, RoutedEventArgs e)
        {
            ForgotPasswordEntity forgotPasswordEntity = new ForgotPasswordEntity();
            ForgotPasswordBLL ForgotPasswordBLL = new ForgotPasswordBLL();

            string employeeEmail = txtEmail.Text;
            int employeeId = int.Parse(txtId.Text);


            forgotPasswordEntity.EmployeeEmail = employeeEmail;
            forgotPasswordEntity.EmployeeID = employeeId;

            string requestReset = null;
            requestReset = ForgotPasswordBLL.ForgotBLL(forgotPasswordEntity);

            if (requestReset!=null)
            {

                MessageBox.Show("Your password is"+requestReset);
                
            }
            else
            {
                MessageBox.Show("Something is wrong..check your details again..");
            }


        }
    }
}
