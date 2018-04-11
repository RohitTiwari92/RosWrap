using System.Linq;
using Business.Interfaces;
using Core.Models;

namespace Business
{
    public class SolutionAnalyser : ISolutionAnalyser
    {
        private readonly IProjectAnalyser _projectAnalyser;
        private readonly ISolutionAstGenerator _solutionAstGenerator;

        public SolutionAnalyser(IProjectAnalyser projectAnalyser, 
            ISolutionAstGenerator solutionAstGenerator)
        {
            _projectAnalyser = projectAnalyser;
            _solutionAstGenerator = solutionAstGenerator;
        }

        public SolutionAnalysisData Analyse(string solutionFilePath)
        {
            var solutionAst = _solutionAstGenerator.GenerateAst(solutionFilePath);
            var projects = _projectAnalyser.Analyse(solutionAst);

            return new SolutionAnalysisData() {Projects = projects.ToList(), SolutionAst = solutionAst};
        }
    }
}
