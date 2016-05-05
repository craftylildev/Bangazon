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

            List<Product> allProducts = new List<Product>();
            List<Product> orderList = new List<Product>();
            List<Customer> allCustomers = new List<Customer>();
            List<PaymentOption> allPaymentOptions = new List<PaymentOption>();

            // Product List Query
            #region
            string queryAllProducts = @"SELECT IdProduct, Name, Price FROM Product";            
            using (SqlConnection connection = new SqlConnection(bangazonPath))
            using (SqlCommand getOrderList = new SqlCommand(queryAllProducts, connection))
            {
                connection.Open();
                using (SqlDataReader reader = getOrderList.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            Product p = new Product(reader[0] as int? ?? 0, reader[1] as string, reader[2] as decimal? ?? 0);
                            allProducts.Add(p);
                            
                        }
                    }
                }
            }
            #endregion

            // Customer List Query
            #region
            string queryAllCustomers = @"SELECT IdCustomer, FirstName, LastName, Address, State, PostalCode, Phone FROM Customer";
            using (SqlConnection connection = new SqlConnection(bangazonPath))
            using (SqlCommand getCustomerList = new SqlCommand(queryAllCustomers, connection))
            {
                connection.Open();
                using (SqlDataReader reader = getCustomerList.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            Customer c = new Customer(reader[0] as int? ?? 0, reader[1] as string, reader[2] as string, reader[3] as string, reader[4] as string, reader[5] as string, reader[6] as string);
                            allCustomers.Add(c);

                        }
                    }
                }
            }
            #endregion

            // Payment Option Query
            #region
            //string queryPaymentOption = @"SELECT IdPaymentOption, IdCustomer, Name, AccountNumber FROM PaymentOption WHERE IdCustomer = " + selectCustomer;
            //using (SqlConnection connection = new SqlConnection(bangazonPath))
            //using (SqlCommand getPaymentList = new SqlCommand(queryPaymentOption, connection))
            //{
            //    connection.Open();
            //    using (SqlDataReader reader = getPaymentList.ExecuteReader())
            //    {
            //        // Check is the reader has any rows at all before starting to read.
            //        if (reader.HasRows)
            //        {
            //            // Read advances to the next row.
            //            while (reader.Read())
            //            {
            //                PaymentOption pt = new PaymentOption(reader[0] as int? ?? 0, reader[1] as int? ?? 0, reader[2] as string, reader[3] as string);
            //                allPaymentOptions.Add(pt);

            //            }
            //        }
            //    }
            //}
            #endregion

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
                #region          
                if (menuSelection == "1")
                {
                    Console.Clear();
                    Console.WriteLine("***** CREATE AN ACCOUNT *****\n");
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
                #endregion

                // MENU SELECTION 2 - CREATE A PAYMENT OPTION
                #region
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
                #endregion

                // MENU SELECTION 3 - ORDER A PRODUCT
                #region
                else if (menuSelection == "3")
                {
                    bool orderMenuVisible = true;
                    while (orderMenuVisible)
                    {
                        Console.Clear();
                        Console.WriteLine("***** ORDER A PRODUCT *****\n");

                        string displayInventoryList = @"SELECT IdProduct, Name, Price FROM Product";

                        using (SqlConnection connection = new SqlConnection(bangazonPath))
                        using (SqlCommand getProdList = new SqlCommand(displayInventoryList, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = getProdList.ExecuteReader())
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
                        
                        int orderChoice = Convert.ToInt32(Console.ReadLine());
                        if (orderChoice <= 6)
                        {
                            Product addThisProduct = allProducts[orderChoice - 1];
                            Console.WriteLine("Item {0} added to order: {1}", orderChoice, addThisProduct.Name);
                            orderList.Add(addThisProduct);
                            Console.WriteLine("\nANY KEY TO CONTINUE > ");
                            Console.ReadKey();
                            Console.WriteLine("\nENTER NUMBER ONLY > ");
                        }
                        else if (orderChoice == 7)
                        {
                            orderMenuVisible = false;
                        }
                    }
                }
                #endregion

                // MENU SELECTION 4 - COMPLETE AN ORDER
                else if (menuSelection == "4")
                {
                    Console.Clear();
                    if (orderList.Count == 0)
                    {
                        Console.WriteLine("PLEASE ADD ITEMS TO YOUR ORDER");
                        Console.WriteLine("PRESS ENTER TO RETURN TO MENU");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("***** COMPLETE AN ORDER *****\n");                                              
                        decimal totalPrice = 0;
                        foreach (Product p in orderList)
                        {
                            totalPrice += p.Price;
                        }
                        Console.WriteLine("YOUR ORDER TOTAL IS ${0}. READY TO PURCHASE?",
                            totalPrice);
                        Console.Write("(Y/N) > ");
                                                
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            Console.WriteLine("\nWHICH CUSTOMER IS PLACING THE ORDER?");

                            foreach (Customer c in allCustomers)
                            {
                                Console.WriteLine("{0}. {1} {2}", c.IdCustomer, c.FirstName, c.LastName);
                            }
                            Console.WriteLine("\nENTER NUMBER ONLY > ");
                            int selectCustomer = Convert.ToInt32(Console.ReadLine());
                            
                            string queryPaymentOption = @"SELECT IdPaymentOption, Name FROM PaymentOption WHERE IdCustomer = " + selectCustomer;
                            using (SqlConnection connection = new SqlConnection(bangazonPath))
                            using (SqlCommand getPaymentList = new SqlCommand(queryPaymentOption, connection))
                            {
                                connection.Open();
                                using (SqlDataReader reader = getPaymentList.ExecuteReader())
                                {
                                    // Check is the reader has any rows at all before starting to read.
                                    if (reader.HasRows)
                                    {
                                        // Read advances to the next row.
                                        while (reader.Read())
                                        {
                                            Console.WriteLine("{0}. {1}",
                                                reader[0], reader[1]);
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("\nSELECT A PAYMENT TYPE > ");
                            int selectPayment = Convert.ToInt32(Console.ReadLine());
                            
                            string newCustomerOrderInput = @"
                            INSERT INTO CustomerOrder
                                (IdCustomer, IdPaymentOption)
                            VALUES
                                ('" + selectCustomer + "', '" + selectPayment + "')";

                                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(bangazonPath);

                                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.CommandText = newCustomerOrderInput;
                                cmd.Connection = sqlConnection1;

                                sqlConnection1.Open();
                                cmd.ExecuteNonQuery();
                                sqlConnection1.Close();

                            // get current/highest auto incremented IdOrder from CustomerOrder
                            int lastInvoiceNumber = 0;

                            string getLastInvoice = @"SELECT MAX(IdOrder) FROM CustomerOrder";
                            using (SqlConnection connection = new SqlConnection(bangazonPath))
                            using (SqlCommand getInvoice = new SqlCommand(getLastInvoice, connection))
                            {
                                connection.Open();
                                using (SqlDataReader reader = getInvoice.ExecuteReader())
                                {
                                    // Check if the reader has any rows at all before starting to read.
                                    if (reader.HasRows)
                                    {
                                        // Read advances to the next row.
                                        while (reader.Read())
                                        {
                                            lastInvoiceNumber = reader[0] as int? ?? 0;
                                        }
                                    }
                                }
                            }

                            foreach (Product p in orderList)
                            {
                                string newOrderProductsInput = @"
                                INSERT INTO OrderProducts
                                    (IdProduct, IdOrder)
                                VALUES
                                    ('" + p.IdProduct + "', '" + lastInvoiceNumber + "')";

                                    System.Data.SqlClient.SqlConnection sqlConnection2 = new System.Data.SqlClient.SqlConnection(bangazonPath);

                                    System.Data.SqlClient.SqlCommand inputOrderProducts = new System.Data.SqlClient.SqlCommand();
                                    inputOrderProducts.CommandType = System.Data.CommandType.Text;
                                    inputOrderProducts.CommandText = newOrderProductsInput;
                                    inputOrderProducts.Connection = sqlConnection2;

                                    sqlConnection2.Open();
                                    inputOrderProducts.ExecuteNonQuery();
                                    sqlConnection2.Close();
                                
                            }

                            Console.WriteLine("\n\nYOUR ORDER IS COMPLETE! PRESS ANY KEY TO RETURN TO MAIN MENU.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("PRESS ANY KEY TO RETURN TO MAIN MENU");
                            Console.ReadKey();
                        }
                    }
                }


                // MENU SELECTION 5 - SEE PRODUCT POPULARITY
                else if (menuSelection == "5")
                {
                    Console.Clear();

                    foreach ()
                    { }
                    //p.Name ordered COUNT(IdProduct) times by COUNT(IdCustomer) customers for total revenue of SUM(p.Price).



                    Console.ReadKey();
                }

                // MENU SELECTION 6 - LEAVE BANGAZON
                else if (menuSelection == "6")
                {
                    programEnded = true;
                    break;
                }
                else
                {
                    Console.WriteLine("PLEASE SELECT FROM MENU");
                }
                
            } // END WHILE PROGRAM ENDED
            
        } // END MAIN
    } // END PROGRAM
} // END NAMESPACE