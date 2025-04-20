namespace ServerClient_Application
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            button2Second = new Button();
            richTextBox3Second = new RichTextBox();
            richTextBox2Second = new RichTextBox();
            label1 = new Label();
            richTextBox1Second = new RichTextBox();
            button1Second = new Button();
            panel1 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button2Second
            // 
            button2Second.BackColor = Color.Transparent;
            button2Second.BackgroundImage = (Image)resources.GetObject("button2Second.BackgroundImage");
            button2Second.BackgroundImageLayout = ImageLayout.Stretch;
            button2Second.FlatStyle = FlatStyle.Popup;
            button2Second.Location = new Point(548, 499);
            button2Second.Name = "button2Second";
            button2Second.Size = new Size(65, 42);
            button2Second.TabIndex = 11;
            button2Second.UseVisualStyleBackColor = false;
            button2Second.Click += button2Second_Click;
            // 
            // richTextBox3Second
            // 
            richTextBox3Second.Location = new Point(160, 499);
            richTextBox3Second.Name = "richTextBox3Second";
            richTextBox3Second.Size = new Size(390, 42);
            richTextBox3Second.TabIndex = 10;
            richTextBox3Second.Text = "";
            // 
            // richTextBox2Second
            // 
            richTextBox2Second.Location = new Point(160, 224);
            richTextBox2Second.Name = "richTextBox2Second";
            richTextBox2Second.Size = new Size(390, 253);
            richTextBox2Second.TabIndex = 9;
            richTextBox2Second.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 165);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 8;
            label1.Text = "Remote IP";
            // 
            // richTextBox1Second
            // 
            richTextBox1Second.Location = new Point(160, 159);
            richTextBox1Second.Name = "richTextBox1Second";
            richTextBox1Second.Size = new Size(239, 31);
            richTextBox1Second.TabIndex = 7;
            richTextBox1Second.Text = "";
            // 
            // button1Second
            // 
            button1Second.Location = new Point(456, 156);
            button1Second.Name = "button1Second";
            button1Second.Size = new Size(94, 34);
            button1Second.TabIndex = 6;
            button1Second.Text = "Connect";
            button1Second.UseVisualStyleBackColor = true;
            button1Second.Click += button1Second_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(676, 64);
            panel1.TabIndex = 12;
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
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(676, 593);
            Controls.Add(panel1);
            Controls.Add(button2Second);
            Controls.Add(richTextBox3Second);
            Controls.Add(richTextBox2Second);
            Controls.Add(label1);
            Controls.Add(richTextBox1Second);
            Controls.Add(button1Second);
            Cursor = Cursors.IBeam;
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button2Second;
        private System.Windows.Forms.RichTextBox richTextBox3Second;
        private System.Windows.Forms.RichTextBox richTextBox2Second;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1Second;
        private System.Windows.Forms.Button button1Second;
        private Panel panel1;
        private Label label2;
    }
}