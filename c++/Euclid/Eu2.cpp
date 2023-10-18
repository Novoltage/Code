//kevin bonifacio
#include <iostream>

using namespace std;


int Swap(int& nA, int& nB)
	{
		int Hold =0;
		
		Hold = nB;
		nB = nA;
		nA = Hold;
		
		return nA, nB;
	}


int GDC(int nA, int nB)
{

	while (nA != nB | nB == 0)
	{
		if (nB > nA) //swap
		{
			int Hold;
			Hold = nB;
			nB = nA;
			nA = Hold;
		}
		nA -= nB;
		cout << nA << " ";
		cout << nB << "\n";
	}
	
		cout << "GDC:" << nA << "\n";
	return nA;

}
int main()
{
	int nA, nB, Hold;
	cout << "Enter two numbers \n";
	while (cin >> nA >> nB)
	{
	  GDC(nA, nB);
		
		
	}
}