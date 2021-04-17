package nure.itinf_19_3.Domashina;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class FractionTests {
    @Test
    public void constructor_Test() {
        var actual = new Fraction();

        var expectedNumerator = new Complex();
        var expectedDenominator = new Complex(1, 1);

        Assertions.assertEquals(expectedNumerator, actual.getN());
        Assertions.assertEquals(expectedDenominator, actual.getM());
    }

    @Test
    public void constructorWithParameters_Test() {
        var expectedNumerator = new Complex(3, 4);
        var expectedDenominator = new Complex(5, 7);

        var actual = new Fraction(expectedNumerator, expectedDenominator);

        Assertions.assertEquals(expectedNumerator, actual.getN());
        Assertions.assertEquals(expectedDenominator, actual.getM());
    }

    @Test
    public void equals_Test() {
        var expected = new Fraction(new Complex(4, 5), new Complex(6, 5));
        var actual = new Fraction(new Complex(4, 5), new Complex(6, 5));

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void equals_Not_Test() {
        var expected = new Fraction(new Complex(4, 5), new Complex(6, 5));
        var actual = new Fraction(new Complex(5, 6), new Complex(5, 5));

        Assertions.assertNotEquals(expected, actual);
    }

    @Test
    public void equals_DifferentTypes_Test() {
        var expected = new Fraction();
        var actual = 5.0;

        Assertions.assertNotEquals(expected, actual);
    }

    @Test
    public void equals_Null_Test() {
        var expected = new Fraction();

        Assertions.assertNotEquals(expected, null);
    }

    @Test
    public void toString_Test() {
        var actual = new Fraction(new Complex(4, 5), new Complex(6, 5));

        Assertions.assertEquals("(4 + (5)i) / (6 + (5)i)", actual.toString());
    }
}
