using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QLNS
{
    public partial class frmdangnhap : Form
    {
        Clsdatabase cls = new Clsdatabase();
        private SqlConnection Con = null;
        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show( cls.thu(textBox2.Text, "select pass from tbuser").ToString());
            if ((cls.kt(textBox1.Text, "select * from tbuser", 0) == true) && (cls.kt(textBox2.Text, "select * from tbuser", 1) == true))
            {
                //string sql = "select quyen from tbuser ";
                //if (cls.kt("admin", "select * from tbuser", 2) == true)
                //{

                this.Hide();
                //global.frmmain.k = 4;
                //global.frmmain.refresh();
                //global.frmmain.truyen();

                //global.frmmain.showdialog();
                MessageBox.Show("bạn đã đăng nhập thành công");
                FrmMain.quyen = "admin";

                this.Hide();
                FrmMain fm = new FrmMain();
                //fm.k = 4;
                fm.truyen();
                MessageBox.Show("bạn đã đăng nhập thành công quyen admin");
                fm.ShowDialog();
                this.Close();
            }
            else //if (sql == "client")
            {
                //t thuwr roi k dc
                //frmmain.quyen = "member";
                //this.hide();
                //frmmain fm = new frmmain();
                //fm.k = 5;
                //fm.truyen();
                //messagebox.show("bạn đã đăng nhập thành công quyền user");
                //fm.showdialog();
                //sửa đi

            }//Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=DESKTOP-QS0AGTR\HIEP;Initial Catalog=QLNS;Integrated Security=True";
            string select = "Select * From tbuser where Username='" + textBox1.Text + "' and Pass='" + textBox2.Text + "' and Quyen='Admin'";
            SqlCommand cmd = new SqlCommand(select, Con);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Read();
                MessageBox.Show("Đăng nhập vào hệ thống (Quyền Admin) !", "Thông báo !");
                FrmMain.quyen = "Admin";
                this.Hide();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Đăng nhập vào hệ thống (Quyền user) !", "Thông báo !");
                FrmMain.quyen = "user";
                this.Hide();
                this.Close();
            }
            FrmMain frm = new FrmMain();
                //frm.Show();
                frm.ShowDialog();
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
           
            
            }

        }

               // else MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        
//    }
//}
