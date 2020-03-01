package site.iblogs.test;

import org.junit.jupiter.api.Test;
import site.iblogs.N005;

import static org.junit.jupiter.api.Assertions.*;

class N005Test {

    @Test
    void longestPalindrome() {

        N005 n005=new N005();
        assertEquals("aaabbaaa",n005.longestPalindrome("accaaabbaaaaa"));

    }
}