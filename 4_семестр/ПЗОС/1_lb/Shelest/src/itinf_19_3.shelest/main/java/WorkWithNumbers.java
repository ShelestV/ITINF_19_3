import java.util.InputMismatchException;
import java.util.Scanner;

public class WorkWithNumbers {

    public static int inputInteger() {
        Scanner in = new Scanner(System.in);
        int number = 0;

        boolean isCorrectValue = false;
        do {
            try {
                System.out.println("Input value: ");
                number = in.nextInt();
                isCorrectValue = true;
            } catch (InputMismatchException e) {
                System.out.println("Enter correct value!");
                in.nextLine();
            }
        } while (!isCorrectValue);
        return number;
    }

    public static void main(String[] args) {
        int amountOfNumbers = inputInteger();

        int[] numbers = new int[amountOfNumbers];
        for (int i = 0; i < amountOfNumbers; ++i) {
            numbers[i] = inputInteger();
        }


    }
}
/*
* Ввести n чисел с консоли.
* Вывести на консоль те числа, длина которых меньше (больше) средней, а также длину.
*/