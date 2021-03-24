package firstLaba;

import java.util.ArrayList;

public class NumericHandler {

    public static boolean isEvenNumber(int number){
        return number % 2 == 0;
    }

    public static boolean isNumberOfEvenAndOddDigitsEqual(int number){
        int evenNumber = 0;
        int oddNumber = 0;
        while (number > 0) {
            if (number % 2 == 0) ++evenNumber;
            else ++oddNumber;
            number /= 10;
        }
        return evenNumber == oddNumber;
    }

    public static int getQuantityOfNumbersWithEqualNumberOfEvenAndOddDigits(ArrayList<Integer> numbers) {
        return (int)numbers.stream().filter(number -> isEvenNumber(number) && isNumberOfEvenAndOddDigitsEqual(number)).count();
    }
}
