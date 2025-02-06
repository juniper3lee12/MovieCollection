using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public class LinkedList
    {
        private MovieLinkedListNode _head;
        private MovieLinkedListNode _tail;
        private int _count = 0;

        private void AddToHead(MovieLinkedListNode node)
        {
            _head.Previous = node;
            node.Next = _head;
            _head = node;
            _count++;
        }

        public void Add(Movie t)
        {
            var node = new MovieLinkedListNode()
            {
                Data = t
            };
            if((_head == null) && (_tail == null)){
                _head = node;
                _tail = node;
                _count++;
                return;
            }
            AddToHead(node);
        }
        public void AddTail(Movie t)
        {
            var node = new MovieLinkedListNode()
            {
                Data = t
            };
            if ((_head == null) && (_tail == null))
            {
                _head = node;
                _tail = node;
                _count++;
                return;
            }
            _tail.Next = node;
            node.Previous = _tail;
            _tail = node;
            _count++;
        }

        public void Remove(Movie t)
        {
            var current = _head;
            var removed = false;
            while (current != null)
            {
                if (current.Data.Title == t.Title)
                {
                    current = RemoveCurrent(current);
                    removed = true;
                    _count--;
                }
                current = current.Next;
            }
        }

        public void RemoveTail()
        {
            if(_tail == null)
            {
                return;
            }
            if(_tail.Previous == null)
            {
                _tail = null;
                _head = null;
                _count--;
                return;
            }
            if(_tail.Next == null)
            {
                _tail = _tail.Previous;
                _tail.Next = null;
                _count--;
                return;
            }
        }

        public void InsertAtNode(MovieLinkedListNode node, MovieLinkedListNode newNode)
        {
            // Removing at tail
            if(node.Next == null)
            {
                newNode.Previous = node.Previous;
                newNode.Next = node;
                _tail = newNode;
                _count++;
                return;
            }
            newNode.Previous = node.Previous;
            newNode.Next = node;
            node.Previous.Next = newNode;
            node.Previous = newNode;
            _count++;
        }

        public void Increment()
        {
            _count++;
        }

        public MovieLinkedListNode Find(Movie movie)
        {
            var current = _head;
            MovieLinkedListNode foundNode = null;
            while (current != null)
            {
                if (current.Data.Title == movie.Title)
                {
                    foundNode = current;
                }
                current = current.Next;
            }
            return foundNode;
        }

        private MovieLinkedListNode RemoveCurrent(MovieLinkedListNode node)
        {
            if(node.Next == null && node.Previous == null)
            {
                _head = null;
                _tail = null;
                return node;
            }

            if(node.Previous == null)
            {
                _head = node.Next;
                node.Next = null;
                return node;
            }

            if(node.Next == null)
            {
                _tail = node.Previous;
                node.Previous = null;
                return node;
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;;
            return node;

        }

        public int Count()
        {
            return _count;
        }

        public MovieLinkedListNode GetHead()
        {
            return _head;
        }

        public MovieLinkedListNode GetTail()
        {
            return _tail;
        }

        public MovieLinkedListNode GetNextMovieNode(MovieLinkedListNode node)
        {
            return node.Next;
        }
    }
}
