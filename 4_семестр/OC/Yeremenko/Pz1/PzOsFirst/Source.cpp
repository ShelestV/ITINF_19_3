#include <iostream>

int main()
{
	int n, k = 0;
	short* array, * newArray;

	std::cout << "Input n: ";
	std::cin >> n;

	array = new short[n];
	newArray = new short[n];

	std::cout << "\nArray:" << std::endl;
	for (int i = 0; i < n; ++i)
	{
		array[i] = rand() % 100;
		std::cout << array[i] << "\t";
	}
	std::cout << std::endl;

	__asm
	{
		mov eax, 0
		mov bh, 3
		mov ecx, 0
		mov edx, array
		mov edi, newArray

		start :
		cmp ecx, n
			jge ending
			mov ax, [edx]
			shr ax, 2
			bits_looping :
			cmp bh, 6
			jg check_ones
			shr ax, 1
			jnc not_one
			inc bl
			not_one :
		inc bh
			jmp bits_looping
			check_ones :
		test bl, 1
			jnz next_elem
			mov ax, [edx]
			mov[edi], ax
			add edi, 2
			inc k
			next_elem :
		add edx, 2
			mov bh, 3
			mov bl, 0
			inc ecx
			jmp start
			ending :
	}

	std::cout << "New Array:" << std::endl;
	for (int i = 0; i < k; ++i)
	{
		std::cout << newArray[i] << "\t";
	}
	std::cout << "\n\n";

	std::cout << "Matrix:" << std::endl;
	int matrix[6][4];
	for (int i = 0; i < 6; ++i)
	{
		for (int j = 0; j < 4; ++j)
		{
			matrix[i][j] = rand() % 200 - 100;
			std::cout << matrix[i][j] << "\t";
		}
		std::cout << std::endl;
	}
	std::cout << std::endl;

	__asm
	{
		mov eax, 0
		mov ebx, 0
		mov ecx, 0
		lea edx, matrix

		check_start_matrix :
		cmp ecx, 24
			jge check_end_matrix
			mov ax,[edx + ecx * 4]
			cmp ax, 0
			je check_not_positive
			test ax, ax
			js check_not_positive
			inc ebx
			check_not_positive :
		inc ecx
			jmp check_start_matrix
			check_end_matrix :
		mov k, ebx
	}
	int* positiveElems = new int[k];
	__asm
	{
		mov eax, 0
		mov ebx, 0
		mov ecx, 0
		lea edx, matrix
		mov edi, positiveElems

		start_matrix :
		cmp ecx, 24
			jge end_matrix
			mov eax, [edx + ecx * 4]
			cmp eax, 0
			je not_positive
			test eax, eax
			js not_positive
			mov[edi], eax
			add edi, 4
			not_positive :
		inc ecx
			jmp start_matrix
			end_matrix :

	}

	std::cout << "Array of positive elements:" << std::endl;
	for (int i = 0; i < k; ++i)
	{
		std::cout << positiveElems[i] << "\t";
	}
	std::cout << std::endl;

	system("pause");
	return 0;
}