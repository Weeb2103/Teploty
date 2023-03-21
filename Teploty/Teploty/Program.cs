using Spectre.Console;
using System.ComponentModel.Design;
//Vytvoření pole na teploty
int[] poleTeplot = new int[30];
start:
var vyber = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Jakej den chceš doplnit?")
        .PageSize(10)
        .MoreChoicesText("[grey](Jeď dolů pro více měsíců)[/]")
        .AddChoices(new[] {
            "1", "2", "3",
            "4", "5", "6",
            "7", "8", "9",
            "10", "11", "12",
            "13", "14", "15",
            "16", "17", "18",
            "19", "20", "21",
            "22", "23", "24",
            "25", "26", "27",
            "28", "29", "30",
            "31"
        }));
int den = int.Parse(vyber);
Console.WriteLine("Zadej hodnoty pro " + den + ". den v stupních Celsia");
poleTeplot[den-1] = int.Parse(Console.ReadLine());
//vybrání jestli hcete další den
var reset = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Chceš další den?")
        .PageSize(10)
        .MoreChoicesText("ne")
        .AddChoices(new[] {
            "Ano", "Ne",
        }));
if(reset == "Ano")
{
    Console.Clear();
    goto start;
}
else
{ //menu na výběr akce
    menu:
    var menu = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Vyber si")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
            .AddChoices(new[] {
            "Min teplota", "Max teplota", "Průměrná teplota", "Ukončit",
            }));
    //max teplota
    if (menu== "Max teplota")
    {
     int max = poleTeplot.Max();
        Console.WriteLine(max);
        Console.WriteLine("Pro vracení zpět do menu stiskni Space");
        ConsoleKeyInfo keyInfo= Console.ReadKey();
        if (keyInfo.Key== ConsoleKey.Spacebar)
        {      
            goto menu;
        }
    }
    //min teplota
    if (menu == "Min Teplota")
    {
       int min = poleTeplot.Min();
        Console.WriteLine(min);
        Console.WriteLine("Pro vracení zpět do menu stiskni Space");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.Spacebar)
        {
            goto menu;           
        }
    }
    //prum teplota
    if (menu== "Průměrná teplota")
    {
        double prumer = poleTeplot.Average();
        Console.WriteLine(prumer);
        Console.WriteLine("Pro vracení zpět do menu stiskni Space");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.Spacebar)
        {
            goto menu;
        }
    }
    //Ukončení
    if (menu== "Ukončit")
    {
        Console.WriteLine("Konec");
    }
}