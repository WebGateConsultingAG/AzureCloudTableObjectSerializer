using System;

namespace WebGate.Azure.CloudTableUtilsTest {

    public class SimplePocoWithArray {
        public string Id {set;get;}
        public int[] IntArray {set;get;}

        public string[] StringArray {set;get;}

        public DateTime[] DateTimeArray {set;get;}


        public static SimplePocoWithArray CreateEmptySimplePocoWithArray() {
            SimplePocoWithArray spwa = new SimplePocoWithArray();
            return spwa;
        }
        public static SimplePocoWithArray CreateFilledSimplePocoWithArray() {
            SimplePocoWithArray spwa = new SimplePocoWithArray();
            int[] intArray = {0, 2, 19, 3, 1};
            spwa.IntArray = intArray;
            string[] stringArray = {"David", "Simon", "Sara", "Christian"};
            spwa.StringArray = stringArray;
            DateTime[] dtArray = {new DateTime(), new DateTime()};
            spwa.DateTimeArray = dtArray;
            return spwa;
        }
    }
}