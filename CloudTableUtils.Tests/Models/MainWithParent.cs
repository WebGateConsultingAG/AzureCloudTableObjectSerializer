using System;
namespace WebGate.Azure.CloudTableUtilsTest {
    public class MainWithParent {
        public string Id {set;get;}
        public ParentPoco Parent { set;get;}

        public SimplePoco Child  {set;get;}

        public static MainWithParent CreateMainWithParent() {
            MainWithParent mwp = new MainWithParent();
            mwp.Child = SimplePoco.CreateInitializedPoco();
            mwp.Parent = ParentPoco.CreateParentWithChild();
            mwp.Id = "01820281";
            return mwp;
        }
    }
}