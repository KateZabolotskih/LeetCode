namespace Algorithms.BracketsInCode;

public class MyStack<T>
{
    public int Size = 0;
    public List<T> brackets = new List<T>();

    public void Push(T item)
    {
        brackets.Add(item);
        Size += 1;
    }

    public T Pop()
    {
        if (Size == 0)
        {
            return default(T);
        }
        var bracket = brackets[Size - 1];
        brackets.RemoveAt(Size - 1);

        Size -= 1;

        return bracket;
    }

    public T Peek()
    {
        if (Size == 0)
        {
            return default(T);
        }
        return brackets[Size - 1];
    }
}

//code for main
 
// class Program
// {
//     static void Main(string[] args)
//     {
//         string line = Console.ReadLine();
//         var (success, index) = IsBalanced(line);

//         if(success)
//         {
//             Console.Write("Success");
//         }
//         else
//         {
//             Console.Write(index);
//         }
//     }

//     public static (bool, int) IsBalanced(string line)
//     {   
//         MyStack<char> brackets = new MyStack<char>();
//         MyStack<int> indexes = new MyStack<int>();
//         int index = 0;

//         foreach (char bracket in line)
//         {
//             index ++;
//             switch(bracket)
//             {
//                 case '{':
//                 case '[':
//                 case '(':
//                     brackets.Push(bracket);
//                     indexes.Push(index);
//                     break;

//                 case ']':
//                     if (brackets.Pop() != '[')
//                     {
//                         return(false, index);
//                     }
//                     indexes.Pop();
//                     break;

//                 case '}':
//                     if (brackets.Pop() != '{')
//                     {
//                         return(false, index);
//                     }
//                     indexes.Pop();
//                     break;

//                 case ')':
//                     if (brackets.Pop() != '(')
//                     {
//                         return(false, index);
//                     }
//                     indexes.Pop();
//                     break;
//             }
//         }
//         if (brackets.Size != 0)
//         {
//             return (false, indexes.Pop());
//         }
//         return (true, index);
//     }
// }