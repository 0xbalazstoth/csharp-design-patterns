using System;
using System.Collections.Generic;

void Main()
{
	Receiver receiver = new Receiver();
	ICommand command = new ConcreteCommand(receiver);
	Sender sender = new Sender();
	
	sender.SetCommand(command);
	sender.ExecuteCommand();
}

interface ICommand
{
	void Execute();
}

class ConcreteCommand : ICommand
{
	protected Receiver receiver;
	
	public ConcreteCommand(Receiver receiver)
	{
		this.receiver = receiver;
	}

	public void Execute()
	{
		receiver.Action();
	}
}

class Receiver
{
	public void Action()
	{
		// Action
	}
}

class Sender
{
	ICommand command;
	
	public void SetCommand(ICommand command)
	{
		this.command = command;
	}
	
	public void ExecuteCommand()
	{
		command.Execute();
	}
}