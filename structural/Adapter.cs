void Main()
{
	Target target = new Adapter();
	target.Request();
}

class Target
{
	public virtual void Request()
	{
		// Target request
	}
}

class Adapter : Target
{
	private Adaptee adaptee = new Adaptee();
	
	public override void Request()
	{
		adaptee.SpecificRequest();
	}
}

class Adaptee
{
	public void SpecificRequest()
	{
		// Specific request
	}
}