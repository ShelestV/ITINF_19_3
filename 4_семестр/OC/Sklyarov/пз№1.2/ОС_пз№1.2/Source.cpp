#include <iostream>

using namespace std;

int main()
{
	int matr[5][5] = { {1,1,1,1,1},
		{2,2,2,2,2},
		{3,3,3,3,3},
		{4,4,4,4,4},
		{5,5,5,5,5} };
	int resMas[5] = {1, 1, 1, 1, 1};
	int res=0;
	for (int i = 0; i < 5; ++i)
	{
		cout << resMas[i] << ' ';
	}
	cout << endl;
	_asm
	{
		mov     res, 0
		lea     ebx, matr
		lea		edi, resMas
		mov     ecx, 5
	ForI:

		mov		res, 0
		mov     esi, 0
		push    ecx
		mov     ecx, 5
	ForJ:
		mov     eax, [esi + ebx]
		add     res, eax
		add     esi, 4
	loop    ForJ		
		pop     ecx
		mov		edx, res
		mov		[edi], edx
		add		edi, 4
		add		ebx, 20
	loop    ForI
	}
	for (int i = 0; i < 5; ++i)
	{
		cout << resMas[i] << ' ';
	}
}