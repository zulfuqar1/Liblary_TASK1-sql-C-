using System.Data.SqlClient;
using System.Numerics;
using System.Xml.Linq;

var connectionStr = "Server=DESKTOP-Q15LSIL\\SQLEXPRESS;Database=CODE_DATABASE;Trusted_Connection=true";

SqlConnection conn= new SqlConnection(connectionStr);

//Users
void GetUsersList() 
{
    string query = "SELECT * FROM Users";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; Name:{reader[1]}; SurName:{reader[2]}; Phone:{reader[3]}; Adress:{reader[4]}; Email:{reader[5]}");
                }

            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void SetUsers(string Name,string SurName,string Phone,string Adress,string Email)
{
    string query = "INSERT INTO Users (Name,Surname,Phone,Adress,Email) VALUES (''+@Name+'',''+@SurName+'',''+@Phone+'',''+@Adress+'',''+@Email+'');";
    using(SqlConnection connection = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("SurName", SurName);
            command.Parameters.AddWithValue("Phone", Phone);
            command.Parameters.AddWithValue("Adress", Adress);
            command.Parameters.AddWithValue("Email", Email);


            conn.Open();
            var result = command.ExecuteNonQuery();

            if (result > 0 ) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User Createt");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        conn.Close();
    }
};

void GetUsersCount()
{
    string query = "SELECT COUNT(*) FROM Users";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            var result = comm.ExecuteScalar();
            Console.WriteLine($"User Count:{result}");
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        conn.Close();
    }
}

