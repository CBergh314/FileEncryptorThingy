namespace FileEncryptorThingy
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
            EncryptButton = new Button();
            DecryptButton = new Button();
            FileNameTextBox = new TextBox();
            FilePickerButton = new Button();
            label1 = new Label();
            HashPicker = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            EncryptionPicker = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            PasswordTextBox = new TextBox();
            label4 = new Label();
            StatusLabel = new Label();
            label5 = new Label();
            FileExtensionTextBox = new TextBox();
            BinaryFileCheck = new CheckBox();
            SuspendLayout();
            // 
            // EncryptButton
            // 
            EncryptButton.Location = new Point(266, 179);
            EncryptButton.Name = "EncryptButton";
            EncryptButton.Size = new Size(75, 23);
            EncryptButton.TabIndex = 0;
            EncryptButton.Text = "Encrypt";
            EncryptButton.UseVisualStyleBackColor = true;
            EncryptButton.Click += EncryptButton_Click;
            // 
            // DecryptButton
            // 
            DecryptButton.Location = new Point(266, 113);
            DecryptButton.Name = "DecryptButton";
            DecryptButton.Size = new Size(75, 23);
            DecryptButton.TabIndex = 1;
            DecryptButton.Text = "Decrypt";
            DecryptButton.UseVisualStyleBackColor = true;
            DecryptButton.Click += DecryptButton_Click;
            // 
            // FileNameTextBox
            // 
            FileNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            FileNameTextBox.Location = new Point(12, 40);
            FileNameTextBox.Name = "FileNameTextBox";
            FileNameTextBox.Size = new Size(248, 23);
            FileNameTextBox.TabIndex = 2;
            // 
            // FilePickerButton
            // 
            FilePickerButton.Location = new Point(12, 69);
            FilePickerButton.Name = "FilePickerButton";
            FilePickerButton.Size = new Size(75, 23);
            FilePickerButton.TabIndex = 3;
            FilePickerButton.Text = "Select File";
            FilePickerButton.UseVisualStyleBackColor = true;
            FilePickerButton.Click += FilePickerButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 4;
            label1.Text = "File selected:";
            // 
            // HashPicker
            // 
            HashPicker.FormattingEnabled = true;
            HashPicker.Items.AddRange(new object[] { "SHA 256", "SHA 512" });
            HashPicker.Location = new Point(12, 179);
            HashPicker.Name = "HashPicker";
            HashPicker.Size = new Size(121, 23);
            HashPicker.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 161);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 6;
            label2.Text = "Hash Algorithm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 161);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 7;
            label3.Text = "Encryption Algorithm";
            // 
            // EncryptionPicker
            // 
            EncryptionPicker.FormattingEnabled = true;
            EncryptionPicker.Items.AddRange(new object[] { "AES 128", "AES 256", "Triple DES" });
            EncryptionPicker.Location = new Point(139, 179);
            EncryptionPicker.Name = "EncryptionPicker";
            EncryptionPicker.Size = new Size(121, 23);
            EncryptionPicker.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
            PasswordTextBox.Location = new Point(12, 113);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(248, 23);
            PasswordTextBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 95);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 10;
            label4.Text = "Password";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.BackColor = SystemColors.Control;
            StatusLabel.Location = new Point(12, 239);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(129, 15);
            StatusLabel.TabIndex = 11;
            StatusLabel.Text = "Status: No File Selected";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(262, 22);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 12;
            label5.Text = "File Extension";
            // 
            // FileExtensionTextBox
            // 
            FileExtensionTextBox.BorderStyle = BorderStyle.FixedSingle;
            FileExtensionTextBox.Location = new Point(266, 40);
            FileExtensionTextBox.Name = "FileExtensionTextBox";
            FileExtensionTextBox.Size = new Size(75, 23);
            FileExtensionTextBox.TabIndex = 13;
            // 
            // BinaryFileCheck
            // 
            BinaryFileCheck.AutoSize = true;
            BinaryFileCheck.Location = new Point(93, 73);
            BinaryFileCheck.Name = "BinaryFileCheck";
            BinaryFileCheck.Size = new Size(139, 19);
            BinaryFileCheck.TabIndex = 14;
            BinaryFileCheck.Text = "Check for Binary Files";
            BinaryFileCheck.UseVisualStyleBackColor = true;
            BinaryFileCheck.CheckedChanged += BinaryFileCheck_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 263);
            Controls.Add(BinaryFileCheck);
            Controls.Add(FileExtensionTextBox);
            Controls.Add(label5);
            Controls.Add(StatusLabel);
            Controls.Add(label4);
            Controls.Add(PasswordTextBox);
            Controls.Add(EncryptionPicker);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(HashPicker);
            Controls.Add(label1);
            Controls.Add(FilePickerButton);
            Controls.Add(FileNameTextBox);
            Controls.Add(EncryptButton);
            Controls.Add(DecryptButton);
            Name = "Form1";
            Text = "File Encryptor Thingy™";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button EncryptButton;
        private Button DecryptButton;
        private TextBox FileNameTextBox;
        private Button FilePickerButton;
        private Label label1;
        private ComboBox HashPicker;
        private Label label2;
        private Label label3;
        private ComboBox EncryptionPicker;
        private OpenFileDialog openFileDialog1;
        private TextBox PasswordTextBox;
        private Label label4;
        private Label StatusLabel;
        private Label label5;
        private TextBox FileExtensionTextBox;
        private CheckBox BinaryFileCheck;
    }
}