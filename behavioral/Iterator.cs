using System;

void Main()
{
	LinkedList<string> list = new LinkedList<string>();
	list.InsertTop("A");
	list.InsertTop("B");
	list.InsertTop("C");
	
	foreach (string item in list)
	{
		// Something...
	}
}

class LinkedList<T> : IEnumerable<T>
{
	class ListItem
	{
		public T content;
		public ListItem next;
	}
	
	class ListIterator : IEnumerator<T>
	{
		ListItem first;
		ListItem actual;
		
		public ListIterator(ListItem first)
		{
			this.first = first;
			
			actual = new ListItem();
			actual.next = first;
		}
		
		public T Current => actual.content;
		
		object IEnumerator.Current => this.Current;
		
		public void Dispose()
		{
			first = null;
			actual = null;
		}
		
		public bool MoveNext()
		{
			if (actual == null)
			{
				return false;
			}
			
			actual = actual.next;
			return actual != null;
		}
		
		public void Reset()
		{
			actual = new ListItem();
			actual.next = first;
		}
	}
	
	private ListItem head;
	
	public LinkedList()
	{
		head = null;
	}
	
	public void InsertTop(T content)
	{
		ListItem newItem = new ListItem();
		newItem.content = content;
		newItem.next = head;
		head = newItem;
	}
	
	public IEnumerator<T> GetEnumerator()
	{
		return new ListIterator(head);
	}
	
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}