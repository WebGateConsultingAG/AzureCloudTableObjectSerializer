using System;
namespace CloudTableObjectSerializerTest {

    public class SimplePoco {
        public string Id {set;get;}
        public int IntValue {set;get;}

        public long LongValue {set;get;}

        public double DoubleValue {set;get;}

        public Guid GuidValue {set;get;}

        public DateTime DTValue {set;get;}

        public DateTimeOffset DTOValue {set;get;}

    }
}