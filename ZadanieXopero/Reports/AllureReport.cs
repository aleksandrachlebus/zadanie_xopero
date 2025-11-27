using Allure.NUnit.Attributes;

namespace ZadanieXopero.Reports
{
    public class AllureReport
    {
        [AllureStep("{0}")]
        public void LogStep(string message)
        { 
        }
    }
}
