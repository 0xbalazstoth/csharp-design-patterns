void Main()
{
	AbstractClass abstractClassA = new ConcreteClassA();
	abstractClassA.TemplateMethod();
	
	AbstractClass abstractClassB = new ConcreteClassB();
	abstractClassB.TemplateMethod();
}

abstract class AbstractClass
{
	public abstract void Operation1();
	public abstract void Operation2();
	
	// The "Template Method"
	public void TemplateMethod()
	{
		Operation1();
		Operation2();
	}
}

class ConcreteClassA : AbstractClass
{
	public override void Operation1()
	{
		// ConcreteClassA - Operation1
	}
	
	public override void Operation2()
	{
		// ConcreteClassA - Operation2
	}
}

class ConcreteClassB : AbstractClass
{
	public override void Operation1()
	{
		// ConcreteClassB - Operation1
	}
	
	public override void Operation2()
	{
		// ConcreteClassB - Operation2
	}
}