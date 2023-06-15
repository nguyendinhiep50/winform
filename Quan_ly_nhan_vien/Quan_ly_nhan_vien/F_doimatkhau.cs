using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace Quan_ly_nhan_vien
{
    public partial class F_doimatkhau : Form
    {
        string tenTKdata;
        public F_doimatkhau()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        List<string> ListThongtinTK = new List<string>();


        private void btn_suathongtin_Click(object sender, EventArgs e)
        {
            if (XacMinhTaikhoan()==true)
            {
                txtmatkhau.ReadOnly = false;
              //  txthoten.ReadOnly = false;
            } 
        }

        private void btn_luuthongtin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn lưu không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (txtmatkhau.ReadOnly == false)
                {
              //      string query = "UPDATE tbuser SET Username = '"+ txt_tendangnhap.Text +"', Pass = '"+ txtmatkhau.Text+"', Quyen ='"+ ListThongtinTK[2] +"', Ten ='" + txthoten.Text +"', Ngaysinh =  '" + dtp_ngaysinh.Text + "'  WHERE Username =  '" + txt_tendangnhap.Text + "'";
                    //support_checksql sql = new support_checksql();
                    //sql.suathongtin(query);
                   
                }
                txtmatkhau.ReadOnly = true;
              //  txthoten.ReadOnly = true;
                fLogin.tenTK = txt_tendangnhap.Text;
                MessageBox.Show("Đổi thành công");
                F_doimatkhau_Load(sender, e);
            }
            
            
        }
        private bool XacMinhTaikhoan()
        {
            string chuoi= Interaction.InputBox("Vui lòng nhập mật khẩu để xác nhận", "Thông báo", "");
            if (chuoi != txtmatkhau.Text)
            {
                MessageBox.Show("Bạn nhập sai mật khẩu");
                return false;
            }
            return true;
        }
        private void F_doimatkhau_Load(object sender, EventArgs e)
        {

            tenTKdata = fLogin.tenTK;
            string query = "Select * from tbuser where Username ='" + tenTKdata + "'";
            support_checksql sql = new support_checksql();
            DataTable data = new DataTable();
            data = sql.TraVe_data(query);
            ListThongtinTK.Clear();
            foreach (DataRow row in data.Rows)
                foreach (var item in row.ItemArray)
                    ListThongtinTK.Add(item.ToString());
            txt_tendangnhap.Text = ListThongtinTK[0];
            txtmatkhau.Text = ListThongtinTK[1];
            //txthoten.Text = ListThongtinTK[3];
            //dtp_ngaysinh.Value = Convert.ToDateTime(ListThongtinTK[4].ToString());


        }



        private void btn_hienthiMK_Click(object sender, EventArgs e)
        {
            if (XacMinhTaikhoan()==true || txtmatkhau.ReadOnly == false)
            {
                txtmatkhau.UseSystemPasswordChar = false;
            }
        }

    }
}
