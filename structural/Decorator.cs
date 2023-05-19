void Main()
{
	ConcreteComponent component = new ConcreteComponent();
	ConcreteDecoratorA d1 = new ConcreteDecoratorA();
	ConcreteDecoratorB d2 = new ConcreteDecoratorB();
	
	// Link decorators
	d1.SetComponent(component);
	d2.SetComponent(d1);
	
	d2.Operation();
}

public abstract class Component
{
    public abstract void Operation();
}

public class ConcreteComponent : Component
{
    public override void Operation()
    {
        // ConcreteComponent.Operation()
    }
}

public abstract class Decorator : Component
{
    protected Component component;
    public void SetComponent(Component component)
    {
        this.component = component;
    }
    public override void Operation()
    {
        if (component != null)
        {
            component.Operation();
        }
    }
}

public class ConcreteDecoratorA : Decorator
{
    public override void Operation()
    {
        base.Operation();
        // ConcreteDecoratorA.Operation()
    }
}

public class ConcreteDecoratorB : Decorator
{
    public override void Operation()
    {
        base.Operation();
        AddedBehavior();
        // ConcreteDecoratorB.Operation()
    }
	
    void AddedBehavior()
    {
	
    }
}