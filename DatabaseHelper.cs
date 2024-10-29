using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab03_23521572_LeQuangTien
{
    
    public static class DatabaseHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["Lab03"].ConnectionString;

        public static bool RegisterUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
        // Phương thức tạo phòng chat mới
        public static bool CreateChatRoom(string roomCode, int createdByUserId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO ChatRooms (RoomCode, CreatedBy) VALUES (@RoomCode, @CreatedBy)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomCode", roomCode);
                    cmd.Parameters.AddWithValue("@CreatedBy", createdByUserId);

                    try
                    {
                        return cmd.ExecuteNonQuery() > 0; // Trả về true nếu tạo phòng thành công
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static bool JoinRoom(string roomCode)
        {
            // Kiểm tra phòng chat có tồn tại trong CSDL không
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM ChatRooms WHERE RoomCode = @RoomCode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomCode", roomCode);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
