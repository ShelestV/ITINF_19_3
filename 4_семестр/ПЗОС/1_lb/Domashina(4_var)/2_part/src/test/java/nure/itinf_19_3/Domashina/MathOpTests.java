package nure.itinf_19_3.Domashina;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class MathOpTests {
    @Test
    public void sum_Test() {
        var first = new Complex(4, 5);
        var second = new Complex(6, -5);

        var expected = new Complex(10, 0);

        Assertions.assertEquals(expected, MathOp.sum(first, second));
    }

    @Test
    public void sum_Null_Test() {
        var first = new Complex(4, 5);

        var expected = new Complex();

        Assertions.assertEquals(expected, MathOp.sum(first, null));
    }

    @Test
    public void minus_Test() {
        var first = new Complex(4, 5);
        var second = new Complex(6, -5);

        var expected = new Complex(-2, 10);

        Assertions.assertEquals(expected, MathOp.minus(first, second));
    }

    @Test
    public void minus_Null_Test() {
        var first = new Complex(4, 5);

        var expected = new Complex();

        Assertions.assertEquals(expected, MathOp.minus(first, null));
    }

    @Test
    public void multiply_Test() {
        var first = new Complex(4, 5);
        var second = new Complex(6, -5);

        var expected = new Complex(49, 10);

        Assertions.assertEquals(expected, MathOp.multiply(first, second));
    }

    @Test
    public void multiply_Null_Test() {
        var first = new Complex(4, 5);

        var expected = new Complex();

        Assertions.assertEquals(expected, MathOp.multiply(first, null));
    }

    @Test
    public void divideOnNumber_Test() {
        var first = new Complex(10, 5);
        var second = 5.0;

        var expected = new Complex(2, 1);

        Assertions.assertEquals(expected, MathOp.divide(first, second));
    }

    @Test
    public void divideOnNumber_Zero_Test() throws ArithmeticException {
        var first = new Complex(4, 5);
        var second = 0.0;

        Assertions.assertThrows(ArithmeticException.class, () -> MathOp.divide(first, second));
    }

    @Test
    public void divideOnComplexNumber_Test() {
        var first = new Complex(3, 4);
        var second = new Complex(2, 1);

        var expected = new Complex(2, 1);

        Assertions.assertEquals(expected, MathOp.divide(first, second));
    }

    @Test
    public void divideOnComplexNumber_Zero_Test() throws ArithmeticException {
        var first = new Complex(4, 5);
        var second = new Complex();

        Assertions.assertThrows(ArithmeticException.class, () -> MathOp.divide(first, second));
    }


    @Test
    public void divideOnComplexNumber_Null_Test() {
        var first = new Complex(4, 5);

        var expected = new Complex();

        Assertions.assertEquals(expected, MathOp.divide(first, null));
    }

    @Test
    public void sum_Array_Test() {
        var array = new Complex[3];

        array[0] = new Complex(2, 3);
        array[1] = new Complex(4, 3);
        array[2] = new Complex(7, 6);

        var actual = new Complex();
        for (var number : array) {
            actual = MathOp.sum(actual, number);
        }

        var expected = new Complex(13, 12);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void sum_Array_OneOfThemIsNull_Test() {
        var array = new Complex[3];

        array[0] = new Complex(2, 3);
        array[1] = null;
        array[2] = new Complex(7, 6);

        var actual = new Complex();
        for (var number : array) {
            actual = MathOp.sum(actual, number);
        }

        var expected = new Complex(7, 6);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void multiply_Array_Test() {
        var array = new Complex[3];

        array[0] = new Complex(2, 3);
        array[1] = new Complex(4, 3);
        array[2] = new Complex(7, 6);

        var actual = new Complex(1, 1);
        for (var number : array) {
            actual = MathOp.multiply(actual, number);
        }

        var expected = new Complex(-235, 5);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void multiply_Array_OneOfThemIsNull_Test() {
        var array = new Complex[3];

        array[0] = new Complex(2, 3);
        array[1] = null;
        array[2] = new Complex(7, 6);

        var actual = new Complex();
        for (var number : array) {
            actual = MathOp.multiply(actual, number);
        }

        var expected = new Complex(0, 0);

        Assertions.assertEquals(expected, actual);
    }
}
