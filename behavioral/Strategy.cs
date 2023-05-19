void Main()
{
	Context context;
	
	// Contexts with different strategies
	context = new Context(new ConcreteStrategyA());
	context.ContextInterface();
	
	context = new Context(new ConcreteStrategyB());
	context.ContextInterface();
	
	context = new Context(new ConcreteStrategyC());
	context.ContextInterface();
}

interface IStrategy
{
	void AlgorithmInterface();
}

class ConcreteStrategyA : IStrategy
{
	public void AlgorithmInterface()
	{
		// ConcreteStrategyA algorithm
	}
}

class ConcreteStrategyB : IStrategy
{
	public void AlgorithmInterface()
	{
		// ConcreteStrategyB algorithm
	}
}

class ConcreteStrategyC : IStrategy
{
	public void AlgorithmInterface()
	{
		// ConcreteStrategyC algorithm
	}
}

class Context
{
	IStrategy strategy;
	
	public Context(IStrategy strategy)
	{
		this.strategy = strategy;
	}
	
	public void ContextInterface()
	{
		strategy.AlgorithmInterface();
	}
}