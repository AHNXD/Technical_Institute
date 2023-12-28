using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Technical_Institute
{
    public static class ConnectionToTheData
    {
        static string connectionString = "Data Source=AHN\\SQLEXPRESS;database=Technical_Institute;Integrated Security=SSPI";
        static int x = 0;
        public static DataSet getAllBranches()
        {
            DataSet ds = new DataSet();
            string query = "select b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree,SUM(s.Theoretical_Hours+s.Practical_Hours)'NumberOfHours' from Branches b inner join SubjectsToBranches s on b.ID = s.ID_Branch group by b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds;
        }
        public static DataSet getBranch(int id)
        {
            DataSet ds = new DataSet();
            string query = $"select b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree,SUM(s.Theoretical_Hours+s.Practical_Hours)'NumberOfHours' from Branches b inner join SubjectsToBranches s on b.ID = s.ID_Branch where b.ID = {id} group by b.id,b.Branch_Name,b.NumberOfYear,b.Minimum_Degree";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds;
        }
        public static DataSet getSubjectFromBranch(int id)
        {
            DataSet ds = new DataSet();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet getSubjectFromBranchForSpecificYear(int id , int year)
        {
            DataSet ds = new DataSet();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id} and sb.Year_Number = {year}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds;
        }
        public static DataSet getSubjectFromBranchForSpecificYearForSpecificSemester(int id, int year , int semester)
        {
            DataSet ds = new DataSet();
            string query = $"select s.ID,s.Subject_Name,sb.Year_Number,sb.Semester_Number,sb.Theoretical_Hours,sb.Practical_Hours,(sb.Theoretical_Hours+sb.Practical_Hours) 'Sum' from Subjects s inner join SubjectsToBranches sb on s.ID = sb.ID_Subject where sb.ID_Branch = {id} and sb.Year_Number = {year} and sb.Semester_Number = {semester}";
            var dbConnection = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(query, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(ds);
            return ds;
        }
    }
}