.586
.model flat,c

.code
_asmFunc_ proc
public _asmFunc_

push ebp
mov ebp,esp

push eax
push ebx
push ecx
push edx
push edi

		mov eax, 0
		mov ebx, 0
		mov ecx, 0
		mov edx, [ebp+8]
		mov edi, [ebp+12]

		start:
			cmp ecx, 10
			jge next_loop

			mov eax, [edx]
			cbw
			test eax, eax
			jns next_elem

			mov [edi], eax
			add edi, 4

		next_elem:
			add edx, 4
			inc ecx
			jmp start

		next_loop:
			mov ecx, 0
			mov edx, [ebp+8]
		start_2:
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

		ending:

pop edi
pop edx
pop ecx
pop ebx
pop eax

pop ebp

ret

_asmFunc_ endp
end