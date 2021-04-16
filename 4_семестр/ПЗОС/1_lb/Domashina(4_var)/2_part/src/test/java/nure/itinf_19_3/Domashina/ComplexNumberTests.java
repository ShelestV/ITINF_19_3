package nure.itinf_19_3.Domashina;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class ComplexNumberTests {
    @Test
    public void ctor_Test() {
        var number = new ComplexNumber();
        Assertions.assertEquals(0, number.getReal());
        Assertions.assertEquals(0, number.getImaginary());
    }

    @Test
    public void ctorWithParametrs_Test() {
        var number = new ComplexNumber(3, 4);
        Assertions.assertEquals(3, number.getReal());
        Assertions.assertEquals(4, number.getImaginary());
    }

    @Test
    public void ctorOfCopying_Test() {
        var original = new ComplexNumber(3, 4);
        var copied = new ComplexNumber(original);

        Assertions.assertEquals(original.getReal(), copied.getReal());
        Assertions.assertEquals(original.getImaginary(), copied.getImaginary());
    }

    @Test
    public void toString_Test() {
        var number = new ComplexNumber(3, 4);
        Assertions.assertEquals("3 + (4)i", number.toString());
    }

    @Test
    public void equals_Test() {
        var first = new ComplexNumber(3, 4);
        var second = new ComplexNumber(3, 4);

        Assertions.assertEquals(first, second);
    }

    @Test
    public void notEquals_Test() {
        var first = new ComplexNumber(3, 4);
        var second = new ComplexNumber(5, 6);

        Assertions.assertNotEquals(first, second);
    }
}
