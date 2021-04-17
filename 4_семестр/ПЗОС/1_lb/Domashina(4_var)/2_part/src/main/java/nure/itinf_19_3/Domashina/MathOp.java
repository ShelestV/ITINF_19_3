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
}
