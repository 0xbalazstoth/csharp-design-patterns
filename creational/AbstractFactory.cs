// Abstract Factory
// Kisebb Factory-k �s Factory-je
// El�nye, hogy elszigeteli a konkr�t oszt�lyokat �s el�seg�ti a "term�kek"/product-ok konzisztenci�j�t
// H�tr�nya, hogy �j kisebb factory hozz�ad�s�hoz m�dos�tani kell az eg�sz Abstract Factory hierarchi�t, mert az interf�sz r�gz�ti a l�trehozhat� "term�keket"

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

// Interf�sz seg�ts�g�vel "fogjuk" �ssze az �sszes kisebb factory-t,
// mert �gy tudunk t�bb t�pus� factory-t elt�rolni majd a Dictionary-be
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
            Text = "Hell� Vil�g! - " + language
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

// Itt van az �s factory, ami �sszefogja az �sszes (kisebb) factory-kat.
// Megold�sa lehet Dictionary-vel vagy reflexi�val (min�l t�bb factory, ann�l lassabb)
// IF el�gaz�sok helyett string alapj�n hajt�djon v�gre a factory
static class LanguageFactory
{
    static Dictionary<string, IFactory> factories; // �sszefogja a factory-ket

    static LanguageFactory()
    {
        // Factory-kat elt�roljuk egy Dictionary-be
        factories = new Dictionary<string, IFactory>();
        factories.Add("HU", new HungarianFactory());
        factories.Add("EN", new EnglishFactory());
        factories.Add("FR", new FrenchFactory());
    }

    static public Language HelloWorld(string text)
    {
        // Itt d�ntj�k el, hogy melyik factory fusson le "text" alapj�n
        var factory = factories[text];

        // Factory �ltal megkapott eredm�nyt visszaadjuk, amit a kliens k�dban felhaszn�lunk
        return factory.HelloWorld(text);
    }
}