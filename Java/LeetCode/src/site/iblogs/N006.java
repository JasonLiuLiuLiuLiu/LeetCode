package site.iblogs;

import java.util.Vector;

//给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。
public class N006 {
  public String convert(String s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }
        int sSize = s.length();
        int storeSize = Math.min(sSize, numRows);
        StringBuilder result= new StringBuilder();

        Vector<Vector<Character>> store = new Vector<>();
        for (int i=0;i<numRows;i++)
        {
            store.add(new Vector<>());
        }
        int loc = 0;

        //初始有一次更改change值，因此初始值为false
        boolean change = false;
        for (int index = 0; index < sSize; index++)
        {
            store.get(loc).add(s.charAt(index));
            if (loc == numRows - 1 || loc == 0)
            {
                change = !change;
            }
            loc += change ? 1 : -1;
        }

        for (int index = 0; index < storeSize; index++)
        {
            for (Character c:store.get(index))
            {
                result.append(c);
            }
        }
        return result.toString();
    }
}
