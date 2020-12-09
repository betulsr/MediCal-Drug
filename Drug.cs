#nullable enable
using System;
using static System.Console;
using MediCal;

namespace Bme121
{
    partial class LinkedList
    {
        // Method used to indicate a target Drug object when searching.
        
        public static bool IsTarget( Drug data ) 
        { 
            return data.Name.StartsWith( "FOSAMAX", StringComparison.OrdinalIgnoreCase ); 
        }
        
        // Method used to compare two Drug objects when sorting.
        // Return is -/0/+ for a<b/a=b/a>b, respectively.
        
        public static int Compare( Drug a, Drug b )
        {
            return string.Compare( a.Name, b.Name, StringComparison.OrdinalIgnoreCase );
        }
        
        // Method used to add a new Drug object to the linked list in sorted order.
        
        public void InsertInOrder( Drug newData )
        {
            int index = 0;
            
            Node? currentNode = Head;
            Node? oldNode = null;
            Node? newNode = new Node(newData);
			
			
            
            if( currentNode == null )
            {
                AddFirst(newData);
                return;
            }
            
            if( currentNode.Next == null && currentNode != null)
            {
                if( Compare ( newData, currentNode.Data) < 0 )
                {
                    AddFirst( newData );
                }
                else
                {
                    AddLast( newData );
                }return;
            }
            
            while( true ) 
            {
                if( currentNode.Next != null && Compare ( newData, currentNode.Data) < 0 )
                {
                    if( index == 0 )
                    {
                        AddFirst( newData );
                        return;
                    }
                    Count ++;
                    
                    newNode.Next = currentNode;
                    oldNode.Next = newNode;
                    return;
                }
                else if( currentNode.Data == Tail.Data)
                {
                    AddLast( newData );
                    return;
                }
                
                oldNode     = currentNode;
                currentNode = currentNode.Next;
                index ++;
            }
            
        }
    }
    
    static class Program
    {
        // Method to test operation of the linked list.
        
        static void Main( )
        {
            Drug[ ] drugArray = Drug.ArrayFromFile( "RXQT1503-100.txt" );
            
            LinkedList drugList = new LinkedList( );
            foreach( Drug d in drugArray ) drugList.InsertInOrder( d );
            
            WriteLine( "drugList.Count = {0}", drugList.Count );
            foreach( Drug d in drugList.ToArray( ) ) WriteLine( d );
        }
    }
}
