void Main()
{
	// Array of creators
	Creator[] creators = new Creator[2];
	
	creators[0] = new ConcreteCreatorA();
	creators[1] = new ConcreteCreatorB();
	
	// Creators and products
	foreach (Creator creator in creators)
	{
		IProduct product = creator.FactoryMethod();
		var createdProduct = product.GetType().Name;
		
		// Created product
	}
}

// Product interface
interface IProduct { }

// Concrete products
class ConcreteProductA : IProduct { }

class ConcreteProductB : IProduct { }

abstract class Creator
{
	public abstract IProduct FactoryMethod(); // Empty factory method
}

class ConcreteCreatorA : Creator
{
	public override IProduct FactoryMethod()
	{
		return new ConcreteProductA();
	}
}

class ConcreteCreatorB : Creator
{
	public override IProduct FactoryMethod()
	{
		return new ConcreteProductA();
	}
}