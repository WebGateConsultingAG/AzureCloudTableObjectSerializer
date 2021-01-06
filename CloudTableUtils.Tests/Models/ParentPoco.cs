using System;
namespace WebGate.Azure.CloudTableUtilsTest {
    public class ParentPoco {
        public string Id {get;set;}
        public SimplePoco Child {set;get;}

        public static ParentPoco CreateParentWithChild() {
            ParentPoco pp = new ParentPoco();
            pp.Child = SimplePoco.CreateInitializedPoco();
            pp.Id = "02830128101";
            return pp;
        }
    }
}