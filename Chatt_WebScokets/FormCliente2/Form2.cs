using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ServerClient_Application
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        UdpClient udpClient;
        IPEndPoint remoteIp;
        int remotePort = 44444;
        int port = 55555;

        private void button1Second_Click(object sender, EventArgs e)
        {
            try
            {
                udpClient = new UdpClient(port);
                remoteIp = new IPEndPoint(IPAddress.Parse(richTextBox1Second.Text), remotePort);
                udpClient.BeginReceive(new AsyncCallback(OnReceive), udpClient);
                MessageBox.Show("Armina is Connected to " + richTextBox1Second.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                byte[] buff = udpClient.EndReceive(ar, ref remoteIp);
                udpClient.BeginReceive(new AsyncCallback(OnReceive), udpClient);
                string message = Encoding.ASCII.GetString(buff);
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string name = "Alessandra";
                string formattedMessage = $"{name}: {message}{Environment.NewLine}{timestamp}";
                ControlInvoke(richTextBox2Second, () => richTextBox2Second.AppendText($"{formattedMessage}{Environment.NewLine}"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receive Error: " + ex.Message);
            }
        }

        private void button2Second_Click(object sender, EventArgs e)
        {
            try
            {
                udpClient.Connect(remoteIp);
                udpClient.Send(Encoding.ASCII.GetBytes(richTextBox3Second.Text), richTextBox3Second.Text.Length);
                richTextBox3Second.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Error: " + ex.Message);
            }
        }

        delegate void UniversalVoidDelegate();
        public static void ControlInvoke(Control control, Action function)
        {
            if (control.IsDisposed || control.Disposing)
                return;
            if (control.InvokeRequired)
            {
                control.Invoke(new UniversalVoidDelegate(() => ControlInvoke(control, function)));
                return;
            }
            function();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
