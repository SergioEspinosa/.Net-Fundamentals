using System.Collections.Generic;

namespace SOLID._4._Interface_segregation.After
{
    public interface IRepositoryNewDataBase
    {
        List<string> GetJurisdictions();
        List<string> GetIndustries();
        object GetProjectInformation(int projectId);
        string GetDisclaimer(int projectId, string type);
    }

    class NewDataBaseRepository : IRepositoryNewDataBase
    {
        dynamic dbContext;
        
        public string GetDisclaimer(int projectId, string type)
            => dbContext.Case.GetDisclaimers(projectId, type);
        
        public List<string> GetIndustries()
            => dbContext.Industry.GetAll();

        public List<string> GetJurisdictions()
            => dbContext.Juridistion.GetAll();
        
        public object GetProjectInformation(int projectId)
            => dbContext.Case.GetProjectInformation(projectId);        
    }

    public interface IRepositoryOldDataBase
    {
        List<string> GetJudges();
        List<string> GetTopCases();
        List<string> GetDebtors(int projectId);
        int GetProjectIdByCode(string projectCode);
        object GetHomePageHtml(int projectId);
    }

    class OldDataBaseRepository : IRepositoryOldDataBase
    {
        dynamic dbContext;

        public List<string> GetDebtors(int projectId)
            => dbContext.Debtor.ById(projectId);
        
        public object GetHomePageHtml(int projectId)
            => dbContext.Case.GetHomePage(projectId);
        
        public List<string> GetJudges()
            => dbContext.Judges.GetAll();

        public int GetProjectIdByCode(string projectCode)
            => dbContext.Case.GetByCode(projectCode);
        
        public List<string> GetTopCases()
            => dbContext.Case.GetTopCases();
    }
}
