using PetCarePro.Data;

namespace PetCarePro;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Database en tabellen aanmaken
        DatabaseHelper.InitializeDatabase();

        // Applicatie starten
        Application.Run(new Form1());
    }
}