using System;
using System.Collections;
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
            DataTable dt = new DataTable();
            string query = "select b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree,SUM(s.Theoretical_Hours+s.Practical_Hours)'NumberOfHours' from Branches b inner join SubjectsToBranches s on b.ID = s.ID_Branch group by b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            dataAdapter.Fill(dt);
            return dt;
        }
        public static DataTable getBranch(int id)
        {
            DataTable dt = new DataTable();
            string query = $"select b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree,SUM(s.Theoretical_Hours+s.Practical_Hours)'NumberOfHours' from Branches b inner join SubjectsToBranches s on b.ID = s.ID_Branch where b.ID = {id} group by b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            dataAdapter.Fill(dt);
            return dt;
        }
        public static DataTable getSubjectFromBranch(int id)
        {
            DataTable dt = new DataTable();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection); 
            dataAdapter.Fill(dt);
            return dt;
        }

        public static DataTable getSubjectFromBranchForSpecificYear(int id, int year)
        {
            DataTable dt = new DataTable();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id} and sb.Year_Number = {year}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            
            dataAdapter.Fill(dt);
            return dt;
        }
        public static DataTable getYearsAndSemesters(int id)
        {
            DataTable dt = new DataTable();
            string query = $"select distinct Year_Number year, Semester_Number semester from SubjectsToBranches where ID_Branch={id} order by 1,2";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection); 
            dataAdapter.Fill(dt);
            return dt;
        }
        public static DataTable getSubjectFromBranchForSpecificYearForSpecificSemester(int id, int year , int semester)
        {
            DataTable dt = new DataTable();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id} and sb.Year_Number = {year} and sb.Semester_Number = {semester}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            dataAdapter.Fill(dt);
            return dt;
        }
        public static DataTable getAllUsers()
        {
            DataTable dt = new DataTable();
            string query = $"select u.ID,u.Is_Admin,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,us.Certificate_Type,u.National_Number,u.Password from Users u left join User_Students us on u.ID = us.ID";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            dataAdapter.Fill(dt);
            return dt;
        }
        public static DataTable getSpecificUser(string national_number,string password)
        {
            DataTable dt = new DataTable();
            string query = $"select u.ID,u.Is_Admin,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,us.Certificate_Type,u.National_Number,u.Password from Users u left join User_Students us on u.ID = us.ID where u.National_Number = {national_number} and u.Password = {password}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            dbConnection.Open();
            dataAdapter.Fill(dt);
            dbConnection.Close();
            return dt;
        }
        public static DataTable checkUser(string national_number, string password)
        {
            DataTable dt = new DataTable();
            string query = $"select u.ID,u.Is_Admin,u.National_Number,u.Password from Users u where u.National_Number = {national_number} and u.Password = {password.GetHashCode()}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            dataAdapter.Fill(dt);
            return dt;
        }
        public static bool addUser(bool isAdmin, string first_name, string last_name, string national_number, string phone, char gender, float degree, string certificate_type, string password)
        {
            string query = $"insert into Users (Is_Admin,First_Name,Last_Name,Gender,Phone_Number,National_Number,Password) values (@isAdmin,@first_name,@last_name,@gender,@phone,@national_number,@password)";
            int rows;
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
                        command.Parameters.AddWithValue("@password", password.GetHashCode());

                        rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            if (isAdmin)
                            {
                                return true;
                            }
                            else
                            {
                                return addStudent(degree, certificate_type);
                            }
                        }
                        else return false;
                    }
                }
                catch { return false; }finally { connection.Close(); }
            }
        }
        public static int getLastStudentID()
        {
            try
            {
                DataTable dt = new DataTable();
                var query = $"select top 1 * from Users order by ID desc";
                var dbConnection = new SqlConnection(connectionString);
                var dataAdapter = new SqlDataAdapter(query, dbConnection);
                dataAdapter.Fill(dt);
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch { return -1; }
 
        }
        public static bool deleteUser(int id)
        {
            var query = $"delete from Users u where u.ID = @id";
            int rows;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        rows = command.ExecuteNonQuery();
                        if(rows > 0 ) return true;
                        else return false;
                    }
                }catch { return false; } finally { connection.Close(); }
            }
        }
        public static bool addStudent(float degree, string certificate_type)
        {
            int id = getLastStudentID();
            int rows;
            if(id != -1)
            {
                var query = "insert into User_Students values (@id,@degree,@certificateType)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@degree", degree);
                            command.Parameters.AddWithValue("@certificateType", certificate_type);

                            rows = command.ExecuteNonQuery();
                            if(rows > 0 ) return true;
                            else
                            {
                                deleteUser(id);
                                return false;
                            }
                        }
                    }
                    catch
                    {
                        deleteUser(id);
                        return false;
                    }
                    finally { connection.Close(); }
                }
            }
            else return false;
        }
        public static DataTable getAllRegisteredStudentsFromAllBranches()
        {
            DataTable dt = new DataTable();
            string query = "select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            dataAdapter.Fill(dt);
            return dt;
        }
        public static DataTable getAllRegisteredStudentsInSpecificBranch(int id)
        {
            DataTable dt = new DataTable();
            string query = $"select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID where r.ID_Branch = {id}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            dataAdapter.Fill(dt);
            return dt;
        }
        public static DataTable getAllRegisteredStudentsWithSpecificStatusFromAllBranches(int status)
        {
            DataTable dt = new DataTable();
            string query;
            if (status == 0 || status == 1)
                query = $"select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID where r.Is_Accepted = {status}";
            else
                query = $"select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID where r.Is_Accepted is null";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection); 
            dataAdapter.Fill(dt);
            return dt;
        }
        public static DataTable getAllRegisteredStudentsWithSpecificStatusInSpecificBranch(int id , int status)
        {
            DataTable dt = new DataTable();
            string query;
            if (status == 0 || status == 1)
                query = $"select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID where r.ID_Branch = {id} and r.Is_Accepted = {status}";
            else
                query = $"select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID where r.ID_Branch = {id} and r.Is_Accepted is null";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);  
            dataAdapter.Fill(dt);
            return dt;
        }
    }
}