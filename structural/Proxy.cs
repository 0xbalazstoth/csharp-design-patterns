void Main()
{
	Proxy proxy = new Proxy();
	proxy.Request();
}

// Service
interface ISubject
{
	void Request();
}

class RealSubject : ISubject
{
	public void Request()
	{
		// RealSubject request
	}
}

class Proxy : ISubject
{
	private RealSubject realSubject;
	
	// Request service
	public void Request()
	{
		if (realSubject == null)
		{
			realSubject = new RealSubject();
		}
		
		realSubject.Request();
	}
}