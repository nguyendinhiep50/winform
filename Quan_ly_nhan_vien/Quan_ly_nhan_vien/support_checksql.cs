using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public class support_checksql
{
    private string connerctionSTR = @"Data Source=DESKTOP-QS0AGTR\HIEP;Initial Catalog=QLNS;Integrated Security=True";
    public int Traketqua(string query, int kieu)
    {
        SqlConnection connection = new SqlConnection(connerctionSTR);
        connection.Open();
        int t = 0;
        SqlCommand comand = new SqlCommand(query, connection);
        switch (kieu)
        {
            case 1:
                t = kieutrave_sohang_thangcong(comand);
                break;
            case 2:
                t = kieutrave_socot_thangcong(comand);
                break;
        }

        connection.Close();
        return t;
    }
    private int kieutrave_sohang_thangcong(SqlCommand sql)
    {
        return sql.ExecuteNonQuery();
    }
    private int kieutrave_socot_thangcong(SqlCommand sql)
    {
        return Convert.ToInt32(sql.ExecuteScalar());
    }
    public int returnCountSQL(string query)
    {

        SqlConnection connection = new SqlConnection(connerctionSTR);
        connection.Open();
        //Mở kết nối
        SqlCommand comand = new SqlCommand(query, connection);
        // đưa câu lệnh truy vấn vào
        DataTable data = new DataTable();
        //tạo hàm data
        SqlDataAdapter adapter = new SqlDataAdapter(comand);
        adapter.Fill(data);
        //đổ dữ liệu adapter vào data
        if (data.Rows.Count == 0)
        {
            return 0;
        }

        else if (data.Rows.Count > 0)
        {
            return data.Rows.Count;
        }
        else
            return 0;
        connection.Close();
        // phải đóng kết nối
        return 0;
    }
    // lưu thông tin
    public void suathongtin(string query)
    {
        SqlConnection connection = new SqlConnection(connerctionSTR);
        connection.Open();
        SqlCommand comand = new SqlCommand(query, connection);
        comand.ExecuteNonQuery();

        connection.Close();
    }

    public DataTable TraVe_data(string s)
    {
        string connerctionSTR = @"Data Source=DESKTOP-QS0AGTR\HIEP;Initial Catalog=QLNS;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connerctionSTR);

        connection.Open();
        SqlCommand comand = new SqlCommand(s, connection);
        DataTable data = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(comand);
        adapter.Fill(data);
        connection.Close();
        return data;
    }
}