using Database.DAL;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=LAPTOP-SF20PBIF;Database=TutorialDatabase;User Id=local;Password=Jios@2022;MultipleActiveResultSets=true";

            SelectData(connectionString);
            Console.WriteLine();

            //InsertData(
            //    connectionString,
            //    new StudentModel()
            //    {
            //        FirstName = "Seak Bing",
            //        LastName = "Teoh",
            //        DateOfBirth = new DateTime(2000, 10, 10),
            //        BloodType = "O+"
            //    });

            SelectDataDataTable(connectionString);
            Console.WriteLine();

            SelectDataEF();
            Console.WriteLine();

            //InsertDataEF(new Student()
            //{
            //    FirstName = "Kai Rui",
            //    LastName = "Low",
            //    DateOfBirth = new DateTime(1985, 03, 03),
            //    BloodType = "O+"
            //});

            UpdateDataEF(new Student()
            {
                Id = 5,
                FirstName = "Kai Rui",
                LastName = "Low",
                DateOfBirth = DateTime.Today,
                BloodType = "O+"
            });

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void SelectData(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Student", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        for (int columnCount = 0; columnCount < reader.FieldCount; columnCount++)
                        {
                            Console.Write($"{reader.GetName(columnCount)} \t");
                        }

                        Console.WriteLine();

                        while (reader.Read())
                        {
                            for (int columnCount = 0; columnCount < reader.FieldCount; columnCount++)
                            {
                                Console.Write($"{reader[columnCount]} \t");
                            }

                            Console.WriteLine();
                        }
                    }
                }

                connection.Close();
            }
        }

        private static void SelectDataDataTable(string connectionString)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Student", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }

                connection.Close();
            }

            foreach(DataColumn column in dataTable.Columns)
            {
                Console.Write($"{column.ColumnName} \t");
            }
            Console.WriteLine();

            foreach(DataRow row in dataTable.Rows)
            {
                Console.WriteLine(string.Join(" \t", row.ItemArray));
            }
        }

        private static void InsertData(string connectionString, StudentModel student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Student (FirstName, LastName, DateOfBirth, BloodType) VALUES (@FirstName, @LastName, @DateOfBirth, @BloodType)";
                    command.Parameters.Add(new SqlParameter("@Firstname", SqlDbType.NVarChar, 100)).Value = student.FirstName;
                    command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 100)).Value = student.LastName;
                    command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date)).Value = student.DateOfBirth.Date;
                    command.Parameters.Add(new SqlParameter("@BloodType", SqlDbType.NChar)).Value = student.BloodType;

                    Console.WriteLine($"Affected rows: {command.ExecuteNonQuery()}");
                }

                connection.Close();
            }
        }

        private static void SelectDataEF()
        {
            using(TutorialDatabaseContext databaseContext = new TutorialDatabaseContext())
            {
                List<Student> students = databaseContext.Students.ToList();

                var properties = typeof(Student).GetProperties();

                Console.WriteLine(
                    string.Join(
                        " \t",
                        properties.Select(property => property.Name)
                        )
                    );

                foreach (Student student in students)
                {
                    Console.WriteLine($"{student.Id} \t {student.FirstName} \t {student.LastName} \t {student.DateOfBirth} \t {student.BloodType}");
                }
            }
        }

        private static void InsertDataEF(Student student)
        {
            using (TutorialDatabaseContext tutorialDatabaseContext = new TutorialDatabaseContext())
            {
                tutorialDatabaseContext.Students.Add(student);
                tutorialDatabaseContext.SaveChanges();
            }
        }

        private static void UpdateDataEF(Student student)
        {
            using (TutorialDatabaseContext tutorialDatabaseContext = new TutorialDatabaseContext())
            {
                tutorialDatabaseContext.Students.Attach(student);
                tutorialDatabaseContext.Entry(student).State = System.Data.Entity.EntityState.Modified;

                tutorialDatabaseContext.SaveChanges();
            }
        }
    }
}
