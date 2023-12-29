using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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

        public static DataTable getSubjectFromBranchForSpecificYear(int id , int year)
        {
            DataSet ds = new DataSet();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id} and sb.Year_Number = {year}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getSubjectFromBranchForSpecificYearForSpecificSemester(int id, int year , int semester)
        {
            DataSet ds = new DataSet();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id} and sb.Year_Number = {year} and sb.Semester_Number = {semester}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getAllStudents()
        {
            DataSet ds = new DataSet();
            string query = "select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID\r\n";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getStudentRegisteredInSpecificBranch(int id)
        {
            DataSet ds = new DataSet();
            string query = $"select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID where r.ID_Branch = {id}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getRegisteredStudents(string status)
        {
            DataSet ds = new DataSet();
            string query = $"select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID where r.Is_Accepted ={status}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable getRegisteredStudentsInSpecificBranch(int id ,string status)
        {
            DataSet ds = new DataSet();
            string query = $"select r.ID,u.First_Name,u.Last_Name,u.Gender,u.Phone_Number,us.Degree,b.Branch_Name,r.Is_Accepted from Registrations r inner join Users u on r.ID_Student = u.ID inner join User_Students us on u.ID = us.ID inner join Branches b on r.ID_Branch = b.ID where r.ID_Branch ={id} and r.Is_Accepted ={status}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }

    }
}