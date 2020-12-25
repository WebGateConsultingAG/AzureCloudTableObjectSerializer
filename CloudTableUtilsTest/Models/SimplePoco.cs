using System;
namespace WebGate.Azure.CloudTableUtilsTest {

    public class SimplePoco {
        public string Id {set;get;}
        public int IntValue {set;get;}

        public long LongValue {set;get;}

        public double DoubleValue {set;get;}

        public Guid GuidValue {set;get;}

        public DateTime DTValue {set;get;}

        public DateTimeOffset DTOValue {set;get;}


        public static SimplePoco CreateInitializedPoco() {
            SimplePoco simplePoco = new SimplePoco();
            simplePoco.Id = "02381012";
            simplePoco.DoubleValue = 2018101.00812;
            simplePoco.IntValue=9789677;
            simplePoco.DTOValue = new DateTimeOffset();
            simplePoco.LongValue = 100008937819;
            simplePoco.GuidValue = new Guid();
            simplePoco.DTValue = new DateTime();
            return simplePoco;
        }

        public static SimplePoco CreatePocoWithoutID() {
            SimplePoco sp = CreateInitializedPoco();
            sp.Id = null;
            return sp;
        }

    }
}