package com.interviewstreet.nikhilesh;

import java.io.BufferedReader;
import java.io.InputStreamReader;

import java.util.ArrayList;
import java.util.List;

public class FindNumberCountInSortedList {
    public FindNumberCountInSortedList() {
    }

    public static void main(String[] args) throws Exception {
        BufferedReader br =
            new BufferedReader(new InputStreamReader(System.in));
        int elementCount = new Integer(br.readLine());
        String elements = br.readLine();
        String[] elementsArray = elements.split(",");
        List<Integer> elementList = new ArrayList<Integer>();
        for (int i = 0; i < elementCount; i++) {
            elementList.add(new Integer(elementsArray[i]));
        }
        int findCountof = new Integer(br.readLine());

        System.out.println(FindCount(elementList, 0, elementCount-1,
                                     findCountof));

    }

    private static int FindCount(List<Integer> list, int start, int end,
                                 int number)

    {

        int mid = (start + end) / 2;
        int retVal = 0;
        
        if ( start > end ) {
            
            return -1;
        }

        if (list.get(mid) < number) {

          retVal =  FindCount(list, mid + 1, end, number);

        }

        if (list.get(mid) > number)

        {

          retVal =  FindCount(list, start, mid - 1, number);
        }

        if (list.get(mid) == number)

        {
            int firstIndex;
            int lastIndex;
            if (list.get(mid - 1) == number) {
                firstIndex = LookforFirstIndex(list, start, mid - 1, number);
            } else {
                firstIndex = mid;
            }

            if (list.get(mid + 1)== number) {
                lastIndex = LookforLastIndex(list, mid + 1, end, number);
            } else {
                lastIndex = mid;
            }


            return lastIndex - firstIndex + 1;

        }

        return retVal;

    }

    private static int LookforFirstIndex(List<Integer> list, int start, int end,
                                 int number)
    {

        if (start == end ) {
            return start;
        }
        int mid = (start + end) / 2;
        int result = 0;

        if (list.get(mid) < number) {
            result = LookforFirstIndex(list, mid + 1, end, number);

        }
        if (list.get(mid) == number) {
            if (list.get(mid-1) == number) {
              result =   LookforFirstIndex(list, start, mid - 1, number);

            } else {
                result = mid;
            }

        }
        
        return result;
    }
        
        private static int LookforLastIndex(List<Integer> list, int start, int end,
                                     int number)
        {

           if (start == end ) {
               return start;
           }
            int mid = (start + end) / 2;
            int result = 0;

            if (list.get(mid) > number) {
               result = LookforLastIndex(list, start, mid-1, number);

            }
            if (list.get(mid) == number) {
                if (list.get(mid+1) == number) {
                  result =  LookforLastIndex(list, mid+1, end, number);

                } else {
                    result = mid;
                }

            }

     return result;
    }



}
