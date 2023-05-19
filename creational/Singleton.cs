void Main()
{
	Singleton.Instance();
}

class Singleton
{
	private static Singleton instance;
	
	private Singleton()
	{
		"Created".Dump();
	}
	
	public static Singleton Instance()
	{
		return instance ?? (instance = new Singleton());
	}
}