package firstLaba.Tests;

import firstLaba.StringHandler;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class StringHandlerTest {

    @Test
    void countVowelNumber() {
        var word = "boomer";
        var expected = 3;
        int actual = StringHandler.countVowelNumber(word);
        assertEquals(expected, actual);
    }

    @Test
    void getTheWordWithTheFewestVowels() {
        var text = "They have a pretty house";
        var expected = "a";
        String actual = StringHandler.getTheWordWithTheFewestVowels(text);
        assertEquals(expected, actual);
    }
}