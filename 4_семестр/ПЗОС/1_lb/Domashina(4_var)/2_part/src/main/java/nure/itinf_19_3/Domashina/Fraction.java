package nure.itinf_19_3.Domashina;

public class Fraction {
    private Complex n;
    private Complex m;

    public Fraction() {
        this.n = new Complex();
        this.m = new Complex(1, 1);
    }

    public Fraction(Complex n, Complex m) {
        var zero = new Complex();

        if (n != null && m != null &&
                !m.equals(zero)) {
            this.n = n;
            this.m = m;
        }
    }

    public Complex getN() {
        return n;
    }

    public Complex getM() {
        return m;
    }

    @Override
    public int hashCode() {
        return super.hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }

        if (obj == null) {
            return false;
        }

        return this.getClass() == obj.getClass() &&
                this.n.equals(((Fraction)obj).n) &&
                this.m.equals(((Fraction)obj).m);
    }

    @Override
    public String toString() {
        return "(" + n.toString() + ") / (" + m.toString() + ")";
    }
}
