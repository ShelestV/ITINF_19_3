package nure.itinf_19_3.Domashina;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class TheLongestWordOfNumbersTests {
    @Test
    public void getTheLongestWordOfNumbers_Test() {
        String text = "Word W0rdWithNumber 123 not max word of numbers 123456 another word 1905 and one more 0000000";

        String expected = "0000000";
        String actual = TheLongestWord.getTheLongestWordOfNumbers(text);

        Assertions.assertEquals(expected, actual);
    }
}
