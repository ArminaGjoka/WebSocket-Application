using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerClient_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ClientWebSocket webSocket = null;

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                webSocket = new ClientWebSocket();
                Uri serverUri = new Uri("ws://localhost:5000/");
                await webSocket.ConnectAsync(serverUri, CancellationToken.None);
                MessageBox.Show("Form1 is Connected to the server");
                _ = ReceiveMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task ReceiveMessages()
        {
            try
            {
                byte[] buffer = new byte[1024 * 4];
                while (webSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string name = "Form1";
                    string formattedMessage = $"{name}: {message}{Environment.NewLine}{timestamp}";
                    ControlInvoke(richTextBox2, () => richTextBox2.AppendText($"{formattedMessage}{Environment.NewLine}"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receive Error: " + ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (webSocket?.State == WebSocketState.Open)
                {
                    string message = richTextBox3.Text;
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                    richTextBox3.Clear();
                }
                else
                {
                    MessageBox.Show("WebSocket is not connected.");
                }
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
