using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg1wpf.logical
{
    public class GraphForSecondLab: Graph
    {
        private class Node
        {
            public int name;
            public int weight;
            public Node next;
            public Node(int name, int weight, Node next)
            {
                this.name = name;
                this.weight = weight;
                this.next = next;
            }
        }

        private class Result
        {
            public int[] dist;

            public int[] up;

            public Result(int length)
            {
                dist = new int[length];
                up = new int[length];
            }
        }

        private Node[] graph;

        private Result result;

        internal HeapD heap;

        private Random random = new Random();

        public GraphForSecondLab()
        {

        }

        public void GetResult()
        {
            #region test           
            int length = 5;
            heap = new HeapD(sizeHeap, length);
            result = new Result(length);
            graph = new Node[length];
            graph[0] = new Node(1, 10,
                new Node(2, 30,
                new Node(3, 50,
                new Node(4, 10, null))));
            graph[1] = null;
            graph[2] = new Node(4, 10, null);
            graph[3] = new Node(1, 40,
                new Node(2, 20, null));
            graph[4] = new Node(0, 10,
                new Node(2, 10,
                new Node(3, 30, null)));
            #endregion
            DijkstraDHeap(4);
            foreach (int a in result.dist)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
            FordBellman(4);
            foreach (int a in result.dist)
            {
                Console.WriteLine(a);
            }
        }

        private Node AddEdge(Node node, int countEdge, int maxIndexNode)
        {
            if (countEdge != 0)
            {
                if (node != null)
                {
                    node.next = AddEdge(node.next, countEdge, maxIndexNode);
                }
                else
                {
                    int weight = random.Next(minWeightOfEdge, maxWeightOfEdge);
                    int name = random.Next(0, maxIndexNode);
                    node = new Node(name, weight, null);
                    countEdge--;
                    node.next = AddEdge(node.next, countEdge, maxIndexNode);
                }
            }
            return node;
        }

        private List<int> FirstExperimentForDijkstraDHeap()
        {
            List<int> timeWork = new List<int>();
            graph = new Node[countNodeForExperiments];
            heap = new HeapD(sizeHeap, countNodeForExperiments);
            result = new Result(countNodeForExperiments);
            int countEdge = 10;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < graph.Length; j++)
                {
                    graph[j] = AddEdge(graph[j], countEdge, countNodeForExperiments - 1);
                }
                DateTime start = DateTime.Now;
                DijkstraDHeap(1000);
                DateTime end = DateTime.Now;
                timeWork.Add((end - start).Milliseconds + (end - start).Seconds * 1000);
            }
            return timeWork;
        }

        private List<int> FirstExperimentForFordBellman()
        {
            List<int> timeWork = new List<int>();
            graph = new Node[countNodeForExperiments];
            result = new Result(countNodeForExperiments);
            int countEdge = 10;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < graph.Length; j++)
                {
                    graph[j] = AddEdge(graph[j], countEdge, countNodeForExperiments - 1);
                }
                DateTime start = DateTime.Now;
                FordBellman(0);
                DateTime end = DateTime.Now;
                timeWork.Add((end - start).Milliseconds + (end - start).Seconds * 1000);
            }
            return timeWork;
        }

        private List<int> SecondExperimentForDijkstraDHeap()
        {
            List<int> timeWork = new List<int>();
            graph = new Node[countNodeForExperiments];
            heap = new HeapD(sizeHeap, countNodeForExperiments);
            result = new Result(countNodeForExperiments);
            int countIteration = 1000;
            int j = 0;
            for (int i = 0; i < 100; i++)
            {
                while (countIteration != 0)
                {
                    graph[j] = AddEdge(graph[j], 1, countNodeForExperiments - 1);
                    j++;
                    if (j == graph.Length)
                    {
                        j = 0;
                    }
                    countIteration--;
                }
                countIteration = 1000;
                DateTime start = DateTime.Now;
                DijkstraDHeap(0);
                DateTime end = DateTime.Now;
                timeWork.Add((end - start).Milliseconds + (end - start).Seconds * 1000);
            }
            return timeWork;
        }

        private List<int> SecondExperimentForFordBellman()
        {
            List<int> timeWork = new List<int>();
            graph = new Node[countNodeForExperiments];
            result = new Result(countNodeForExperiments);
            int countIteration = 1000;
            int j = 0;
            for (int i = 0; i < 100; i++)
            {
                while (countIteration != 0)
                {
                    graph[j] = AddEdge(graph[j], 1, countNodeForExperiments - 1);
                    j++;
                    if (j == graph.Length)
                    {
                        j = 0;
                    }
                    countIteration--;
                }
                countIteration = 1000;
                DateTime start = DateTime.Now;
                FordBellman(0);
                DateTime end = DateTime.Now;
                timeWork.Add((end - start).Milliseconds + (end - start).Seconds * 1000);
            }
            return timeWork;
        }

        private void DijkstraDHeap(int indexNode)
        {
            heap.countNotVisit = heap.names.Length;
            for (int i = 0; i < heap.countNotVisit; i++)
            {
                result.up[i] = 0;
                result.dist[i] = infinity;
                heap.names[i] = i;
                heap.keys[i] = infinity;
                heap.index[i] = i;
            }
            if (indexNode >= result.dist.Length)
            {
                return;
            }
            heap.keys[indexNode] = 0;
            heap.Emersion(indexNode);
            while (heap.countNotVisit > 0)
            {
                int i = heap.names[0];
                result.dist[i] = heap.keys[0];
                heap.DeliteMin();
                Node node = graph[i];
                while (node != null)
                {
                    int j = node.name;
                    int index = heap.index[j];
                    if (result.dist[j] == infinity)
                    {
                        if (heap.keys[index] > result.dist[i] + node.weight)
                        {
                            heap.keys[index] = result.dist[i] + node.weight;
                            heap.Emersion(index);
                            result.up[j] = i;
                        }
                    }
                    node = node.next;
                }
            }
        }

        private void FordBellman(int indexNode)
        {
            for (int i = 0; i < result.dist.Length; i++)
            {
                result.dist[i] = infinity;
                result.up[i] = 0;
            }
            if (indexNode >= result.dist.Length)
                return;
            result.dist[indexNode] = 0;
            for (; ; )
            {
                bool any = false;
                for (int i = 0; i < result.dist.Length; i++)
                {
                    Node node = graph[i];
                    while (node != null)
                    {
                        int j = node.name;
                        if (result.dist[i] < infinity)
                        {
                            if (j != indexNode)
                            {
                                if (result.dist[j] > result.dist[i] + node.weight)
                                {
                                    result.dist[j] = result.dist[i] + node.weight;
                                    result.up[j] = i;
                                    any = true;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                        node = node.next;
                    }
                }
                if (!any) break;
            }
        }

        public override List<int> FirstExperimentForFirstMethod()
        {
            return FirstExperimentForDijkstraDHeap();
        }

        public override List<int> FirstExperimentForSecondMethod()
        {
            return FirstExperimentForFordBellman();
        }

        public override List<int> SecondExperimentForFirstMethod()
        {
            return SecondExperimentForDijkstraDHeap();
        }

        public override List<int> SecondExperimentForSecondMethod()
        {
            return SecondExperimentForFordBellman();
        }
    }
}
