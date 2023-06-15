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
    public partial class F_main : Form
    {
        private Form activeForm;
        public F_main()
        {
            InitializeComponent();
        }
        private void F_main_Load(object sender, EventArgs e)
        {
           // TSMI_quanlytaikhoan.Visible = false;
        }
        public DataTable data_login;


        private void TSMI_DangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TSMI_doimatkhau_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_doimatkhau(), sender);
        }

        private void TSMI_quanlytaikhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_quanlyTK_NV(), sender);
        }

        private void TSMI_thongtincanhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_thongtincaNhan_NV(), sender);
        }

        private void TSMI_nhansu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_thongtin_nv_coban(), sender);
        }

        private void TSMI_tracuu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_timkiemNV(), sender);
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlShow.Controls.Add(childForm);
            this.pnlShow.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void TSMI_phongban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_phongban(), sender);
        }

        private void TSMI_bophan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_bophan(), sender);
        }

        private void TSMI_bangluong_Click(object sender, EventArgs e)
        {

        }
    }
}
