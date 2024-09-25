using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;
using System.Text.Json;

namespace filbehandling_oppgaver;



class Program
{
    static readonly HttpClient client = new HttpClient();

    // For å kunne kjøre async-metoder i Main, endret jeg (retur?)-typen til Task. 
    static async Task Main(string[] args)
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

        City? avJSONifisertCity = JsonSerializer.Deserialize<City>(jsonString);


        // Sjekker at man ender opp med et City-objekt igjen, etter serialisering og deserialisering.
        Console.WriteLine(avJSONifisertCity.Name);

        // Det er litt uklart for meg hva andre del av oppgave 2 spør om: JsonSerializer og File-metodene
        // fungerer allerede til å skrive til, lese fra og opprette JSON-filer og -objekter. 

        // Oppgave 3

        // url-en går til en liste over verdens valutaer med euro som base.
        string url = "https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@latest/v1/currencies/eur.json";
        string apisti = "valuta.json";
        
        // Henter ut data og lagrer i variabelen data.
        var data = await HentData(url);

        // Sjekker at dette gikk bra
        Console.WriteLine(data);

        //Skriver dataen man hentet fra api-et, til en egen fil.
        File.WriteAllText(apisti, data);

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


    // Oppgave 3


    // Denne metoden tar en url som parameter, og returnerer dataen på det endepunktet som en streng.
    static async Task<string> HentData(string url) {
        try 
        {
            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        } catch {
            Console.WriteLine("Noe gikk galt med å hente ut data");
            return "Noe gikk galt med å hente ut data";
        }
    }
}
