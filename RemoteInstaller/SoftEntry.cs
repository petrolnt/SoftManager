using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftManager
{
    /// <summary>
    /// класс описывающий сущность программы удаление или установка которой выполняется, поля сущности успользуются для отображения текущего состояния
    /// в таблице прогресса в форме ProgressTable
    /// </summary>
    class SoftEntry
    {

        public SoftEntry()
        {


        }

        public SoftEntry(string name, string version, string installDate)
        {
            this.name = name;
            this.version = version;
            this.installDate = installDate;
        }

        string identifyingNumber;

        public string IdentifyingNumber
        {
            get { return identifyingNumber; }
            set { identifyingNumber = value; }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string version;
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        string installDate;
        public string InstallDate
        {
            get { return installDate; }
            set { installDate = value; }
        }

        

    }
}
