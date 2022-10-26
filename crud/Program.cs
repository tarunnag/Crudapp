using System;
using System.Data.SqlClient;
namespace crud
{
    class program
    {
        static void Main(string[] args)
        {
            string connectionstring = @"Data Source=Moback;Initial Catalog=employee2;Integrated Security=True";
            SqlConnection sqlconnection=new SqlConnection(connectionstring);
            sqlconnection.Open();
            try
            {
                Console.WriteLine("connection string established");
                string answer;
                do
                {
                    Console.WriteLine("select from the option below \n1.Creation \n2.Retrieve \n3.update \n.4 delete");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case (1):
                            //create crud
                            Console.WriteLine("enter the name");
                            string ename = Console.ReadLine();
                            Console.WriteLine("enter the age ");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter the salary:");
                            float salary = float.Parse(Console.ReadLine());
                            Console.WriteLine("enter the salaryid");
                            int salid = int.Parse(Console.ReadLine());
                            string insertquery = "insert into details(ename,eage,esalary,esalaryid) values('" + ename + "'," + age + "," + salary + "," + salid + ")";
                            SqlCommand insertcommand = new SqlCommand(insertquery, sqlconnection);
                            insertcommand.ExecuteNonQuery();
                            Console.WriteLine("data inserted to the table");
                            break;
                        //Retrieve => R
                        case (2):
                            string display = "select * from details";
                            SqlCommand displaycommand = new SqlCommand(display, sqlconnection);
                            SqlDataReader datareader = displaycommand.ExecuteReader();
                            while (datareader.Read())
                            {
                                Console.WriteLine("eid :" + datareader.GetValue(0).ToString());
                                Console.WriteLine("ename :" + datareader.GetValue(1).ToString());
                                Console.WriteLine("eage :" + datareader.GetValue(2).ToString());
                                Console.WriteLine("esalary :" + datareader.GetValue(3).ToString());
                                Console.WriteLine("esalid :" + datareader.GetValue(4).ToString());
                            }
                            datareader.Close();
                            break;
                        //update
                        case (3):
                            int e_id;
                            float e_salary;
                            Console.WriteLine("enter the id that you would like to update");
                            e_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter the salary to update");
                            e_salary = float.Parse(Console.ReadLine());
                            string updateQuery = "update details set esalary = " + e_salary + "where empid= " + e_id + "";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlconnection);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("data updated successfully");
                            break;
                        //delete
                        case (4):
                            int d_id;
                            Console.WriteLine("enter the id to be deleted");
                            d_id = int.Parse(Console.ReadLine());
                            string deleteQuery = "delete from details where empid =" + d_id;
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlconnection);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Deleted successfully");
                            break;
                        default:
                            Console.WriteLine("invalid input");
                            break;

                    }
                    Console.WriteLine("do you want to continue?");
                    answer = Console.ReadLine();
                } while (answer != "No");


                sqlconnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}