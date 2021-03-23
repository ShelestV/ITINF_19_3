#include <iostream>
#include <intrin.h>
#include<string>

using namespace std;

extern "C" void _asmFunc_(int* array, int* newArray);

void func(int* array, int* newArray)
{
	int counter = 0;
	for (int i = 0; i < 10; ++i)
	{
		if (array[i] < 0)
			newArray[counter++] = array[i];
	}
	for (int i = 0; i < 10; ++i)
	{
		if (array[i] >= 0)
			newArray[counter++] = array[i];
	}
}

void printTime(string timeName, long long firstTime, long long secondTime) {
	cout << timeName << secondTime - firstTime << endl;
	cout << endl;
}

int main()
{
	int* array = new int[10];
	int* newArray = new int[10];

	for (int i = 0; i < 10; ++i)
	{
		array[i] = rand() % 100 - 60;
		cout << array[i] << "\t";
	}
	cout << endl;
	int counter = 0;

	long long firstTime = __rdtsc();
	for (int i = 0; i < 10; ++i)
	{
		if (array[i] < 0)
			newArray[counter++] = array[i];
	}
	for (int i = 0; i < 10; ++i)
	{
		if (array[i] >= 0)
			newArray[counter++] = array[i];
	}
	long long secondTime = __rdtsc();
	for (int i = 0; i < 10; ++i)
	{
		cout << newArray[i] << "\t";
	}
	cout << endl << endl;
	printTime("C++:", firstTime, secondTime);

	firstTime = __rdtsc();
	func(array, newArray);
	secondTime = __rdtsc();
	printTime("C++ Func:", firstTime, secondTime);

	firstTime = __rdtsc();
	__asm
	{

		mov eax, 0
		mov ebx, 0
		mov ecx, 0
		mov edx, array
		mov edi, newArray

		start :
		cmp ecx, 10
			jge next_loop

			mov eax, [edx]
			cbw
			test eax, eax
			jns next_elem

			mov[edi], eax
			add edi, 4

			next_elem:
		add edx, 4
			inc ecx
			jmp start

			next_loop :
		mov ecx, 0
			mov edx, array
			start_2 :
		cmp ecx, 10
			jge ending

			mov eax, [edx]
			cbw
			test eax, eax
			js next_elem_2

			mov[edi], eax
			add edi, 4

			next_elem_2:
		add edx, 4
			inc ecx
			jmp start_2

			ending :


	}
	secondTime = __rdtsc();

	printTime("Asm:", firstTime, secondTime);

	firstTime = __rdtsc();
	_asmFunc_(array, newArray);
	secondTime = __rdtsc();

	printTime("Asm Func:", firstTime, secondTime);

	system("pause");
	return 0;
}

