using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms_Unit
{
    [TestClass]
    public class BinarySearchTests
    {
        #region name tests

        [TestMethod]
        public void BinarySearchTest()
        {
            var cheatSheet = new Algorithms.Algorithms.AlgorithmCheatSheet(true);
            cheatSheet.RunBinarySearchSentencesSingleSearchTermPrototype();
        }

        #endregion
    }
}
