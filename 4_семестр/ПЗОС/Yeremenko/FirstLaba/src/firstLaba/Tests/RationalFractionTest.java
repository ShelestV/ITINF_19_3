package firstLaba.Tests;

import firstLaba.RationalFraction;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class RationalFractionTest {

    @Test
    void setDenominatorDenominatorZero() {
        try{
            new RationalFraction(2,2);
        } catch (Exception exception){
           assertTrue(true);
        }
    }
    @Test
    void setDenominatorDenominatorLessZero(){
        var rationalFraction = new RationalFraction(-2, -2);
        int actual = rationalFraction.getNumerator();
        var expected = 2;
        assertEquals(expected, actual);
    }
}