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
    public partial class F_phongban : Form
    {
        public F_phongban()
        {
            InitializeComponent();
        }

        private void F_bophan_Load(object sender, EventArgs e)
        {
            string s = "Select * from TblPhongBan";
            support_checksql sql = new support_checksql();
            DataTable data = new DataTable();
            data = sql.TraVe_data(s);
            dgv_phongban.DataSource = data;
            truyenduieu(0);
        }
        private void truyenduieu(int hang)
        {
            txtmabophan.Text = dgv_phongban.Rows[hang].Cells[0].Value.ToString();
            txtmaphong.Text = dgv_phongban.Rows[hang].Cells[1].Value.ToString();
            txttenphong.Text = dgv_phongban.Rows[hang].Cells[2].Value.ToString();
            dtp_ngaythanhlap.Text = dgv_phongban.Rows[hang].Cells[3].Value.ToString();
            txtghichu.Text = dgv_phongban.Rows[hang].Cells[4].Value.ToString();
        }

        private void dgv_phongban_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnxoa_Click(object sender, EventArgs e)
        {

        }
    }
}
