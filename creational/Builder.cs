using System;

void Main()
{
	// Director
	Director director = new Director();

	// Builders
	IBuilder b1 = new Builder();
	IBuilder b2 = new Builder2();
	
	// Construct
	director.Construct(b1);
	director.Construct(b2);
}

class MyClass
{
	public string Name { get; set; }
}

interface IBuilder
{
	public void Build();
	public MyClass GetMyClass { get; }
}

class Builder : IBuilder
{
	private MyClass	_myClass = new MyClass();
	public MyClass GetMyClass { get => _myClass; }

	public void Build()
	{
		_myClass.Name = "-- A --";
	}
}

class Builder2 : IBuilder
{
	private MyClass	_myClass = new MyClass();
	public MyClass GetMyClass { get => _myClass; }

	public void Build()
	{
		_myClass.Name = "-- A2 --";
	}
}

class Director
{
	public void Construct(IBuilder builder)
	{
		builder.Build();
	}
}