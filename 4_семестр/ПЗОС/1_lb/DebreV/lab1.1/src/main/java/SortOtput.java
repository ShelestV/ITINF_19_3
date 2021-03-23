//Ввести n чисел с консоли. Упорядочитьи вывести числа в порядке возрастания (убывания) значений их длины.
import java.util.Scanner;

public class SortOtput {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("Input an array size(n) of numbers: ");
        int size = input.nextInt();
        int[] array = new int[size];
        for (int i = 0; i < size; i++) {
            array[i] = input.nextInt();
        }
        input.close();

        System.out.println("Ascending sequence :");
        sortArray(array);
        for (int i = 0; i < array.length; i++) {
            System.out.print(array[i] + " ");
        }
        System.out.println("Decline sequence :");
        for (int i = array.length - 1; i >= 0; i--) {
            System.out.print(array[i] + " ");
        }
    }

    public static void sortArray(int[] array) {
        int size = array.length;
        int[] lengthArray = new int[size];
        for (int i = 0; i < size; i++) {
            lengthArray[i] = String.valueOf(array[i]).toCharArray().length;
        }
        int temp;
        boolean sorted = false;
        boolean ascending = true;
        while (!sorted) {
            sorted = true;
            for (int i = 0; i < size - 1; i++) {
                if (lengthArray[i] > lengthArray[i + 1]) {
                    temp = lengthArray[i];
                    lengthArray[i] = lengthArray[i + 1];
                    lengthArray[i + 1] = temp;
                    temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    sorted = false;
                }
            }
        }
    }
}
