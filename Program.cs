namespace filbehandling_oppgaver;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        WriteToFile("Heihei", "oppgavefil.txt");



    }

    // Oppgave 1

    // Denne metoden tar to parametre: En streng som skal skrives til en fil, og en streng som representerer
    // filstien til filen den skriver til.
    // (Jeg så øyeblikkelig etter å ha laget metoden at File.WriteAllText gjør nøyaktig det samme, bare med
    // omvendt rekkefølge på parametrene.)

    static void WriteToFile(string melding, string filsti) {
        File.WriteAllText(filsti, melding);
    }

    // Oppgave 2
    
}
