package com.interviewstreet.nikhilesh;


import com.sun.xml.internal.ws.util.StringUtils;

import java.io.BufferedReader;
import java.io.InputStreamReader;

import java.util.*;

public class Solution {

    static String stringCount;
    static Set<Order> dealSet = new HashSet<Order>();
    static Set<Long> fraudIdSet = new HashSet<Long>();

    public Solution() {
    }

    public static void main(String[] args) throws Exception {
        BufferedReader br =
            new BufferedReader(new InputStreamReader(System.in));
        stringCount = br.readLine();
        for (int i = 0; i < new Integer(stringCount); i++) {
            String s = br.readLine();
            String[] sarray = s.split(",");
            Solution.Order o =
                new Solution.Order(sarray[0], sarray[1], sarray[2], sarray[3],
                                   sarray[4], sarray[5], sarray[6], sarray[7]);
            if (!(dealSet.add(o))) {
                fraudIdSet.add(o.fraudOrderId);
                fraudIdSet.add(o.orderId);
            }

        }
        Set<Long> sortedSet = new TreeSet<Long>(fraudIdSet);
        Iterator itr = sortedSet.iterator();
        while (itr.hasNext()) {
            System.out.print(itr.next());
            if (itr.hasNext()) {
                System.out.print(",");
            }
        }

    }

    static private class Order {

        long orderId;
        int dealId;
        String emailAddress;
        String streetaddress;
        String City;
        String State;
        String zipCode;
        String creditCard;
        long fraudOrderId;


        char[] ignoreCharacters = ".".toCharArray();


        public Order(String orderId, String dealId, String emailAddress,
                     String streetaddress, String City, String State,
                     String zipCode, String creditCard) {

            this.orderId = new Long(orderId);
            this.dealId = new Integer(dealId);
            this.emailAddress = sanitizeEmailAddress(emailAddress);
            this.streetaddress = sanitizeStreetAddress(streetaddress);
            this.City = sanitizeCity(City);
            this.State = sanitizeState(State);
            this.zipCode = removeAllSpacesAndTrim(zipCode);
            this.creditCard = removeAllSpacesAndTrim(creditCard);

        }
        
        public String removeAllSpacesAndTrim(String input) {
                          return input.replaceAll("\\s+", "").trim();
                      }
        
        public String sanitizeCity(String city) {
            city = removeAllSpacesAndTrim(city);

            if (city.equalsIgnoreCase("NY")) {
                return "newyork";
            }
            return city.toLowerCase();
        }

        public String sanitizeEmailAddress(String emailAddress) {

            emailAddress = removeAllSpacesAndTrim(emailAddress);
            String output = emailAddress.toLowerCase();
            String[] splitoutput = output.split("@");
            String username = splitoutput[0];

            for (char c : ignoreCharacters) {
                username = username.replace("" + c, "");
            }


            int indexOfPlus = username.indexOf("+");
            if (indexOfPlus == -1) {
                return username + "@" + splitoutput[1];
            } else {
                return username.substring(0, indexOfPlus) + "@" +
                    splitoutput[1];
            }


        }

        public String sanitizeStreetAddress(String streetaddress) {


            if (streetaddress.toLowerCase().endsWith("st.")) {
                streetaddress =
                        streetaddress.substring(0, streetaddress.toLowerCase().lastIndexOf("st.")) +
                        "street";
            }
            if (streetaddress.toLowerCase().endsWith("rd.")) {
                streetaddress =
                        streetaddress.substring(0, streetaddress.toLowerCase().lastIndexOf("rd.")) +
                        "road";
            }
            return removeAllSpacesAndTrim(streetaddress).toLowerCase();
            
        }

        public String sanitizeState(String state) {

            state = removeAllSpacesAndTrim(state);

            if (state.equalsIgnoreCase("IL")) {
                return "illinois";
            }
            if (state.equalsIgnoreCase("CA")) {
                return "california";
            }
            if (state.equalsIgnoreCase("NY")) {
                return "newyork";
            }
            return state.toLowerCase();
        }

        public boolean equals(Object o) {
            Order input = (Order)o;

            if (input.emailAddress.equalsIgnoreCase(this.emailAddress) &&
                !(input.creditCard.equalsIgnoreCase(this.creditCard))) {
                this.fraudOrderId = input.orderId;
                return true;
            }

            if (input.zipCode.equalsIgnoreCase(this.zipCode) &&
                input.streetaddress.equalsIgnoreCase(this.streetaddress) &&
                input.City.equalsIgnoreCase(this.City) &&
                input.State.equalsIgnoreCase(this.State) &&
                !(input.creditCard.equalsIgnoreCase(this.creditCard))) {
                this.fraudOrderId = input.orderId;
                return true;
            }


            return false;

        }

        public int hashCode() {

            return dealId;
        }
    }
}
