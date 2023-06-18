using System.Data.SqlClient;

var connectionStr = "Server=DESKTOP-Q15LSIL\\SQLEXPRESS;Database=CODE_DATABASE;Trusted_Connection=true";

SqlConnection conn= new SqlConnection(connectionStr);


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
    string query = $"INSERT INTO Users (Name,Surname,Phone,Adress,Email) VALUES ('{Name}','{SurName}','{Phone}','{Adress}','{Email}');";
    using(SqlConnection connection = new SqlConnection(connectionStr))
    {
        try
        {
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            var result = command.ExecuteNonQuery();

            if (result > 0 ) 
            {
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



SetUsers("Yegane","Aliyeva","55-227-76-24","yeravan","Y@gmail.com");


GetUsersList();