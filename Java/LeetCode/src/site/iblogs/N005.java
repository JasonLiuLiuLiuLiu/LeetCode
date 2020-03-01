package site.iblogs;

import java.util.Arrays;
import java.util.List;
import java.util.Vector;

public class N005 {

    // 暴力解法
//    public String longestPalindrome(String s) {
//        String result = "";
//        int sSize = s.length();
//        for (int i = 0; i < sSize; i++) {
//            for (int end = sSize; end > i; end--) {
//                String tmpStr = s.substring(i, end);
//                if (isPalindrome(tmpStr) && tmpStr.length() > result.length()) {
//                    result = tmpStr;
//                }
//            }
//        }
//        return result;
//    }
//
//    private boolean isPalindrome(String s) {
//        int left = 0;
//        int right = s.length() - 1;
//        for (; left < right; left++, right--) {
//            if (s.charAt(left) != s.charAt(right)) {
//                return false;
//            }
//        }
//        return true;
//    }


    public String longestPalindrome(String s) {
        int n = s.length();
        String res = "";
        boolean[] P = new boolean[n];
        for (int i = n - 1; i >= 0; i--) {
            for (int j = n - 1; j >= i; j--) {
                P[j] = s.charAt(i) == s.charAt(j) && (j - i < 3 || P[j - 1]);
                if (P[j] && j - i + 1 > res.length()) {
                    res = s.substring(i, j + 1);
                }
            }
        }
        return res;
    }

};

