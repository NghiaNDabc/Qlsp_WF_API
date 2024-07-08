using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dtgSanPham.DataSource = DsSanPham();
        }
      //  string URI = "http://192.168.42.105:1212/api/";
        string URI = "http://localhost:64796//api/";
        List<SanPham> DsSanPham()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URI);

            var rp = client.GetAsync("SanPham").Result;

            if(rp.IsSuccessStatusCode)
            {
                return rp.Content.ReadAsAsync<List<SanPham>>().Result;
            }
            return null;
        }
        SanPham getSP()
        {
            SanPham x = new SanPham();
            x.MaSP = int.Parse(txtMa.Text);
            x.DonGia = double.Parse(txtDG.Text);
            x.SoLuongBan = double.Parse(txtSL.Text);
            x.TienBan = double.Parse(txtTien.Text);
            x.TenSanPham = txtTen.Text;
            return x;
        }
        bool Add(SanPham sanPham)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URI);

            var x = client.PostAsJsonAsync("SanPham", sanPham);
            return x.Result.IsSuccessStatusCode;
        }

        bool Delete(int ma)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URI);
            var rp = client.DeleteAsync($"SanPham?ma={ma}").Result;
            return rp.IsSuccessStatusCode;
        }
        bool Put(SanPham sp)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URI);
            var rp = client.PutAsJsonAsync($"SanPham", sp).Result;
            return rp.IsSuccessStatusCode;
        }
        void HienThi()
        {
            dtgSanPham.DataSource = null;
            dtgSanPham.DataSource = DsSanPham();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SanPham sp = getSP();

            if (!Add(sp)) MessageBox.Show("ko them dc");
            HienThi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(URI);
            //var rp = client.GetAsync("SanPham/DS").Result;

            //dtgSanPham.DataSource = null;
            //dtgSanPham.DataSource = rp.Content.ReadAsAsync<List<SanPham>>().Result;
            if (!Put(getSP()))
            {
                MessageBox.Show("fail");
                return;
            }
            HienThi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dtgSanPham.CurrentRow;

            if(row != null)
            {
                if(MessageBox.Show("xoa ko?", "thong bao", MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    Delete(int.Parse(row.Cells[0].Value.ToString()));
                    HienThi();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URI);
            var rp = client.GetAsync($"SanPham/DS?ma={txtMa.Text}").Result;
            Form2 x = new Form2();
            x.dataGridView1.DataSource = null;
            x.dataGridView1.DataSource = rp.Content.ReadAsAsync<List<SanPham>>().Result;
            x.Show();
        }

        private void dtgSanPham_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dtgSanPham.CurrentRow;

            if (row != null)
            {

                txtMa.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
