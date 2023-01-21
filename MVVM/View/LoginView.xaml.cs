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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eCatalog.MVVM.View
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void AutentifBtn_Checked(object sender, RoutedEventArgs e)
        {
            var username = user.Text;
            var passwd = pass.Password.ToString();

            using (eCatalogEntities1 context = new eCatalogEntities1())
            {
                var student = context.Studentis.FirstOrDefault(u => u.Username == username);
                var profesor = context.Profesoris.FirstOrDefault(u => u.Username == username);

                if (student != null)
                {
                    if (student.Parola == passwd)
                    {
                        MainWindowStudent objStudent = new MainWindowStudent(username, passwd);
                        objStudent.ShowDialog();
                        user.Text = string.Empty; pass.Password = string.Empty;
                        AutentifBtn.IsChecked = false;
                    }
                    else
                    {
                        WarningLabel.Text = "Parola gresita!";
                        user.Text = string.Empty; pass.Password = string.Empty;
                    }
                }
                else if (profesor != null)
                {
                    if (profesor.Parola == passwd)
                    {
                        MainWindowProfesor objProfesor = new MainWindowProfesor(username, passwd);
                        objProfesor.ShowDialog();
                        //WindowAfterLoginProfesor objAfterLogin = new WindowAfterLoginProfesor(username, passwd);
                        //objAfterLogin.ShowDialog();
                        user.Text = string.Empty; pass.Password = string.Empty;
                        AutentifBtn.IsChecked = false;
                    }
                    else
                    {
                        WarningLabel.Text = "Parola gresita!";
                        user.Text = string.Empty; pass.Password = string.Empty;
                    }
                }
                else
                {
                    WarningLabel.Text = "Credentiale gresite!";
                    user.Text = string.Empty; pass.Password = string.Empty;
                }
            }
            AutentifBtn.IsChecked = false; 
        }

        private void user_GotFocus(object sender, RoutedEventArgs e)
        {
            WarningLabel.Text=string.Empty;
        }

        private void pass_GotFocus(object sender, RoutedEventArgs e)
        {
            WarningLabel.Text = string.Empty;
        }
    }
}
