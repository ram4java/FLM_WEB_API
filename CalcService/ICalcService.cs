using System.ServiceModel;

namespace FLM_WEB_API.CalcService
{
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        int Add(int fno, int sno);
        
        [OperationContract]
        int Subtract(int fno, int sno);

        [OperationContract]
        int Multiply(int fno, int sno);

        [OperationContract]
        int Divide(int fno, int sno);
    }
}
