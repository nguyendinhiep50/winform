using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_nhan_vien
{
    public partial class F_thongtincaNhan_NV : Form
    {
        public F_thongtincaNhan_NV()
        {
            InitializeComponent();
        }
        

        private void F_thongtincaNhan_NV_Load(object sender, EventArgs e)
        {
            string s = "Select * from TblTTCaNhan";
            support_checksql sql = new support_checksql();
            DataTable data = new DataTable();
            data = sql.TraVe_data(s);
            dgv_thongtincanhan.DataSource = data;
            truyenduieu(0);
        }
        private void truyenduieu(int hang)
        {
            txtmaNV.Text = dgv_thongtincanhan.Rows[hang].Cells[0].Value.ToString();
            txthoten.Text = dgv_thongtincanhan.Rows[hang].Cells[1].Value.ToString();
            txtnoisinh.Text = dgv_thongtincanhan.Rows[hang].Cells[2].Value.ToString();
            txtnguyenquan.Text = dgv_thongtincanhan.Rows[hang].Cells[3].Value.ToString();
            txtDC_tamchu.Text = dgv_thongtincanhan.Rows[hang].Cells[4].Value.ToString();
            txtDC_thuongchu.Text = dgv_thongtincanhan.Rows[hang].Cells[5].Value.ToString();
            txtSDT.Text = dgv_thongtincanhan.Rows[hang].Cells[6].Value.ToString();
            txtdantoc.Text = dgv_thongtincanhan.Rows[hang].Cells[7].Value.ToString();
            txttongiao.Text = dgv_thongtincanhan.Rows[hang].Cells[8].Value.ToString();
            txt_quoctich.Text = dgv_thongtincanhan.Rows[hang].Cells[9].Value.ToString();
            txthocvan.Text = dgv_thongtincanhan.Rows[hang].Cells[10].Value.ToString();
            txtghichu.Text = dgv_thongtincanhan.Rows[hang].Cells[11].Value.ToString();               
        }


        private void dgv_thongtincanhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                truyenduieu(hang);

            }
            catch (Exception)
            {
                MessageBox.Show("lỗi");
            }
        }


        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string s = "mã NV:" + txtmaNV.Text + " tên nhân viên :" + txthoten.Text;
            MessageBox.Show($"Bạn muốn xoá nhân viên có {s}");
            string query = $"	delete from TblTTCaNhan where MaNV = '{txtmaNV.Text}'; ";
            support_checksql sql = new support_checksql();
            sql.suathongtin(query);
            F_thongtincaNhan_NV_Load(sender, e);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string s = "mã NV:" + txtmaNV.Text + " tên nhân viên :" + txthoten.Text;
            MessageBox.Show($"Bạn muốn sửa nhân viên có {s}");
            string query = $"UPDATE TblTTCaNhan  SET MaNV = '{txtmaNV.Text}', HoTen = N'{txthoten.Text}', NoiSinh = N'{txtnoisinh.Text}' , NguyenQuan = N'{txtnguyenquan.Text}', DCThuongChu = N'{txtDC_thuongchu.Text}',DCTamChu = N'{txtDC_tamchu.Text}',SDT = '{txtSDT.Text}',DanToc = N'{txtdantoc.Text}',TonGiao = N'{txttongiao.Text}', QuocTich = N'{txt_quoctich.Text}',HocVan = N'{txthocvan.Text}',GhiChu = N'{txtghichu.Text}' where MaNV = '{txtmaNV.Text}'";
            support_checksql sql = new support_checksql();
            sql.suathongtin(query);
            F_thongtincaNhan_NV_Load(sender, e);
        }

        private void btnmoi_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in groupBox1.Controls)
                if (ctl is TextBox)
                    (ctl as TextBox).Clear();
           
        }
    }
}
