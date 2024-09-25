using System.Text.Json;

namespace filbehandling_oppgaver;

class Program
{
    static void Main(string[] args)
    {

        // Oppgave 1
        string filsti = "oppgavefil.txt";
        Console.WriteLine("Hello, World!");


        WriteToFile("Heihei", filsti);
        Console.WriteLine(ReadFile(filsti));


        AddToFile(filsti, " Hallo hallo!");
        Console.WriteLine(ReadFile(filsti));

        // Oppgave 2

        string filnavn = "cities.json";

        string name = "Bergen";
        string county = "Vestland";
        string country = "Norge";
        int population = 291_940;

        var newCity = new City 
        {
            Name = name,
            County = county,
            Country = country,
            Population = population
        };

        // Omgjør City-objektet til et JSON-objekt
        string jsonString = JsonSerializer.Serialize(newCity);
        Console.WriteLine(jsonString);

        // Skriver dette JSON-objektet til en fil som heter cities.json

        File.WriteAllText(filnavn, jsonString);


    }

    // Oppgave 1

    // Denne metoden tar to parametre: En streng som skal skrives til en fil, og en streng som representerer
    // filstien til filen den skriver til.
    // (Jeg så øyeblikkelig etter å ha laget metoden at File.WriteAllText gjør nøyaktig det samme, bare med
    // omvendt rekkefølge på parametrene.)

    static void WriteToFile(string melding, string filsti) {
        File.WriteAllText(filsti, melding);
    }

    /* Metoden under tar en filsti som parameter, leser av filen på den adressen og returnerer innholdet som en streng.
    */

    static string ReadFile(string filsti) 
    {
        string filinnhold = File.ReadAllText(filsti);
        return filinnhold;
    }

    // Metoden under tillater brukeren å legge til tekst i en teksfil, uten å skrive over det som er der.
    // Tar i bruk begge metodene over. 
    static void AddToFile(string filsti, string melding)
    {
        string filinnhold = ReadFile(filsti);
        WriteToFile($"{filinnhold}" + melding, filsti);
    }

}
