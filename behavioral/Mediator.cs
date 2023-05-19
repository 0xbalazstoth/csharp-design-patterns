using System;
using System.Collections.Generic;

void Main()
{
	// Client code
	Component1 component1 = new Component1();
	Component2 component2 = new Component2();
	new ConcreteMediator(component1, component2);
	
	// Client triggers operation A
	component1.DoSomethingA();
	
	// Client triggers operation D
	component2.DoSomethingD();
}

interface IMediator
{
	void Notify(object sender, string ev);
}

class ConcreteMediator : IMediator
{
	private Component1 component1;
	private Component2 component2;
	
	public ConcreteMediator(Component1 component1, Component2 component2)
	{
		this.component1 = component1;
		this.component1.SetMediator(this);
		
		this.component2 = component2;
		this.component2.SetMediator(this);
	}
	
	public void Notify(object sender, string ev)
	{
		if (ev == "A")
		{
			// Mediator reacts on D and triggers these operations
			this.component2.DoSomethingC();
		}
		
		if (ev == "D")
		{
			// Mediator reacts on D and triggers these operations
			this.component1.DoSomethingB();
			this.component2.DoSomethingC();
		}
	}
}

class BaseComponent
{
	protected IMediator mediator;
	
	public BaseComponent(IMediator mediator = null)
	{
		this.mediator = mediator;
	}
	
	public void SetMediator(IMediator mediator)
	{
		this.mediator = mediator;
	}
}

class Component1 : BaseComponent
{
	public void DoSomethingA()
	{
		// Notify A
		this.mediator.Notify(this, "A");
	}
	
	public void DoSomethingB()
	{
		// Notify B
		this.mediator.Notify(this, "B");
	}
}

class Component2 : BaseComponent
{
	public void DoSomethingC()
	{
		// Notify C
		this.mediator.Notify(this, "C");
	}
	
	public void DoSomethingD()
	{
		// Notify D
		this.mediator.Notify(this, "D");
	}
}