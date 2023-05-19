void Main()
{
	var context = new Context(new ConcreteStateA());

	context.Request();
	context.Request();
	context.Request();
	context.Request();
}

interface IState
{
	void Handle(Context context);	
}

class ConcreteStateA : IState
{
	public void Handle(Context context)
	{
		context.State = new ConcreteStateB();
	}
}

class ConcreteStateB : IState
{
	public void Handle(Context context)
	{
		context.State = new ConcreteStateA();
	}
}

class Context
{
	IState state;

	public Context(IState state)
	{
		this.State = state;
	}

	public IState State
	{
		get => state;
		set
		{
			state = value;
			// State
		}
	}

	public void Request()
	{
		state.Handle(this);
	}
}
