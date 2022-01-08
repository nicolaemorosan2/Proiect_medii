using Clase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

namespace Proiect_Medii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
     enum ActionState
     {
        New,
        Edit,
        Delete,
        Nothing
     }

    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        Clase_entities_model ctx = new Clase_entities_model();
        CollectionViewSource clientsViewSource;
        CollectionViewSource adminsViewSource;
        CollectionViewSource courtsViewSource;
        CollectionViewSource clientsAppointmentsViewSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            clientsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientsViewSource")));
            clientsViewSource.Source = ctx.Clients.Local;
            ctx.Clients.Load();

            adminsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("adminsViewSource")));
            adminsViewSource.Source = ctx.Admins.Local;
            ctx.Admins.Load();

            courtsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("courtsViewSource")));
            courtsViewSource.Source = ctx.Courts.Local;
            ctx.Courts.Load();

            clientsAppointmentsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientsAppointmentsViewSource")));
            //clientsAppointmentsViewSource.Source = ctx.Appointments.Local;
            BindDataGrid();

            ctx.Appointments.Load();
            ctx.Clients.Load();
            ctx.Admins.Load();
            ctx.Courts.Load();

            cmbAdmins.ItemsSource = ctx.Admins.Local;
            cmbAdmins.DisplayMemberPath = "Prenume";
            cmbAdmins.SelectedValuePath = "Id_Admins";

            cmbClients.ItemsSource = ctx.Clients.Local;
            //cmbClients.DisplayMemberPath = "Prenume";
            cmbClients.SelectedValuePath = "Id_Clients";

            cmbCourts.ItemsSource = ctx.Courts.Local;
            //cmbCourts.DisplayMemberPath = "Nume";
            cmbCourts.SelectedValuePath = "Id_Courts";
        }

        private void btnPrevAd_Click(object sender, RoutedEventArgs e)
        {
            clientsViewSource.View.MoveCurrentToPrevious();
        }

        private void btnNextAd_Click(object sender, RoutedEventArgs e)
        {
            clientsViewSource.View.MoveCurrentToNext();
        }

        private void btnPrevCl_Click(object sender, RoutedEventArgs e)
        {
            clientsViewSource.View.MoveCurrentToPrevious();
        }

        private void btnNextCl_Click(object sender, RoutedEventArgs e)
        {
            clientsViewSource.View.MoveCurrentToNext();
        }

        private void btnPrevCourts_Click(object sender, RoutedEventArgs e)
        {
            clientsViewSource.View.MoveCurrentToPrevious();
        }

        private void btnNextCourts_Click(object sender, RoutedEventArgs e)
        {
            clientsViewSource.View.MoveCurrentToNext();
        }
        private void SaveClients()
        {
            Clients clients = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem clienti entity
                    clients = new Clients()
                    {
                        Prenume = prenumeTextBox1.Text.Trim(),
                        Nume = numeTextBox1.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Clients.Add(clients);
                    clientsViewSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    clients = (Clients)clientsDataGrid.SelectedItem;
                    clients.Prenume = prenumeTextBox1.Text.Trim();
                    clients.Nume = numeTextBox1.Text.Trim();
                    clients.Telefon = telefonTextBox1.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    clients = (Clients)clientsDataGrid.SelectedItem;
                    ctx.Clients.Remove(clients);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clientsViewSource.View.Refresh();
            }

        }
        private void SaveAdmins()
        {
            Admins admins = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem clienti entity
                    admins = new Admins()
                    {
                        Prenume = prenumeTextBox.Text.Trim(),
                        Nume = numeTextBox.Text.Trim(),
                        Telefon = telefonTextBox.Text.Trim(),
                        E_mail = e_mailTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Admins.Add(admins);
                    adminsViewSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    admins = (Admins)adminsDataGrid.SelectedItem;
                    admins.Prenume = prenumeTextBox.Text.Trim();
                    admins.Nume = numeTextBox.Text.Trim();
                    admins.Telefon = telefonTextBox.Text.Trim();
                    admins.E_mail = e_mailTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    admins = (Admins)adminsDataGrid.SelectedItem;
                    ctx.Admins.Remove(admins);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                adminsViewSource.View.Refresh();
            }

        }
        private void SaveCourts()
        {
            Courts courts = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem clienti entity
                    courts = new Courts()
                    {
                        Nume_Courts = numeTextBox1.Text.Trim(),
                        Adresa = adresaTextBox.Text.Trim(),
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Courts.Add(courts);
                    courtsViewSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    courts = (Courts)courtsDataGrid.SelectedItem;
                    courts.Nume_Courts = numeTextBox1.Text.Trim();
                    courts.Adresa = adresaTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    courts = (Courts)courtsDataGrid.SelectedItem;
                    ctx.Courts.Remove(courts);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                courtsViewSource.View.Refresh();
            }

        }

        private void SaveAppointments()
        {
            Appointments appointments = null;
            if (action == ActionState.New)
            {
                try
                {
                    Clients clients = (Clients)cmbClients.SelectedItem;
                    Courts courts = (Courts)cmbCourts.SelectedItem;
                    //instantiem Order entity
                    appointments = new Appointments()
                    {
                        Id_Clients = clients.Id_Clients,
                        Id_Courts = courts.Id_Courts,
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Appointments.Add(appointments);
                    //salvam modificarile
                    ctx.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Edit)
            {
                dynamic selectedAppointments = appointmentsDataGrid.SelectedItem;
                try
                {
                    int curr_id = selectedAppointments.Id_Appointments;
                    var editedAppointments = ctx.Appointments.FirstOrDefault(s => s.Id_Appointments == curr_id);
                    if (editedAppointments != null)
                    {
                        editedAppointments.Id_Clients = Int32.Parse(cmbClients.SelectedValue.ToString());
                        editedAppointments.Id_Courts = Convert.ToInt32(cmbCourts.SelectedValue.ToString());
                        //salvam modificarile
                        ctx.SaveChanges();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                BindDataGrid();
                // pozitionarea pe item-ul curent
                clientsAppointmentsViewSource.View.MoveCurrentTo(selectedAppointments);
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    dynamic selectedAppointments = appointmentsDataGrid.SelectedItem;
                    int curr_id = selectedAppointments.Id_Appointments;
                    var deletedAppointments = ctx.Appointments.FirstOrDefault(s => s.Id_Appointments == curr_id);
                    if (deletedAppointments != null)
                    {
                        ctx.Appointments.Remove(deletedAppointments);
                        ctx.SaveChanges();
                        MessageBox.Show("Order Deleted Successfully", "Message");
                        BindDataGrid();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }
        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            SetValidationBinding();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
            BindingOperations.ClearBinding(prenumeTextBox1, TextBox.TextProperty);
            BindingOperations.ClearBinding(numeTextBox1, TextBox.TextProperty);
            SetValidationBinding();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrl_Inchiriere_terenuri.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Clients":
                    SaveClients();
                    break;
                case "Admins":
                    SaveAdmins();
                    break;
                case "Courts":
                    SaveCourts();
                    break;
                case "Appointments":
                    break;
            }
            ReInitialize();
        }
        private void BindDataGrid()
        {
            var queryAppointments = from app in ctx.Appointments
                             join cl in ctx.Clients on app.Id_Clients equals cl.Id_Clients
                             join crts in ctx.Courts on app.Id_Courts equals crts.Id_Courts
                             select new
                             {
                                 app.Id_Appointments,
                                 app.Id_Courts,
                                 app.Id_Clients,
                                 cl.Prenume,
                                 cl.Nume,
                                 crts.Nume_Courts,
                                 crts.Adresa
                             };
            clientsAppointmentsViewSource.Source = queryAppointments.ToList();
        }
        private void SetValidationBinding()
        {
            Binding firstNameValidationBinding = new Binding();
            firstNameValidationBinding.Source = clientsViewSource;
            firstNameValidationBinding.Path = new PropertyPath("FirstName");
            firstNameValidationBinding.NotifyOnValidationError = true;
            firstNameValidationBinding.Mode = BindingMode.TwoWay;
            firstNameValidationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //string required
            firstNameValidationBinding.ValidationRules.Add(new StringNotEmpty());
            prenumeTextBox1.SetBinding(TextBox.TextProperty, firstNameValidationBinding);
            Binding lastNameValidationBinding = new Binding();
            lastNameValidationBinding.Source = clientsViewSource;
            lastNameValidationBinding.Path = new PropertyPath("LastName");
            lastNameValidationBinding.NotifyOnValidationError = true;
            lastNameValidationBinding.Mode = BindingMode.TwoWay;
            lastNameValidationBinding.UpdateSourceTrigger =
           UpdateSourceTrigger.PropertyChanged;
            //string min length validator
            lastNameValidationBinding.ValidationRules.Add(new StringMinLengthValidator());
            numeTextBox1.SetBinding(TextBox.TextProperty, lastNameValidationBinding); //setare binding nou
        }
    }
}
