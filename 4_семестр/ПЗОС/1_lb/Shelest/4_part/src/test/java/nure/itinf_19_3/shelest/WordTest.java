package nure.itinf_19_3.shelest;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class WordTest {
    @Test
    public void getterSetterTest() {
        Word word = new Word(0, "word");

        Assertions.assertEquals(0, word.getIndex());
        Assertions.assertEquals('w', word.getFirstSymbol());
        Assertions.assertEquals('d', word.getLastSymbol());
    }

    @Test
    public void equalsDifferentStringsSameIndexesTest() {
        Word word = new Word(0, "word");
        Word anotherWord = new Word(0, "anotherWord");

        Assertions.assertTrue(word.equals(anotherWord));
    }

    @Test
    public void equalsDifferentIndexesSameStringsTest() {
        Word word = new Word(1, "word");
        Word anotherWord = new Word(0, "word");

        Assertions.assertFalse(word.equals(anotherWord));
    }

    @Test
    public void equalsDifferentStringsDifferentIndexesTest() {
        Word word = new Word(0, "word");
        Word anotherWord = new Word(1, "anotherWord");

        Assertions.assertFalse(word.equals(anotherWord));
    }

    @Test
    public void equalsSameStringsSameIndexesTest() {
        Word word = new Word(0, "word");
        Word anotherWord = new Word(0, "word");

        Assertions.assertTrue(word.equals(anotherWord));
    }

    @Test
    public void toStringTest() {
        Word word = new Word(0, "Word");

        Assertions.assertEquals("Word", word.toString());
    }
}
