package nure.itinf_19_3.shelest;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.Assertions;

import java.util.ArrayList;
import java.util.List;

public class WorkWithNumbersTests {
    @Test
    public void getAvarageValueTest() {
        List<Integer> array = new ArrayList<>();
        array.add(1);
        array.add(6);
        array.add(2);

        double actual = WorkWithNumbers.getAvarageValue(array);
        double expected = 3.0;
        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void getValuesLessThenAvarageValueTest() {
        List<Integer> array = new ArrayList<>();
        array.add(1);
        array.add(6);
        array.add(2);

        List<Integer> actual = WorkWithNumbers.getValuesLessThenAvarageValue(array);
        List<Integer> expected = new ArrayList<>();
        expected.add(1);
        expected.add(2);
        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void getValuesGreaterThenAvarageValueTest() {
        List<Integer> array = new ArrayList<>();
        array.add(1);
        array.add(6);
        array.add(2);

        List<Integer> actual = WorkWithNumbers.getValueGreaterThenAvarageValue(array);
        List<Integer> expected = new ArrayList<>();
        expected.add(6);
        Assertions.assertEquals(expected, actual);
    }
}
