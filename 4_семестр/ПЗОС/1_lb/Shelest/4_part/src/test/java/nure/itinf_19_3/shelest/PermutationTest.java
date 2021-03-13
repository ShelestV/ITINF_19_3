package nure.itinf_19_3.shelest;


import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class PermutationTest {
    @Test
    public void getPermutationTest() {
        Permutation permutation = new Permutation("ada ant bda dab zz dd");

        String actual = permutation.getPermutation();
        String expected = "dd dab bda ada ant zz";

        Assertions.assertEquals(expected, actual);
    }
}
