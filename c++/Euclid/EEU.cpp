#include <iostream>

using namespace std;

int main()
{
	int nA, nB, Hold;
	cout << "Enter two numbers \n";
	while (cin >> nA >> nB)
	{
		while (nA != nB | nB == 0)
		{
			if (nB > nA) //swap
			{
				Hold = nB;
				nB = nA;
				nA = Hold;
			}
			nA -= nB;
			cout << nA << " ";
			cout << nB << "\n";
		}
		cout << "GDC:"<<nA << "\n";

	}
}