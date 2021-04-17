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
    public void sumArrayElements_Test() {
        var array = new Complex[3];

        array[0] = new Complex(2, 3);
        array[1] = new Complex(4, 3);
        array[2] = new Complex(7, 6);

        var actual = MathOp.sumArrayElements(array);
        var expected = new Complex(13, 12);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void sumArrayElements_OneOfArrayElementsIsNull_Test() {
        var array = new Complex[3];

        array[0] = new Complex(2, 3);
        array[1] = null;
        array[2] = new Complex(7, 6);

        var actual = MathOp.sumArrayElements(array);
        var expected = new Complex(7, 6);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void multiplyArrayElements_Test() {
        var array = new Complex[3];

        array[0] = new Complex(2, 3);
        array[1] = new Complex(4, 3);
        array[2] = new Complex(7, 6);

        var actual = MathOp.multiplyArrayElements(array);
        var expected = new Complex(-235, 5);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void multiplyArrayElements_OneOfArrayElementsIsNull_Test() {
        var array = new Complex[3];

        array[0] = new Complex(2, 3);
        array[1] = null;
        array[2] = new Complex(7, 6);

        var actual = MathOp.multiplyArrayElements(array);
        var expected = new Complex(0, 0);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void sum_Fraction_Test() {
        var first = new Fraction(new Complex(2, 1), new Complex(1, 2));
        var second = new Fraction(new Complex(4, 3), new Complex(5, 6));

        var actual = MathOp.sum(first, second);
        var expected = new Fraction(new Complex(2, 28), new Complex(-7, 16));

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void sumOddAndEvenElementsOfArray_Test() {
        var actual = new Fraction[5];
        actual[0] = new Fraction(new Complex(2, 1), new Complex(1, 2));
        actual[1] = new Fraction(new Complex(4, 3), new Complex(5, 6));
        actual[2] = new Fraction(new Complex(2, 1), new Complex(1, 2));
        actual[3] = new Fraction(new Complex(4, 3), new Complex(5, 6));
        actual[4] = new Fraction(new Complex(2, 1), new Complex(1, 2));

        MathOp.sumArrayOddElementsWithEven(actual);

        var expected = new Fraction[5];
        expected[0] = new Fraction(new Complex(2, 28), new Complex(-7, 16));
        expected[1] = new Fraction(new Complex(4, 3), new Complex(5, 6));
        expected[2] = new Fraction(new Complex(2, 28), new Complex(-7, 16));
        expected[3] = new Fraction(new Complex(4, 3), new Complex(5, 6));
        expected[4] = new Fraction(new Complex(2, 1), new Complex(1, 2));

        Assertions.assertArrayEquals(expected, actual);
    }
}
