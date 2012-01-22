package com.interviewstreet.nikhilesh;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.*;


public class SolutionOld {


    static String[] strList = new String[50];
    static String stringCount;
    static String printCount;
    static int[] indList = new int[500];
    static HashMap<String,Object> subStringCollection = new HashMap<String,Object>();

    public SolutionOld() {
    }

    public static void main(String[] args) {
        try {
            BufferedReader br =
                new BufferedReader(new InputStreamReader(System.in));
            stringCount = br.readLine();
            for (int i = 0; i < new Integer(stringCount); i++) {
                strList[i] = br.readLine();               
                for( int c = 0 ; c < strList[i].length() ; c++ )
                     {
                        for( int j = 1 ; j <= strList[i].length() - c ; j++ )
                        {
                            if ( !subStringCollection.containsKey(strList[i].substring(c, c+j)))
                                   {
                           subStringCollection.put(strList[i].substring(c, c+j),null);
                                   }
                        }
                     }
            }
            printCount = br.readLine();
            for (int i = 0; i < new Integer(printCount); i++) {
                indList[i] = new Integer(br.readLine());
            }
            
            String [] temp = new  String [2];
        //    String [] sortedStringArray = subStringCollection.toArray(temp);
            
             List<String> list = new ArrayList<String>(subStringCollection.keySet());
              Collections.sort(list);

          String [] sortedStringArray =    list.toArray(temp);
            
            for (int i = 0; i < new Integer(printCount); i++) {
                
                if(indList[i] > sortedStringArray.length) {
                    System.out.println("INVALID");
                }
                else
                {
                System.out.println(sortedStringArray[indList[i]-1]);
                }
            }
   


        } catch (Exception e) {
            System.err.println("Error:" + e.getMessage());
        }
    }
}
