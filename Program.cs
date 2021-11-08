using AirlineCargo.OrderHandler;
using AirlineCargo.Utility;
using Unity;

class Programm
{
    static void Main(string[] args)
    {
        var list = CommonUtility.CreateFilghtInfo();
        CommonUtility.GetCharterInfo(list.OrderBy(s => s.Day).ToList());

        var container = new UnityContainer();
        container.RegisterType<IOrderHandler, OrderHandler>();
        var con=container.Resolve<OrderConcreate>();
        con.InvokeMethod(list);
    }

}
