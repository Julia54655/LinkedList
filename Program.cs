using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17 { 

   public class Node<T>
{
        public Node<T> Next { get; set; }
        public T Data { set; get; }

        public Node( T data)
        {
            Data = data;
        }
}
    public class LinkedList<T> : IEnumerable<T>

    {
         Node<T> head;
         Node<T> last;
        int count;

        //добавление
        
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            { last.Next = node;
            }
                
                last = node;
            count++;
            
        }

        //добавлекение в начало
        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
            {
                last = head;
                count++;
            }
        }

        //удаление
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> pre = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (pre != null)
                    {
                        pre.Next = current.Next;
                        if (current.Next == null)
                        {
                            last = pre;
                        }
                    }
                    else
                    {
                        head = current.Next;
                        if (head == null)
                        {
                            last = null;
                        }

                    }
                    count--;
                    return true;
                }
                pre = current;
                current = current.Next;
            }
            return false;
        }

        //наличие элемента
        public bool Contain(T data)
        {
            
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                    current = current.Next;
                
            }
            return false;
        }
         IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();     }

         IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

      
    }

    class Program
    {
        static void Main(string[] args)
        {

            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            foreach(var i in list)
            {
                Console.WriteLine(i);
            }

            list.Remove(3);
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            list.AddFirst(5);
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            bool s= list.Contain(2);
           
                Console.WriteLine(s==true? "yes":"no");
            

            Console.ReadKey();

        }
    }
}
