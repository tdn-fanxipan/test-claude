using System;
using System.Data.SqlClient;

namespace DemoApp
{
    public class UserService
    {
        // LỖI 1: hardcoded connection string + secret
        private const string ConnString =
            "Server=prod-db;Database=Users;User Id=sa;Password=P@ssw0rd123!;";

        public string GetUserEmail(string userId)
        {
            var conn = new SqlConnection(ConnString); // LỖI 2: không dispose (no using)
            conn.Open();

            // LỖI 3: SQL injection — nối chuỗi trực tiếp
            var query = "SELECT Email FROM Users WHERE Id = '" + userId + "'";
            var cmd = new SqlCommand(query, conn);

            // LỖI 4: không kiểm tra null trước khi gọi .ToString()
            var result = cmd.ExecuteScalar();
            return result.ToString();
        }

        public void DeleteUser(string userId)
        {
            try
            {
                // ... xử lý xóa
            }
            catch (Exception) // LỖI 5: nuốt exception, không log
            {
            }
        }
    }
}