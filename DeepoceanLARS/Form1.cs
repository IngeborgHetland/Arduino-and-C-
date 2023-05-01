
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepoceanLARS
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }

        SERVER server = new SERVER();

        private void Form1_Load(object sender, EventArgs e)
        {
            string StringHost;
            IPAddress StrIP;

            try
            {
                StringHost = System.Net.Dns.GetHostName();
                StrIP = Dns.GetHostByName(StringHost).AddressList[1];//check if it is correct 
                label1.Text = "Host Name:  " + StringHost;
                label2.Text = "IP address: " + StrIP.ToString();
            }

            catch (Exception ex)
            {


            }


            try
            {
                richTextBox1.AppendText("------------Arduino program is running---------");

            }
            catch
            {

            }

            server.Message += recInfo;






        }
        private delegate void updateTXTbox(RichTextBox box1, string text);

        private void updatetxt(RichTextBox box1, string text)
        {
            if (InvokeRequired)
                box1.Invoke(new updateTXTbox(updatetxt), new object[] { box1, text });
            else if (box1 != null)
                box1.AppendText(text + "\n");

            string[] sensordata = text.Split(new char[] { '*', ',', 'x', 'x', 'x', ';' });
            List<string> sensorlist = new List<string>();

            try
            {
                foreach (string s in sensordata)
                {
                    if (s.Length != 0)
                    {
                        sensorlist.Add(s);
                        txtCROV.BackColor = Color.Green;
                    }
                }



                txtaccX.Text = sensorlist[1];
                txtaccY.Text = sensorlist[2];
                txtaccZ.Text = sensorlist[3];
                // txtRange.Text = sensorlist[4];
            }
            catch (Exception e)
            {

            }


            string[] sensordata2 = text.Split(new char[] { '#', '%', ':', ':', ':', '!' });
            List<string> sensorlist2 = new List<string>();
            try
            {
                foreach (string s in sensordata2)
                {
                    if (s.Length != 0)
                    {
                        txtCUSV.BackColor = Color.Green;
                        sensorlist2.Add(s);
                    }
                }



                txtaccUSVx.Text = sensorlist2[1];
                txtaccUSVy.Text = sensorlist2[2];
                txtaccUSVz.Text = sensorlist2[3];
                txtRange.Text = sensorlist2[4];
            }
            catch (Exception e)
            {

            }
            /*
                        if (sensorlist[1] && sensorlist2[1] == 3)
                        {


                        }*/

            /*
                        try
                        {
                            foreach (string str in sensordataUSV)
                            {
                                if (str.Length != 0)
                                {
                                    sensorlistUSV.Add(str);
                                }
                            }


                            txtaccUSVx.Text = sensorlistUSV[0];
                            txtaccUSVy.Text = sensorlistUSV[1];
                            txtaccUSVz.Text = sensorlistUSV[2];
                        }
                        catch (Exception e)
                        {

                        }*/





        }

        private void recInfo(SERVER sender, string data)
        {
            updatetxt(richTextBox1, data);

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.IsListening = false;

        }

        private void txtaccX_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaccY_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaccZ_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
          
          //  bool winch = false;
          //  server.SendData(true);

        }
    }
}


