package nure.itinf_19_3.Domashina;

import java.util.InputMismatchException;
import java.util.Scanner;

public class Main {
    private static int getInputValue() {
        int result = -1;
        boolean isCorrectValue = false;

        while (!isCorrectValue) {
            System.out.println("Введите размер матрицы");
            Scanner input = new Scanner(System.in);
            try {
                result = input.nextInt();
                isCorrectValue = true;
            }
            catch (InputMismatchException e) {
                // There is empty to continue loop
            }
        }
        return result;
    }

    private static void outputMatrix(int[][] matrix, int n) {
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                System.out.print(matrix[i][j] + "\t");
            }
            System.out.println();
        }
        System.out.println();
    }

    public static void main(String[] args) {
        int n = getInputValue();
        MatrixTransformation mt = new MatrixTransformation(n);
        outputMatrix(mt.getMatrix(), mt.getN());
        mt.turnOn90Degrees();
        outputMatrix(mt.getMatrix(), mt.getN());
        mt.turnOn180Degrees();
        outputMatrix(mt.getMatrix(), mt.getN());
        mt.turnOn270Degrees();
        outputMatrix(mt.getMatrix(), mt.getN());
    }
}
