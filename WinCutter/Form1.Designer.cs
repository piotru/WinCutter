namespace WinCutter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button2 = new Button();
            TextBoxData = new RichTextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(606, 390);
            button2.Name = "button2";
            button2.Size = new Size(161, 48);
            button2.TabIndex = 1;
            button2.Text = "Wyślij do drukarki";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // TextBoxData
            // 
            TextBoxData.Location = new Point(47, 21);
            TextBoxData.Name = "TextBoxData";
            TextBoxData.Size = new Size(516, 251);
            TextBoxData.TabIndex = 2;
            TextBoxData.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TextBoxData);
            Controls.Add(button2);
            Name = "Form1";
            Text = "Drukowanie do Wycinarki";
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private RichTextBox TextBoxData;
    }
}
