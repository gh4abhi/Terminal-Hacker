using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    enum Screen { MainMenu, Password, Win};
    int level;
    const string menuHint = "You may write menu at any time.";
    bool clearMenuScreen = true;
    bool clearPasswordScreen = true;
    Screen CurrentScreen;
    string password;
    string[] level1Paaswords = { "books", "aisle", "shelf","password", "font", "borrow" };
    string[] level2Paaswords = {"prisoner","handcuffs","holster","uniform","arrest" };
    string[] level3Paaswords = {"starfield","telescope","environment","exploration","astronauts"};
    void Start()
    {
        ShowMainMenu("Hello Buddy");
    }

    void ShowMainMenu(string greeting)
    {
        CurrentScreen = Screen.MainMenu;
        if(clearMenuScreen)
        { 
            Terminal.ClearScreen();
        }
        clearMenuScreen = true;
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into\n");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for police station");
        Terminal.WriteLine("Press 3 for ISRO\n");
        Terminal.WriteLine("Enter your selection :");
    }

    void OnUserInput(string input)
    {
        bool isValid = (input == "1" || input == "2" || input=="3");
        if (input == "menu")
        {
            ShowMainMenu("Hello Buddy");
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            if (isValid)
            {
                RunMainMenu(input);
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Wrong Choice!");
                Terminal.WriteLine("Try Again");
                Terminal.WriteLine(menuHint);
                clearMenuScreen = false;
                ShowMainMenu("Hello Buddy");
            }
        }
        else if(CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }


    void RunMainMenu(string input)
    {
        level = int.Parse(input);
        StartGame(level);
    }

    void StartGame(int level)
    {
        switch (level)
        {
            case 1:
                password = level1Paaswords[Random.Range(0, level1Paaswords.Length)];
                AskForPassword();
                break;
            case 2:
                password = level2Paaswords[Random.Range(0, level2Paaswords.Length)];
                AskForPassword();
                break;
            case 3:
                password = level3Paaswords[Random.Range(0, level3Paaswords.Length)];
                AskForPassword();
                break;
            default:
                Terminal.WriteLine("Wrong Choice!");
                Terminal.WriteLine("Try Again");
                clearMenuScreen = false;
                Terminal.WriteLine(menuHint);
                ShowMainMenu("Hello Buddy");
                break;
        }
    }

    void AskForPassword()
    {
        CurrentScreen = Screen.Password;
        GenerateHints();
    }

    void GenerateHints()
    {
        if (clearPasswordScreen)
        {
            Terminal.ClearScreen();
        }
        clearPasswordScreen = true;
        Terminal.WriteLine("Enter Password, hint : " + password.Anagram());
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinSceen();
        }
        else
        {
            Terminal.WriteLine("Wrong Password.");
            Terminal.WriteLine(menuHint);
            clearPasswordScreen = false;
            StartGame(level);
        }
    }
    
    void DisplayWinSceen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book.....");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/  


");
                break;
            case 2:
                Terminal.WriteLine("You got the prision key.....");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '


");
                break;
            case 3:
                Terminal.WriteLine("Welcome to ISROs internal system.");
                Terminal.WriteLine(@"
      /\
     /__\
     |||| 
     ||||
     ||||
     ----
    /||||\
---------------

");
                break;
        }

        Terminal.WriteLine(menuHint);
    }

        void Update()
        {

        }
}
