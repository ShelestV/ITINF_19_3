package nure.itinf_19_3.Domashina;

public class Complex {
    private final double real;
    private final double imaginary;

    /**
     * Creates complex number<br>
     * real = 0<br>
     * imaginary = 0
     */
    public Complex() {
        this.real = 0;
        this.imaginary = 0;
    }

    public Complex(Complex other) {
        this.real = other.real;
        this.imaginary = other.imaginary;
    }

    public Complex(double real, double imaginary) {
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
    public int hashCode() {
        return super.hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }

        if (this == obj) {
            return true;
        }

        return this.getClass() == obj.getClass() &&
                this.real == ((Complex)obj).real &&
                this.imaginary == ((Complex)obj).imaginary;
    }

    @Override
    public String toString() {
        int real = (int)Math.round(this.real);
        int imaginary = (int)Math.round(this.imaginary);

        return String.format("%d + (%d)i", real, imaginary);
    }
}
