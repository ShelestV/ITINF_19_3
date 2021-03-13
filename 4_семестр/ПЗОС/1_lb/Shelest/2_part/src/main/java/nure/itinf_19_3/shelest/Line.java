package nure.itinf_19_3.shelest;

public class Line {
    private final Point A;
    private final Point B;
    
    public Line(Point first, Point second) {
        this.A = first;
        this.B = second;
    }

    @Override
    public int hashCode() {
        return super.hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        return super.equals(obj);
    }

    @Override
    public String toString() {
        return "A(" + A.getX() + "; " + A.getY() + ") - " +
                "B(" + B.getX() + "; " + B.getY() + ");\n";
    }

    public boolean isParallel(Line other) {
        return isParallel(this, other);
    }

    public static boolean isParallel(Line first, Line second) {
        if (first == null || second == null) {
            return false;
        }

        // 1 - this; 2 - other
        double A1 = first.A.getY().toDouble() - first.B.getY().toDouble();
        double B1 = first.B.getX().toDouble() - first.A.getX().toDouble();
        double A2 = second.A.getY().toDouble() - second.B.getY().toDouble();
        double B2 = second.B.getX().toDouble() - second.A.getX().toDouble();

        double cos = (A1 * A2 + B1 * B2) /
                (Math.sqrt(Math.pow(A1, 2.0) + Math.pow(B1, 2.0)) *
                        Math.sqrt(Math.pow(A2, 2.0) + Math.pow(B2, 2.0)));
        return Math.ceil(cos * 1000000) / 1000000 == 1.0 ||
                Math.ceil(cos * 1000000) / 1000000 == -1.0;
    }


    public static Point intersectionPoint(Line first, Line second) {
        if (first == null || second == null ||
            Line.isParallel(first, second)) {

            return new Point();
        }

        RationalFraction a1 = RationalFraction.minus(first.A.getY(), first.B.getY());
        RationalFraction b1 = RationalFraction.minus(first.B.getX(), first.A.getX());
        RationalFraction c1 = RationalFraction.minus(
                RationalFraction.multiply(first.A.getX(), first.B.getY()),
                RationalFraction.multiply(first.B.getX(), first.A.getY())
        );

        RationalFraction a2 = RationalFraction.minus(second.A.getY(), second.B.getY());
        RationalFraction b2 = RationalFraction.minus(second.B.getX(), second.A.getX());
        RationalFraction c2 = RationalFraction.minus(
                RationalFraction.multiply(second.A.getX(), second.B.getY()),
                RationalFraction.multiply(second.B.getX(), second.A.getY())
        );

        RationalFraction x = RationalFraction.division(
                RationalFraction.minus(
                        RationalFraction.multiply(b1, c2),
                        RationalFraction.multiply(b2, c1)),
                RationalFraction.minus(
                        RationalFraction.multiply(a1, b2),
                        RationalFraction.multiply(a2, b1))
        );

        RationalFraction y = RationalFraction.division(
                RationalFraction.addition(RationalFraction.multiply(a1, x).reverse(), c1.reverse()), b1);

        return new Point(x, y);
    }

    public Point intersectOX() {
        Line OX = new Line(
                new Point(new RationalFraction(4, 1), new RationalFraction(0, 1)),
                new Point(new RationalFraction(5, 1), new RationalFraction(0, 1))
        );

        return Line.intersectionPoint(this, OX);
    }

    public Point intersectOY() {
        Line OY = new Line(
                new Point(new RationalFraction(0, 1), new RationalFraction(4, 1)),
                new Point(new RationalFraction(0, 1), new RationalFraction(5, 1))
        );

        return Line.intersectionPoint(this, OY);
    }
}
