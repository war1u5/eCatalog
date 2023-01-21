using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace eCatalog
{
    /// <summary>
    /// Interaction logic for MainWindowProfesor.xaml
    /// </summary>
    /// 

    public partial class MainWindowProfesor : Window
    {
        string pass;
        string user;
        private bool isSelectionChanged = false;

        public MainWindowProfesor(string username, string password)
        {
            InitializeComponent();
            this.pass = password;
            this.user = username;

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

            //-----------------------------------------------------------

            using (eCatalogEntities1 context = new eCatalogEntities1())
            {
                var profesor = context.Profesoris.FirstOrDefault(u => u.Username == username);
                if (profesor != null)
                {
                    this.NumeBlock.Text = $"Nume: {profesor.Nume.ToString()}";
                    this.PrenumeBlock.Text = $"Prenume: {profesor.Prenume.ToString()}";
                    this.UsernameBlock.Text = $"Username: {profesor.Username.ToString()}";
                }
            }
            VizStatsBorder.Visibility = Visibility.Hidden;
            MakeStatsBorder.Visibility = Visibility.Hidden;

            //------------------------------------------------------------
            using (eCatalogEntities1 context = new eCatalogEntities1())
            {
                var grupe = (from pm in context.ProfesoriMateriis
                             join p in context.Profesoris
                            on pm.IdProfesor equals p.IdProfesor
                             join gs in context.GrupeStudius
                            on pm.IdGrupa equals gs.IdGrupa
                             join m in context.Materiis
                            on pm.IdMaterie equals m.IdMaterie
                             where p.Username.Equals(user)
                             select gs.NumeGrupa);

                foreach (var grupa in grupe)
                {
                    GrupaComboBox.Items.Add(grupa);
                    GrupaComboBox1.Items.Add(grupa);
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

        private void ContBtn_Click(object sender, RoutedEventArgs e)
        {
            WelcomeText.Visibility = Visibility.Visible;
            DetaliiContBorder.Visibility = Visibility.Visible;
            DetaliiProfBorder.Visibility = Visibility.Visible;
            VizStatsBorder.Visibility = Visibility.Hidden;
            MakeStatsBorder.Visibility = Visibility.Hidden;
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
            else if (oldpsswd.Length == 0)
            {
                WarningLabel.Text = "Trebuie sa reconfirmati parola!";
                ChangePassBlock.Password = string.Empty;
                ConfirmPassBlock.Password = string.Empty;
                ConfirmBtn.IsChecked = false;
            }
            else if (psswd.Length < 6)
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
                        var profesor = context.Profesoris.FirstOrDefault(s => s.Username == user);

                        if (profesor != null)
                        {
                            profesor.Parola = psswd;
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

        private void VizStatsBtn_Click(object sender, RoutedEventArgs e)
        {
            WelcomeText.Visibility = Visibility.Hidden;
            DetaliiContBorder.Visibility = Visibility.Hidden;
            DetaliiProfBorder.Visibility = Visibility.Hidden;
            VizStatsBorder.Visibility = Visibility.Visible;
            MakeStatsBorder.Visibility = Visibility.Hidden;
        }

        private void GrupaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grupaStudiu = this.GrupaComboBox.SelectedItem.ToString();
           
            if (this.MaterieComboBox.Items.Count > 0)
            {
                isSelectionChanged= false;
                this.MaterieComboBox.SelectedItem = "";
                this.MaterieComboBox.Items.Clear();
            }

            isSelectionChanged = true;
            using (eCatalogEntities1 context = new eCatalogEntities1())
            {
                var materiiGrupa = (from pm in context.ProfesoriMateriis
                             join p in context.Profesoris
                            on pm.IdProfesor equals p.IdProfesor
                             join gs in context.GrupeStudius
                            on pm.IdGrupa equals gs.IdGrupa
                             join m in context.Materiis
                            on pm.IdMaterie equals m.IdMaterie
                             where p.Username.Equals(user)
                             where gs.NumeGrupa.Equals(grupaStudiu)
                             select m.NumeMaterie).ToList();



                //this.MaterieComboBox.ItemsSource = materiiGrupa;

                foreach (var materie in materiiGrupa)
                {
                    this.MaterieComboBox.Items.Add(materie);
                }
            }
        }

    
        private void MaterieComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }
            var grupaStudiu = GrupaComboBox.SelectedItem.ToString();


            var materieStudiu = this.MaterieComboBox.SelectedItem.ToString();

            //select s.Nume + ' ' + s.Prenume as NumeStudent, ns.Nota, m.NumeMaterie from NoteStudenti ns inner join Studenti s
            //on ns.IdStudent = s.IdStudent inner join Materii m
            //on ns.IdMaterie = m.IdMaterie inner join Profesori p
            //on ns.IdProfesor = p.IdProfesor
            //where p.Username = 'mihai.togan' and s.Grupa = 'C111A' and m.NumeMaterie = 'Programare'

            using (eCatalogEntities1 context = new eCatalogEntities1())
            {
                var studenti = (from ns in context.NoteStudentis
                            join s in context.Studentis on ns.IdStudent equals s.IdStudent
                            join m in context.Materiis on ns.IdMaterie equals m.IdMaterie
                            join p in context.Profesoris on ns.IdProfesor equals p.IdProfesor
                            where p.Username.Equals(user)
                            where s.Grupa.Equals(grupaStudiu)
                            where m.NumeMaterie.Equals(materieStudiu)
                            select new
                            {
                                s.Nume,
                                s.Prenume,
                                ns.Nota
                            }
                          );

                string nota_de_afisat = "";
                foreach (var nota in studenti)
                {
                    nota_de_afisat += nota.Nume + ' ' + nota.Prenume + ' ' + nota.Nota + '\n';
                }

                if (nota_de_afisat.Length == 0)
                {
                    nota_de_afisat = "Nu sunt note momentan!";
                }

                this.showNote.Text = nota_de_afisat;
            }
        }

        private void AcordBtn_Click(object sender, RoutedEventArgs e)
        {
            WelcomeText.Visibility = Visibility.Hidden;
            DetaliiContBorder.Visibility = Visibility.Hidden;
            DetaliiProfBorder.Visibility = Visibility.Hidden;
            VizStatsBorder.Visibility = Visibility.Hidden;
            MakeStatsBorder.Visibility = Visibility.Visible;
        }

        private void GrupaComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grupaStudiu = this.GrupaComboBox1.SelectedItem.ToString();

            this.MaterieComboBox1.Items.Clear();
            this.StudentComboBox1.Items.Clear();

            if (this.MaterieComboBox1.Items.Count > 0)
            {
                isSelectionChanged = false;
                this.MaterieComboBox1.SelectedItem = "";
                this.MaterieComboBox1.Items.Clear();
            }

            isSelectionChanged = true;
            using (eCatalogEntities1 context = new eCatalogEntities1())
            {
                var materiiGrupa = (from pm in context.ProfesoriMateriis
                                    join p in context.Profesoris
                                   on pm.IdProfesor equals p.IdProfesor
                                    join gs in context.GrupeStudius
                                   on pm.IdGrupa equals gs.IdGrupa
                                    join m in context.Materiis
                                   on pm.IdMaterie equals m.IdMaterie
                                    where p.Username.Equals(user)
                                    where gs.NumeGrupa.Equals(grupaStudiu)
                                    select m.NumeMaterie).ToList();



                //this.MaterieComboBox.ItemsSource = materiiGrupa;

                foreach (var materie in materiiGrupa)
                {
                    this.MaterieComboBox1.Items.Add(materie);
                }
            }
        }

        private void MaterieComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count == 0)
            {
                return;
            }
            var grupaStudiu = GrupaComboBox1.SelectedItem.ToString();
            var materieStudiu = this.MaterieComboBox1.SelectedItem.ToString();


            //select* from Studenti s inner join GrupeStudiu gs
            //on s.Grupa = gs.NumeGrupa
            //where gs.NumeGrupa = 'C113C'

            using (eCatalogEntities1 context = new eCatalogEntities1())
            {
                var studenti = (from s in context.Studentis
                                join gs in context.GrupeStudius
                                 on s.Grupa equals gs.NumeGrupa
                                where s.Grupa.Equals(grupaStudiu)
                                select new
                                {
                                    s.Nume,
                                    s.Prenume,

                                }
                              );

                foreach (var stud in studenti)
                {
                    var s = stud.Nume + ' ' + stud.Prenume;
                    this.StudentComboBox1.Items.Add(s);
                }
            }

        }

        private void SubmitBtn_Checked(object sender, RoutedEventArgs e)
        {
            var nota = NotaTextBox.Text;

            if(SubmitBtn.IsChecked == true && (this.GrupaComboBox1.Items.Count == 0 || this.MaterieComboBox1.Items.Count == 0 || this.StudentComboBox1.Items.Count ==0))
            {
                this.EroareNotaWarning.Text = "Eroare! Nu Ati completat toate campurile";
                SubmitBtn.IsChecked = false;
            }

            var grupa = this.GrupaComboBox1.Text;
            var materie = this.MaterieComboBox1.Text;
            var student = this.StudentComboBox1.Text;

            if(SubmitBtn.IsChecked == true && (nota=="" || grupa == null || materie == null || student == null)) 
            {
                this.EroareNotaWarning.Text = "Eroare la selectare!";
                SubmitBtn.IsChecked = false;    
            }

            float rezultat;

            if (float.TryParse(nota, out rezultat) == false)
            {
                this.EroareNotaWarning.Text = "Nu ati introdus o nota valida";
                SubmitBtn.IsChecked = false;
            }
            else
            {
                //insert nota in database;

                using (eCatalogEntities1 context = new eCatalogEntities1())
                {
                    var idMaterie = (from m in context.Materiis
                                     where m.NumeMaterie.Equals(materie)
                                     select m.IdMaterie).First();

                    string[] words = student.Split(' ');
                    var numeStud = words[0];
                    var prenumeStud = words[1];

                    var idStudent = (from s in context.Studentis
                                     where s.Nume.Equals(numeStud)
                                     where s.Prenume.Equals(prenumeStud)
                                     select s.IdStudent).First();

                    var idProfesor = (from p in context.Profesoris
                                      where p.Username.Equals(user)
                                      select p.IdProfesor).First();

                    var note = context.Set<NoteStudenti>();
                    note.Add(new NoteStudenti { IdMaterie = idMaterie, Nota = rezultat, IdStudent = idStudent, IdProfesor = idProfesor });

                    context.SaveChanges();
                    EroareNotaWarning.Foreground = Brushes.LightGreen;
                    this.EroareNotaWarning.Text = "Nota introdusa cu succes";
                    EroareNotaWarning.Foreground = Brushes.Red;

                    SubmitBtn.IsChecked = false;


                }
            }
        }

        private void StudentComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var student = this.StudentComboBox1.SelectedItem;
        }
    }
}
