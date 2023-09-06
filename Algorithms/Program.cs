namespace Algorithms.TreeHeight;

class Program
{
    static void Main(string[] args)
    {
        int leaf_num = int.Parse(Console.ReadLine());
        int[] parents = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int root = 0;

        // составляем список смежностей
        List<int>[] tree = new List<int>[leaf_num];
        for (int i = 0; i < leaf_num; i++)
        {
            if (i == parents[i] || parents[i] == -1)
            {
                root = i;
                continue;
            }
            if (tree[parents[i]] == null)
            {
                tree[parents[i]] = new List<int>();
            }
            tree[parents[i]].Add(i);
        }

        // кладем в очередь каждый уровень детей и считаем, сколько раз мы так сделали
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(root);
        int height = 0;

        while(queue.Count > 0)
        {
            int queue_size = queue.Count;
            for (int i = 0; i < queue_size; i++)
            {
                int node = queue.Dequeue();
                if (tree[node] != null)
                {
                    foreach(var child in tree[node])
                    {
                        queue.Enqueue(child);
                    }
                }
            }
            height++;
        }

        Console.Write(height);
    }
}