void SerachUsersByName(string search) 
{
    string query = "SELECT * FROM Users WHERE Name like '%'+@search+'%'";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("search", search);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; Name:{reader[1]}; SurName:{reader[2]}; Phone:{reader[3]}; Adress:{reader[4]}; Email:{reader[5]}");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void UpdateUser(int ID,string Name, string SurName, string Phone, string Adress, string Email)
{
    string query = "UPDATE Users SET Name=''+@Name+'',Surname=''+@SurName+'',Phone=''+@Phone+'',Adress=''+@Adress+'',Email=''+@Email+'' WHERE ID = ''+@ID+'';";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("Name", Name);
            cmd.Parameters.AddWithValue("SurName", SurName);
            cmd.Parameters.AddWithValue("Phone", Phone);
            cmd.Parameters.AddWithValue("Adress", Adress);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("ID", ID);

            conn.Open();
            var result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("User Updated");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void DeleteUsers(int ID)
{
    string query = "DELETE FROM Users WHERE ID=''+@ID+'';";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("ID", ID);

            conn.Open();
            var result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User Deleted");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}


//books
void GetBookList()
{
    string query = "SELECT * FROM Books";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; Name:{reader[1]}; ISBN:{reader[2]}; Pagecount:{reader[3]}");
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void SetBooks(string Name,string ISBN, int PageCount)
{
    string query = "INSERT INTO Books (Name,ISBN,PageCount) VALUES (''+@Name+'',''+@ISBN+'',''+@PageCount+'');";
    using (SqlConnection connection = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("ISBN", ISBN);
            command.Parameters.AddWithValue("PageCount", PageCount);

            conn.Open();
            var result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book Createt");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        conn.Close();
    }
};

void GetBookCount()
{
    string query = "SELECT COUNT(*) FROM Books";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            var result = comm.ExecuteScalar();
            Console.WriteLine($"Book Count:{result}");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        conn.Close();
    }
}

void SerachBooksByName(string search)
{
    string query = "SELECT * FROM Books WHERE Name like '%'+@search+'%'";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("search", search);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; Name:{reader[1]}; ISBN:{reader[2]}; Pagecount:{reader[3]}");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("book not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void SerachBooksByISBN(string search)
{
    string query = "SELECT * FROM Books WHERE ISBN like ''+@search+'%'";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("search", search);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; Name:{reader[1]}; ISBN:{reader[2]}; Pagecount:{reader[3]}");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("book not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void UpdateBooks(int ID, string Name, string ISBN, int PageCount)
{
    string query = "UPDATE Books SET Name=''+@Name+'',ISBN=''+@ISBN+'',PageCount=''+@PageCount+'' WHERE ID = ''+@ID+'';";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("Name", Name);
            cmd.Parameters.AddWithValue("ISBN", ISBN);
            cmd.Parameters.AddWithValue("PageCount", PageCount);
            cmd.Parameters.AddWithValue("ID", ID);

            conn.Open();
            var result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Book Updated");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void DeleteBooks(int ID)
{
    string query = "DELETE FROM Books WHERE ID=''+@ID+'';";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("ID", ID);

            conn.Open();
            var result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book Deleted");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}


//Borrowings
void GetAllBorrowings()
{
    string query = "SELECT * FROM Borrowings";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; UserID:{reader[1]}; BookID:{reader[2]}; Borrowing Date:{reader[3]}; Return Date:{reader[4]}");
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void GetBorrowingsCount()
{
    string query = "SELECT COUNT(*) FROM Borrowings";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            var result = comm.ExecuteScalar();
            Console.WriteLine($"Borrowing Count:{result}");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        conn.Close();
    }
}

void SetBorrowings(int UserID,int BookID, string BorrowingsDate, string ReturnDate)
{
    string query = "INSERT INTO Borrowings (UserID,BookID,BorrowingsDate,ReturnDate) VALUES (''+@UserID+'',''+@BookID+'',''+@BorrowingsDate+'',''+@ReturnDate+'');";
    using (SqlConnection connection = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("UserID", UserID);
            command.Parameters.AddWithValue("BookID", BookID);
            command.Parameters.AddWithValue("BorrowingsDate", BorrowingsDate);
            command.Parameters.AddWithValue("ReturnDate", ReturnDate);

            conn.Open();
            var result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Borrowing Createt");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        conn.Close();
    }
};

void SerachBorrowingByUserID(string UserID)
{
    string query = "SELECT * FROM Borrowings WHERE UserID like ''+@UserID+'%'";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("UserID", UserID);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; UserID:{reader[1]}; BookID:{reader[2]}; Borrowing Date:{reader[3]}; Return Date:{reader[4]}");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Borrowing not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void SerachBorrowingByBookID(string BookID)
{
    string query = "SELECT * FROM Borrowings WHERE BookID like ''+@BookID+'%'";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("BookID", BookID);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; UserID:{reader[1]}; BookID:{reader[2]}; Borrowing Date:{reader[3]}; Return Date:{reader[4]}");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Borrowing not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void SerachBorrowingByBorrowingsDate(string BorrowingsDate)
{
    string query = "SELECT * FROM Borrowings WHERE BorrowingsDate like '%'+@BorrowingsDate+'%'";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("BorrowingsDate", BorrowingsDate);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; UserID:{reader[1]}; BookID:{reader[2]}; Borrowing Date:{reader[3]}; Return Date:{reader[4]}");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Borrowing not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void SerachBorrowingByReturnDate(string ReturnDate)
{
    string query = "SELECT * FROM Borrowings WHERE ReturnDate like '%'+@ReturnDate+'%'";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("ReturnDate", ReturnDate);

            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id:{reader[0]}; UserID:{reader[1]}; BookID:{reader[2]}; Borrowing Date:{reader[3]}; Return Date:{reader[4]}");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Borrowing not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void UpdateBorrowing(int ID,int UserID, int BookID, string BorrowingsDate, string ReturnDate)
{
    string query = "UPDATE Borrowings SET UserID=''+@UserID+'',BookID=''+@BookID+'',BorrowingsDate=''+@BorrowingsDate+'',ReturnDate=''+@ReturnDate+'' WHERE ID = ''+@ID+'';";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("UserID", UserID);
            cmd.Parameters.AddWithValue("BookID", BookID);
            cmd.Parameters.AddWithValue("BorrowingsDate", BorrowingsDate);
            cmd.Parameters.AddWithValue("ReturnDate", ReturnDate);
            cmd.Parameters.AddWithValue("ID", ID);

            conn.Open();
            var result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Borrowing Updated");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Borrowing not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}

void DeleteBorrowings(int ID)
{
    string query = "DELETE FROM Borrowings WHERE ID=''+@ID+'';";
    using (SqlConnection conn = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("ID", ID);

            conn.Open();
            var result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Borrowing Deleted");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Borrowing not found !!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    };
    conn.Close();
}
