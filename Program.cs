using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Library
{
    class Client
    {
        private int id;
        public string name;
        string surname;
        int year_of_birth;
        string email;

        IDictionary<int, string> client_data = new Dictionary<int, string>()
        {   
            {0, "1234"},
            {1, "saba"},
            {2, "mirza"},
            {3, "2003"},
            {4, "sadsaba@gmail.com"},
            //
            {5, "2874"},
            {6, "sabsaa"},
            {7, "miasdarza"},
            {8, "2001"},
            {9, "dasfa@gmail.com"}
        };

        public void GetData()
        {
            Random rnd = new Random();
            id = rnd.Next(9999);

            Console.Write("\nEnter name: ");
            name = Console.ReadLine();

            Console.Write("Enter surname: ");
            surname = Console.ReadLine();

            Console.Write("Enter year of birth: ");
            year_of_birth = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter email: ");
            email = Console.ReadLine();
        }
        public void ShowData()
        {
            Console.WriteLine("\nYOUR CREDENTIALS");
            Console.Write("\nid: {0}", id);
            Console.WriteLine(" (MUST REMEMBERED)");
            Console.WriteLine("name: {0}", name);
            Console.WriteLine("surname: {0}", surname);
            Console.WriteLine("year of birth: {0}", year_of_birth);
            Console.WriteLine("email: {0}", email);
        }
        public string [] GetFullInfo()
        {
            string [] FullInfo = { id.ToString(), name, surname, year_of_birth.ToString(), email };
            return FullInfo;
        } 

        public void CreateClient()
        {
            GetData();

            foreach(string i in GetFullInfo())
            {
                client_data.Add(client_data.Count + 1, i);       
            }

            ShowData();
    }

        public void AuthClient(string x)
        {

            IDictionary<int, string> id_collection = new Dictionary<int, string>();

            for(int i = 0; i<client_data.Count; i++)
            {
                if (i % 5 == 0)
                {
                    id_collection.Add(id_collection.Count + 1, client_data[i]);
                }
            }

            string result;


            for(int i = 0; i<= id_collection.Count; i++)
            {
                if (id_collection.TryGetValue(i, out result))
                {
                    if (result == x)
                    {
                        DashboardClient(x);
                    }
                }
            }   
        }

        public void DashboardClient(string x)
        {
            Console.WriteLine("\n\tIts Your Dashboard");
            Console.WriteLine("1.See Book List");
            Console.WriteLine("2.Edit Credentials");
            Console.WriteLine("3.Delete my account");

            string choice;
            choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Books booksObj = new Books();
                    booksObj.ShowData();
                    Console.WriteLine("\n1.borrow book");
                    Console.WriteLine("2.return book");
                    string cho;
                    cho = Console.ReadLine();

                    if (cho == "1")
                    {
                        Console.WriteLine("\nEnter book's title to borrow: ");
                        string bookTitle;
                        bookTitle = Console.ReadLine();

                        for(int i =0; i<client_data.Count; i++)
                        {
                            if(client_data[i] == x)
                            {
                                string borrowerName = client_data[i + 1];
                                
                                booksObj.BorrowBook(borrowerName, bookTitle);
                                break;
                            }
                        }
                    }
                    else if (cho == "2")
                    {
                        Console.WriteLine("\nEnter book's title to return: ");
                        string bookTitle;
                        bookTitle = Console.ReadLine();

                        for (int i = 0; i < client_data.Count; i++)
                        {
                            if (client_data[i] == x)
                            {
                                string returnerName = client_data[i + 1];

                                booksObj.ReturnBook(returnerName, bookTitle);
                                break;
                            }
                        }
                    }
                    break;
                case "2":
                    EditClient(x);
                    break;
                case "3":
                    DeleteClient(x);
                    break;
            }
        }
        public void EditClient(string x)
        {
            for (int i = 0; i < client_data.Count; i++)
            {
                if (client_data[i] == x)
                {
                    GetData();
                    client_data[i + 1] = name;
                    client_data[i + 2] = surname;
                    client_data[i + 3] = year_of_birth.ToString();
                    client_data[i + 4] = email;
                    Console.WriteLine("Your account has been successfully edited!");
                }
            }
        }
        public void DeleteClient(string x)
        {
            for(int i =0; i<client_data.Count; i++)
            {
                if(client_data[i] == x)
                {
                    client_data.Remove(i);
                    client_data.Remove(i+1);
                    client_data.Remove(i+2);
                    client_data.Remove(i+3);
                    client_data.Remove(i+4);
                    Console.WriteLine("Your account has been successfully deleted!");
                }
            }
        }
    }


    class Stuff
    {
        private int id;
        string name;
        string surname;
        int year_of_birth;
        string email;

        IDictionary<int, string> stuff_data = new Dictionary<int, string>()
        {
            {0, "1234"},
            {1, "saba"},
            {2, "mirza"},
            {3, "2003"},
            {4, "sadsaba@gmail.com"},
            //
            {5, "2874"},
            {6, "sabsaa"},
            {7, "miasdarza"},
            {8, "2001"},
            {9, "dasfa@gmail.com"}
        };

        public void GetData()
        {
            Random rnd = new Random();
            id = rnd.Next(9999);

            Console.Write("\nEnter name: ");
            name = Console.ReadLine();

            Console.Write("\nEnter surname: ");
            surname = Console.ReadLine();

            Console.Write("\nEnter year of birth: ");
            year_of_birth = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter email: ");
            email = Console.ReadLine();


        }
        public void ShowData()
        {
            Console.WriteLine("YOUR CREDENTIALS");
            Console.Write("\nid: {0}", id);
            Console.WriteLine(" (MUST REMEMBERED)");
            Console.WriteLine("name: {0}", name);
            Console.WriteLine("surname: {0}", surname);
            Console.WriteLine("year of birth: {0}", year_of_birth);
            Console.WriteLine("email: {0}", email);
        }
        public int GetId()
        {
            return id;
        }
        public string[] GetFullInfo()
        {
            string[] FullInfo = { id.ToString(), name, surname, year_of_birth.ToString(), email };
            return FullInfo;
        }
        public void CreateStuff()
        {
            GetData();

            foreach (string i in GetFullInfo())
            {
                stuff_data.Add(stuff_data.Count + 1, i);
            }
            ShowData();
        }
        public void AuthStuff(string x)
        {
            IDictionary<int, string> id_collection = new Dictionary<int, string>();

            for (int i = 0; i < stuff_data.Count; i++)
            {
                if (i % 5 == 0)
                {
                    id_collection.Add(id_collection.Count + 1, stuff_data[i]);
                }
            }

            string result;


            for (int i = 0; i <= id_collection.Count; i++)
            {
                if (id_collection.TryGetValue(i, out result))
                {
                    if (result == x)
                    {
                        DashboardStuff(x);
                    }
                }
            }
        }
        public void DashboardStuff(string x)
        {
            Console.WriteLine("\n\tIts Your Dashboard");
            Console.WriteLine("1.See Book List");
            Console.WriteLine("2.Edit Credentials");
            Console.WriteLine("3.Delete my account");
            Console.WriteLine("4.See the history");

            string choice;
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Books booksObj = new Books();
                    booksObj.ShowData();
                    Console.WriteLine("You have some privileges as you are stuff member, what do you want to do?");
                    Console.WriteLine("1.Add Book");
                    Console.WriteLine("2.Edit Book");
                    Console.WriteLine("3.Delete Book");
                    int cho;
                    cho = Convert.ToInt32(Console.ReadLine());
                    if(cho == 1)
                    {
                        booksObj.AddBook();
                    }
                    else if(cho == 2)
                    {
                        Console.WriteLine("Enter title: ");
                        string a;
                        a = Console.ReadLine();
                        booksObj.EditBook(a);
                    }
                    else if(cho == 3)
                    {
                        Console.WriteLine("Enter title: ");
                        string b;
                        b = Console.ReadLine();
                        booksObj.DeleteBook(b);
                    }

                    break;
                case "2":
                    EditStuff(x);
                    break;
                case "3":
                    DeleteStuff(x);
                    break;
                case "4":
                    History historyObj = new History();
                    historyObj.ShowHistory();
                    break;
            }
        }
        public void EditStuff(string x)
        {
            for (int i = 0; i < stuff_data.Count; i++)
            {
                if (stuff_data[i] == x)
                {
                    GetData();
                    stuff_data[i + 1] = name;
                    stuff_data[i + 2] = surname;
                    stuff_data[i + 3] = year_of_birth.ToString();
                    stuff_data[i + 4] = email;
                    Console.WriteLine("Your account has been successfully edited!");
                }
            }
        }
        public void DeleteStuff(string x)
        {
            for (int i = 0; i < stuff_data.Count; i++)
            {
                if (stuff_data[i] == x)
                {
                    stuff_data.Remove(i);
                    stuff_data.Remove(i + 1);
                    stuff_data.Remove(i + 2);
                    stuff_data.Remove(i + 3);
                    stuff_data.Remove(i + 4);
                    Console.WriteLine("Your account has been successfully deleted!");
                }
            }
        }
    }

    class Books
    {
        string title;
        string author;
        int productionYear;
        bool borrowed;

        IDictionary<int, string> books_data = new Dictionary<int, string>()
        {
            {0, "megobrebi1"},
            {1, "xuani1"},
            {2, "2002"},
            {3, "false"},
            //
            {4, "megobrebi2"},
            {5, "xuani2"},
            {6, "2003"},
            {7, "false"},
            //
            {8, "megobrebi3"},
            {9, "xuani3"},
            {10, "2004"},
            {11, "false"}

            //
        };

        public void ShowData()
        {
            Console.WriteLine("\nBOOK LIST:");
            for(int i=0; i<books_data.Count; i+=4)
            {
                Console.Write("{0}, author: {1}, ({2}) ", books_data[i], books_data[i + 1], books_data[i + 2]);
                if(books_data[i + 3] == "false")
                {
                    Console.WriteLine("(available)");
                } else
                {
                    Console.WriteLine("(is not available available)");
                }
            }
        }

        public void GetBook()
        {
            Console.Write("\nEnter title: ");
            title = Console.ReadLine();

            Console.Write("\nEnter author: ");
            author = Console.ReadLine();

            Console.Write("\nEnter year of production: ");
            productionYear = Convert.ToInt32(Console.ReadLine());

            borrowed = false;
        }


        public string[] GetFullInfo()
        {
            string[] FullInfo = { title, author, productionYear.ToString(), borrowed ? "available" : "not available" };
            return FullInfo;
        }

        public void AddBook()
        {
            GetBook();
            foreach(string i in GetFullInfo())
            {
                books_data.Add(books_data.Count + 1, i);
            }
            ShowData();
        }
        public void EditBook(string x)
        {
            for (int i = 0; i < books_data.Count; i++)
            {
                if (books_data[i] == x)
                {
                    GetBook();
                    books_data[i] = title;
                    books_data[i + 1] = author;
                    books_data[i + 2] = productionYear.ToString();
                    Console.WriteLine("book has been successfully edited!");

                }
            }
        }
        public void DeleteBook(string x)
        {
            for (int i = 0; i < books_data.Count; i++)
            {
                if (books_data[i] == x)
                {
                    books_data.Remove(i);
                    books_data.Remove(i + 1);
                    books_data.Remove(i + 2);
                    books_data.Remove(i + 3);
                    Console.WriteLine("book has been successfully deleted!");
                }
            }
        }
        public void BorrowBook(string borrowerName, string bookTitle)
        {
            for (int i = 0; i < books_data.Count; i++)
            {
                if (books_data[i] == bookTitle && books_data[i + 3] == "false")
                {
                    books_data[i + 3] = true.ToString();
                    Console.WriteLine("the book has been successfully borrowed");

                    string operation = "borrow";

                    History historyObj = new History();
                    historyObj.AddHistory(borrowerName, bookTitle, operation);
                    
                    break;
                }
            }
        }
        public void ReturnBook(string returnerName, string bookTitle)
        {
            for (int i = 0; i < books_data.Count; i++)
            {
                if (books_data[i] == bookTitle && books_data[i + 3] == "true")
                {
                    books_data[i + 3] = false.ToString();
                    Console.WriteLine("the book has been successfully returned");

                    string operation = "return";

                    History historyObj = new History();
                    historyObj.AddHistory(returnerName, bookTitle, operation);

                    break;
                }
            }
        }
    }

    class History
    {
        string personName;
        string title;
        string status;
        DateTime time;


        IDictionary<int, string> history_data = new Dictionary<int, string>()
        {
            {0, "satauri1"},
            {1, "xuani1"},
            {2, "11/1/2021 12:30:12 PM"},
            {3, "borrowed"},

            {4, "satauri2"},
            {5, "xuani2"},
            {6, "10/1/2021 04:30:12 PM"},
            {7, "returned"},
        };

        public void ShowHistory()
        {
            Console.WriteLine("\n\tHISTORY: ");

            for (int i = 0; i< history_data.Count; i+=4)
            {
                Console.Write("\nbook \"{0}\" has been {1} by {2} ({3})", history_data[i], history_data[i + 3], history_data[i + 1], history_data[i + 2]);
            }
        }

        public void AddHistory(string name, string bookTitle, string operation)
        {
            personName = name;
            title = bookTitle;
            if (operation == "borrow") status = "borrowed";
            if (operation == "return") status = "returned";
            time = DateTime.Now;

            history_data.Add(history_data.Count + 1, title);
            history_data.Add(history_data.Count + 1, personName);
            history_data.Add(history_data.Count + 1, time.ToString());
            history_data.Add(history_data.Count + 1, status);

        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Client clientObj = new Client();
            Stuff stuffObj = new Stuff();

            Console.WriteLine("\t\tWelcome to our international library");
            Console.WriteLine("\nLet's continue as a");
            Console.WriteLine("1.Client");
            Console.WriteLine("2.Staff");

            string choice;
            choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.WriteLine("\nChoose one of them");
                    Console.WriteLine("1.I am existing client");
                    Console.WriteLine("2.I want to become client");

                    int cho;
                    cho = Convert.ToInt32(Console.ReadLine());

                    if(cho == 1)
                    {
                        Console.WriteLine("\nLet's authorize");
                        Console.WriteLine("Enter your id: ");
                        string id;
                        id = Console.ReadLine();
                        clientObj.AuthClient(id);

                    } else if (cho == 2)
                    {
                        clientObj.CreateClient();
                    }

                    break;
                case "2":
                    Console.WriteLine("\nChoose one of them");
                    Console.WriteLine("1.I am existing member of stuff");
                    Console.WriteLine("2.I want to become a member of stuff");

                    int cho1;
                    cho1 = Convert.ToInt32(Console.ReadLine());

                    if (cho1 == 1)
                    {
                        Console.WriteLine("\nLet's authorize");
                        Console.WriteLine("Enter your id: ");
                        string id;
                        id = Console.ReadLine();
                        stuffObj.AuthStuff(id);

                    }
                    else if (cho1 == 2)
                    {
                        stuffObj.CreateStuff();
                    }
                    break;
            }
        }
    }
}