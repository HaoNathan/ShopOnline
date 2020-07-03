using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class ColorService:BaseService<Color>,IColorService
    {
        public ColorService() : base(new CSContext())
        {

        }
    }
}