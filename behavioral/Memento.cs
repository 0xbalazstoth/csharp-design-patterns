using System;
using System.Collections.Generic;

void Main()
{
	Originator originator = new Originator();
	originator.State = "ON";
	
	// Store internal state
	Caretaker caretaker = new Caretaker();
	caretaker.Memento = originator.CreateMemento();
	
	// Continue changing originator
	originator.State = "OFF";
	
	// Restore saved state
	originator.RestoreOriginalMemento(caretaker.Memento);
}

class Originator
{
	string state;
	
	public string State
	{
		get => state;
		set
		{
			state = value;
		}
	}
	
	public Memento CreateMemento()
	{
		return new Memento(state);
	}
	
	public void RestoreOriginalMemento(Memento memento)
	{
		// Restoring state
		State = memento.State;
	}
}

class Memento
{
	string state;
	
	public Memento(string state)
	{
		this.state = state;
	}
	
	public string State
	{
		get => state;
	}
}

class Caretaker
{
	Memento memento;
	
	public Memento Memento
	{
		get => memento;
		set => memento = value;
	}
}