namespace FLM_WEB_API.CalcService
{
    public class CalcServiceImpl : ICalcService
    {
        public int Add(int fno, int sno)
        {
            return fno + sno;
        }

        public int Divide(int fno, int sno)
        {
            if (sno == 0)
                return 0;

            return fno / sno;
        }

        public int Multiply(int fno, int sno)
        {
            return fno * sno;
        }

        public int Subtract(int fno, int sno)
        {
            return fno - sno;
        }
    }
}
