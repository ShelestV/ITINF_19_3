package firstLaba;

import java.util.ArrayList;

public class Permutator {
    private static int chainTailPointer;
    private static int maxLength;
    private static ArrayList<String> words;
    private static  ArrayList<String> chain;
    private static ArrayList<String> maxChain;

    private static int findNextWord(char letter, int n){
        int i = 0;
        while(i < words.size() && n > 0){
            if(words.get(i).charAt(0) == letter) --n;
            ++i;
        }
        if(n == 0) return i - 1;
        else return -1;
    }

    private static void buildChain(char letter, int n){
        int i = findNextWord(letter, n);
        if(i >= 0){
            ++chainTailPointer;
            chain.set(chainTailPointer, words.get(i));
            var strikethroughWord = new StringBuilder(words.get(i));//вычеркиваем
            strikethroughWord.setCharAt(0, '-');
            words.set(i, strikethroughWord.toString());
            buildChain(words.get(i).charAt(words.get(i).length() - 1), 1);
            --chainTailPointer;
            var oldWord = new StringBuilder(words.get(i));//возвращаем
            oldWord.setCharAt(0, letter);
            words.set(i, oldWord.toString());
            buildChain(letter, n + 1);
        }
        else{
            if(chainTailPointer > maxLength){
                maxChain = new ArrayList<>(chain);
                maxLength = chainTailPointer;
            }
        }
    }

    public static ArrayList<String>  permutate(ArrayList<String> inputWords){
         chainTailPointer = -1;
         maxLength = 0;
         words = inputWords;
         chain = new ArrayList<>(words.size());
         maxChain = new ArrayList<>(words.size());
         for(int i = 0; i < words.size(); ++i){
             chain.add(null);
             maxChain.add(null);
         }
        for (String word : words) {
            buildChain(word.charAt(0), 1);
        }
         return maxChain;
    }
}
