package com.interviewstreet.nikhilesh;

import java.io.BufferedReader;
import java.io.InputStreamReader;

import java.util.*;

public class Solution {

    static String stringCount;

    public Solution() {
    }

    public static void main(String[] args) throws Exception {
        BufferedReader br =
            new BufferedReader(new InputStreamReader(System.in));
        stringCount = br.readLine();
        for (int i = 0; i < new Integer(stringCount); i++) {
            HashMap<Integer, List<Integer>> hm =
                new HashMap<Integer, List<Integer>>();
            Integer noOfCities = new Integer(br.readLine());
            String distance = br.readLine();
            String population = br.readLine();
            String[] distArray = distance.split(" ");
            String[] populationArray = population.split(" ");
            for (int j = 0; j < noOfCities; j++) {

                Integer intgr = new Integer(populationArray[j]);
                if (hm.containsKey(intgr)) {
                    List l = hm.get(intgr);
                    l.add(new Integer(distArray[j]));
                } else {
                    List<Integer> l = new ArrayList<Integer>();
                    l.add(new Integer(distArray[j]));
                    hm.put(intgr, l);
                }

            }

            TreeMap<Integer, List<Integer>> tm =
                new TreeMap<Integer, List<Integer>>(hm);
            hm = null;
            int k = 0;
            long[] prevDistance = new long[200000];
            long totalDistance = 0;
            for (int val : tm.keySet()) {
                for (int dist : tm.get(val)) {
                    if (k == 0) {
                        prevDistance[k] = dist;
                        k++;
                    } else {
                        // totalDistance =
                        //  totalDistance + (Math.abs(dist * k - prevDistance) *
                        // val);
                        for (int ind = 0; ind < k; ind++) {
                            totalDistance =
                                    totalDistance + Math.abs(dist - prevDistance[ind]) *
                                    val;
                        }
                        prevDistance[k] = dist;
                        k++;
                        

                    }


                }
            }
            System.out.println(totalDistance % 1000000007);
        }
    }
}
