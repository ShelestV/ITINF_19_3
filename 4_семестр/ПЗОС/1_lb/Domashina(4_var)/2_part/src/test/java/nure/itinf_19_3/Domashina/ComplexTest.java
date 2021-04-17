package nure.itinf_19_3.Domashina;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class ComplexTest {
    @Test
    public void constructor_Test() {
        var actual = new Complex();

        double expectedReal = 0.0;
        double expectedImaginary = 0.0;

        Assertions.assertEquals(expectedReal, actual.getReal());
        Assertions.assertEquals(expectedImaginary, actual.getImaginary());
    }

    @Test
    public void constructorOfCopying_Test() {
        var expected = new Complex(4, 5);
        var actual = new Complex(expected);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void constructorWithParameters_Test() {
        double expectedReal = 4;
        double expectedImaginary = 5;

        var actual = new Complex(expectedReal, expectedImaginary);

        Assertions.assertEquals(expectedReal, actual.getReal());
        Assertions.assertEquals(expectedImaginary, actual.getImaginary());
    }

    @Test
    public void equals_Test() {
        var expected = new Complex(4, 5);
        var actual = new Complex(4, 5);

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void equals_Not_Test() {
        var expected = new Complex(4, 5);
        var actual = new Complex(5, 4);

        Assertions.assertNotEquals(expected, actual);
    }

    @Test
    public void equals_DifferentTypes_Test() {
        var expected = new Complex();
        var actual = 5.0;

        Assertions.assertNotEquals(expected, actual);
    }

    @Test
    public void equals_Null_Test() {
        var expected = new Complex();

        Assertions.assertNotEquals(expected, null);
    }

    @Test
    public void toString_Test() {
        var actual = new Complex(5.4, 6.7);

        Assertions.assertEquals("5 + (7)i", actual.toString());
    }
}
