package nure.itinf_19_3.shelest;

public class Point {
    private RationalFraction x;
    private RationalFraction y;
    
    public Point() {
        x = new RationalFraction(0, 1);
        y = new RationalFraction(0, 1);
    }
    
    public Point(RationalFraction x, RationalFraction y) {
        this.x = x;
        this.y = y;
    }
    
    public void setX(RationalFraction x) {
        this.x = x;
    }
    
    public RationalFraction getX() {
        return x;
    }
    
    public void setY(RationalFraction y) {
        this.y = y;
    }
    
    public RationalFraction getY() {
        return y;
    }
    
    @Override
    public String toString() {
        return "x = " + x.toString() + "\n" + "y = " + y.toString();
    }

    @Override
    public int hashCode() {
        return super.hashCode();
    }

    @Override
    public boolean equals(Object obj) {

        return super.equals(obj);
    }
}
