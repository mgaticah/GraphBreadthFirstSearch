using System;

namespace GraphsBreadthFirstSearch
{

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph("graphInfo.txt");
            graph.BreadthFirstSearch();
        }
    }
}
