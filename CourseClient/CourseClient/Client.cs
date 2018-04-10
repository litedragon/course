using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CourseClient
{
    abstract class Client
    {
        private IPAddress Address = IPAddress.Parse("95.165.128.204");
        private int Port = 50123;
        private TcpClient c;
        private StreamReader cin;
        private StreamWriter cout;

        public Client()
        {
            c = new TcpClient();
        }

        public void ClientDis()
        {   
                cout.WriteLine("sdis");
                Thread.Sleep(20);
                cout.Flush();
                cin.Close();
                cout.Close();
                c.Close();
        }

        public void connect()
        {
            c.Connect(Address, Port);
            cin = new StreamReader(c.GetStream());
            cout = new StreamWriter(c.GetStream());
            Thread readth = new Thread(Readmsg);
            readth.Start();
        }
        public void Send(string msg)
        {
            cout.WriteLine("m"+msg);
            cout.Flush();
        }

        public async void Readmsg()
        {
            while(true)
            {
                try
                {
                    string answer = await cin.ReadLineAsync();
                    if (answer != null)
                    {
                        if ('m' == answer[0])
                        {
                            answer = answer.TrimStart(new char[] { 'm' });
                            reply(answer);
                        }
                    }
                }
                catch (Exception e) {
                    return;
                }
            }
        }

        public abstract void reply(string msg);
    }

}
