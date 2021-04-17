package nure.itinf_19_3.Domashina;

import java.util.InputMismatchException;
import java.util.Scanner;

public class Main {
    public static int getInputValue() {
        boolean isCorrectValue = false;
        int value = -1;

        while (!isCorrectValue) {
            Scanner input = new Scanner(System.in);

            try {
                System.out.print("Enter size of matrix: ");
                value = input.nextInt();
                isCorrectValue = true;
            }
            catch (InputMismatchException e) {
                // to continue loop
            }
        }
        return value;
    }

    public static void main(String[] args) {
        int size = getInputValue();

        MatrixTransformation mt = new MatrixTransformation(size);
        mt.consoleOutput();

        mt.turnOn90Degrees();
        mt.consoleOutput();

        mt.turnOn180Degrees();
        mt.consoleOutput();

        mt.turnOn270Degrees();
        mt.consoleOutput();
    }
}
