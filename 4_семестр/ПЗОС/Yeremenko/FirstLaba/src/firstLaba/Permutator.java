package firstLaba;

import java.util.*;

public class Permutator {
    private static int currentChainLength;
    private static int maxChainLength;
    private static ArrayList<String> words;
    private static ArrayList<Boolean> ifTheWordsAreUsed;
    private static  ArrayList<String> currentChain;
    private static ArrayList<String> maxChain;

    private static void buildChain(String currentWord, int wordIndex){
        currentChain.add(currentWord);
        ifTheWordsAreUsed.set(wordIndex, true);
        ++currentChainLength;
        var nobodySatisfiesTheCondition = true;
        for(var i = 0; i < words.size(); ++i){
            if(!ifTheWordsAreUsed.get(i) && currentWord.charAt(currentWord.length() - 1) == words.get(i).charAt(0)){
                buildChain(words.get(i), i);
                nobodySatisfiesTheCondition = false;
            }
        }
        if(nobodySatisfiesTheCondition){
            if(currentChainLength > maxChainLength) {
                maxChain = new ArrayList<>(currentChain);
                maxChainLength = currentChainLength;
            }
        }
        ifTheWordsAreUsed.set(wordIndex, false);
        currentChain.remove(currentChainLength - 1);
        --currentChainLength;
    }

    public static ArrayList<String>  permutate(ArrayList<String> inputWords){
         currentChainLength = 0;
         maxChainLength = 0;
         words = inputWords;
         ifTheWordsAreUsed = new ArrayList<>(words.size());
         currentChain = new ArrayList<>(words.size());
         maxChain = new ArrayList<>(words.size());
         for(int i = 0; i < words.size(); ++i){
             ifTheWordsAreUsed.add(false);
         }
        for (var i = 0; i < words.size(); ++i) {
            buildChain(words.get(i), i);
        }
        if(words.size() > maxChainLength){
            for (String word : words) {
                if (!maxChain.contains(word)) {
                    maxChain.add(word);
                }
            }
        }
         return maxChain;
    }
}
