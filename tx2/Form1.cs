using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace tx2
{
    public partial class Form1 : Form
    {
        XmlDocument doc = new XmlDocument();
        static string filepath = "E:/Study/Tich hop htpm/tx2/truonghoc.xml";
        DataUtils dataUtils = new DataUtils(filepath);
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataUtils.timKiem(txtPhonghoc.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataUtils.hienthi();
        }

        private void them_Click(object sender, EventArgs e)
        {
            string malop = txtMalop.Text;
            string phonghoc = txtPhonghoc.Text;
            string masv = txtMsv.Text;
            string hoten = txtHoten.Text;
            string diachi = txtDiachi.Text;

            if (dataUtils.hienthi().Any(l => l.masv == masv))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!");
                return;
            }

            lophoc lh = new lophoc();
            lh.malop = malop;
            lh.phonghoc = phonghoc;
            lh.masv = masv;
            lh.hoten = hoten;
            lh.diachi = diachi;
            dataUtils.them(lh);
            dataGridView1.DataSource = dataUtils.hienthi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            lophoc lh = (lophoc)dataGridView1.CurrentRow.DataBoundItem;
            txtMalop.Text = lh.malop;
            txtPhonghoc.Text = lh.phonghoc;
            txtMsv.Text = lh.masv;
            txtHoten.Text = lh.hoten;
            txtDiachi.Text = lh.diachi;
            
        }

        private void sua_Click(object sender, EventArgs e)
        {
            string malop = txtMalop.Text;
            string phonghoc = txtPhonghoc.Text;
            string masv = txtMsv.Text;
            string hoten = txtHoten.Text;
            string diachi = txtDiachi.Text;

            lophoc lh = new lophoc();
            lh.malop = malop;
            lh.phonghoc = phonghoc;
            lh.masv = masv;
            lh.hoten = hoten;
            lh.diachi = diachi;

            bool check = dataUtils.sua(lh);
            if (check)
            {
                dataGridView1.DataSource = dataUtils.hienthi();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã sinh viên để sửa!");
            }

            dataGridView1.DataSource = dataUtils.hienthi();
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                string masv = txtMsv.Text;
                bool check = dataUtils.xoa(masv);
                if (check)
                {
                    dataGridView1.DataSource = dataUtils.hienthi();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã sinh viên để xóa!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = dataUtils.demSoSinhVien();
            MessageBox.Show("Tổng số sinh viên: " + count);
        }
    }
}