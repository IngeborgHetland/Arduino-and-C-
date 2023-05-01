using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace DeepoceanLARS
{
    internal class SERVER
    {
        //public bool sende = false;

        public event MessageEventHandler Message;
      //  public event MessageEventHandler Message2;
        public delegate void MessageEventHandler(SERVER sender, string data);

     


        //server control 
        // public IPAddress ROVIP = IPAddress.Parse("192.168.100.101");
        //public int ROVPort = 80;
        public IPAddress serverIP = IPAddress.Parse("192.168.100.103");
        public int serverPort = 80;
       // IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("192.168.100.102"), 80);

        //Socket klientSokkel = new Socket(AddressFamily.InterNetwork,
       // SocketType.Stream,
       // ProtocolType.Tcp);

        public TcpListener lytter;

        public Thread thread;
        
        public bool IsListening = true;

        public Thread SendDataTraad;
      //  NetworkStream networkStream;
        
        //Client 

        public TcpClient Client = new TcpClient();
        public StreamReader clientdata;
      



        // Send data to the Arduino

        

 
      
       
       // public StreamReader clientdata;

        public SERVER()
        { 
            try
            {
                lytter= new TcpListener(serverIP, serverPort);
                lytter.Start();
                thread = new Thread(new ThreadStart(Hearing));
                thread.Start();


            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }

            /*try
            {
                //Tråd for å sende data fra c# til Arduino
                SendDataTraad = new Thread(new ThreadStart(SendData));
                SendDataTraad.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        private void Hearing()

        {
            while (IsListening)
            {
                if (lytter.Pending() == true)
                {
                    Client = lytter.AcceptTcpClient();
                    clientdata = new StreamReader(Client.GetStream());//få inn data
                    string klientdata = clientdata.ReadLine();
                    NetworkStream stream = Client.GetStream();
                   // int num = 12;
                   // byte f = Convert.ToByte(num);
                  
                       byte[] data = System.Text.Encoding.ASCII.GetBytes("x");
                       // byte[] data= new byte[f];

                    stream.Write(data, 0, data.Length);
                   
                    stream.Write(data);
                    
                    

                   // IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("192.168.100.102"), 80);
                    try
                    {
                        //klientSokkel.Connect(serverEP); // blokkerende metode
                    }
                    catch (SocketException e)
                    {
                    }
                    //char input = 'x';
                    //klientSokkel.Send(Encoding.ASCII.GetBytes(input.ToString()));

                    try
                    {

                        Message?.Invoke(this, klientdata);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Thread.Sleep(10);


                }
            }

                

            

        }

        /*public void SendData(bool o)
        {
         
            //Sende data fra c# til arduino 
            StreamWriter clientStreamWriter;
            clientStreamWriter = new StreamWriter(Client.GetStream());
            

            string klientdata = clientStreamWriter.Write();
            try
            {

                Message?.Invoke(this, klientdata);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Thread.Sleep(10);
        }

        */

        /*public string SeperateCLients(List<string> data, TcpClient client)
        {
            client = new TcpClient();
            int n = 3;
            while(n-->0)
            {
                client = client.AcceptTcpClient();
                clientdata = new StreamReader(client.GetStream());
            }

            List<string> datalist = new List<string>();
            string[] datastring = data.Split(new char[] { ',', ' ' });
            
        }
        */

    }
}
