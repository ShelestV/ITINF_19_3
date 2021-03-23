#include <iostream>

int main()
{
	std::cout << "Enter the length of array: ";
	int n;
	std::cin >> n;
	short int a[100];
	short int b[100] = { 0 };
	
	for (int i = 0; i < n; ++i)
	{
		std::cin >> a[i];
	}

	std::cout << std::endl;

	_asm
	{
		mov esi, 0; задаём счётчик
		mov ecx, n; конечное значение цикла

		L : ; точка начала цикла
			;xor ax, ax; обнуляем регистр ax
			mov ax, a[esi]; записываем в регистр элемент массива
			mov bx, 1101101101101101b; записываем в регистр число, у которого каждый третий бит нулевой
			and ax, bx; заменяем каждый третий бит на 0
			mov b[esi], ax; записываем в массив изменённое значения

			; инкрементируем счётчик, чтобы увеличить на 1, надо 2 инкремента
			inc esi
			inc esi
		loop L
	};
	
	std::cout << "Result\n";
	for (int i = 0; i < n; ++i)
	{
		std::cout << b[i] << std::endl;
	}
	return 0;
}

/*
Задано  масив  байтів.
Переписати  його  елементи  до  іншого  масиву,
змінюючи кожний третій біт елемента на 0.
*/