package nure.itinf19_3.shelest;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class TheLongestWord {
    public static String findTheLongestWord(String str) {
        if (str == null) {
            return "";
        }

        String[] words = str.split(" ");

        int maxLength = 0;
        String theLongestWord = "";
        for (String word : words) {
            if (word.length() > maxLength) {
                maxLength = word.length();
                theLongestWord = word;
            }
        }

        return theLongestWord;
    }
}
