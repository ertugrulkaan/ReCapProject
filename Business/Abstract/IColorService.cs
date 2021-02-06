using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Entities.Concrete.Color> GetAll();
        void Add(Entities.Concrete.Color color);
        void Update(Entities.Concrete.Color color);
        void Delete(Entities.Concrete.Color color);
        Entities.Concrete.Color GetById(int colorId);
        Entities.Concrete.Color GetByName(string colorName);
    }
}
