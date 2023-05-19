void Main()
{
	Composite root = new Composite("root");
	
	Composite comp = new Composite("Composite X");
	comp.Add(new Leaf("Leaf XA"));
	comp.Add(new Leaf("Leaf XB"));
	
	root.Add(comp);
	root.Add(new Leaf("Leaf C"));
	
	Leaf leaf = new Leaf("Leaf D");
	root.Add(leaf);
	root.Remove(leaf);
	
	root.Display(1);
}

interface IComponent
{
	void Add(IComponent component);
	void Remove(IComponent component);
	void Display(int depth);
}

class Composite : IComponent
{
	List<IComponent> children = new List<IComponent>();
	string name;
	
	public Composite(string name)
	{
		this.name = name;
	}
	
	public void Add(IComponent component)
	{
		children.Add(component);
	}
	
	public void Remove(IComponent component)
	{
		children.Remove(component);
	}
	
	public void Display(int depth)
	{
		// $"{new String('-', depth) + name}"
		
		// Recursively display child nodes
		foreach (IComponent component in children)
		{
			component.Display(depth + 2);
		}
	}
}

class Leaf : IComponent
{
	string name;
	
	public Leaf(string name)
	{
		this.name = name;
	}
	
	public void Add(IComponent component)
	{
		// Cannot add to a leaf
	}
	
	public void Remove(IComponent component)
	{
		// Cannot remove from leaf
	}
	
	public void Display(int depth)
	{
		// $"{new String('-', depth) + name}"
	}
}