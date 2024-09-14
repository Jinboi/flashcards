using Spectre.

namespace Flashcards
{
    internal static class Constants
    {
        // SQL Queries
        public const string CheckStacksTableQuery = @"
            SELECT COUNT(*) 
            FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_NAME = 'Stacks'";

        public const string CreateStacksTableQuery = @"
            CREATE TABLE Stacks (
                Stack_Primary_Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                Name NVARCHAR(50) NOT NULL
            )";

        public const string ShowAllStacksQuery = @"
            SELECT Stack_Primary_Id, Name
            FROM Stacks";

        // Colors
        public static readonly Color MainMenuColor = Color.White;
        public static readonly Color ManageStacksColor = Color.RosyBrown;
        public static readonly Color StudyColor = Color.Yellow;
        public static readonly Color StudyHistoryColor = Color.Orange3;
        public static readonly Color ManageFlashcardsColor = Color.Plum1;
        public static readonly Color CurrentStackMenuColor = Color.Gold1;

        // Messages
        public const string TableCreationSuccessMessage = "Table 'Stacks' created successfully.";
        public const string TableAlreadyExistsMessage = "Table already exists.";
        public const string StackNamePrompt = "Input Name of the Stack you want to work with Or Input 0 to Return to MainMenu";
        public const string InvalidCommandMessage = "\nInvalid Command. Please type a number from 0 to 6.\n";
        public const string GoodbyeMessage = "\nGoodbye!\n";
    }
}
