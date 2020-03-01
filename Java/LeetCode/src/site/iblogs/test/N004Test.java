package site.iblogs.test;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import site.iblogs.N004;

import static org.junit.jupiter.api.Assertions.assertEquals;


class N004Test {

    private N004 n004 = new N004();

    @Test
    void findMedianSortedArrays() {
        assertEquals(n004.findMedianSortedArrays(new int[]{1, 2}, new int[]{1, 1}), 1.0);
    }
}