package nure.itinf_19_3.Domashina;

import java.util.Arrays;

public class TheLongestWord {
    private static String charToString(char symbol) {
        return new String(new char[] { symbol });
    }

    private static boolean isNumber(char symbol) {
        String numbers = "0123456789";
        return numbers.contains(charToString(symbol));
    }

    private static boolean isNumberString(String word) {
        for (var symbol : word.toCharArray()) {
            if (!isNumber(symbol)) {
                return false;
            }
        }
        return true;
    }

    private static int compareStringLength(String first, String second) {
        return Integer.compare(first.length(), second.length());
    }

    public static String getTheLongestWordOfNumbers(String text) {
        String[] words = text.split(" ");
        return Arrays.stream(words).
                filter(TheLongestWord::isNumberString).
                max(TheLongestWord::compareStringLength).get();

    }
}
