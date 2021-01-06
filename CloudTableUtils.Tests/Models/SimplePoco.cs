using System;
namespace WebGate.Azure.CloudTableUtilsTest {

    public enum SP {
        VALID,
        INVALID
    }
    public class SimplePoco {
        public string Id {set;get;}
        public int IntValue {set;get;}

        public long LongValue {set;get;}

        public double DoubleValue {set;get;}

        public Guid GuidValue {set;get;}

        public DateTime DTValue {set;get;}

        public DateTimeOffset DTOValue {set;get;}

        public uint UIntValue {set;get;}

        public ulong ULongValue {set;get;}

        public TimeSpan TimeSpanValue {set;get;}

        public SP EnumValue {set;get;}

        public static SimplePoco CreateInitializedPoco() {
            SimplePoco simplePoco = new SimplePoco();
            simplePoco.Id = "02381012";
            simplePoco.DoubleValue = 2018101.00812;
            simplePoco.IntValue=9789677;
            simplePoco.DTOValue = DateTimeOffset.Now;
            simplePoco.LongValue = 100008937819;
            simplePoco.GuidValue = Guid.NewGuid();
            simplePoco.DTValue = DateTime.UtcNow;
            simplePoco.UIntValue = 392;
            simplePoco.ULongValue = 1999189917819917881;
            simplePoco.TimeSpanValue = new TimeSpan(5,3,12);
            simplePoco.EnumValue = SP.INVALID;
            return simplePoco;
        }

        public static SimplePoco CreatePocoWithoutID() {
            SimplePoco sp = CreateInitializedPoco();
            sp.Id = null;
            return sp;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else {
                SimplePoco spo = (SimplePoco) obj;
            return (Id == spo.Id) && (EnumValue == spo.EnumValue) && (spo.DoubleValue == DoubleValue) && (spo.DTOValue == DTOValue) && (spo.DTValue == DTValue) && (spo.GuidValue == GuidValue);
            }
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode():0) + EnumValue.GetHashCode();
        }

      

    }
}