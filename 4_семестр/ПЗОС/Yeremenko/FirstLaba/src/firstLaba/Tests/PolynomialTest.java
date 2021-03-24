package firstLaba.Tests;

import firstLaba.Polynomial;
import firstLaba.RationalFraction;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

class PolynomialTest {

    @Test
    void getSum() {
        var fractions = new ArrayList<RationalFraction>();
        fractions.add(new RationalFraction(1, 2));
        fractions.add(new RationalFraction(2,3));
        fractions.add(new RationalFraction(3,4));
        var expected = new RationalFraction(46, 24);
        var polynomial = new Polynomial(fractions);
        RationalFraction actual = polynomial.getSum();
        assertTrue(expected.getDenominator() == actual.getDenominator() && expected.getNumerator() == actual.getNumerator());
    }
}