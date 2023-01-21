using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace eCatalog
{
    /// <summary>
    /// Interaction logic for MainWindowStudent.xaml
    /// </summary>
    public partial class MainWindowStudent : Window
    {
        string pass;
        string user;
        public MainWindowStudent(string username, string password)
        {
            InitializeComponent();
            
            //MateriiComboBox.Items.Add(username);
            this.pass = password;
            this.user = username;
            VizNoteBorder.Visibility = Visibility.Hidden;



//SELECT m.NumeMaterie from Studenti s inner join GrupeStudiu gs
//on s.Grupa = gs.NumeGrupa inner join Materii m
//on gs.An = m.An
//where s.Nume = 'Prelipcean' and s.Prenume = 'Marius'


            using (eCatalogEntities1 context = new eCatalogEntities1())
            {
                var materii = (from s in context.Studentis
                               join gs in context.GrupeStudius on s.Grupa equals gs.NumeGrupa
                               join m in context.Materiis on gs.An equals m.An
                               where s.Username.Equals(username) 
                               select m.NumeMaterie);   
                
            
                foreach(var materie in materii)
                {
                    MateriiComboBox.Items.Add(materie);
                }
            
            }

            string[] words = username.Split('.');

            DateTime t1 = DateTime.Now;
            DateTime t2 = Convert.ToDateTime("12:00:00 PM");
            int i = DateTime.Compare(t1, t2);

            var prenume = words[0];
            var nume = words[1];

            if (i < 0)
            {
                this.WelcomeText.Text = $"Buna dimineata, ";
            }
            else
            {
                this.WelcomeText.Text = $"Buna ziua, ";
            }

            this.WelcomeText.Text += prenume.ToUpper()[0];

            for (int k = 1; k < prenume.Length; k++)
            {
                this.WelcomeText.Text += prenume[k];
            }

            this.WelcomeText.Text += ' ';
            this.WelcomeText.Text += nume.ToUpper()[0];

            for (int k = 1; k < nume.Length; k++)
            {
                this.WelcomeText.Text += nume[k];
            }

            this.WelcomeText.Text += '!';

            //-----------------------------------------------


            using (eCatalogEntities1 context = new eCatalogEntities1())
            {
                var student = context.Studentis.FirstOrDefault(u => u.Username == username);
                if(student != null)
                {
                    this.GrupaBlock.Text = $"Grupa: {student.Grupa.ToString()}";
                    this.NumeBlock.Text = $"Nume: {student.Nume.ToString()}";
                    this.PrenumeBlock.Text = $"Prenume: {student.Prenume.ToString()}";
                    this.UsernameBlock.Text = $"Username: {student.Username.ToString()}";
                }
            }

        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DeconectareBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NoteBtn_Click(object sender, RoutedEventArgs e)
        {
            WelcomeText.Visibility = Visibility.Hidden;
            DetaliiContBorder.Visibility = Visibility.Hidden;
            DetaliiStudBorder.Visibility = Visibility.Hidden;
            VizNoteBorder.Visibility = Visibility.Visible;
        }

        private void ContBtn_Click(object sender, RoutedEventArgs e)
        {
            WelcomeText.Visibility = Visibility.Visible;
            DetaliiContBorder.Visibility = Visibility.Visible;
            DetaliiStudBorder.Visibility = Visibility.Visible;
            VizNoteBorder.Visibility = Visibility.Hidden;
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            WarningLabel.Foreground = Brushes.Red;
            var psswd = ChangePassBlock.Password.ToString();
            var oldpsswd = ConfirmPassBlock.Password.ToString();
            if (oldpsswd.Length == 0 && psswd.Length == 0)
            {
                WarningLabel.Text = "Toate campurile trebuie completate!";
                ChangePassBlock.Password = string.Empty;
                ConfirmPassBlock.Password = string.Empty;
                ConfirmBtn.IsChecked = false;
            }
            else if (oldpsswd.Length== 0)
            {
                WarningLabel.Text = "Trebuie sa reconfirmati parola!";
                ChangePassBlock.Password = string.Empty;
                ConfirmPassBlock.Password = string.Empty;
                ConfirmBtn.IsChecked = false;
            }
            else if(psswd.Length<6)
            {
                WarningLabel.Text = "Parola trebuie sa aiba mai mult de 6 caractere!";
                ChangePassBlock.Password = string.Empty;
                ConfirmPassBlock.Password = string.Empty;
                ConfirmBtn.IsChecked = false;
            }
            else
            {
                if (psswd != oldpsswd)
                {
                    WarningLabel.Text = "Parolele nu sunt la fel!";
                    ChangePassBlock.Password = string.Empty;
                    ConfirmPassBlock.Password = string.Empty;
                    ConfirmBtn.IsChecked = false;
                }
                else
                {
                    using (eCatalogEntities1 context = new eCatalogEntities1())
                    {
                        var student = context.Studentis.FirstOrDefault(s => s.Username == user);

                        if(student != null)
                        {
                            student.Parola = psswd;
                            context.SaveChanges();
                        }
                            
                    }

                    WarningLabel.Foreground = Brushes.LightGreen;
                    WarningLabel.Text = "Parola a fost schimbata cu succes!";
                    ChangePassBlock.Password = string.Empty;
                    ConfirmPassBlock.Password = string.Empty;
                    ConfirmBtn.IsChecked = false;
                }
            }
        }

        private void MateriiComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var materie = this.MateriiComboBox.SelectedItem.ToString();
            //string gol = "";
            //this.VizNotaBlock.Text = nice;

            //select Nota from NoteStudenti ns inner join Studenti s
            //
            //on ns.IdStudent = s.IdStudent 
            //
            //inner join Materii m on ns.IdMaterie = m.IdMaterie
            //where m.NumeMaterie = 'PSO' and s.Username = 'marius.prelipcean'
            //if (this.VizNotaBlock.Text == gol)
            //{
            //    string no_note = "Nu sunt note momentan!";
            //    this.VizNotaBlock.Text = no_note;
            //}
            //else
            //{

            //  select Nota from NoteStudenti ns inner
            //               join Studenti s
            //  on ns.IdStudent = s.IdStudent inner
            //                join Materii m
            //  on ns.IdMaterie = m.IdMaterie
            //  where m.NumeMaterie = 'PSO' and s.Username = 'marius.prelipcean'

                using (eCatalogEntities1 context = new eCatalogEntities1())
                {
                    var note = (from n in context.NoteStudentis
                                join s in context.Studentis on n.IdStudent equals s.IdStudent
                                join m in context.Materiis on n.IdMaterie equals m.IdMaterie
                                where s.Username.Equals(user)
                                where m.NumeMaterie.Equals(materie)
                                select n.Nota);

                    string nota_de_afisat = "";
                    foreach (var nota in note)
                    {
                        nota_de_afisat += nota.ToString() + ' ' + materie +'\n';
                    }

                    if(nota_de_afisat.Length == 0)
                    {
                        nota_de_afisat = "Nu sunt note momentan!";
                    }

                    this.VizNotaBlock.Text = nota_de_afisat;

                }
        }
    }
}
