import org.junit.Test;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

public class ComplexTest {
    private final ComplexNumber complexNumber = new ComplexNumber();


    @Test
    public void setDefaultComplexNumber(){assertTrue(complexNumber.complexPart == 0.f & complexNumber.realPart == 0.f); }
    private final ComplexNumber complexNumber2 = new ComplexNumber(2.4f,5.6f);
    @Test
    public void setComplexNumber(){assertTrue(complexNumber2.complexPart == 2.4f & complexNumber2.realPart == 5.6f); }
    @Test
    public void addSingleComplexNumber(){
        complexNumber.AddNumber(complexNumber2);
        assertTrue(complexNumber.complexPart == 2.4f & complexNumber.realPart == 5.6f);
    }
    private final ComplexNumber[] arrayNumbers = new ComplexNumber[] { new ComplexNumber(1.f, 2.5f), new ComplexNumber(2.f, 3.5f), new ComplexNumber(55.f, 1.5f) };
    @Test
    public void addArrayComplexNumbers(){
        complexNumber.AddArrayNumbers(arrayNumbers);
        assertTrue(complexNumber.complexPart == 58.f & complexNumber.realPart == 7.5f);
    }
    private final ComplexNumber[] arrayNumbers2 = new ComplexNumber[] { new ComplexNumber(1.f, 1.f), new ComplexNumber(1.f, 2.f)};
    @Test
    public void multiplyArrayComplexNumbers(){
        complexNumber.MultiplyArrayNumbers(arrayNumbers2);
        assertTrue(complexNumber.complexPart == (3.f) & complexNumber.realPart == (-1.f));
    }

    private final ComplexPolynom complexPolynom = new ComplexPolynom();

    @Test
    public void setDefaultComplexPolynom(){
        assertTrue(complexPolynom.degree == 1 & complexPolynom.coefficients[0].complexPart == 0.f & complexPolynom.coefficients[0].realPart == 0.f );
    }

    private final ComplexPolynom complexPolynom2 = new ComplexPolynom(arrayNumbers.length,arrayNumbers);
    private final ComplexPolynom complexPolynom3 = new ComplexPolynom(arrayNumbers2.length,arrayNumbers2);
    @Test
    public void setComplexPolynom(){
        assertTrue(complexPolynom2.degree == 3 & complexPolynom2.coefficients == arrayNumbers);
    }


    @Test
    public void addArrayComplexPolynom(){
        ComplexPolynom[] arrayComplexPolynoms = new ComplexPolynom[] { complexPolynom2,complexPolynom3 };
        complexPolynom2.AddPolynoms(arrayComplexPolynoms);
        assertTrue(complexPolynom2.degree == 3d
                & complexPolynom2.coefficients[0].complexPart == 2.f & complexPolynom2.coefficients[0].realPart == 3.5f
                & complexPolynom2.coefficients[1].complexPart == 3.f & complexPolynom2.coefficients[1].realPart == 5.5f);
    }
}
