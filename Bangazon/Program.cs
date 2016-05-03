using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Bangazon
{
    class Program
    {
        static void Main(string[] args)
        {

            bool programEnded = false;
            string bangazonPath = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\jen solima\\documents\\visual studio 2015\\Projects\\Bangazon\\Bangazon\\BangazonDatabase.mdf\"; Integrated Security = True";

            while (!programEnded)
            {
                Console.Clear();
                StringBuilder menu = new StringBuilder();
                menu.AppendLine("*********************************************************");
                menu.AppendLine("* *Welcome to Bangazon!Command Line Ordering System * *");
                menu.AppendLine("*********************************************************");
                menu.AppendLine("1.Create an account");
                menu.AppendLine("2.Create a payment option");
                menu.AppendLine("3.Order a product");
                menu.AppendLine("4.Complete an order");
                menu.AppendLine("5.See product popularity");
                menu.AppendLine("6.Leave Bangazon!");
                menu.AppendLine(">");
                Console.WriteLine(menu.ToString());

                string menuSelection = Console.ReadKey().KeyChar.ToString();

// MENU SELECTION 1 - CREATE AN ACCOUNT
                if (menuSelection == "1")
                {
                    Console.Clear();
                    Console.WriteLine("***** CREATE AN ACCOUNT *****\n");
                    //Console.Write("ENTER ID >");
                    //string customerId = Console.ReadLine();
                    Console.Write("ENTER FIRST NAME > ");
                    string firstName = Console.ReadLine();
                    Console.Write("ENTER LAST NAME > ");
                    string lastName = Console.ReadLine();
                    Console.Write("ENTER STREET ADDRESS > ");
                    string address = Console.ReadLine();
                    Console.Write("ENTER CITY > ");
                    string city = Console.ReadLine();
                    Console.Write("ENTER STATE > ");
                    string state = Console.ReadLine();
                    Console.Write("ENTER POSTAL CODE > ");
                    string postal = Console.ReadLine();
                    Console.Write("ENTER PHONE NUMBER > ");
                    string phone = Console.ReadLine();

                    string newCustInput = @"
                        INSERT INTO Customer
                            (FirstName, LastName, Address, City, State, PostalCode, Phone)
                        VALUES
                            ('" + firstName + "', '" + lastName + "', '" + address + "', '" + city + "', '" + state + "', '" + postal + "', '" + phone + "')";

                    System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(bangazonPath);

                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = newCustInput;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    Console.WriteLine("\nCUSTOMER * {0} {1} * ADDED", firstName, lastName);
                    Console.WriteLine("PRESS ANY KEY TO RETURN TO MAIN MENU");
                    Console.ReadKey();

                }

// MENU SELECTION 2 - CREATE A PAYMENT OPTION
                else if (menuSelection == "2")
                {
                    Console.Clear();
                    Console.WriteLine("***** SELECT A PAYMENT OPTION *****\n");
                    Console.WriteLine("WHICH CUSTOMER?\n");

                    string displayCustList = @"SELECT IdCustomer, FirstName, LastName FROM Customer";

                    using (SqlConnection connection = new SqlConnection(bangazonPath))
                    using (SqlCommand getCustList = new SqlCommand(displayCustList, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = getCustList.ExecuteReader())
                        {
                            // Check is the reader has any rows at all before starting to read.
                            if (reader.HasRows)
                            {
                                // Read advances to the next row.
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0}. {1} {2}",
                                        reader[0], reader[1], reader[2]);
                                }
                            }
                        }
                    }

                    Console.Write("ENTER NUMBER ONLY > ");
                    int idCustomer = Convert.ToInt32(Console.ReadLine());
                    //int idCustomer = Console.ReadKey().KeyChar;

                    Console.Write("ENTER PAYMENT TYPE (ex. Visa, Amex, Checking) > ");
                    string paymentName = Console.ReadLine();

                    Console.Write("ENTER ACCOUNT NUMBER > ");
                    string accountNumber = Console.ReadLine();


                    string newPaymentInput = @"
                        INSERT INTO PaymentOption
                            (IdCustomer, Name, AccountNumber)
                        VALUES
                            ('" + idCustomer + "', '" + paymentName + "', '" + accountNumber + "')";

                    System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(bangazonPath);

                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = newPaymentInput;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    Console.WriteLine("\nPAYMENT * {0} {1} * ADDED", paymentName, accountNumber);
                    Console.WriteLine("PRESS ANY KEY TO RETURN TO MAIN MENU");
                    Console.ReadKey();

                }

// MENU SELECTION 3 - ORDER A PRODUCT
                else if (menuSelection == "3")
                {
                    Console.Clear();
                    Console.WriteLine("***** ORDER A PRODUCT *****\n");

                    string displayInventoryList = @"SELECT IdProduct, Name, Price FROM Product";

                    using (SqlConnection connection = new SqlConnection(bangazonPath))
                    using (SqlCommand getCustList = new SqlCommand(displayInventoryList, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = getCustList.ExecuteReader())
                        {
                            // Check is the reader has any rows at all before starting to read.
                            if (reader.HasRows)
                            {
                                // Read advances to the next row.
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0}. {1} {2}",
                                        reader[0], reader[1], reader[2]);
                                    
                                }
                            }
                        }
                    }
                    Console.WriteLine("7. BACK TO MAIN MENU");
                    Console.Write("\nENTER NUMBER ONLY > ");
                    int idProduct = Convert.ToInt32(Console.ReadLine());





                }










                else if (menuSelection == "4")
                            {
                                Console.Clear();
                                Console.WriteLine("\nYOU ENTERED {0}.COMPLETE AN ORDER");
                            }
                            else if (menuSelection == "5")
                            {
                                Console.Clear();
                                Console.WriteLine("\nYOU ENTERED {0}.SEE PRODUCT POPULARITY");
                            }
                            else if (menuSelection == "6")
                            {
                                programEnded = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("PLEASE SELECT FROM MENU");
                            }
                            //using (SqlConnection connection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\Jen Solima\\documents\\visual studio 2015\\Projects\\Bangazon\\Bangazon\\BangazonDatabase.mdf\"; Integrated Security = True"))
                            //using (SqlCommand cmd = new SqlCommand(query, connection))
                            //{
                            //    connection.Open();
                            //    using (SqlDataReader reader = cmd.ExecuteReader())
                            //    {
                            //        // Check is the reader has any rows at all before starting to read.
                            //        if (reader.HasRows)
                            //        {
                            //            // Read advances to the next row.
                            //            while (reader.Read())
                            //            {
                            //                Console.WriteLine("test");
                            //            }

                            //        }
                            //    }
                            //}


                            // Console.ReadLine();

                        }



             
        }
    }
}