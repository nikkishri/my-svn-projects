package com.interviewstreetchallenge.nikhilesh;

import java.io.BufferedReader;
import java.io.InputStreamReader;

import java.math.BigDecimal;

import java.math.BigInteger;

import java.text.DecimalFormat;

public class Solution {

    static String stringCount;

    public Solution() {
    }

    public static void main(String[] args) {
        try {
            BufferedReader br =
                new BufferedReader(new InputStreamReader(System.in));
            stringCount = br.readLine();
            for (int i = 0; i < new Integer(stringCount); i++) {
                String s = br.readLine();
                String[] sarray = s.split(" ");
                Integer totalHeads = new Integer(sarray[0]);
                Integer scoredHeads = new Integer(sarray[1]);

                int remHeads = totalHeads - scoredHeads;

                BigDecimal sum;

                BigInteger totalAttemptsForTotalHeads =
                    BigInteger.valueOf(2).pow(totalHeads +
                                              1).subtract(new BigInteger("2"));

                if (remHeads == 0) {
                    System.out.println("0.00");
                } else if (remHeads == totalHeads) {
                    DecimalFormat dec = new DecimalFormat("#.00");
                    System.out.println(dec.format(totalAttemptsForTotalHeads));
                } else {
                    sum = getTossesRequired(totalHeads, scoredHeads);
                    DecimalFormat dec = new DecimalFormat("#.00");
                    BigDecimal rounded =
                        sum.setScale(2, BigDecimal.ROUND_HALF_UP);
                    System.out.println(dec.format(rounded));
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static BigDecimal getTossesRequired(int totalHeads,
                                               int headScored) {

        if (totalHeads == headScored) {
            return BigDecimal.valueOf(0);
        }

        BigDecimal one = BigDecimal.valueOf(1);
        BigDecimal totalAttempts = BigDecimal.valueOf(2).pow(totalHeads + 1).subtract(new BigDecimal("2")).multiply(new BigDecimal(".5"));
        BigDecimal recursion = getTossesRequired(totalHeads, headScored + 1).multiply(new BigDecimal(".5"));

        return one.add(totalAttempts).add(recursion);
                                       

    }
}
