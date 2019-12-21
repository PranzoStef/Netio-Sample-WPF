using Netio_Sample_WPF.XML;
using System;
using System.Windows;

namespace Netio_Sample_WPF
{
    /// <summary>
    /// Interaction logic for wdSettings.xaml
    /// </summary>
    public partial class wdSettings : Window
    {
        public wdSettings()
        {
            InitializeComponent();
        }


        /// <summary>
        /// NSettings
        /// </summary>
        public const string FLD_NSettings = "NSettings";

        /// <summary>
        /// NSettings
        /// </summary>
        private NetioSettings mNSettings;

        /// <summary>
        /// NSettings
        /// </summary>
        public NetioSettings NSettings
        {
            get
            {
                return mNSettings;
            }
            set
            {
                mNSettings = value;
            }
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                NSettings = new NetioSettings();
                //Netio _Netio1 = new Netio();
                //_Netio1 = Netio.ReadXml(myXml1);
                if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "NSettings.xml"))
                {
                    NSettings = NetioSettings.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "NSettings.xml", false);
                    txtAddressNetio1.Text = NSettings.AddressNetio1;
                    txtUserNameNetio1.Text = NSettings.UserNameNetio1;
                    txtPasswordNetio1.Text = NSettings.PasswordNetio1;
                    txtAddressNetio2.Text = NSettings.AddressNetio2;
                    txtUserNameNetio2.Text = NSettings.UserNameNetio2;
                    txtPasswordNetio2.Text = NSettings.PasswordNetio2;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NSettings = new NetioSettings();
            
            //NSettings = NetioSettings.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "NSettings.xml");
            NSettings.AddressNetio1 = txtAddressNetio1.Text;
            NSettings.UserNameNetio1 = txtUserNameNetio1.Text;
            NSettings.PasswordNetio1 = txtPasswordNetio1.Text;
            NSettings.AddressNetio2 = txtAddressNetio2.Text;
            NSettings.UserNameNetio2 = txtUserNameNetio2.Text;
            NSettings.PasswordNetio2 = txtPasswordNetio2.Text;
            NSettings.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "NSettings.xml");

            this.Close();

        }
    }
}
