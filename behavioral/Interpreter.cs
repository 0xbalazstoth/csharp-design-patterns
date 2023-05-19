using System;
using System.Collections.Generic;

void Main()
{
	Context context = new Context();
	
	// Tree
	List<IExpression> expressions = new List<IExpression>();
	
	// Syntax tree
	expressions.Add(new TerminalExpression());
    expressions.Add(new NonterminalExpression());
    expressions.Add(new TerminalExpression());
    expressions.Add(new TerminalExpression());
	
    // Interpret
    foreach (IExpression exp in expressions)
    {
        exp.Interpret(context);
    }
}

class Context { }

interface IExpression
{
	void Interpret(Context context);
}

class TerminalExpression : IExpression
{
	public void Interpret(Context context)
	{
		// Terminal.Interpret()
	}
}

class NonterminalExpression : IExpression
{
	public void Interpret(Context context)
	{
		// Nonterminal.Interpret()
	}
}