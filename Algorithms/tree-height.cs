namespace Algorithms.TreeHeight;

public class Tree<T> where T : IEquatable<T>
{
    public T Node { get; set; }
    public List<Tree<T>> Children { get; set; }

    public Tree(T node, List<T>? children)
    {
        Node = node;
        Children = new List<Tree<T>>();
        if (children != null)
        {
            foreach (T child in children)
            {
                Children.Add(new Tree<T>(child, null));
            }
        }
    }

    public bool AddLeaf(T leaf, T parent)
    {
        if (Node.Equals(parent))
        {
            Children.Add(new Tree<T>(leaf, null));
            return true;
        }

        bool added = false;
        foreach (Tree<T> child in Children)
        {
            added = added || child.AddLeaf(leaf, parent);
        }

        return added;
    }

    public bool FindLeaf(T leaf)
    {
        if (Node.Equals(leaf))
        {
            return true;
        }

        bool found = false;
        foreach (Tree<T> child in Children)
        {
            found = found || child.FindLeaf(leaf);
        }

        return found;
    }

    public int Height()
    {
        int height = 1;

        foreach (Tree<T> child in Children)
        {
            height += Math.Max(height, 1 + child.Height());
        }

        return height;
    }

}
// другое решение задачи о нахождении высоты дерева, заданного списком  родителей
// static void Main(string[] args)
// {
//     int leaf_num = int.Parse(Console.ReadLine());
//     int[] parents = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
//     int root = 0;

//     // составляем список смежностей
//     List<int>[] tree = new List<int>[leaf_num];
//     for (int i = 0; i < leaf_num; i++)
//     {
//         if (i == parents[i] || parents[i] == -1)
//         {
//             root = i;
//             continue;
//         }
//         if (tree[parents[i]] == null)
//         {
//             tree[parents[i]] = new List<int>();
//         }
//         tree[parents[i]].Add(i);
//     }

//     // кладем в очередь каждый уровень детей и считаем, сколько раз мы так сделали
//     Queue<int> queue = new Queue<int>();
//     queue.Enqueue(root);
//     int height = 0;

//     while (queue.Count > 0)
//     {
//         int queue_size = queue.Count;
//         for (int i = 0; i < queue_size; i++)
//         {
//             int node = queue.Dequeue();
//             if (tree[node] != null)
//             {
//                 foreach (var child in tree[node])
//                 {
//                     queue.Enqueue(child);
//                 }
//             }
//         }
//         height++;
//     }

//     Console.Write(height);
// }