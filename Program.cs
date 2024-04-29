using cat.itb.M6UF3EA2.helpers;
using cat.itb.M6UF3EA4.cruds;

namespace cat.itb.M6UF3EA4;

public class Driver
{
    public static void Main()
    {
        const string MenuTitle = "Select one of the activities";
        const string AskValue = "Provide me with the option index: ";
        const string SplitText = ". ";
        const string ExitText = "Exit";
        const string ExitOption = "0";
        Menu mainMenu = new Menu(MenuTitle, new Dictionary<string, string>()
        {
            {"1","Import restaurants"},
            {"2A", "Group and count cuisines"},
            {"2B", "Show amount of grades"},
            {"2C", "Show maximum score on each restaurant" },
            {"2D", "Cuissine for each borough"},
            {ExitOption,ExitText}
        }, AskValue);
        string option;

        do
        {
            Console.Write(mainMenu.ToString(SplitText));
            option = Console.ReadLine();

            switch (option.Trim().ToUpper())
            {
                case "1":
                    EA4CRUD.ACT1InsertFiles();
                    break;
                case "2A":
                    Console.WriteLine(EA4CRUD.ACT2AShowRestaurant());
                    break;
                case "2B":
                    Console.WriteLine(EA4CRUD.ACT2BShowRestaurant());
                    break;
                case "2C":
                    Console.WriteLine(EA4CRUD.ACT2CShowRestaurant());
                    break;
                case "2D":
                    Console.WriteLine(EA4CRUD.ACT2DShowTypeForEachBorough());
                    break;
            }
        } while (option != ExitOption);
    }
}
