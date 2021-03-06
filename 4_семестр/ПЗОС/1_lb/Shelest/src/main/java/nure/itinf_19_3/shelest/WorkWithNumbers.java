package nure.itinf_19_3.shelest;

import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.List;
import java.util.Scanner;

public class WorkWithNumbers {
    private static int inputInteger() {
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

    public static double getAvarageValue(List<Integer> array) {
        double result = 0.0;
        for (int value : array) {
            result += value;
        }
        result /= array.size();
        return result;
    }

    public static List<Integer> getValuesLessThenAvarageValue(List<Integer> array) {
        List<Integer> result = new ArrayList<>();

        double avg = getAvarageValue(array);
        for (int value : array) {
            if ((double)value < avg) {
                result.add(value);
            }
        }
        return result;
    }

    public static List<Integer> getValueGreaterThenAvarageValue(List<Integer> array) {
        List<Integer> result = new ArrayList<>();

        double avg = getAvarageValue(array);
        for (int value : array) {
            if ((double)value > avg) {
                result.add(value);
            }
        }
        return result;
    }

    public static void main(String[] args) {
        System.out.println("Input amount of numbers: ");
        int amountOfNumbers = inputInteger();
        System.out.println();

        List<Integer> numbers = new ArrayList<>();
        System.out.println("Input values of arrays: ");
        for (int i = 0; i < amountOfNumbers; ++i) {
            numbers.add(inputInteger());
        }

        List<Integer> lessThenAvg = getValuesLessThenAvarageValue(numbers);
        List<Integer> greaterThenAvg = getValueGreaterThenAvarageValue(numbers);

        System.out.println(
                "Length of array of numbers less than avarage number of array inputted by user = " + lessThenAvg.size());
        for (int value : lessThenAvg) {
            System.out.print(value + " ");
        }

        System.out.println();
        System.out.println(
                "Length of array of numbers greater than avarage number of array inputted by user = " + greaterThenAvg.size());
        for (int value : greaterThenAvg) {
            System.out.print(value + " ");
        }
    }
}
/*
* Ввести n чисел с консоли.
* Вывести на консоль те числа,
* длина которых меньше (больше) средней,
* а также длину.
*/