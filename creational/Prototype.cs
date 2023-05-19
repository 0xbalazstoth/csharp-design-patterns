using System;

void Main()
{
	// A
	// New instance
	ConcretePrototypeA cPA = new ConcretePrototypeA();
	cPA.A = "-- A --";
	
	// Copy
	ConcretePrototypeA copyA = (ConcretePrototypeA)cPA.Clone();
	
	// B
	// New instance
	ConcretePrototypeB cPB = new ConcretePrototypeB();
	cPB.B = "-- B --";
	
	// Copy
	ConcretePrototypeB copyB = (ConcretePrototypeB)cPB.Clone();
}

interface IPrototype
{
	IPrototype Clone();
}

class ConcretePrototypeA : IPrototype
{
	public string A;

	public IPrototype Clone()
	{
		// Shallow copy
		return (IPrototype)MemberwiseClone();
		
		// Deep copy
		//return (IPrototype)this.Clone();
	}
}

class ConcretePrototypeB : IPrototype
{
	public string B;

	public IPrototype Clone()
	{
		// Shallow copy
		return (IPrototype)MemberwiseClone();
		
		// Deep copy
		// return (IPrototype)this.Clone();
	}
}