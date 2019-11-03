using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    public class MyStack
    {
        private int n;
        private int top; 
        private int[] array;
        private bool operation;
        private int maxSize;

        public int length { get { return this.array.Length; } }

        public MyStack()
        {
            n = 1;
            this.array = new int[n];
            this.top = 0;
        }

        public MyStack(int maxSize)
        {
            n = 1;
            this.array = new int[n];
            this.top = 0;
            this.maxSize = maxSize;
        }

        private bool isEmpty()
        {
            var emptyTop = this.top == 0 ? true : false;
            return emptyTop;

        }

        private int[] Resize(int[] array)
        {
            if(operation)
            {
                int[] newArray = new int[this.top + 1];
                for (int i = 0; i < this.array.Length; i++)
                    newArray[i] = array[i];
                return newArray;
            }
            else
            {
                int[] newArray = new int[this.top];
                for (int i = 0; i < this.array.Length - 1; i++)
                    newArray[i] = array[i];
                return newArray;
            }
        }

        public void Push(int number)
        {
            operation = true;
            if (this.array.Length == maxSize)
            {
                Console.WriteLine("Стек переполнен! Удалите элемент.");
            } 
           else if (this.array.Length >= n)
            {
                this.array = Resize(array);
                this.array[this.top] = number;
                top++;
            }

        }

        public int Pop()
        {
            if (isEmpty())
            {
                throw new ArgumentException();
            }
            else
            {
                operation = false;
                var topElement = this.array[top-1];
                this.top--;
                this.array = Resize(this.array);
                return topElement;   
            }
        }

        public void Print()
        {
            foreach (var elem in this.array)
                Console.Write(elem + "\t");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();
            stack.Push(5);
            stack.Push(12);
            stack.Push(1);
            stack.Print();
            stack.Pop();
            stack.Push(1);
            stack.Print();
            Console.ReadLine();
        }
    }
}
