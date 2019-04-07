using System;
    public class Node<T> {
        public T data;
        public Node<T> next;
        public Node(T data, Node<T> next) {
            this.data = data;
            this.next = next;
        }
    }
public class Queue<T> {
     
    public Node<T> rear;
    public int size;
     
    public Queue() {
        rear = null;
        size = 0;
    }
 
    public void Enqueue(T item) {
        Node<T> newItem = new Node<T>(item, null);
        if (rear == null) {
            newItem.next = newItem;
        } else {
            newItem.next = rear.next;
            rear.next = newItem;
        }
        size++;
        rear = newItem;
    }
     
    public T Dequeue()  {
        if (rear == null) {
            throw new Exception("queue is empty");
        }
        T data = rear.next.data;
        if (rear == rear.next) {
            rear = null;
        } else {
            rear.next = rear.next.next;
        }
        size--;
        return data;
    }
     
    public int Size() {
        return size;
    }
     
    public bool IsEmpty() {
        return size == 0;
    }
     
    public void Clear() {
        size = 0;
        rear = null;
    }
     
    public T Peek() {
        if (rear == null) {
            throw new Exception("queue is empty");
        }
        return rear.next.data;              
    }
}