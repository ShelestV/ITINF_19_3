#include <iostream>
#include <vector>

int main()
{
	std::cout << "Enter the length of array: ";
	int n;
	std::cin >> n;
	short int a[100];
	short int b[100] = {0};
	for (int i = 0; i < n; ++i)
	{
		std::cin >> a[i];
	};
	std::cout << std::endl;
	_asm
	{
		mov esi, 0		
		mov ecx, n
		
		L :
		xor bx, bx
			mov ax, a[esi]
			shl ax, 1
			rcl bx, 1
			shl ax, 1
			rcl bx, 1
			shl ax, 1
			rcl bx, 1
			rol bx, 3
			ror ax, 3

			shr ax, 1
			rcr bx, 1
			shr ax, 1
			rcr bx, 1
			shr ax, 1
			rcr bx, 1
			rol ax, 3
			or bx, ax
		mov b[esi], bx
		inc esi
		inc esi
		loop L
	};
	for (int i = 0; i < n; ++i)
	{
		std::cout << (unsigned short int)b[i] << " ";
	};
	return 0;
}