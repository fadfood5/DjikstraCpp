using System;

namespace WBFS{

	using System;
	using System.IO;
	using System.Linq;
	using System.Collections;
	using System.Collections.Generic;

	//Class for weighted Node Edges
	public class Edge{
		public int source;
		public int destination;
		public int weight;

		public Edge(int src,int dst,int wgt){
			source = src;
			destination = dst;
			weight = wgt;
		}
	}

	//Class for Nodes of a graph
	public class Node{
		//Instantiate list of edges for every node
		public List<Edge> NodeList;
		public Node(){
			//Create list of Edge Objects and log its creation
			NodeList= new List<Edge>();
			Console.Write("Created Node\n");
		}
	}

	public class Graph{
		//Instantiate list of nodes and number of vertices
		Node[] list;
		int vertices;

		public Graph(int v){
			//Save number of vertices
			vertices = v;
			//Create number of nodes according to number of vertices
			list = new Node[3];
			for(int i=0; i < v; i++) 
				list[i] = new Node();
		}

		public void addEdge(int src,int dst,int wgt){
			//Create Edge Object
			Edge ed = new Edge(src, dst, wgt);
			//Add Edge Object to source node edge list and log its addition
			list[src].NodeList.Add(ed);// If it were an undirected graph add the edge to source as well as destination node
			Console.Write("Added edge to vertex: " + src + "\n");
		}

		public void bfs(){
			bfs(0, 1);
		}

		public System.Boolean bfs(int s, int t){

			System.Boolean[] visited=new System.Boolean[vertices];
			visited[s]=true;

			List<int> queue=new List<int>();
			queue.Add(s);
			int next = s;

			while(queue.Any()){
				list.Skip(1).ToArray();
				next = list [0].NodeList [0].destination;
				Console.Write("Visited " + next + "node");
				for(int i=0;i<list[next].NodeList.Count();i++){
					Edge e1=list[next].NodeList[i];
					if(!visited[e1.destination]){
						visited[e1.destination] = true;
						queue.Add(e1.destination);
					}
				}
				Console.Write ("Queue is: ");
				for(int i = 0; i < queue.Count(); i++)
					Console.Write(queue[i]);
				Console.Write ("\n");
			}
			Console.Write("Empty");
			return false;
		}

		public static void Main(string[] args){


			/*Graph gr = new Graph(3);

			gr.addEdge(0, 1, 3);
			gr.addEdge(1, 2, 1);
			gr.addEdge(2, 0, 1);
			gr.addEdge(0, 2, 1);

			gr.bfs(0, 2);*/

			Console.Write("Do you want to import a .txt file with values or enter the vertices manually?\n");
			Console.Write("Enter 0 for file input and 1 for user input\n");

			var a = Console.ReadLine();
			var ch = Convert.ToChar(a);
			var value = int.Parse(ch.ToString());

			if (value == 0) {
				Console.Write ("What is the name of your .txt file? Make sure it is in the current directory\n");
				var b = Console.ReadLine ();

				string line;
				int counter = 0;
				System.IO.StreamReader file = new System.IO.StreamReader("../../" + b + ".txt");
				while((line = file.ReadLine()) != null)
				{
					Console.WriteLine (line);
					counter++;
				}

				file.Close();
				Console.Write (counter + " edges have been added\n");
			}
			if (value == 1) {
				Console.Write ("How many edges are there?\n");
				var e = Console.ReadLine ();
				var ch2 = Convert.ToChar(e);
				var value2 = int.Parse(ch2.ToString());
			}
		}
	}
}
