using Core.Entity.Concrete;

namespace Business.Utilities.Abstract
{
    public interface IParser
    {
        User ParseJwtToUser(string token);
    }
}
