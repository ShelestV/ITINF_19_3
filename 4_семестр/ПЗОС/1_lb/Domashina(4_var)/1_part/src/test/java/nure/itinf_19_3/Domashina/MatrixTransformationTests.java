package nure.itinf_19_3.Domashina;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class MatrixTransformationTests {
    @Test
    public void turnOn90Degrees_Test() {
        var matrix = new int[][] {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
        };

        var actual = MatrixTransformation.turnOn90Degrees(matrix);
        var expected = new int[][] {
                {3, 6, 9},
                {2, 5, 8},
                {1, 4, 7}
        };

        Assertions.assertArrayEquals(expected, actual);
    }
}
