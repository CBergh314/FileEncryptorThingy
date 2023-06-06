using System.Text.Json;

namespace FileEncryptorThingy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileContainer file;
                if (BinaryFileCheck.Checked) //read binary file
                {
                    byte[] bytes = File.ReadAllBytes(FileNameTextBox.Text);

                    file = new(PasswordTextBox.Text, EncryptionPicker.Text, HashPicker.Text, bytes);
                }
                else //read string file
                {
                    string text = File.ReadAllText(FileNameTextBox.Text);

                    file = new(PasswordTextBox.Text, EncryptionPicker.Text, HashPicker.Text, text);
                }
                JsonSerializerOptions options = new() { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(file, options);

                string fileName = Path.ChangeExtension(FileNameTextBox.Text, ".enc");
                File.WriteAllText(fileName, jsonString);

                StatusLabel.Text = "Status: File Encrypted";
                StatusLabel.BackColor = Color.LightGreen;
                StatusLabel.ForeColor = Color.DarkGreen;
            }
            catch (Exception error)
            {
                StatusLabel.Text = "Status: " + error.Message;
                StatusLabel.BackColor = Color.PaleVioletRed;
                StatusLabel.ForeColor = Color.Red;
            }
        }

        private void FilePickerButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileNameTextBox.Text = openFileDialog1.FileName;
                FileExtensionTextBox.Text = Path.GetExtension(openFileDialog1.FileName);

                if(FileExtensionTextBox.Text.ToUpper() == "BIN" || FileExtensionTextBox.Text.ToUpper() == "DAT")
                {
                    BinaryFileCheck.Checked = true;
                }
            }
            StatusLabel.Text = "Status: File Selected";
            StatusLabel.BackColor = SystemColors.Control;
            StatusLabel.ForeColor = Color.Black;
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                using FileStream fs = new(FileNameTextBox.Text, FileMode.Open, FileAccess.Read);
                using StreamReader sr = new(fs);
                string s = sr.ReadToEnd();
                var file = JsonSerializer.Deserialize<FileContainer>(s);
                var decryptor = new Encryptor(PasswordTextBox.Text, file.Metadata);
                if (decryptor.VerifyHmac(file.Data, file.Iv, file.HMAC)) //only decrypt if file was not modified
                {
                    string text = decryptor.Decrypt(file.Data);
                    string fileName = Path.ChangeExtension(FileNameTextBox.Text, FileExtensionTextBox.Text);

                    StatusLabel.Text = "Status: File Decrypted";
                    StatusLabel.BackColor = Color.LightGreen;
                    StatusLabel.ForeColor = Color.DarkGreen;
                }
            }
            catch (Exception error)
            {
                StatusLabel.Text = "Status: " + error.Message;
                StatusLabel.BackColor = Color.PaleVioletRed;
                StatusLabel.ForeColor = Color.DarkRed;
            }
        }

        private void BinaryFileCheck_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}