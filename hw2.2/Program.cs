abstract class Worker
{
    public string Name;
    public string Position;
    public Worker(string name)
    { 
        Name = name;
    }
    public string Call()
    {
        return "Join a meeting\n";
    }
    public string WriteCode()
    {
        return "Coding\n";
    }
    public string Relax()
    {
        return "Chill\n";
    }
    public abstract string FillWorkDay();
}

class Developer : Worker
{
    public Developer(string name) : base(name)
    {
        Position = "Developer";
    }
    public override string FillWorkDay()
    {
        return Call() + WriteCode() + Relax();

    }
}

class Manager : Worker
{
    private static Random quantity = new Random();
    public Manager(string name) : base(name)
    {
        Position = "Manager";
    }
    int j = quantity.Next(1, 10);
    int k = quantity.Next(1, 5);
    public override string FillWorkDay()
    {
        string call1 = "";
        for (int i = 0; i < j; i++)
        {
            call1 += Call();
        }
        string call2 = "";
        for (int i = 0; i < k; i++)
        { 
            call2 += Call();
        }
        return call1 + Relax() + call2;
    }
}

class Team
{
    private string name;
    private List<Worker> workers = new List<Worker>();
    public Team(string _name)
    {
        name = _name;
    }
    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }
    public void PrintTeamInfo()
    {
        Console.WriteLine("Team name: " + name);
        foreach (var item in workers)
        {
            Console.WriteLine(item.Name);
        }
    }
    public void PrintDetailsInfo(int i)
    {
        Console.WriteLine(workers[i].Name + " " + workers[i].Position);

    }
    public void Display(List<string> positionList)
    {
        Console.WriteLine("Team name: " + name);
        for (int i = 0; i < positionList.Count; i++)
        {
            if (positionList[i] == "Developer")
            {
                Developer dev = new Developer(name);
                PrintDetailsInfo(i);
                Console.WriteLine(dev.FillWorkDay());
            }
            else if (positionList[i] == "Manager")
            {
                Manager man = new Manager(name);
                PrintDetailsInfo(i);
                Console.WriteLine(man.FillWorkDay());
            }
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string name;
        int count = 0;
        Console.WriteLine("Enter team name: ");
        name = Console.ReadLine();
        Team team = new Team(name);
        string WorkerPosition = "";
        List<string> WorkerPositionList = new List<string>();
        while (true)
        {
            int action = 0;//enter a workday
            Console.WriteLine("Choose action 1,2,3,4\n1. Add worker to the team\n2. Print information about team members\n3. Print details\n4. End");
            try
            {
                action = Int32.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            switch (action)
            {
                case 1:
                    //count++;
                    string WorkerName;
                    Console.WriteLine("Enter name: ");
                    WorkerName = Console.ReadLine();
                    Console.WriteLine("Enter position: ");
                    WorkerPosition = Console.ReadLine();
                    WorkerPositionList.Add(WorkerPosition);
                    while (WorkerPosition != "Developer" && WorkerPosition != "Manager")
                    {
                        Console.WriteLine("There is no such position. Try again");
                        WorkerPosition = Console.ReadLine();
                    }
                    if (WorkerPosition == "Developer")
                    {
                        Worker worker = new Developer(WorkerName);
                        team.AddWorker(worker);
                    }
                    else if (WorkerPosition == "Manager")
                    {
                        Worker worker = new Manager(WorkerName);
                        team.AddWorker(worker);
                    }
                    Console.WriteLine();
                    break;

                case 2:
                    team.PrintTeamInfo();
                    Console.WriteLine();
                    break;

                case 3:
                    team.Display(WorkerPositionList);
                    Console.WriteLine();
                    break;
                
                case 4:
                    return;
            }
        }
    }
}
