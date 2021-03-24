package firstLaba.Tests;

import firstLaba.RationalFraction;
import firstLaba.RationalFractionHandler;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

class RationalFractionHandlerTest {
    @Test
    void sumFractions(){
        var firstFraction = new RationalFraction(2, 5);
        var secondFraction = new RationalFraction(1, 3);
        RationalFraction actual = RationalFractionHandler.sumFractions(firstFraction, secondFraction);
        var expected = new RationalFraction(11, 15);
        assertTrue(actual.getNumerator() == expected.getNumerator() && actual.getDenominator() == expected.getDenominator());
    }

    @Test
    void increaseEvenItemsWithOddOnes() {
        var sumList = new ArrayList<RationalFraction>();
        sumList.add(new RationalFraction(2,4));
        sumList.add(new RationalFraction(3, 5));
        sumList.add(new RationalFraction(1, 3));
        RationalFractionHandler.increaseEvenItemsWithOddOnes(sumList);
        var expectedFraction = new RationalFraction(22, 20);
        assertTrue(sumList.get(0).getNumerator() == expectedFraction.getNumerator() && sumList.get(0).getDenominator() == expectedFraction.getDenominator());
    }
}