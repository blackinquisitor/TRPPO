using KFC.Context;

namespace KFC;

public class Helper
{
    private static MyDbContext _satellitecontext;
    public static MyDbContext GetContext()
    {
        return _satellitecontext ??= new MyDbContext();
    }
}