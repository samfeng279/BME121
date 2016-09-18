// -------------------------------------------------------------------
// Biomedical Engineering Program
// Department of Systems Design Engineering
// University of Waterloo
//
// Student Name:     Samantha Feng
// Userid:           s38feng
//
// Assignment:       Programming Assignment 4
// Submission Date:  December 4, 2015
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// Cheers to Felix Kurniawan for suffering through reading my incorrect code.
// -------------------------------------------------------------------

using System;

// This part of the DrugList class definition just holds the four
// private routines which manipulate nodes to do insert, remove, and find
// in support of select sort and insert sort.
partial class DrugList
{
    // Insert node 'target' between nodes 'previous' and 'current'.
    void InsertNode( Node target, Node previous, Node current )
    {
        // If the target is null, return without doing anything to list.
        if( target == null ){ return; }
        
        else 
        {            
            // If there are no nodes in the LinkedList, insert target as the only node. 
            if( count == 0 )
            {
                target.Next = null;
                tail = target;
                head = target;
            }
            
            // Insert target before head.
            else if( current == head ) 
            {   
                target.Next = current;
                head = target;
            }
        
            // Insert target after tail.
            else if( previous == tail ) 
            { 
                previous.Next = target;
                target.Next = null;
                tail = target;
            }
        
            // Insert target between previous and current.
            else 
            {
                previous.Next = target;
                target.Next = current;
            }
            
            // If a node is inserted, increase the count of nodes by one.
            count++;            
        }    
        
    }// End of InsertNode method.
    
    // Remove (and return) node 'current'.
    Node RemoveNode( Node previous, Node current )
    {
        if( current == null ) return null; // Nothing to remove.

        if( current == head ) // Remove element at head.
        {
            head = head.Next;
            if( head == null ) tail = null; // Removed only element.
        }
        else if( current == tail ) // Remove element at tail.
        {
            previous.Next = null;
            tail = previous;
        }
        else // Remove element in middle.
        {
            previous.Next = current.Next;
        }
        
        count--;
        
        current.Next = null; // Isolate the returned node.
        return current;
    
    }// End of RemoveNode method
    
    // Find the minimal node using UsersDrugComparer to compare Drugs held in nodes.
    void FindMinimalNode( out Node previous, out Node minimum, Comparison< Drug > UsersDrugComparer )
    {               
        Node current = head;        // Node that minimum node is compared to
        minimum = head;             // Set minimum node to the first node to begin with
        previous = null;            // Because minimum is the first node, then previous must be null
                
        // If there is only one node in the LinkedList, the minimum value is that node.
        if( current.Next == null )
        {
            minimum = head;
            return;
        }
                    
        // If there are multiple nodes in the LinkedList, search through the LinkedList to find the smallest value.
        // Search until there are no more nodes to compare to.
        while( current.Next != null )
        {   
            // If the value of the data of the minimum node is less than that of the next node, set minimum as that node.
            // Set previous to the node before the new minimum node. 
            if( UsersDrugComparer( minimum.Data, current.Next.Data ) > 0 )
            {
                previous = current;
                minimum = current.Next;
            }       
            
            // Move to the next node to compare. 
            current = current.Next;
        }        
    }
    
    // Find the first node larger than 'target' using UsersDrugComparer to compare Drugs held in nodes.
    void FindFirstLargerNode( Node target, out Node previous, out Node current, Comparison< Drug > UsersDrugComparer )
    {        
        current = head;                 // Set current node to the first node to begin with
        previous = null;                // Because current is the first node, then previous must be null
                        
        if( target == null )            // If the target node is null, return current as the first node
        {
            return;
        }
       
        // If there are multiple nodes in the LinkedList, search through the LinkedList to find the first larger node than target.
        // Search until the first larger node is found, or there are no more nodes to compare to.
        while( current != null )
        {                         
            // If target is smaller than the current node, the current node must be the first larger node
            // If a current node that is larger than the target is found, break the loop and return the current node. 
            if( UsersDrugComparer( target.Data, current.Data ) < 0 )
            {
                break;
            }           
           
            // Move onto the next node to compare.
            previous = current;
            current = current.Next;
        }   
        
    }// End of FindFirstLargerNode method.
    
}// End of partial DrugList class 