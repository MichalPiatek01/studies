using static System.Console;

try
{
    liczba1:
    WriteLine("Podaj liczbę od 0 do 255: ");
    string dane1 = ReadLine();
    int liczba1 = int.Parse(dane1);
    
    if (liczba1 < 0 | liczba1 > 255)
    {
        WriteLine("Podana liczba musi być większa od zera ale mniejsza od 256.");
        goto liczba1;
    }
    
    liczba2:
    WriteLine("Podaj inną liczbę od 0 do 255: ");
    string dane2 = ReadLine();
    int liczba2 = int.Parse(dane2);
    
    if (liczba2 < 0 | liczba2 > 255)
    {
        WriteLine("Podana liczba musi być większa od zera ale mniejsza od 256.");
        goto liczba2;
    }
    else 
    {
        WriteLine($"{liczba1} podzielona przez {liczba2} to {liczba1/liczba2}");
    }

}
catch (FormatException)
{
    WriteLine("Podane liczba nie jest liczbą.");
}
catch (OverflowException)
{
    WriteLine("Podane liczba jest liczbą ,ale jest albo za duża albo za mała.");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} z komunikatem: {ex.Message}");
}
