using System;
using System.IO;

public class Graph
{
    Vertex[] AdjacencyLists;
    public Graph(string fileName)
    {
        using (StreamReader file = new StreamReader(fileName))
        {
            string graphType = file.ReadLine();
            bool undirected = graphType.Equals("undirected");
            int vertexsNumber=int.Parse(file.ReadLine());
            AdjacencyLists = new Vertex[vertexsNumber];
            for (int vertexIndex = 0; vertexIndex < vertexsNumber; vertexIndex++)
            {
                string vertexName=file.ReadLine();
                AdjacencyLists[vertexIndex] = new Vertex(vertexName, null);
            }
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string vertex1Name=line.Split(' ')[0];
                string vertex2Name=line.Split(' ')[1];
                int vertex1Index = indexForName(vertex1Name);
                int vertex2Index = indexForName(vertex2Name);
                AdjacencyLists[vertex1Index].AdjacencyList = new Neighbor(vertex2Index, AdjacencyLists[vertex1Index].AdjacencyList);
                if (undirected)
                {
                    AdjacencyLists[vertex2Index].AdjacencyList = new Neighbor(vertex1Index, AdjacencyLists[vertex2Index].AdjacencyList);
                }
            }
        }
    }

    int indexForName(string name)
    {
        for (int vertexNumber = 0; vertexNumber < AdjacencyLists.Length; vertexNumber++)
        {
            if (AdjacencyLists[vertexNumber].Name.Equals(name))
            {
                return vertexNumber;
            }
        }
        return -1;
    }
    public void BreadthFirstSearch()
    {
        bool[] visited = new bool[AdjacencyLists.Length];
        Queue<int> queue = new Queue<int>();
        for (int vertexNumber = 0; vertexNumber < visited.Length; vertexNumber++)
        {
            if (!visited[vertexNumber])
            {
                Console.WriteLine("\nSTART AT: " + AdjacencyLists[vertexNumber].Name);
                queue.Clear();
                BreadthFirstSearch(vertexNumber, visited, queue);
            }
        }
    }
    private void BreadthFirstSearch(int startVertexNumber, bool[] visited, Queue<int> queue)
    {
        visited[startVertexNumber] = true;
        Console.WriteLine("visiting " + AdjacencyLists[startVertexNumber].Name);
        queue.Enqueue(startVertexNumber);
        while (!queue.IsEmpty())
        {
            int vertexNumber = queue.Dequeue();
            for (var neighbor = AdjacencyLists[vertexNumber].AdjacencyList; neighbor != null; neighbor = neighbor.Next)
            {
                int neighborVertexNumber = neighbor.VertexNum;
                if (!visited[neighborVertexNumber])
                {
                    Console.WriteLine("\n" + AdjacencyLists[vertexNumber].Name + "--" + AdjacencyLists[neighborVertexNumber].Name);
                    visited[neighborVertexNumber] = true;
                    queue.Enqueue(neighborVertexNumber);
                }
            }
        }
    }
}