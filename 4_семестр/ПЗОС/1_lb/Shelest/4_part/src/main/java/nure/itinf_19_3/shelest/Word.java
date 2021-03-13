package nure.itinf_19_3.shelest;

public class Word {
    private final int index;
    private final String word;
    private final int length;
    
    public Word(int index, String word) {
        this.index = index;
        this.word = word;
        this.length = word.length();
    }
    
    public int getIndex() {
        return index;
    }

    public char getFirstSymbol() {
        return word.toCharArray()[0];
    }

    public char getLastSymbol() {
        return word.toCharArray()[length - 1];
    }

    public boolean equals(Word other) {
        if (other == null) {
            return false;
        }

        return this.index == other.index;
    }

    @Override
    public String toString() {
        return word;
    }
}
