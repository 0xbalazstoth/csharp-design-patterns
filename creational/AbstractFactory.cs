// Abstract Factory
// Kisebb Factory-k õs Factory-je
// Elõnye, hogy elszigeteli a konkrét osztályokat és elõsegíti a "termékek"/product-ok konzisztenciáját
// Hátránya, hogy új kisebb factory hozzáadásához módosítani kell az egész Abstract Factory hierarchiát, mert az interfész rögzíti a létrehozható "termékeket"

void Main()
{
    var a = LanguageFactory.HelloWorld("EN");

    System.Console.WriteLine(a.Text);
}

// Factories
class Language
{
    public string Text { get; set; }
}

// Interfész segítségével "fogjuk" össze az összes kisebb factory-t,
// mert így tudunk több típusú factory-t eltárolni majd a Dictionary-be
interface IFactory
{
    Language HelloWorld(string text);
}

// Kisebb factory-k
class HungarianFactory : IFactory
{
    public Language HelloWorld(string language)
    {
        return new Language()
        {
            Text = "Helló Világ! - " + language
        };
    }
}

class EnglishFactory : IFactory
{
    public Language HelloWorld(string language)
    {
        return new Language()
        {
            Text = "Hello World! - " + language
        };
    }
}

class FrenchFactory : IFactory
{
    public Language HelloWorld(string language)
    {
        return new Language()
        {
            Text = "Bonjour le monde! - " + language
        };
    }
}

// Itt van az õs factory, ami összefogja az összes (kisebb) factory-kat.
// Megoldása lehet Dictionary-vel vagy reflexióval (minél több factory, annál lassabb)
// IF elágazások helyett string alapján hajtódjon végre a factory
static class LanguageFactory
{
    static Dictionary<string, IFactory> factories; // Összefogja a factory-ket

    static LanguageFactory()
    {
        // Factory-kat eltároljuk egy Dictionary-be
        factories = new Dictionary<string, IFactory>();
        factories.Add("HU", new HungarianFactory());
        factories.Add("EN", new EnglishFactory());
        factories.Add("FR", new FrenchFactory());
    }

    static public Language HelloWorld(string text)
    {
        // Itt döntjük el, hogy melyik factory fusson le "text" alapján
        var factory = factories[text];

        // Factory által megkapott eredményt visszaadjuk, amit a kliens kódban felhasználunk
        return factory.HelloWorld(text);
    }
}