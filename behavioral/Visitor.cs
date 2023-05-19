using System;

void Main()
{
	List<IElement> elements = new List<IElement>()
	{
		new ConcreteElementA(),
		new ConcreteElementB(),
	};
	
	var visitor1 = new ConcreteVisitorA();
	Client.ClientCode(elements, visitor1);
	
	var visitor2 = new ConcreteVisitorB();
	Client.ClientCode(elements, visitor2);
}

// Element
interface IElement
{
	void Accept(IVisitor visitor);
}

class ConcreteElementA : IElement
{
	public void Accept(IVisitor visitor)
	{
		visitor.VisitConcreteComponentA(this);
	}
	
	public string SpecialMethod()
	{
		return "A";
	}
}

class ConcreteElementB : IElement
{
	public void Accept(IVisitor visitor)
	{
		visitor.VisitConcreteComponentB(this);
	}
	
	public string SpecialMethod()
	{
		return "B";
	}
}

// Visitor
interface IVisitor
{
	void VisitConcreteComponentA(ConcreteElementA element);
	void VisitConcreteComponentB(ConcreteElementB element);
}

class ConcreteVisitorA : IVisitor
{
	public void VisitConcreteComponentA(ConcreteElementA element)
	{
		// A
	}
	
	public void VisitConcreteComponentB(ConcreteElementB element)
	{
		// B
	}
}

class ConcreteVisitorB : IVisitor
{
	public void VisitConcreteComponentA(ConcreteElementA element)
	{
		// A2
	}
	
	public void VisitConcreteComponentB(ConcreteElementB element)
	{
		// B2
	}
}

class Client
{
	public static void ClientCode(List<IElement> elements, IVisitor visitor)
	{
		foreach (var element in elements)
		{
			element.Accept(visitor);
		}
	}
}