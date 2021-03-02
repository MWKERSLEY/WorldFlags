using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WorldFlags.Models
{
    public class World
    {
        public World()
        {

        }
        public World(DateTime date, List<Country> countries)
        {
            Date = date;
            Countries = countries;
        }

        public DateTime Date { get; set; }
        public List<Country> Countries { get; set; }
        public override string ToString() => JsonSerializer.Serialize<World>(this);
    }
    public class Country
    {
        public string Name { get; set; }
        //public List<string> TopLevelDomain { get; set; }
        public string Alpha2Code { get; set; }
        //public string Alpha3Code { get; set; }
        //public List<string> CallingCodes { get; set; }
        public string Capital { get; set; }
        //public List<string> AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        //public int Population { get; set; }
        //public List<float> Latlng { get; set; }
        //public string Demonym { get; set; }
        //public float? Gini { get; set; }
        //public List<string> Timezones { get; set; }
        //public List<string> Borders { get; set; }
        //public string NativeName { get; set; }
        //public string NumericCode { get; set; }
        //public List<Currency> Currencies { get; set; }
        //public List<Language> Languages { get; set; }
        //public Translation Translations { get; set; }
        public string Flag { get; set; }
        public List<RegionalBloc> RegionalBlocs { get; set; }
        //public string Cioc { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Country>(this);
    }
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Currency>(this);
    }
    public class Language
    {
        public string Iso639_1 { get; set; }
        public string Iso639_2 { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Language>(this);
    }
    public class Translation
    {
        public string DE { get; set; }
        public string ES { get; set; }
        public string FR { get; set; }
        public string JA { get; set; }
        public string IT { get; set; }
        public string BR { get; set; }
        public string PT { get; set; }
        public string NL { get; set; }
        public string HR { get; set; }
        public string FA { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Translation>(this);
    }
    public class RegionalBloc
    {
        //public string Acronym { get; set; }
        public string Name { get; set; }
        //public List<string> OtherAcronyms { get; set; }
        //public List<string> OtherNames { get; set; }
        public override string ToString() => JsonSerializer.Serialize<RegionalBloc>(this);
    }
    public class DateGot
    {
        public DateTime Date { get; set; }
    }
}
