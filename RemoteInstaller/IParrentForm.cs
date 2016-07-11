using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftManager
{
    /// <summary>
    /// Интерфейс для всех родительских окон используемых в этом приложении
    /// </summary>
    public interface IParrentForm
    {
        void setComputers(string str);
        void cleanData();
        //void setSoftGridView(SoftGridView sv);
    }
}
