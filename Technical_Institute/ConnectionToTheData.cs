using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public static class ConnectionToTheData
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

        public static DataTable getAllBranches()
        {
            DataSet ds = new DataSet();
            string query = "select b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree,SUM(s.Theoretical_Hours+s.Practical_Hours)'NumberOfHours' from Branches b inner join SubjectsToBranches s on b.ID = s.ID_Branch group by b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getBranch(int id)
        {
            DataSet ds = new DataSet();
            string query = $"select b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree,SUM(s.Theoretical_Hours+s.Practical_Hours)'NumberOfHours' from Branches b inner join SubjectsToBranches s on b.ID = s.ID_Branch where b.ID = {id} group by b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getSubjectFromBranch(int id)
        {
            DataSet ds = new DataSet();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable getSubjectFromBranchForSpecificYear(int id, int year)
        {
            DataSet ds = new DataSet();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id} and sb.Year_Number = {year}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getSubjectFromBranchForSpecificYearForSpecificSemester(int id, int year, int semester)
        {
            DataSet ds = new DataSet();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id} and sb.Year_Number = {year} and sb.Semester_Number = {semester}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getAllUsers()
        {
            DataSet ds = new DataSet();
            string query = $"select u.ID,u.Is_Admin,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,us.Certificate_Type,u.National_Number,u.Password from Users u left join User_Students us on u.ID = us.ID";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getSpecificUser(string national_number,string password)
        {
            DataSet ds = new DataSet();
            string query = $"select u.ID,u.Is_Admin,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,us.Certificate_Type,u.National_Number,u.Password from Users u left join User_Students us on u.ID = us.ID where u.National_Number = {national_number}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static bool addUser(bool isAdmin, string first_name, string last_name, string national_number, string phone, char gender, float degree, string certificate_type, string password)
        {
            string query = $"insert into Users (Is_Admin,First_Name,Last_Name,Gender,Phone_Number,National_Number,Password) values (@isAdmin,@first_name,@last_name,@gender,@phone,@national_number,@password)";
            int rows,id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@isAdmin", isAdmin ? 1 : 0);
                        command.Parameters.AddWithValue("@first_name", first_name);
                        command.Parameters.AddWithValue("@last_name", last_name);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@national_number", national_number);
                        command.Parameters.AddWithValue("@password", password);

                        rows = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { return false; }finally { connection.Close(); }
            }
            if(isAdmin)
            {
                return rows > 0 ? true : false;
            }
            else
            {
                try
                {
                    DataSet ds = new DataSet();
                    query = $"select top 1 * from Users order by ID desc";
                    var dbConnection = new SqlConnection(connectionString);
                    var dataAdapter = new SqlDataAdapter(query, dbConnection);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.Fill(ds);
                    id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
                catch (Exception ex) { return false; }

                query = "insert into User_Students values (@id,@degree,@certificateType)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@degree", degree);
                            command.Parameters.AddWithValue("@certificateType", certificate_type);

                            rows = command.ExecuteNonQuery();
                        }
                        catch (Exception ex) { return false; }
                        finally { connection.Close(); }
                    }
                }
                return rows > 0 ? true: false;
            }
        }
    }
}