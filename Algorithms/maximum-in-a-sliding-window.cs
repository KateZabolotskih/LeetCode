namespace Algorithms.MaxInSlideWindow;

public class StackWithMax
{
    public int Size = 0;
    private List<int> _dataLinkedList = new List<int>();
    private List<int> _maxLinkedList = new List<int>();

    public void Push(int item)
    {
        _dataLinkedList.Add(item);

        if (_maxLinkedList.Count == 0 || _maxLinkedList[_maxLinkedList.Count - 1] <= item)
        {
            _maxLinkedList.Add(item);
        }
        else
        {
            _maxLinkedList.Add(_maxLinkedList[_maxLinkedList.Count - 1]);
        }

        Size += 1;
    }

    public int Peek()
    {
        if (_dataLinkedList.Count == 0)
        {
            return -1;
        }

        return _dataLinkedList[Size - 1];
    }

    public int Pop()
    {
        if (_dataLinkedList.Count == 0)
        {
            return -1;
        }
        var item = _dataLinkedList[Size - 1];

        _dataLinkedList.RemoveAt(Size - 1);
        _maxLinkedList.RemoveAt(Size - 1);

        Size -= 1;

        return item;
    }

    public int Max()
    {
        if (Size == 0)
        {
            return 0;
        }
        return _maxLinkedList[Size - 1];
    }
}

public class QueueWithMax
{
    public int Size = 0;
    public int Max = 0;
    private StackWithMax _stackWithMax = new StackWithMax();
    private StackWithMax _revertStackWithMax = new StackWithMax();

    public void Add(int item)
    {
        _stackWithMax.Push(item);
        Max = _stackWithMax.Max() >= _revertStackWithMax.Max() ? _stackWithMax.Max() : _revertStackWithMax.Max();
        Size = _stackWithMax.Size + _revertStackWithMax.Size;
    }

    public int Element()
    {
        if (_revertStackWithMax.Size == 0)
        {
            while (_stackWithMax.Size != 0)
            {
                _revertStackWithMax.Push(_stackWithMax.Pop());
            }
        }
        return _revertStackWithMax.Peek();
    }

    public int Remove()
    {
        if (_revertStackWithMax.Size == 0)
        {
            while (_stackWithMax.Size != 0)
            {
                _revertStackWithMax.Push(_stackWithMax.Pop());
            }
        }

        Size -= 1;
        if (Size == 0)
        {
            Max = 0;
        }
        return _revertStackWithMax.Pop();
    }
}

// code for main procedure
//namespace Algorithms;
//
//class Program
//{
//    static void Main(string[] args)
//    {
//        int size = int.Parse(Console.ReadLine());
//        string[] parameters = Console.ReadLine().Split(' ');
//        int window_size = int.Parse(Console.ReadLine());
//
//        QueueWithMax queue = new QueueWithMax();
//
//        for (int i = 0; i < window_size; i++)
//        {
//            queue.Add(int.Parse(parameters[i]));
//        }
//        for (int i = window_size; i < size; i++)
//        {
//            Console.Write(queue.Max + " ");
//            queue.Remove();
//            queue.Add(int.Parse(parameters[i]));
//        }
//        Console.Write(queue.Max);
//    }
//}