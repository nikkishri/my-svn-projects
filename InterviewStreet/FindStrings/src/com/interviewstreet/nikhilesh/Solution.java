package com.interviewstreet.nikhilesh;

import java.io.BufferedReader;
import java.io.InputStreamReader;

import java.util.*;


public class Solution {


    static String stringCount;
    static String printCount;
    static int[] indList = new int[500];
    static TreeMap<String, HashSet<String>> subStringCollection =
        new TreeMap<String, HashSet<String>>();

    public Solution() {
    }

    public static int InsertInHashMap(String input, int startindex,
                                      int endindex) {

        String key = input.substring(startindex, endindex);
        String value = input.substring(endindex);
        if (!subStringCollection.containsKey(key)) {
            HashSet<String> list = new HashSet<String>();
            list.add(value);
            subStringCollection.put(key, list);
        } else {
            subStringCollection.get(key).add(value);
        }
        return startindex + 1;
    }

    public static void main(String[] args) {
        try {
            BufferedReader br =
                new BufferedReader(new InputStreamReader(System.in));
            stringCount = br.readLine();
            for (int i = 0; i < new Integer(stringCount); i++) {
                String input = br.readLine();
                int c = 0;
                while (c < input.length()) {
                    c = InsertInHashMap(input, c, c + 1);
                }
            }


            printCount = br.readLine();
            for (int i = 0; i < new Integer(printCount); i++) {
                indList[i] = new Integer(br.readLine());
            }

            br.close();


            for (int i = 0; i < new Integer(printCount); i++) {
                int sum = 0;
                int flag = 0;
                for (String key : subStringCollection.keySet()) {
                    Set<String> l = new TreeSet<String>();
                    for (String s : subStringCollection.get(key)) {
                        for (int k = 0; k <= s.length(); k++) {
                            l.add(key + s.substring(0, k));
                        }
                    }
                    if ((indList[i] - sum) > l.size()) {
                        sum = sum + l.size();
                    } else {
                        String[] temp = new String[2];
                        String[] sortedStringArray = l.toArray(temp);
                        System.out.println(sortedStringArray[indList[i] -sum-1]);
                        flag = 1;
                        break;
                    }
                }               
                if (flag ==0) {
                    System.out.println("INVALID");
                }
                
            }


        } catch (Exception e) {
            System.err.println("Error:" + e.getMessage());
        }
    }

}

