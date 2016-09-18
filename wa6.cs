partial class LinkedList< TData >
{
    public int Count 
	{ 
		get 
		{ 
			//If no nodes exist in the linked list, then return count as 0
			if(head == tail && head == null)
			{
				return 0;
			}
			
			//If no nodes, other than the head/tail exist in the linked list, then return count as 1
			else if(head == tail)
			{
				return 1;
			}
			
			else
			{
				//Start a counter at 0
				int count = 1;
				
				//Create a temporary reference called currentNode
				//Begin this reference at head
				Node currentNode = head;
				
				//Stop looping when the Next property is null
				while( currentNode.Next != null )
				{
					//If there is another node following the current node, count up
					count++;
					
					//Set the temporary reference to the next node
					currentNode = currentNode.Next;
				}
				
				//Return the count
				return count;
			}
		} 
	}
}