using Aassur.Core.Model;
using MySql.Data.MySqlClient;
using SQLite;

namespace Aassur;

public partial class MainPage : ContentPage
{
    int count = 0;
    private SQLiteConnection conn;

    public MainPage()
    {
        InitializeComponent();
    }
    
    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection("D:\\Projets\\App\\Aassur\\Aassur\\Core\\DataBase\\Aassur.db");
        conn.CreateTable<Client>();
        
        
    }
    public void AddNewPerson(string name)
    {
        int result = 0;
        try
        {
            Init();

            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            result = conn.Insert(new Client { FirstName = name });
        }
        catch (Exception)
        {
            //
        }
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
         count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
        
        AddNewPerson("Johnny");
        
        var connStr = "server=localhost;user=root;database=aassur;port=3306;password=2001";
        
        using (var conn = new MySqlConnection(connStr))
        {
            conn.Open();

            string sql = "INSERT INTO client (CivilityId, FirstName, LastName) VALUES (@civilityId, @firstName, @lastName)";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                // Remplacez les valeurs suivantes par les données que vous voulez insérer
                cmd.Parameters.AddWithValue("@civilityId", 1);
                cmd.Parameters.AddWithValue("@firstName", "John");
                cmd.Parameters.AddWithValue("@lastName", "Doe");

                cmd.ExecuteNonQuery();
            }
            
            using (var cmd = new MySqlCommand("SELECT * FROM client", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString());
                    }
                }
            }
        }
    }
}