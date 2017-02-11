#include <iostream>
#include <list>

using namespace std;

class VerticesSet{
	int count;
	list<int> *nearMe;
public:
	VerticesSet(int count);
	void createNode(int newNode, int currList);
	bool checkIfDoable(int x, int y);
};

VerticesSet::VerticesSet(int count){
	this->count = count;
	nearMe = new list<int>[count];
}

void VerticesSet::createNode(int newNode, int currList){
	nearMe[newNode].push_back(currList);
}

bool VerticesSet::checkIfDoable(int x, int y){
	if(x == y){
		return true;
	}
	bool *visited;
	bool visitedArr = new bool[count];
	visited = &visitedArr;
	 for (int i = 0; i < count; i++)
			 visited[i] = false;

	 // Create a queue for BFS
	 list<int> queue;

	 // Mark the current node as visited and enqueue it
	 visited[x] = true;
	 queue.push_back(x);


	 // it will be used to get all adjacent vertices of a vertex
	 list<int>::iterator i;


	 while (!queue.empty()){
			 // Dequeue a vertex from queue and print it
			 x = queue.front();
			 queue.pop_front();


			 // Get all adjacent vertices of the dequeued vertex x
			 // If a adjacent has not been visited, then mark it visited
			 // and enqueue it
			 for (i = nearMe[x].begin(); i != nearMe[x].end(); ++i){
					 // If this adjacent node is the destination node, then return true
					 if (*i == y)
							 return true;


					 // Else, continue to do BFS
					 if (!visited[*i])
					 {
							 visited[*i] = true;
							 queue.push_back(*i);
					 }
			 }
	 }


	 return false;
}


// Driver program to test methods of VerticesSet class
int main(){
	 // Create a VerticesSet given in the above diagram
	 VerticesSet g(4);
	 g.createNode(0, 1);
	 g.createNode(0, 2);
	 g.createNode(1, 2);
	 g.createNode(2, 0);
	 g.createNode(2, 3);
	 g.createNode(3, 3);


	 cout << "Enter the source and destination vertices: (0-3)" << endl;
	 int u, v;
	 cin >> u >> v;
	 if (g.checkIfDoable(u, v))
			 cout << "\nThere is a path from " << u << " to " << v << endl;
	 else
			 cout << "\nThere is no path from " << u << " to " << v << endl;

	 int temp = u;
	 u = v;
	 v = temp;
	 if (g.checkIfDoable(u, v))
			 cout << "\nThere is a path from " << u << " to " << v << endl;
	 else
			 cout << "\nThere is no path from " << u << " to " << v << endl;

	 return 0;
	}
