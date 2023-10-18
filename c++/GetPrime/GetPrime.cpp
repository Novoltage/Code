//Kevin Bonifacio

#include<iostream>
using namespace std;

void getPrime(int number) 
{
    int array[50];// array exist only in get prime funct
    
    for (int i = 5, a = 0; i < number; ++i) //fill array with primes.
    {
        int x = 0;// variable to check if prime. 1 = prime, 0 = not prime.
        for (int j = 2; j < i; j++) //prime loop
        {
            if (i % j == 0) 
            {
                x = 1;
                break;// break out of loop if not prime
            }
        }
        if (x == 0)//if prime save into array
        {
            array[a] = i;
            cout << array[a] << endl;
            a = a++;// next array point                
        }         
    }
    cout <<"This Your List Prime Numbers up to "<<number<<endl;
}

int main()
{     
    int number;

    cout << "Enter a Number: ";
    cin >> number;
    getPrime(number);
    
    return 0;
}