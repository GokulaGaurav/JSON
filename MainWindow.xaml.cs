using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
namespace registrationcombobox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<user_record> list = new List<user_record>();
        public MainWindow()
        {
            InitializeComponent();
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fullpath = Path.Combine(path, "user.txt");
            if (File.Exists(fullpath))
            {
                string jsondata = File.ReadAllText(fullpath);
                list = JsonConvert.DeserializeObject<List<user_record>>(jsondata);
            }
            if (list != null && list.Count>0)
            {
                cmbnames.DisplayMemberPath = "name";
                cmbnames.ItemsSource= list;
                lstname.ItemsSource = list;
                cmbnames.ItemsSource = null;
                lstname.ItemsSource = null;
                cmbnames.DisplayMemberPath = "name";
                cmbnames.ItemsSource = list;
                lstname.ItemsSource = list;
            }
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            List<user_record> list= new List<user_record>();
            user_record record= new user_record();
            record.name=txtname.Text;
            record.email=txtemail.Text;
            record.phone=txtphn.Text;
            record.email=txtloc.Text;
            list.Add(record);
            string listjson= JsonConvert.SerializeObject(list);
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fullpath = Path.Combine(path, "user.txt");
            File.WriteAllText(fullpath, listjson);
            cmbnames.ItemsSource = null;
            lstname.ItemsSource = null;
            cmbnames.DisplayMemberPath = "name";
            cmbnames.ItemsSource = list;
            lstname.ItemsSource=list;
        }

        private void cmbnames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user_record value =cmbnames.SelectedItem as user_record;
            if (value != null)
            {
                txtname.Text= value.name;
                txtphn.Text = value.phone;
                txtemail.Text = value.email;
                txtloc.Text = value.location;
            }
        }
    }
}