package nure.itinf_19_3.shelest;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.awt.*;
import java.util.ArrayList;
import java.util.List;

public class RationalFractionServerTest {
    @Test
    public void arrayModifyOddSizeTest() {
        List<RationalFraction> array = new ArrayList<>();
        array.add(new RationalFraction(1, 2));
        array.add(new RationalFraction(3, 4));
        array.add(new RationalFraction(5, 6));

        array = RationalFractionServer.modifyArray(array);
        List<String> actual = new ArrayList<>();
        for (RationalFraction fraction : array) {
            actual.add(fraction.toString());
        }

        List<String> expected = new ArrayList<>();
        expected.add("5/4");
        expected.add("3/4");
        expected.add("5/6");

        Assertions.assertArrayEquals(expected.toArray(), actual.toArray());
    }

    @Test
    public void arrayModifyEvenSizeTest() {
        List<RationalFraction> array = new ArrayList<>();
        array.add(new RationalFraction(1, 2));
        array.add(new RationalFraction(3, 4));
        array.add(new RationalFraction(5, 6));
        array.add(new RationalFraction(1, 2));

        array = RationalFractionServer.modifyArray(array);
        List<String> actual = new ArrayList<>();
        for (RationalFraction fraction : array) {
            actual.add(fraction.toString());
        }

        List<String> expected = new ArrayList<>();
        expected.add("5/4");
        expected.add("3/4");
        expected.add("4/3");
        expected.add("1/2");

        Assertions.assertArrayEquals(expected.toArray(), actual.toArray());
    }

}
