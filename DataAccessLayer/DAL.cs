using System.Data.SqlClient;
using System.Data;
namespace DataAccessLayer
{

    //Đầu tiên tạo class DataAccessLayer để truy cập dữ liệu 
    public class DAL
    {
        string Constr = "Data Source=(local);" + "Initial Catalog=QUANLYBIDA;Integrated Security=True";
        //Chuỗi kết nối đến cơ sở dữ liệu QUANLYBIDA trên SQL Server cục bộ (local)
        SqlConnection conn = null; // Dùng để thiết lập kết nối với SQL Server
        SqlCommand comm = null; // Một biến dùng để thực thi truy vấn SQL
        SqlDataAdapter da = null; // dùng để lấy dữ liệu từ SQL Server và đưa vào DataSet
        //Contructor
        public DAL()
        {
            conn = new SqlConnection(Constr);
            comm = conn.CreateCommand();
        }
        // Khởi tạo kết nối mới conn và tạo 1 lệnh SQL comm dựa trên kết nối đó
        // Khai báo hàm thực thi tầng kết nối
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            // Đóng kết nối nếu đang mở 
            conn.Open();
            // Mở lại kết nối 
            comm.Connection = conn;
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            // Gán connection cho comm

            comm.Parameters.Clear();
            if (p != null)
            {
                comm.Parameters.AddRange(p);
            }
            // Xóa tham số cũ trước khi thêm mới để tránh bị trùng

            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Close();
            return ds;
        }
        // Đóng kết nối sau khi lấy dữ liệu

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] param)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        // Thực hiện truy vấn = Insert | Delete | Update | Stored Procedure
    }
}
