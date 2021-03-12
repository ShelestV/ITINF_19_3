public class Point {
    ComplexNumber x,y,z;
    public Point(ComplexNumber x, ComplexNumber y, ComplexNumber z){
        this.x = x;
        this.y = y;
        this.z =z;
    }

    public static ComplexNumber distanceBetweenPoints(Point start, Point end){
        return ComplexNumber.getSqrtOfComplexNumber(ComplexNumber.getSumOfComplexNumbers(
                ComplexNumber.getSumOfComplexNumbers(ComplexNumber.getSqrOfComplexNumber(
                ComplexNumber.getSubOfComplexNumbers(end.x, start.x)),
                ComplexNumber.getSqrOfComplexNumber(ComplexNumber.getSubOfComplexNumbers(end.y, start.y))),
                ComplexNumber.getSqrOfComplexNumber(ComplexNumber.getSubOfComplexNumbers(end.z, start.z))));
    }
}
