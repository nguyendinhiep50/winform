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
    public partial class F_quanlyTK_NV : Form
    {
        public F_quanlyTK_NV()
        {
            InitializeComponent();
        }

        private void F_quanlyTK_NV_Load(object sender, EventArgs e)
        {
            string query = "Select * from tbuser";
            support_checksql sql = new support_checksql();
            DataTable data = new DataTable();
            data = sql.TraVe_data(query);
            dgv_ds_NV.DataSource = data;
            truyenduieu(1);
        }

        private void dgv_ds_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                truyenduieu(hang);

            }
            catch (Exception)
            {
                return;
            }
        }
        private void truyenduieu(int hang)
        {
            txt_tendangnhap.Text = dgv_ds_NV.Rows[hang].Cells[0].Value.ToString();
            txtmatkhau.Text = dgv_ds_NV.Rows[hang].Cells[1].Value.ToString();
            txtquyen.Text = dgv_ds_NV.Rows[hang].Cells[2].Value.ToString();
            txthoten.Text = dgv_ds_NV.Rows[hang].Cells[3].Value.ToString();


            dtp_ngaysinh.Text = dgv_ds_NV.Rows[hang].Cells[4].Value.ToString();
        }


        private void btn_suathongtin_Click(object sender, EventArgs e)
        {
            lenh_xac_nhan("mã"+txt_tendangnhap.Text, "sửa thông tin");
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            lenh_xac_nhan("mã"+txt_tendangnhap.Text, "xoá");
        }
        bool lenh_xac_nhan(string chuoi,string loai)
        {
            DialogResult result = MessageBox.Show($"Bạn muốn {loai} Nhân viên {chuoi} phải không", "Yêu cầu xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        private void btn_themtk_Click(object sender, EventArgs e)
        {
            lenh_xac_nhan("", "thêm tài khoản");
        }
    }
}
