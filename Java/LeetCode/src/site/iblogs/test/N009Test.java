package site.iblogs.test;

import org.junit.jupiter.api.Test;
import site.iblogs.N009;

import static org.junit.jupiter.api.Assertions.*;

class N009Test {

    @Test
    void isPalindrome() {
        N009 tester=new N009();
        assertTrue(tester.isPalindrome(121));
    }
}