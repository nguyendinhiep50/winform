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
    public partial class F_thongtin_nv_coban : Form
    {
        public F_thongtin_nv_coban()
        {
            InitializeComponent();
        }

        private void F_thongtin_nv_coban_Load(object sender, EventArgs e)
        {
            string s = "Select * from TblTTNVCoBan";
            support_checksql sql = new support_checksql();
            DataTable data = new DataTable();
            data = sql.TraVe_data(s);
            dgv_thongtin_coban.DataSource = data;
            truyenduieu(0);
        }

    
        private void truyenduieu(int hang)
        {
            txtmabophan.Text = dgv_thongtin_coban.Rows[hang].Cells[0].Value.ToString();
            txtmaphong.Text = dgv_thongtin_coban.Rows[hang].Cells[1].Value.ToString();
            txtmaNV.Text = dgv_thongtin_coban.Rows[hang].Cells[2].Value.ToString();
            txthoten.Text = dgv_thongtin_coban.Rows[hang].Cells[3].Value.ToString();
            txtmaluong.Text = dgv_thongtin_coban.Rows[hang].Cells[4].Value.ToString();
            dtp_ngaysinh.Text = dgv_thongtin_coban.Rows[hang].Cells[5].Value.ToString();
            cbo_giotinh.Text = dgv_thongtin_coban.Rows[hang].Cells[6].Value.ToString();
            if (dgv_thongtin_coban.Rows[hang].Cells[7].Value.ToString() == "chưa")
                chk_kethon.Checked = false;
            else
                chk_kethon.Checked = true;
            txt_CMTND.Text = dgv_thongtin_coban.Rows[hang].Cells[8].Value.ToString();
            txtnoicap.Text = dgv_thongtin_coban.Rows[hang].Cells[9].Value.ToString();
            txt_chucvu.Text = dgv_thongtin_coban.Rows[hang].Cells[10].Value.ToString();
            txt_loai_HD.Text = dgv_thongtin_coban.Rows[hang].Cells[11].Value.ToString();
            txt_thoigian.Text = dgv_thongtin_coban.Rows[hang].Cells[12].Value.ToString();
            dtp_ngayky.Text = dgv_thongtin_coban.Rows[hang].Cells[13].Value.ToString();
            dtp_ngayhethan.Text = dgv_thongtin_coban.Rows[hang].Cells[14].Value.ToString();
            txtghichu.Text = dgv_thongtin_coban.Rows[hang].Cells[15].Value.ToString();

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
            F_thongtin_nv_coban_Load(sender, e);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string s = "mã NV:" + txtmaNV.Text + " tên nhân viên :" + txthoten.Text;
            MessageBox.Show($"Bạn muốn sửa nhân viên có {s}");
       //     string query = $"UPDATE TblTTCaNhan  SET MaNV = '{txtmaNV.Text}', HoTen = N'{txthoten.Text}', NoiSinh = N'{txtnoisinh.Text}' , NguyenQuan = N'{txtnguyenquan.Text}', DCThuongChu = N'{txtDC_thuongchu.Text}',DCTamChu = N'{txtDC_tamchu.Text}',SDT = '{txtSDT.Text}',DanToc = N'{txtdantoc.Text}',TonGiao = N'{txttongiao.Text}', QuocTich = N'{txt_quoctich.Text}',HocVan = N'{txthocvan.Text}',GhiChu = N'{txtghichu.Text}' where MaNV = '{txtmaNV.Text}'";
            support_checksql sql = new support_checksql();
        //    sql.suathongtin(query);
            F_thongtin_nv_coban_Load(sender, e);
        }

        private void btnmoi_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in groupBox1.Controls)
                if (ctl is TextBox)
                    (ctl as TextBox).Clear();
            foreach (Control ctl in groupBox1.Controls)
                if (ctl is ComboBox)
                    (ctl as ComboBox).Text = "";
            foreach (Control ctl in groupBox1.Controls)
                if (ctl is DateTimePicker)
                    (ctl as DateTimePicker).Value = DateTime.Now;
        }

        private void dgv_thongtin_coban_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
