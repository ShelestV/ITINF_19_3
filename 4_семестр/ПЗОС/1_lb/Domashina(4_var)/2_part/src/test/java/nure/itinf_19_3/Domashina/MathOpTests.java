package nure.itinf_19_3.Domashina;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class MathOpTests {
    @Test
    public void sum_Test() {
        var first = new ComplexNumber(3, 4);
        var second = new ComplexNumber(5, 6);

        var actual = MathOp.sum(first, second);
        var expected = new ComplexNumber(8, 10);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void minus_Test() {
        var first = new ComplexNumber(5, 6);
        var second = new ComplexNumber(3, 4);

        var actual = MathOp.minus(first, second);
        var expected = new ComplexNumber(2, 2);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void multiply_Test() {
        var first = new ComplexNumber(3, 4);
        var second = new ComplexNumber(2, -1);

        var actual = MathOp.multiply(first, second);
        var expected = new ComplexNumber(10, 5);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void divideOnNumber_Test() {
        var first = new ComplexNumber(10, 15);
        var divider = 5.0;

        var actual = MathOp.divide(first, divider);
        var expected = new ComplexNumber(2, 3);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void divide_Test() {
        var first = new ComplexNumber(3, 4);
        var second = new ComplexNumber(2, 1);

        var actual = MathOp.divide(first, second);
        var expected = new ComplexNumber(2, 1);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void divideOnNumberZero_Test() throws ArithmeticException {
        var first = new ComplexNumber(10, 15);
        var zero = 0.0;

        Assertions.assertThrows(ArithmeticException.class, () -> MathOp.divide(first, zero));
    }

    @Test
    public void divideOnZero_Test() throws ArithmeticException {
        var first = new ComplexNumber(10, 15);
        var zero = new ComplexNumber();

        Assertions.assertThrows(ArithmeticException.class, () -> MathOp.divide(first, zero));
    }
}
