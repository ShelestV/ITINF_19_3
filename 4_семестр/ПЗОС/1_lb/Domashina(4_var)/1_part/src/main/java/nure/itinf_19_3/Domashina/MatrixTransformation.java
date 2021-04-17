package nure.itinf_19_3.Domashina;

import java.util.Random;

public class MatrixTransformation {
    private final int length;
    private int[][] matrix;

    public MatrixTransformation(int length) {
        this.length = length;
        matrix = new int[length][length];
        Random random = new Random();

        for (int i = 0; i < length; ++i) {
            for (int j = 0; j < length; ++j) {
                matrix[i][j] = random.nextInt(length);
            }
        }
    }

    public void consoleOutput() {
        for (int i = 0; i < length; ++i) {
            for (int j = 0; j < length; ++j) {
                System.out.print(matrix[i][j] + "\t");
            }
            System.out.println();
        }
        System.out.println();
    }

    public static int[][] turnOn90Degrees(int[][] matrix) {
        if (matrix != null && matrix.length == matrix[0].length) {
            int length = matrix.length;
            int[][] result = new int[length][length];

            for (int i = 0; i < length; ++i) {
                for (int j = 0; j < length; ++j) {
                    result[length - j - 1][i] = matrix[i][j];
                }
            }

            return result;
        }
        return null;
    }

    public void turnOn90Degrees() {
        matrix = turnOn90Degrees(matrix);
    }

    public void turnOn180Degrees() {
        turnOn90Degrees();
        turnOn90Degrees();
    }

    public void turnOn270Degrees() {
        turnOn180Degrees();
        turnOn90Degrees();
    }
}
