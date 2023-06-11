using MySql.Data.MySqlClient;

namespace Aassur;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
         count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
        
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