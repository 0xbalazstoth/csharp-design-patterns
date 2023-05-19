void Main()
{
	Abstraction abstraction = new RefinedAbstraction();
	
	// Bridge (implementors)
	abstraction.Implementor = new ConcreteImplementorA();
	abstraction.Operation();
	
	abstraction.Implementor = new ConcreteImplementorB();
	abstraction.Operation();
}

// Abstract
class Abstraction
{
	protected IImplementor implementor; // Bridge
	
	public IImplementor Implementor
	{
		set => implementor = value;
	}
	
	public virtual void Operation()
	{
		implementor.Operation();
	}
}

class RefinedAbstraction : Abstraction
{
	public override void Operation()
	{
		implementor.Operation();
	}
}

// Bridge
interface IImplementor
{
	void Operation();
}

class ConcreteImplementorA : IImplementor
{
	public void Operation()
	{
		// ConcreteImplementorA operation
	}
}

class ConcreteImplementorB : IImplementor
{
	public void Operation()
	{
		// ConcreteImplementorB operation
	}
}