package nure.itinf_19_3.shelest;

public class RationalFraction {
    private int m;
    private int n;

    public RationalFraction() {
        this.m = 1;
        this.n = 1;
    }

    public RationalFraction(int m, int n) {
        this.m = m;
        this.n = n;
    }

    public void setM(int m) {
        this.m = m;
    }

    public int getM() {
        return m;
    }

    public void setN(int n) {
        this.n = n;
    }

    public int getN() {
        return n;
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
        return m + "/" + n;
    }

    public double toDouble() {
        return (double)m / (double)n;
    }

    public RationalFraction addition(RationalFraction other) {
        if (other == null)
            return new RationalFraction();

        int resultM = other.m * this.n + this.m * other.n;
        int resultN = other.n * this.n;

        RationalFraction result = new RationalFraction(resultM, resultN);

        return result.simplify();
    }

    public static RationalFraction addition(RationalFraction a, RationalFraction b) {
        if (a == null || b == null)
            return new RationalFraction();

        int resultM = a.m * b.n + b.m * a.n;
        int resultN = a.n * b.n;

        RationalFraction result = new RationalFraction(resultM, resultN);

        return result.simplify();
    }

    public RationalFraction minus(RationalFraction other) {
        if (other == null)
            return new RationalFraction();

        int resultM =  this.m * other.n - other.m * this.n;
        int resultN = other.n * this.n;

        RationalFraction result = new RationalFraction(resultM, resultN);

        return result.simplify();
    }

    public static RationalFraction minus(RationalFraction a, RationalFraction b) {
        if (a == null || b == null)
            return new RationalFraction();

        int resultM = a.m * b.n - b.m * a.n;
        int resultN = a.n * b.n;

        RationalFraction result = new RationalFraction(resultM, resultN);

        return result.simplify();
    }

    public RationalFraction multiply(RationalFraction other) {
        if (other == null)
            return new RationalFraction();

        int resultM =  this.m * other.m;
        int resultN = other.n * this.n;

        RationalFraction result = new RationalFraction(resultM, resultN);

        return result.simplify();
    }

    public static RationalFraction multiply(RationalFraction a, RationalFraction b) {
        if (a == null || b == null)
            return new RationalFraction();

        int resultM = a.m * b.m;
        int resultN = a.n * b.n;

        RationalFraction result = new RationalFraction(resultM, resultN);

        return result.simplify();
    }

    public RationalFraction division(RationalFraction other) {
        if (other == null)
            return new RationalFraction();

        int resultM =  this.m * other.n;
        int resultN = this.n * other.m;

        RationalFraction result = new RationalFraction(resultM, resultN);

        return result.simplify();
    }

    public static RationalFraction division(RationalFraction a, RationalFraction b) {
        if (a == null || b == null)
            return new RationalFraction();

        int resultM = a.m * b.n;
        int resultN = a.n * b.m;

        RationalFraction result = new RationalFraction(resultM, resultN);

        return result.simplify();
    }

    public RationalFraction simplify() {
        boolean isSimple = false;
        RationalFraction result = this;

        if (result.m < 0 && result.n < 0 ||
            result.m >= 0 && result.n < 0) {
            result.m *= -1;
            result.n *= -1;
        }

        while (!isSimple) {
            int limit = Math.min(Math.abs(result.m), Math.abs(result.n));
            isSimple = true;
            for (int divider = 2; divider <= limit; ++divider) {
                if (result.m % divider == 0 && result.n % divider == 0) {
                    result.m /= divider;
                    result.n /= divider;
                    isSimple = false;
                    break;
                }
            }
        }

        return result;
    }

    public RationalFraction reverse() {
        return new RationalFraction(-this.m, this.n);
    }
}
/*
* а)
* Определить класс Рациональная Дробь в виде пары чисел m и n.
* Объявить и инициализировать массив из k дробей, ввести/вывести значения для массива дробей.
* Создать массив/список/множество объектов и передать его в метод,
* который изменяет каждый элемент массива с четным индексом путем добавления следующего за ним элемента.
*
* б)
* Определить класс Прямая на плоскости (в пространстве),
* параметры которой задаются с помощью Рациональной Дроби.
* Определить точки пересечения прямой с осями координат.
* Определить координаты пересечения двух прямых.
* Создать массив/список/множество объектов и определить группы параллельных прямых
*/