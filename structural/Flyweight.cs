void Main()
{
	FlyweightOnTheFlyProperty();
	FlyweightSharedObject();
	ReuseObject();
}

void FlyweightOnTheFlyProperty()
{
    OnTheFlyProperty onTheFlyProperty = new OnTheFlyProperty();
    foreach (var item in onTheFlyProperty.GetEverySecondLetter)
    {
        System.Console.WriteLine(item);
    }
}

void FlyweightSharedObject()
{
    SharedObject sharedObject = new SharedObject();
    sharedObject.Name = "Name #1";
    sharedObject.Description = "Description #1";
    System.Console.WriteLine($"sharedObject: {sharedObject.IsLearning}");

    SharedObject sharedObject2 = new SharedObject();
    sharedObject2.Name = "Name #2";
    sharedObject2.Description = "Description #2";
    System.Console.WriteLine($"sharedObject2: {sharedObject2.IsLearning}");
}

void ReuseObject()
{
    ReusableObject.AdditionalData additionalData = new ReusableObject.AdditionalData();
    additionalData.Age = 10;
    System.Console.WriteLine($"additionalData on initializing: {additionalData.Age}");

    ReusableObject reusableObject = new ReusableObject();
    reusableObject.Reuse(additionalData); // Like for example recalculating the age with the same object
    System.Console.WriteLine($"additionalData after reuse: {additionalData.Age}");
}

public class OnTheFlyProperty
{
	List<string> _list = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"
        };

        public List<string> GetEverySecondLetter => _list.Where((x, i) => i % 2 == 0).ToList();
}

public class SharedObject
{
	public string Name { get; set; }
    public string Description { get; set; }
    public bool IsLearning // This is the shared object
    {
        get
        {
            return Learning; // Calling a static property
        }
    }
    static bool Learning => true; // ONLY READABLE
}

public class ReusableObject
{
    public class AdditionalData
    {
        public int Age { get; set; }
    }

    public void Reuse(AdditionalData data)
    {
        data.Age = 25;
    }
}