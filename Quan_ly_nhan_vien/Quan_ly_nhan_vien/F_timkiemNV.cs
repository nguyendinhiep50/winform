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
    public partial class F_timkiemNV : Form
    {
        public F_timkiemNV()
        {
            InitializeComponent();
        }

        private void F_timkiemNV_Load(object sender, EventArgs e)
        {
            string s = "Select * from TblTTCaNhan";
            support_checksql sql = new support_checksql();
            DataTable data = new DataTable();
            data = sql.TraVe_data(s);
            dgv_timkiem.DataSource = data;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from TblTTCaNhan where HoTen like N'%" + txt_timkiem.Text + "%'";
            support_checksql sql = new support_checksql();
            DataTable data = new DataTable();
            data = sql.TraVe_data(query);
            dgv_timkiem.DataSource = data;
        }
    }
}
