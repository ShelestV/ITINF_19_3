package nure.itinf_19_3.Domashina;

public class MathOp {
    public static ComplexNumber sum(ComplexNumber first, ComplexNumber second) {
        if (first == null ||
            second == null) {
            return new ComplexNumber();
        }

        double resultReal = first.getReal() + second.getReal();
        double resultImaginary = first.getImaginary() + second.getImaginary();

        return new ComplexNumber(resultReal, resultImaginary);
    }

    public static ComplexNumber minus(ComplexNumber first, ComplexNumber second) {
        if (first == null ||
            second == null) {
            return new ComplexNumber();
        }

        double resultReal = first.getReal() - second.getReal();
        double resultImaginary = first.getImaginary() - second.getImaginary();

        return new ComplexNumber(resultReal, resultImaginary);
    }

    public static ComplexNumber multiply(ComplexNumber first, ComplexNumber second) {
        if (first == null ||
            second == null) {
            return new ComplexNumber();
        }
        double resultReal = (first.getReal() * second.getReal()) -
                (first.getImaginary() * second.getImaginary());
        double resultImaginary = (first.getReal() * second.getImaginary()) +
                (first.getImaginary() * second.getReal());

        return new ComplexNumber(resultReal, resultImaginary);
    }

    public static ComplexNumber divide(ComplexNumber division, double divider) {
        if (division == null) {
            return new ComplexNumber();
        }

        if (divider == 0.0) {
            throw new ArithmeticException();
        }

        double resultReal = division.getReal() / divider;
        double resultImaginary = division.getImaginary() / divider;

        return new ComplexNumber(resultReal, resultImaginary);
    }

    public static ComplexNumber divide(ComplexNumber first, ComplexNumber second) {
        if (first == null) {
            return new ComplexNumber();
        }

        if (second.equals(new ComplexNumber())) {
            throw new ArithmeticException();
        }

        // To do not change original data
        ComplexNumber division = new ComplexNumber(first);
        ComplexNumber divider = new ComplexNumber(second);
        ComplexNumber conjugate = new ComplexNumber(divider.getReal(), -(divider.getImaginary()));

        division = multiply(division, conjugate);
        double doubleDivider = Math.pow(divider.getReal(), 2) + Math.pow(divider.getImaginary(), 2);

        return divide(division, doubleDivider);
    }
}
