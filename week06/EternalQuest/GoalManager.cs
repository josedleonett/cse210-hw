public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            List<string> menuOptions = new List<string>
            {
                "1. Create New Goal.",
                "2. List Goals",
                "3. Save Goals",
                "4. Load Goals",
                "5. Record Event",
                "6. Quit"
            };

            foreach (string option in menuOptions)
            {
                Console.WriteLine($"    {option}");
            }
            Console.Write("Select a choice from the menu: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    CreateGoal();
                    break;

                case 2:
                    Console.Clear();
                    ListGoalDetails();
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    SaveGoalsWithPrompt();
                    break;

                case 4:
                    Console.Clear();
                    LoadGoals();
                    break;

                case 5:
                    Console.Clear();
                    RecordGoal();
                    break;

                case 6:
                    Console.WriteLine("Goodbye!");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. \n");
    }

    public void ListGoalNames()
    {
        if (_goals.Count < 1)
        {
            Console.WriteLine("No goals have been created yet.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
            }
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals List:");

        if (_goals.Count < 1)
        {
            Console.WriteLine("    No goals have been created yet.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"    {i + 1}. - {_goals[i].GetDetailString()}");
            }
        }
    }

    public void CreateGoal()
    {
        List<string> goalTypes = new List<string>
        {
            "1. Simple Goal.",
            "2. Eternal Goal.",
            "3. Checklist Goal.",
            "4. Back to Main Menu"
        };

        bool isGoalCreationFinished = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Select a goal type:");
            foreach (string option in goalTypes)
            {
                Console.WriteLine($"    {option}");
            }
            Console.Write("Select a choice from the menu: ");
            int goalType = int.Parse(Console.ReadLine());
            switch (goalType)
            {
                case 1:
                    string name, description;
                    int points;

                    Console.Clear();
                    Console.Write("Creating a new Simple Goal.\n");
                    Console.Write("Enter the name of the goal: ");
                    name = Console.ReadLine();

                    Console.Write("Enter a short description for this goal: ");
                    description = Console.ReadLine();

                    Console.Write("Enter amount of associated points for this goal: ");
                    points = int.Parse(Console.ReadLine());

                    _goals.Add(new SimpleGoal(name, description, points));
                    Console.WriteLine($"Goal '{name}' created successfully!");

                    isGoalCreationFinished = true;
                    Thread.Sleep(1000);
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("Creating a new Eternal Goal.\n");
                    Console.Write("Enter the name of the goal: ");
                    name = Console.ReadLine();

                    Console.Write("Enter a short description for this goal: ");
                    description = Console.ReadLine();

                    Console.Write("Enter amount of associated points for this goal: ");
                    points = int.Parse(Console.ReadLine());

                    _goals.Add(new EternalGoal(name, description, points));
                    Console.WriteLine($"Goal '{name}' created successfully!");

                    isGoalCreationFinished = true;
                    Thread.Sleep(1000);
                    break;

                case 3:
                    Console.Clear();
                    Console.Write("Creating a new Checklist Goal.\n");
                    Console.Write("Enter the name of the goal: ");
                    name = Console.ReadLine();

                    Console.Write("Enter a short description for this goal: ");
                    description = Console.ReadLine();

                    Console.Write("Enter amount of associated points for this goal: ");
                    points = int.Parse(Console.ReadLine());

                    Console.Write("Enter the target number of times to complete this goal: ");
                    int target = int.Parse(Console.ReadLine());

                    Console.Write("Enter how many times does this goal need to be completed to earn a bonus: ");
                    int bonus = int.Parse(Console.ReadLine());

                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    Console.WriteLine($"Goal '{name}' created successfully!");

                    isGoalCreationFinished = true;
                    Thread.Sleep(1000);
                    break;

                case 4:
                    isGoalCreationFinished = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(1000);
                    break;
            }

        } while (!isGoalCreationFinished);
    }

    public void RecordGoal()
    {
        if (_goals.Count < 1)
        {
            Console.WriteLine("No goals have been created yet.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Select a goal to record an event for: ");
        ListGoalNames();
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal selection. Please try again.");
            Thread.Sleep(1000);
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Recording event for goal: {_goals[goalIndex].GetShortName()}");
            Goal selectedGoal = _goals[goalIndex];
            int previousScore = _score;

            if (!selectedGoal.IsComplete())
            {
                selectedGoal.RecordEvent();
                _score += selectedGoal.GetPoints();
            }
            else
            {
                Console.WriteLine("This goal is already complete. No points were added.");
            }

            Console.WriteLine($"Your total score is now: {_score}");
            Thread.Sleep(2000);
            Console.WriteLine($"Press any key to return to the main menu...");
            Console.ReadKey();

        }
    }

    public void SaveGoals(string fullFilePath)
    {
        using (StreamWriter outputFile = new StreamWriter(fullFilePath))
        {
            foreach (var goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void SaveGoalsWithPrompt()
    {
        Console.WriteLine("Enter the filename to save goals: ");
        string filename = Console.ReadLine();

        string directory = AppContext.BaseDirectory;
        directory = Path.GetFullPath(Path.Combine(directory, @"..\..\..\"));

        string fullFilePath = Path.Combine(directory, filename);

        try
        {
            SaveGoals(fullFilePath);
            Console.WriteLine($"Goals successfully saved to {fullFilePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    public void LoadGoals()
    {
        Console.WriteLine("Enter the filename to load goals from: ");
        string filename = Console.ReadLine();

        string directory = AppContext.BaseDirectory;
        directory = Path.GetFullPath(Path.Combine(directory, @"..\..\..\"));

        string fullFilePath = Path.Combine(directory, filename);

        try
        {
            if (!File.Exists(fullFilePath))
            {
                Console.WriteLine($"File '{filename}' does not exist.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }

            _goals.Clear();

            string[] lines = File.ReadAllLines(fullFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                string goalType = parts[0];
                switch (goalType)
                {
                    case "SimpleGoal":
                        string simpleName = parts[1];
                        string simpleDescription = parts[2];
                        int simplePoints = int.Parse(parts[3]);
                        bool isComplete = bool.Parse(parts[4]);
                        SimpleGoal simpleGoal = new SimpleGoal(simpleName, simpleDescription, simplePoints);
                        if (isComplete)
                        {
                            simpleGoal.RecordEvent();
                        }
                        _goals.Add(simpleGoal);
                        break;

                    case "EternalGoal":
                        string eternalName = parts[1];
                        string eternalDescription = parts[2];
                        int eternalPoints = int.Parse(parts[3]);
                        EternalGoal eternalGoal = new EternalGoal(eternalName, eternalDescription, eternalPoints);
                        _goals.Add(eternalGoal);
                        break;

                    case "ChecklistGoal":
                        string checklistName = parts[1];
                        string checklistDescription = parts[2];
                        int checklistPoints = int.Parse(parts[3]);
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        ChecklistGoal checklistGoal = new ChecklistGoal(checklistName, checklistDescription, checklistPoints, target, bonus);
                        for (int i = 0; i < amountCompleted; i++)
                        {
                            checklistGoal.RecordEvent();
                        }
                        _goals.Add(checklistGoal);
                        break;

                    default:
                        Console.WriteLine($"Unknown goal type: {goalType}");
                        break;
                }
            }

            Console.WriteLine("Goals successfully loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}