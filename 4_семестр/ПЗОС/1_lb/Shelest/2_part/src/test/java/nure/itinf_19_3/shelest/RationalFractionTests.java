package nure.itinf_19_3.shelest;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class RationalFractionTests {
    @Test
    public void toDoubleTest() {
        RationalFraction fraction = new RationalFraction(12, 8);

        double actual = fraction.toDouble();
        double expected = 1.5;

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void toStringTest() {
        RationalFraction fraction = new RationalFraction(3, 4);

        String actual = fraction.toString();
        String expected = "3/4";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void additionTest() {
        RationalFraction f1 = new RationalFraction(5, 15);
        RationalFraction f2 = new RationalFraction(15, 25);

        String actual = f1.addition(f2).toString();
        String expected = "14/15";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void additionStaticTest() {
        RationalFraction f1 = new RationalFraction(3, 4);
        RationalFraction f2 = new RationalFraction(1, 2);

        String actual = RationalFraction.addition(f1, f2).toString();
        String expected = "5/4";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void multiplyTest() {
        RationalFraction f1 = new RationalFraction(3, 4);
        RationalFraction f2 = new RationalFraction(1, 2);

        String actual = f1.multiply(f2).toString();
        String expected = "3/8";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void multiplyStaticTest() {
        RationalFraction f1 = new RationalFraction(15, 32);
        RationalFraction f2 = new RationalFraction(8, 9);

        String actual = RationalFraction.multiply(f1, f2).toString();
        String expected = "5/12";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void divisionTest() {
        RationalFraction f1 = new RationalFraction(3, 4);
        RationalFraction f2 = new RationalFraction(1, 2);

        String actual = f1.division(f2).toString();
        String expected = "3/2";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void divisionStaticTest() {
        RationalFraction f1 = new RationalFraction(15, 32);
        RationalFraction f2 = new RationalFraction(8, 9);

        String actual = RationalFraction.division(f1, f2).toString();
        String expected = "135/256";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void minusTest() {
        RationalFraction f1 = new RationalFraction(3, 4);
        RationalFraction f2 = new RationalFraction(1, 2);

        String actual = f1.minus(f2).toString();
        String expected = "1/4";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void minusStaticTest() {
        RationalFraction f1 = new RationalFraction(27, 34);
        RationalFraction f2 = new RationalFraction(75, 23);

        String actual = RationalFraction.minus(f1, f2).toString();
        String expected = "-1929/782";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void simplifyTest() {
        RationalFraction fraction = new RationalFraction(10, 75);

        String actual = fraction.simplify().toString();
        String expected = "2/15";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void reverseTest() {
        RationalFraction fraction = new RationalFraction(10, 75);

        String actual = fraction.reverse().toString();
        String expected = "-10/75";

        Assertions.assertEquals(expected, actual);
    }
}
