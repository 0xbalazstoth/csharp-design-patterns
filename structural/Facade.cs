void Main()
{
	Facade facade = new Facade();
	
	facade.MethodA();
	facade.MethodB();
}

class SubSystemOne
{
	public void MethodOne()
	{
		// Method one
	}
}

class SubSystemTwo
{
	public void MethodTwo()
	{
		// Method two
	}
}

class Facade
{
	SubSystemOne one;
	SubSystemTwo two;
	
	public Facade()
	{
		one = new SubSystemOne();
		two = new SubSystemTwo();
	}
	
	public void MethodA()
	{
		// MethodA
		one.MethodOne();
		two.MethodTwo();
	}
	
	public void MethodB()
	{
		// MethodB
		two.MethodTwo();
	}
}