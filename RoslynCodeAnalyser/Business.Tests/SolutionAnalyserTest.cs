using Business.DiRegistry;
using Business.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Business.Tests
{
    [TestClass]
    public class SolutionAnalyserTest
    {
        [TestMethod]
        public void SolutionAnalyser_WhenAllInputsAreCorrect_ReturnSolutionStructure()
        {
            var container = new Container();
            container.Configure(p => { p.AddRegistry<BusinessRegistry>();});

            var solutionAnalyser = container.GetInstance<ISolutionAnalyser>();
            var result = solutionAnalyser.Analyse(@"D:\Rohit\PRoject\RoslynSimplifiedforCodeAnalysis\RoslynSimplifiedforCodeAnalysis\HelperTestSubject\HelperTestSubject.sln");
            
            Assert.IsTrue(result != null);    
        }
    }
}
