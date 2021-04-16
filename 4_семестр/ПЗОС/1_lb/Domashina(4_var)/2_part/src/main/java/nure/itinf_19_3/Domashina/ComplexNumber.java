package nure.itinf_19_3.Domashina;

public class ComplexNumber {
    private final double real;
    private final double imaginary;

    /**
     * real = 0
     * imaginary = 0
     */
    public ComplexNumber() {
        this.real = 0;
        this.imaginary = 0;
    }

    public ComplexNumber(ComplexNumber other) {
        this.real = other.real;
        this.imaginary = other.imaginary;
    }

    public ComplexNumber(double real, double imaginary) {
        this.real = real;
        this.imaginary = imaginary;
    }

    public double getReal() {
        return real;
    }

    public double getImaginary() {
        return imaginary;
    }

    @Override
    public String toString() {
        int real = (int)Math.round(this.real);
        int imaginary = (int)Math.round(this.imaginary);
        return String.format("%d + (%d)i", real, imaginary);
    }

    @Override
    public int hashCode() {
        return super.hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        return obj != null &&
                this.getClass() == obj.getClass() &&
                this.real == ((ComplexNumber)obj).real &&
                this.imaginary == ((ComplexNumber)obj).imaginary;
    }
}
