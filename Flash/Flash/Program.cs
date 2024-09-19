using Flashcards.ConsoleApp.Views;

namespace Flash;
public static class Configuration
{
    public static string ConnectionString { get; } = "Data Source=(LocalDB)\\LocalDBDemo;Integrated Security=True";
}
class Program
{
    static void Main(string[] args)
    {
        MainMenuPage.Show();
    }
}



