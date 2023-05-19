using System;
using System.Collections.Generic;

void Main()
{
    // Client code
    var subject = new Subject();
    var observerA = new ConcreteObserverA();
    subject.Subscribe(observerA);

    var observerB = new ConcreteObserverB();
    subject.Subscribe(observerB);

    subject.SomeBusinessLogic();
    subject.SomeBusinessLogic();

    subject.UnSubscribe(observerB);

    subject.SomeBusinessLogic();
}

interface IObserver
{
    void StateChange(ISubject subject);
}

interface ISubject
{
    void Subscribe(IObserver observer);
    void UnSubscribe(IObserver observer);
    void Notify();
}

class Subject : ISubject
{
    public int State { get; set; } = -1;

    private List<IObserver> observers = new List<IObserver>();

    public void Subscribe(IObserver observer)
    {
        // Subscribing observer
        observers.Add(observer);
    }

    public void UnSubscribe(IObserver observer)
    {
        // Unsubscribing observer
        observers.Remove(observer);
    }

    public void Notify()
    {
        // Notifying observers

        foreach (IObserver observer in observers)
        {
            observer.StateChange(this);
        }
    }

    public void SomeBusinessLogic()
    {
        // Doing something
        this.State = new Random().Next(0, 10);

        Thread.Sleep(15);

        // State has changed
        this.Notify();
    }
}

class ConcreteObserverA : IObserver
{
    public void StateChange(ISubject subject)
    {
        if ((subject as Subject).State < 3)
        {
            // ConcreteObserverA reacted to the event
        }
    }
}

class ConcreteObserverB : IObserver
{
    public void StateChange(ISubject subject)
    {
        if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
        {
            // ConcreteObserverB reacted to the event
        }
    }
}