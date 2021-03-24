package firstLaba.Tests;

import static org.junit.jupiter.api.Assertions.*;

import firstLaba.NumericHandler;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Arrays;


class NumericHandlerTest {

    @Test
    void isEvenNumber() {
        Assertions.assertTrue(NumericHandler.isEvenNumber(206));
    }

    @Test
    void isNumberOfEvenAndOddDigitsEqual() {
        var number = 5728;
        assertTrue(NumericHandler.isNumberOfEvenAndOddDigitsEqual(number));
    }

    @Test
    void getQuantityOfNumbersWithEqualNumberOfEvenAndOddDigits() {
        var numbers = new ArrayList<>(Arrays.asList(21, 3, 58, 6, 2136, 1112, 1122));
        var expected = 3;
        int actual = NumericHandler.getQuantityOfNumbersWithEqualNumberOfEvenAndOddDigits(numbers);
        assertEquals(expected, actual);
    }
}