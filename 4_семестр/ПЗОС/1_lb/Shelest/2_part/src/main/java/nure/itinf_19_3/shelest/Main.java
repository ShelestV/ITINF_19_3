package nure.itinf_19_3.shelest;

import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.List;
import java.util.Scanner;

public class Main {
    private static int inputInteger() {
        Scanner in = new Scanner(System.in);
        int number = 0;

        boolean isCorrectValue = false;
        do {
            try {
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
        int k;
        System.out.println("Enter size of array: ");
        k = inputInteger();

        List<RationalFraction> fractions = new ArrayList<>();
        for (int i = 0; i < k; ++i) {
            RationalFraction fraction = new RationalFraction();
            System.out.println("Enter " + (i + 1) + " fraction: ");
            System.out.println("m: ");
            fraction.setM(inputInteger());
            System.out.println("n: ");
            fraction.setN(inputInteger());
            fractions.add(fraction);
        }

        for (RationalFraction fraction : fractions) {
            System.out.println(fraction.toString());
        }
        System.out.println();

        fractions = RationalFractionServer.modifyArray(fractions);

        for (RationalFraction fraction : fractions) {
            System.out.println(fraction.toString());
        }
    }
}
