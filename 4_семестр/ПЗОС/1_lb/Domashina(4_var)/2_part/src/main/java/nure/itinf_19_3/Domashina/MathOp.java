package nure.itinf_19_3.Domashina;

public class MathOp {
    public static Complex sum(Complex first, Complex second) {
        if (first == null || second == null) {
            return new Complex();
        }

        double real = first.getReal() + second.getReal();
        double imaginary = first.getImaginary() + second.getImaginary();

        return new Complex(real, imaginary);
    }

    public static Complex minus(Complex subtrahend, Complex subtractor) {
        if (subtrahend == null || subtractor == null) {
            return new Complex();
        }

        double real = subtrahend.getReal() - subtractor.getReal();
        double imaginary = subtrahend.getImaginary() - subtractor.getImaginary();

        return new Complex(real, imaginary);
    }

    public static Complex multiply(Complex first, Complex second) {
        if (first == null || second == null) {
            return new Complex();
        }

        double real = first.getReal() * second.getReal() - first.getImaginary() * second.getImaginary();
        double imaginary = first.getReal() * second.getImaginary() + first.getImaginary() * second.getReal();

        return new Complex(real, imaginary);
    }

    public static Complex divide(Complex division, double divider) throws ArithmeticException {
        if (division == null) {
            return new Complex();
        }

        if (divider == 0.0) {
            throw new ArithmeticException();
        }

        double real = division.getReal() / divider;
        double imaginary = division.getImaginary() / divider;

        return new Complex(real, imaginary);
    }

    public static Complex divide(Complex division, Complex divider) throws ArithmeticException {
        if (division == null || divider == null) {
            return new Complex();
        }

        if (divider.equals(new Complex())) {
            throw new ArithmeticException();
        }

        Complex conjugate = new Complex(divider.getReal(), -divider.getImaginary());

        Complex numerator = multiply(division, conjugate);
        double denominator = Math.pow(divider.getReal(), 2) + Math.pow(divider.getImaginary(), 2);

        return divide(numerator, denominator);
    }

    public static Complex sumArrayElements(Complex[] array) {
        if (array == null) {
            return new Complex();
        }

        var result = new Complex();
        for (var number : array) {
            result = sum(result, number);
        }

        return result;
    }

    public static Complex multiplyArrayElements(Complex[] array) {
        if (array == null || array.length == 0) {
            return new Complex();
        }

        var result = new Complex(1, 1);
        for (var number : array) {
            result = multiply(result, number);
        }

        return result;
    }

    public static Fraction sum(Fraction first, Fraction second) {
        if (first == null || second == null) {
            return new Fraction();
        }

        var numerator = sum(multiply(first.getN(), second.getM()), multiply(first.getM(), second.getN()));
        var denominator = multiply(first.getM(), second.getM());

        return new Fraction(numerator, denominator);
    }

    public static void sumArrayOddElementsWithEven(Fraction[] array) {
        if (array != null) {
            for (int i = 0; i < array.length - 1; i += 2) {
                array[i] = sum(array[i], array[i + 1]);
            }
        }
    }
}
