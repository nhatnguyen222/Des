using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.ToString().Length==8&& textBox3.Text.ToString().Length == 8)
            {
                Vigenere vig = new Vigenere();
                string maHoa = vig.Encipher(textBox2.Text.ToString(), textBox4.Text.ToString()); // ma hoa key truoc khi des
                var des = new Des();
                var key = des.chuyenThanhBytes(maHoa);
                var iv = des.chuyenThanhBytes(textBox3.Text.ToString());
                string message = textBox1.Text.ToString();
                var encrypted = des.Encrypt(Encoding.UTF8.GetBytes(message), key, iv);
                MessageBox.Show(Convert.ToBase64String(encrypted));
            }    
          else
            {
                MessageBox.Show("key hoac iv phai 8 ky tu(64 bit)");
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.ToString().Length == 8 && textBox3.Text.ToString().Length == 8)
            {
                Vigenere vig = new Vigenere();
                string maHoa = vig.Decipher(textBox2.Text.ToString(), textBox4.Text.ToString());
                try
                {
                    var des = new Des();
                    var key = des.chuyenThanhBytes(maHoa);
                    var iv = des.chuyenThanhBytes(textBox3.Text.ToString());
                    string message = textBox1.Text.ToString();
                    var decrypted = des.Decrypt(Convert.FromBase64String(message), key, iv);
                    MessageBox.Show(Encoding.UTF8.GetString(decrypted));
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Khong the giai ma");
                }

            }
            else
            {
                MessageBox.Show("key hoac iv phai 8 ky tu(64 bit)");
            }
         
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
