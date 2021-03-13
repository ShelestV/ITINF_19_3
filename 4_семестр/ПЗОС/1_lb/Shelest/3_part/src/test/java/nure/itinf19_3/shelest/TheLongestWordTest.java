package nure.itinf19_3.shelest;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class TheLongestWordTest {
    @Test
    public void findTheLongestWordTest() {
        String str = "I love aa programming zzz";

        String actual = TheLongestWord.findTheLongestWord(str);
        String expected = "programming";

        Assertions.assertEquals(expected, actual);
    }
    
    @Test
    public void findLongestWord_NullTest() {
        String actual = TheLongestWord.findTheLongestWord(null);
        String expected = "";

        Assertions.assertEquals(expected, actual);
    }
}
