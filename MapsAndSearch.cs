using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_3_SvetlioMaps
{
    class MapsAndSearch
    {
        private Dictionary<int, List<Node>> map = new Dictionary<int, List<Node>>();
        private Dictionary<int, List<int>> shortestWay = new Dictionary<int, List<int>>();
        private Dictionary<int, string> townsNames = new Dictionary<int, string>();
        private int[] shortCuts = new int[27];
        private int[] visitedCities = new int[27];

        public void PrintShortestWay(List<int> shortestWay, int start, int end)
        {
            string startTown = this.townsNames[start];
            string endTown = this.townsNames[end];
            int shortestWayIs = this.shortCuts[end];
            Console.WriteLine(" Distance from \"{0}\" to \"{1}\", is - {2}km.", startTown, endTown, shortestWayIs);
            Console.WriteLine();
            Console.WriteLine(" Road passes through these cities: ");
            foreach (var town in shortestWay)
            {
                Console.WriteLine(" \t" + this.townsNames[town]);
            }
        }

        public void PrintCitiesCode()
        {
            Console.WriteLine(" ------------------------   Cities Code   -----------------------------");
            Console.WriteLine();
            Console.WriteLine(" Blagoevgrad- 6    Burgas- 24      Varna- 23          Veliko Tarnovo- 9");
            Console.WriteLine(" Vidin- 0          Vratsa- 2       Gabrovo- 10        Dobrich- 22");
            Console.WriteLine(" Kardzhali- 15     Kyustendil- 5   Lovech- 8          Montana- 1");
            Console.WriteLine(" Pazardzhik- 13    Pernik- 4       Pleven- 7          Plovdiv- 12");
            Console.WriteLine(" Razgrad- 18       Ruse- 20        Silistra- 21       Sliven- 26");
            Console.WriteLine(" Smolyan- 16       Sofia- 3        Stara Zagora- 11   Targovishte- 17");
            Console.WriteLine(" Haskovo- 14       Shumen- 19      Yambol- 25");
            Console.WriteLine();
            Console.WriteLine(" -----------   Search shortest way between two cities   ---------------");
            Console.WriteLine();
        }

        private void CreateTownsNames()
        {
            this.townsNames.Add(0, "Vidin");
            this.townsNames.Add(1, "Montana");
            this.townsNames.Add(2, "Vratsa");
            this.townsNames.Add(3, "Sofia");
            this.townsNames.Add(4, "Pernik");
            this.townsNames.Add(5, "Kyustendil");
            this.townsNames.Add(6, "Blagoevgrad");
            this.townsNames.Add(7, "Pleven");
            this.townsNames.Add(8, "Lovech");
            this.townsNames.Add(9, "Veliko Tarnovo");
            this.townsNames.Add(10, "Gabrovo");
            this.townsNames.Add(11, "Stara Zagora");
            this.townsNames.Add(12, "Plovdiv");
            this.townsNames.Add(13, "Pazardzhik");
            this.townsNames.Add(14, "Haskovo");
            this.townsNames.Add(15, "Kardzhali");
            this.townsNames.Add(16, "Smolyan");
            this.townsNames.Add(17, "Targovishte");
            this.townsNames.Add(18, "Razgrad");
            this.townsNames.Add(19, "Shumen");
            this.townsNames.Add(20, "Ruse");
            this.townsNames.Add(21, "Silistra");
            this.townsNames.Add(22, "Dobrich");
            this.townsNames.Add(23, "Varna");
            this.townsNames.Add(24, "Burgas");
            this.townsNames.Add(25, "Yambol");
            this.townsNames.Add(26, "Sliven");
        }

        public List<int> GiveMeShortestWayTo(int end)
        {
            List<int> shortestWay = new List<int>();

            List<int> tempShortWay = this.shortestWay[end];
            foreach (var item in tempShortWay)
            {
                    shortestWay.Add(item);
            }
            shortestWay.Add(end);
            return shortestWay;
        }

        public void SearchShortCut(int start, int end)
        {
            for (int i = 0; i < this.shortCuts.Length; i++)
            {
                this.shortestWay.Add(i, new List<int>() {start});
            }

            for (int i = 0; i < this.shortCuts.Length; i++)
            {
                this.shortCuts[i] = int.MaxValue;
                this.visitedCities[i] = i;
            }

            visitedCities[start] = -1;
            List<Node> nodes = this.map[start];
            foreach (var item in nodes)
            {
                this.shortCuts[item.NextNode] = item.Distance;
            }

            int nodeOnShortestWayIndex = 0;
            int lastVisited = 0;
            bool isWayFound = false;
            for (int j = 0; j < this.shortCuts.Length - 1; j++)
            {
                int shortestWayToNextNode = int.MaxValue;
                for (int i = 0; i < this.shortCuts.Length; i++)
                {
                    if (this.shortCuts[i] < shortestWayToNextNode)
                    {
                        if (this.visitedCities[i] != -1)
                        {
                            shortestWayToNextNode = this.shortCuts[i];
                            nodeOnShortestWayIndex = i;
                        }
                    }
                }

                if (nodeOnShortestWayIndex != start)
                {
                    List<Node> neighbours = this.map[nodeOnShortestWayIndex];
                    foreach (var item in neighbours)
                    {
                        if (this.visitedCities[item.NextNode] != -1)
                        {
                            if ((this.shortCuts[item.NextNode]) > (this.shortCuts[nodeOnShortestWayIndex] + item.Distance))
                            {
                                this.shortCuts[item.NextNode] = this.shortCuts[nodeOnShortestWayIndex] + item.Distance;
                                List<int> currentWay = new List<int>();
                                List<int> oldWay = this.shortestWay[nodeOnShortestWayIndex];
                                currentWay.AddRange(oldWay);
                                currentWay.Add(nodeOnShortestWayIndex);
                                this.shortestWay[item.NextNode] = currentWay;
                                this.shortestWay[nodeOnShortestWayIndex] = oldWay;

                                if (item.NextNode == end)
                                {
                                    isWayFound = true;
                                }
                            }
                        }
                    }
                    this.visitedCities[nodeOnShortestWayIndex] = -1;
                    lastVisited = nodeOnShortestWayIndex;
                }
                if (isWayFound)
                {
                    break;
                }
            }
        }

        public void CreateMap()
        {
            StreamReader reader = new StreamReader("map.txt", Encoding.GetEncoding("UTF-8"));
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] tokens = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int keyNode = int.Parse(tokens[0]);
                    int nextNode = int.Parse(tokens[1]);
                    int distance = int.Parse(tokens[2]);
                    Node currentNode = new Node(nextNode, distance);

                    if (this.map.ContainsKey(keyNode))
                    {
                        List<Node> nodes = this.map[keyNode];
                        nodes.Add(currentNode);
                        this.map[keyNode] = nodes;
                    }
                    else
                    {
                        List<Node> nodes = new List<Node>();
                        nodes.Add(currentNode);
                        this.map.Add(keyNode, nodes);
                    }
                    line = reader.ReadLine();
                }
            }
        }

        public int ReadUserInput()
        {
            int point = 0;
            string inputLine = Console.ReadLine();
            bool isInputValide = true;
            while (isInputValide)
            {
                if (int.TryParse(inputLine, out point))
                {
                    isInputValide = false;
                }
                else
                {
                    Console.WriteLine(" ! ERROR !");
                    Console.WriteLine(" Invalide input: {0}", inputLine);
                    Console.WriteLine(" --------------------------------------- -------------");
                    Console.WriteLine(" input data must to be only integers, between 0 and 26");
                    Console.WriteLine(" -----------------------------------------------------");
                    Console.Write(" Please, try again: ");
                    inputLine = Console.ReadLine();
                }
            }
            return point;
        }

        public static void Main(string[] args)
        {
            MapsAndSearch theMap = new MapsAndSearch();
            theMap.CreateMap();
            theMap.CreateTownsNames();
            theMap.PrintCitiesCode();

            Console.Write(" Please, enter start point: ");
            int startPoint = theMap.ReadUserInput();
            Console.WriteLine();
            Console.Write(" Please, enter end point: ");
            int endPoint = theMap.ReadUserInput();
            Console.WriteLine();

            theMap.SearchShortCut(startPoint, endPoint);
            List<int> shortestWay = theMap.GiveMeShortestWayTo(endPoint);
            theMap.PrintShortestWay(shortestWay, startPoint, endPoint);

            Console.WriteLine(" ---------------   have a nice trip   --------------------");
            Console.ReadKey();
        }
    }
}
