//Kevin Bonifacio

#include <iostream>
using namespace std;

int main()
{
	int inNum;
	string romanNum;
		cout << "Enter A Number 1-12 \n";
		cin >> inNum;
		
		switch (inNum)
		{
		case 1:
			romanNum = "I";
			break;
		case 2:
			romanNum = "II";
			break;
		case 3:
			romanNum = "III";
			break;
		case 4:
			romanNum = "IV";
			break;
		case 5:
			romanNum = "V";
			break;
		case 6:
			romanNum = "VI";
			break;
		case 7:
			romanNum = "VII";
			break;
		case 8:
			romanNum = "VIII";
			break;
		case 9:
			romanNum = "IX";
			break;
		case 10:
			romanNum = "X";
			break;
		case 11:
			romanNum = "XI";
			break;
		case 12:
			romanNum = "XII";
			break;

		default:
			romanNum = "Wrong";
			
		}
		if (romanNum.compare("Wrong") ==0)
		{
			cout << "Please try a Number 1-12";
		}
			else
			{
			cout << " Roman Number =" <<romanNum<<endl;
			}

		return 0;

}