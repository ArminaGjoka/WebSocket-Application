using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerClient_Application
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        ClientWebSocket webSocket = null;

        private async void button1Second_Click(object sender, EventArgs e)
        {
            try
            {
                webSocket = new ClientWebSocket();
                Uri serverUri = new Uri("ws://localhost:5000/");
                await webSocket.ConnectAsync(serverUri, CancellationToken.None);
                MessageBox.Show("Form2 is Connected to the server");
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
                    string name = "Form2";
                    string formattedMessage = $"{name}: {message}{Environment.NewLine}{timestamp}";
                    ControlInvoke(richTextBox2Second, () => richTextBox2Second.AppendText($"{formattedMessage}{Environment.NewLine}"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receive Error: " + ex.Message);
            }
        }

        private async void button2Second_Click(object sender, EventArgs e)
        {
            try
            {
                if (webSocket?.State == WebSocketState.Open)
                {
                    string message = richTextBox3Second.Text;
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                    richTextBox3Second.Clear();
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            panel1 = new Panel();
            label2 = new Label();
            button2Second = new Button();
            richTextBox3Second = new RichTextBox();
            richTextBox2Second = new RichTextBox();
            label1 = new Label();
            richTextBox1Second = new RichTextBox();
            button1Second = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(615, 64);
            panel1.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courgette", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkBlue;
            label2.Location = new Point(313, 21);
            label2.Name = "label2";
            label2.Size = new Size(92, 28);
            label2.TabIndex = 0;
            label2.Text = "Armina";
            // 
            // button2Second
            // 
            button2Second.BackColor = Color.Transparent;
            button2Second.BackgroundImage = (Image)resources.GetObject("button2Second.BackgroundImage");
            button2Second.BackgroundImageLayout = ImageLayout.Stretch;
            button2Second.FlatStyle = FlatStyle.Popup;
            button2Second.Location = new Point(540, 434);
            button2Second.Name = "button2Second";
            button2Second.Size = new Size(65, 42);
            button2Second.TabIndex = 18;
            button2Second.UseVisualStyleBackColor = false;
            // 
            // richTextBox3Second
            // 
            richTextBox3Second.Location = new Point(152, 434);
            richTextBox3Second.Name = "richTextBox3Second";
            richTextBox3Second.Size = new Size(390, 42);
            richTextBox3Second.TabIndex = 17;
            richTextBox3Second.Text = "";
            // 
            // richTextBox2Second
            // 
            richTextBox2Second.Location = new Point(152, 159);
            richTextBox2Second.Name = "richTextBox2Second";
            richTextBox2Second.Size = new Size(390, 253);
            richTextBox2Second.TabIndex = 16;
            richTextBox2Second.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 100);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 15;
            label1.Text = "Remote IP";
            // 
            // richTextBox1Second
            // 
            richTextBox1Second.Location = new Point(152, 94);
            richTextBox1Second.Name = "richTextBox1Second";
            richTextBox1Second.Size = new Size(239, 31);
            richTextBox1Second.TabIndex = 14;
            richTextBox1Second.Text = "";
            // 
            // button1Second
            // 
            button1Second.Location = new Point(448, 91);
            button1Second.Name = "button1Second";
            button1Second.Size = new Size(94, 34);
            button1Second.TabIndex = 13;
            button1Second.Text = "Connect";
            button1Second.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(615, 516);
            Controls.Add(panel1);
            Controls.Add(button2Second);
            Controls.Add(richTextBox3Second);
            Controls.Add(richTextBox2Second);
            Controls.Add(label1);
            Controls.Add(richTextBox1Second);
            Controls.Add(button1Second);
            Name = "Form2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private Panel panel1;
        private Label label2;
        private Button button2Second;
        private RichTextBox richTextBox3Second;
        private RichTextBox richTextBox2Second;
        private Label label1;
        private RichTextBox richTextBox1Second;
        private Button button1Second;
    }
}
