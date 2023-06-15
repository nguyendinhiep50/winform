using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Quan_ly_nhan_vien
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        public static string tenTK { get; set; }
        private bool KiemtraKQ(string s)
        {
            string connerctionSTR = @"Data Source=DESKTOP-QS0AGTR\HIEP;Initial Catalog=QLNS;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connerctionSTR);

            connection.Open();
            SqlCommand comand = new SqlCommand(s, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(comand);
            adapter.Fill(data);
            
            if (data.Rows.Count == 0)
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            bool ktra = false;
            if (rad_admin.Checked)
            {
                string chuoi = " EXEC dbo.USP_Login @userName = N'" + txtTaiKhoan.Text + "' ,@passWord = N'" + txtMat_khau.Text + "',@quyen = N'Admin'";
                ktra = KiemtraKQ(chuoi);
                if (ktra == true)
                {
                    // MessageBox.Show("Đã đăng nhập thành công với tư cách quản lý");
                    tenTK = txtTaiKhoan.Text;
                    F_main f = new F_main();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai");


            }
            else if (rad_user.Checked)
            {
                string chuoi = " EXEC dbo.USP_Login @userName = N'" + txtTaiKhoan.Text + "' ,@passWord = N'" + txtMat_khau.Text + "',@quyen = N'User'";
                ktra = KiemtraKQ(chuoi);
                if (ktra == true)
                {
                    MessageBox.Show("Đã đăng nhập thành công với tư cách nhân viên");
                    F_main f = new F_main();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai");
            }
            else 
            {
                MessageBox.Show("Lỗi đăng nhập");
            }    
        }
    }
}
     