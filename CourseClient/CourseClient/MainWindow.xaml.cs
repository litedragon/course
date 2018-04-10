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

namespace CourseClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyClient cl;
        CommandBinding binding1;
        CommandBinding binding2;
        Boolean CanCD = true;
        Boolean CanSend = false;
        public MainWindow()
        {
            InitializeComponent();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyExceptionHandler);

            binding1 = new CommandBinding(ApplicationCommands.New);
            binding1.Executed += new ExecutedRoutedEventHandler(ConnectCommand);
            binding1.CanExecute += new CanExecuteRoutedEventHandler(CanConnectDis);
            this.CommandBindings.Add(binding1);

            binding2 = new CommandBinding(ApplicationCommands.Open);
            binding2.Executed += new ExecutedRoutedEventHandler(SendCommand);
            binding2.CanExecute += new CanExecuteRoutedEventHandler(CanSendB);
            this.CommandBindings.Add(binding2);
        }

        static void MyExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            MessageBox.Show(e.Message);
        }

        public void appendMsg(string data)
        {
            chat.AppendText(data);
        }

        class MyClient : Client
        {
            public MyClient(MainWindow context)
            {
                this.context = context;
            }
            MainWindow context;

            delegate void AppendDeligate(string msg);

            public override void reply(string msg)
            {
                if (!context.chat.Dispatcher.CheckAccess())
                {
                    AppendDeligate ad = new AppendDeligate(reply);
                    context.Dispatcher.Invoke(ad, new object[] { msg });
                }
                else
                {
                    context.chat.AppendText(msg + '\n');
                }
            }
        }

        private void SendCommand(object sender, RoutedEventArgs e)
        {
            try
            {
                string msg = Msgbox.Text;
                cl.Send(msg);
            }
            catch
            {
                cl.reply("Failed to send a message, please try connecting again");
            }
        }

        void CanConnectDis(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanCD;
            
        }

        void CanSendB(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanSend;

        }

        void ConnectCommand(object sender, RoutedEventArgs e)
        {
            cl = new MyClient(this);
            try
            {
                CanCD = false;
                cl.connect();
                cl.reply("Connected");
                binding1.Executed += new ExecutedRoutedEventHandler(DisCommand);
                Connect_btn.Content = "Disconect";
                CanSend = true;
            }
            catch
            {
                cl.reply("Connection failed");
                Connect_btn.IsEnabled = true;
                return;
            }
        }

        void DisCommand(object sender, RoutedEventArgs e)
        { 
      
                try
                {
                    CanCD = false;
                    Connect_btn.IsEnabled = false;
                    cl.ClientDis();
                    cl.reply("Disconnected");
                    Connect_btn.Content = "Connect";
                    binding1.Executed += new ExecutedRoutedEventHandler(ConnectCommand);
                    Connect_btn.IsEnabled = true;
                    CanCD = true;
                    CanSend = false;
                    cl = null;
                }
                catch
                {
                    cl.reply("You are already disconnected");
                    Connect_btn.Content = "Connect";
                    Connect_btn.IsEnabled = true;
                    CanSend = false;
                    CanCD = true;
                    cl = null;
                    return;
                }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((string)Connect_btn.Content == "Disconect")
            {
                try
                {
                    cl.ClientDis();
                }
                catch { }
                

            }
            MainWindow1.Close();
        }
    }

}
//context.chat.Dispatcher.CheckAccess()