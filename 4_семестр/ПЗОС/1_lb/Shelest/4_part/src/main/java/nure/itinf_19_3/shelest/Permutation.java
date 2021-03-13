package nure.itinf_19_3.shelest;

import java.util.ArrayList;
import java.util.List;

public class Permutation {
    private final Word errorWord;

    private final List<Word> beginWords;
    private final List<Word> middleWords;
    private final List<Word> endWords;
    private String wordsWithoutLinks;

    private boolean[] isInResult;

    private void getGroup(String[] words, String word, int index) {
        if (words == null || word == null) {
            return;
        }

        boolean isLinkBegin = false;
        boolean isLinkEnd = false;

        for (int i = 0; i < words.length; ++i) {
            if (i == index) {
                continue;
            }

            if (!isLinkBegin &&
                    word.toCharArray()[0] == words[i].toCharArray()[words[i].length() - 1]) {
                isLinkBegin = true;
            }
            if (!isLinkEnd &&
                    word.toCharArray()[word.length() - 1] == words[i].toCharArray()[0]) {
                isLinkEnd = true;
            }

            if (isLinkBegin && isLinkEnd) {
                middleWords.add(new Word(index, word));
                return;
            }
        }

        if (isLinkBegin) {
            endWords.add(new Word(index, word));
        }
        else if (isLinkEnd) {
            beginWords.add(new Word(index, word));
        }
        else {
            wordsWithoutLinks += word + " ";
            isInResult[index] = true;
        }
    }

    public Permutation(String text) {
        errorWord = new Word(-1, "");

        beginWords = new ArrayList<>();
        middleWords = new ArrayList<>();
        endWords = new ArrayList<>();
        wordsWithoutLinks = "";

        if (text != null) {
            String[] words = text.split(" ");

            isInResult = new boolean[words.length];

            for (int i = 0; i < words.length; ++i) {
                getGroup(words, words[i], i);
            }


        }
    }

    private boolean isResultFull() {
        for (boolean isIn : isInResult) {
            if (!isIn) {
                return false;
            }
        }
        return true;
    }

    private Word getBeginWord() {
        for (Word word : beginWords) {
            if (!isInResult[word.getIndex()]) {
                isInResult[word.getIndex()] = true;
                return word;
            }
        }

        for (Word word : middleWords) {
            if (!isInResult[word.getIndex()]) {
                isInResult[word.getIndex()] = true;
                return word;
            }
        }

        return errorWord;
    }

    private Word getMiddleWord(char symbol) {
        for (Word word : middleWords) {
            if (!isInResult[word.getIndex()] &&
                    symbol == word.getFirstSymbol()) {
                isInResult[word.getIndex()] = true;
                return word;
            }
        }
        return errorWord;
    }

    private Word getEndWord(char symbol) {
        for (Word word : endWords) {
            if (!isInResult[word.getIndex()] &&
                    word.getFirstSymbol() == symbol) {
                isInResult[word.getIndex()] = true;
                return word;
            }
        }
        return errorWord;
    }

    private String getRemainderWords() {
        StringBuilder result = new StringBuilder();
        for (Word word : endWords) {
            result.append(word.toString()).append(" ");
            isInResult[word.getIndex()] = true;
        }
        return result.toString();
    }

    public String getPermutation() {
        StringBuilder result = new StringBuilder();
        while (!isResultFull()) {
            Word part = getBeginWord();
            if (part.equals(errorWord)) {
                result.append(getRemainderWords());
                break;
            }
            result.append(part.toString()).append(" ");

            char endSymbol = part.getLastSymbol();
            part = getMiddleWord(endSymbol);

            while (!part.equals(errorWord)) {
                result.append(part.toString()).append(" ");
                endSymbol = part.getLastSymbol();
                part = getMiddleWord(endSymbol);
            }

            part = getEndWord(endSymbol);
            if (part.equals(errorWord)) {
                result.append(getRemainderWords());
            }
            result.append(part.toString()).append(" ");
        }
        result.append(wordsWithoutLinks);
        return result.substring(0, result.length() - 1);
    }
}
