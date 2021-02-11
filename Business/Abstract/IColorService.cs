using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Entities.Concrete.Color>> GetAll();
        IResult Add(Entities.Concrete.Color color);
        IResult Update(Entities.Concrete.Color color);
        IResult Delete(Entities.Concrete.Color color);
        IDataResult<Entities.Concrete.Color> GetById(int colorId);
        IDataResult<Entities.Concrete.Color> GetByName(string colorName);
    }
}
