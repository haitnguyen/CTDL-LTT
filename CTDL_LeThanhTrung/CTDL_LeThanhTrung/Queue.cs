using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTDL_LeThanhTrung
{
    class Queue
    {
        private int[] ele;
        private int front;
        private int rear;
        private int max;

        public Queue(int size)
        {
            ele = new int[size];
            front  = 0 ;
            rear   = -1;
            max = size;
        }

        public void push(int item)
        {
            if (rear == max - 1)
            {
                //full Queue
                return;
            }
            else
            {
                ele[++rear] = item;
            }
        }

        public int pop()
        { 
            if(front == rear + 1)
            {
                //Queue is empty
                return -1;
            }
            else
            {
                return ele[front++];
            }
        }
    }
}
