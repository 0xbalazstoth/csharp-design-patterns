using System;

void Main()
{
	// Chain of responsibility
	var handlerA = new ConcreteHandlerA();
	var handlerB = new ConcreteHandlerB();
	handlerA.SetSuccessor(handlerB);
	
	// Processing requests
	handlerA.HandleRequest(5);
	handlerA.HandleRequest(15);
	handlerA.HandleRequest(1);
}

interface IHandler
{
	public void HandleRequest(int request);
	public void SetSuccessor(Handler successor);
}

abstract class Handler : IHandler
{
	protected Handler _successor;

	public abstract void HandleRequest(int request);
	
	public void SetSuccessor(Handler successor)
	{
		_successor = successor;
	}
}

class ConcreteHandlerA : Handler
{
	public override void HandleRequest(int request)
	{
		if (request == 1)
		{
			// "Handled by ConcreteHandlerA"
		}
		else if (_successor != null)
		{
			_successor.HandleRequest(request);
		}
	}
}

class ConcreteHandlerB : Handler
{
	public override void HandleRequest(int request)
	{
		if (request > 10)
		{
			// "Handled by ConcreteHandlerB"
		}
		else if (_successor != null)
		{
			_successor.HandleRequest(request);
		}
	}
}